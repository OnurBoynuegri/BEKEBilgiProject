using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BekEkProject
{
	public class Work
	{
		public Work(string name, int difficulty)
		{
			Name = name;
			Difficulty = difficulty;
		}

		public string Name { get; set; }
        public int Difficulty { get; set; }


		public override string ToString()
		{
			return $"{Name} (Difficulty: {Difficulty})";
		}

	}
}
