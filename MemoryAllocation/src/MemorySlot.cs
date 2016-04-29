using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryAllocation
{
  public class MemorySlot : IComparable<MemorySlot>
  {
    public int start { get; set; }
    public int size { get; set; }
    public Process process { get; set; }

    public MemorySlot(int start, int size, Process process)
    {
      this.start = start;
      this.size = size;
      this.process = process;
    }

    public MemorySlot(int start, int size)
      : this(start, size, null)
    {
    }

    public override String ToString()
    {
      return String.Format("{0} : {1} ({2})", start, start + size, process != null ? process.name : "Empty");
    }

    int IComparable<MemorySlot>.CompareTo(MemorySlot slot)
    {
      return this.start - slot.start;
    }
  }
}
