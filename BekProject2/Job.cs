using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BekProject2
{
	public class Job
	{
		public int JobId { get; set; }
		public string JobName { get; set; }
		public int Difficulty { get; set; }

		public virtual ICollection<EmployeeJob> EmployeeJobs { get; set; }
	}
}
