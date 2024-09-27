using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BekProject2
{
	public class Employee
	{
		public int EmployeeId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }

		public virtual ICollection<EmployeeJob> EmployeeJobs { get; set; }
	}
}
