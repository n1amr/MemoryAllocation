using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace MemoryAllocation
{
  class Controller
  {
    public static readonly int FIRST_FIT = 0;
    public static readonly int BEST_FIT = 1;

    public int algorithm { get; set; }
    private int memorySize;

    private BindingList<Process> processes;
    private List<MemorySlot> allocatedSlots;
    private List<MemorySlot> freeSlots;

    public Controller(int algorithm, int memorySize)
    {
      reset(algorithm, memorySize);
    }

    public void reset(int algorithm, int memorySize)
    {
      this.processes = new BindingList<Process>();
      this.allocatedSlots = new List<MemorySlot>();
      this.freeSlots = new List<MemorySlot>();
      this.algorithm = algorithm;
      this.memorySize = memorySize;

      freeSlots.Add(new MemorySlot(0, memorySize));
    }

    public bool allocate(String name, int size)
    {
      MemorySlot freeSlot = findSlot(size);
      if (freeSlot != null)
      {
        int allocationStart = freeSlot.start;
        int remainingSize = freeSlot.size - size;
        int remainingStart = freeSlot.start + size;

        freeSlots.Remove(freeSlot);
        addFreeSlot(new MemorySlot(remainingStart, remainingSize));

        allocatedSlots.Add(new MemorySlot(allocationStart, size));

        processes.Add(new Process(name, size));
        return true;
      }
      return false;
    }

    public void deallocate(int index)
    {
      processes.RemoveAt(index);
    }

    public BindingList<Process> getProcesses()
    {
      return processes;
    }

    private MemorySlot findSlot(int size)
    {
      MemorySlot slot = null;
      for (int i = 0; i < freeSlots.Count; i++)
        if (freeSlots[i].size >= size)
        {
          slot = freeSlots[i];
          break;
        }

      return slot;
    }

    private void addFreeSlot(MemorySlot slot)
    {
      freeSlots.Add(slot);
    }

  }
}
