using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BekProject2
{
	public class EmployeeJob
	{
		public int EmployeeJobId { get; set; }
		public int EmployeeId { get; set; }
		public int JobId { get; set; }
		public DateTime AssignedDate { get; set; }

		public virtual Employee Employee { get; set; }
		public virtual Job Job { get; set; }
	}
}
