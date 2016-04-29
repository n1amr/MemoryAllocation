using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryAllocation.src
{
  class Process
  {
    public String name { get; set; }
    public int PID { get; set; }
    public int size { get; set; }

    public Process(String name, int pid, int size)
    {
      this.name = name;
      this.PID = pid;
      this.size = size;
    }

    public Process(int size)
      : this(null, -1, size)
    {
    }

    public override String ToString()
    {
      return String.Format("Process\tname: {0}\tPID: {1}\tsize: {2}", name, PID, size);
    }
  }
}
