using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace MemoryAllocation.src
{
  class Controller
  {
    private BindingList<Process> processes;

    public Controller()
    {
      this.processes = new BindingList<Process>();
    }

    public void allocate(String name, int size)
    {
      processes.Add(new Process(name, size));
    }

    public void deallocate(int index)
    {
      processes.RemoveAt(index);
    }

    public BindingList<Process> getProcesses()
    {
      return processes;
    }
  }
}
