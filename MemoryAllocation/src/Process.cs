using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryAllocation
{
	public class Process
	{
		public String name { get; set; }
		public int size { get; set; }

		public Process(String name, int size)
		{
			this.name = name;
			this.size = size;
		}

		public Process(int size)
			: this("Process", size)
		{
		}

		public override String ToString()
		{
			return String.Format("{0} ({1} B)", name, size);
		}
	}
}
