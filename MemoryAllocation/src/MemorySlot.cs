using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryAllocation
{
  class MemorySlot
  {
    public int start{ get; set; }
    public int size { get; set; }

    public MemorySlot(int start, int size)
    {
      this.start = start;
      this.size = size;
    }

    public override String ToString()
    {
      return String.Format("{0} : {1}", start, start+size);
    }
  }
}
