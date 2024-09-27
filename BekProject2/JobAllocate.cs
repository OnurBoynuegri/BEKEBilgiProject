using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BekProject2
{
	public class JobAllocate
	{
		private List<Job> jobs;
		private List<Employee> employees;
		private Random random;
		private Dictionary<Employee, List<int>> employeeCompletedJobs;
		private List<int> jobDifficulties = new List<int> { 1, 2, 3, 4, 5, 6 };
		private BekEbilgiDbContext _context;
		public JobAllocate(List<Employee> employees, List<Job> jobs,BekEbilgiDbContext context)
        {
			this.employees = employees;
			this.jobs = jobs;
			random = new Random();
			employeeCompletedJobs = new Dictionary<Employee, List<int>>();
			_context = context;
			
			foreach (var employee in employees)
			{
				employeeCompletedJobs[employee] = new List<int>();
			}

		}

        public Dictionary<Employee, Job> AllocateDailyJobs()
        {
			var allocation = new Dictionary<Employee, Job>();

			// Geçici iş listesi
			var availableJobs = new List<Job>(jobs);

			foreach (var employee in employees)
			{
				List<int> previousDifficulties = GetEmployeeJobDifficulteis(employee.EmployeeId);				
				int jobDifficulty = selectDifficulty(previousDifficulties);
				var jobToAssign = jobs.First(j => j.Difficulty == jobDifficulty);

				allocation.Add(employee, jobToAssign);

				if (previousDifficulties.Count % 6 == 0)
				{
					var allEmployeeJobs = _context.EmployeeJobs.ToList();
					_context.EmployeeJobs.RemoveRange(allEmployeeJobs);

					// Değişiklikleri kaydet
					_context.SaveChanges();
				}
			}


			return allocation;
		}
		public List<EmployeeJob> GetEmployeeJobs(int employeeId)
		{
			using (var context = new BekEbilgiDbContext())
			{
				// Çalışanın yaptığı işleri çek
				var employeeJobs = context.EmployeeJobs
										  .Where(ej => ej.EmployeeId == employeeId)
										  .Include(ej => ej.Job)
										  .ToList();

				return employeeJobs;
			}
		}



		public List<int> GetEmployeeJobDifficulteis(int employeeId)
		{
			using (var context = new BekEbilgiDbContext())
			{
				var employeeJobDifficulteis = context.EmployeeJobs
										  .Where(ej => ej.EmployeeId == employeeId)
										  .Include(ej => ej.Job).Select(a => a.Job.Difficulty)
										  .ToList();

				return employeeJobDifficulteis;
			}
		}

		private int selectDifficulty(List<int> employeeJobDifficulteis)
		{
			var selectedvalue = 0;
			var newListDifficulties = jobDifficulties.Except(employeeJobDifficulteis).ToList();
			if (newListDifficulties.Count < 1)
			{
				selectedvalue = jobDifficulties[0];
			}
			else
			{
				selectedvalue = newListDifficulties[random.Next(newListDifficulties.Count)];
			}
			
			jobDifficulties.Remove(selectedvalue);

			return selectedvalue;


		}
		public void SaveAllocationsToDatabase(Dictionary<Employee, Job> dailyAllocations)
		{
			using (var context = new BekEbilgiDbContext())
			{
				foreach (var allocation in dailyAllocations)
				{
					context.EmployeeJobs.Add(new EmployeeJob
					{
						EmployeeId = allocation.Key.EmployeeId,
						JobId = allocation.Value.JobId,
						AssignedDate = DateTime.Now
					});
				}
				context.SaveChanges();
			}
		}

	}
}
