using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BekEkProject
{
	public class WorkAllocate
	{
		private List<Work> works;
		private List<Employee> employees;
		private Random random;

        public WorkAllocate(List<Employee> employees, List<Work> works)
        {
            this.employees = employees;
			this.works = works;
			random = new Random();
        }

		public Dictionary<Employee, Work> AllocateDilyWorks()
		{
			var allocation = new Dictionary<Employee, Work>();
			var jobs= new List<Work>(works);

			foreach(var employee in employees)
			{
				Work selectedJob = jobs[random.Next(jobs.Count)];
				while (allocation.Values.Any(j => j.Difficulty == selectedJob.Difficulty))
				{
					selectedJob = jobs[random.Next(jobs.Count)];
				}
				allocation.Add(employee, selectedJob);
				jobs.Remove(selectedJob);
			}

			return allocation;
		}

    }
}
