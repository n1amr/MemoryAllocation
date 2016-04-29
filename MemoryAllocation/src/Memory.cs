using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace MemoryAllocation
{
  class Memory
  {
    public static readonly int FIRST_FIT = 0;
    public static readonly int BEST_FIT = 1;
    public static readonly int WORST_FIT = 2;

    public int algorithm { get; set; }
    private int memorySize;

    private BindingList<Process> processes;
    private List<MemorySlot> allocatedSlots;
    private List<MemorySlot> freeSlots;

    public Memory(int algorithm, int memorySize)
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
        if (remainingSize > 0)
          addFreeSlot(new MemorySlot(remainingStart, remainingSize));

        Process process = new Process(name, size);
        allocatedSlots.Add(new MemorySlot(allocationStart, size, process));
        processes.Add(process);

        return true;
      }
      return false;
    }

    public void deallocate(int index)
    {
      Process process = processes[index];
      MemorySlot allocatedSlot = null;
      foreach (MemorySlot slot in allocatedSlots)
      {
        if (slot.process == process)
        {
          allocatedSlot = slot;
          break;
        }
      }

      allocatedSlots.Remove(allocatedSlot);

      MemorySlot freeSlot = new MemorySlot(allocatedSlot.start, allocatedSlot.size);
      addFreeSlot(freeSlot);

      processes.RemoveAt(index);
    }

    public BindingList<Process> getProcesses()
    {
      return processes;
    }

    public List<MemorySlot> getFreeSlots()
    {
      return freeSlots;
    }

    public int getMemorySize()
    {
      return memorySize;
    }

    public List<MemorySlot> getAllocatedSlots()
    {
      return allocatedSlots;
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
      MemorySlot previousSlot = null;
      MemorySlot nextSlot = null;

      foreach (MemorySlot s in freeSlots)
      {
        if (s.start + s.size == slot.start)
          previousSlot = s;
        else if (slot.start + slot.size == s.start)
          nextSlot = s;
      }

      if (previousSlot != null)
      {
        slot.start = previousSlot.start;
        slot.size += previousSlot.size;
        freeSlots.Remove(previousSlot);
      }
      if (nextSlot != null)
      {
        slot.size += nextSlot.size;
        freeSlots.Remove(nextSlot);
      }
      freeSlots.Add(slot);
    }
  }
}
