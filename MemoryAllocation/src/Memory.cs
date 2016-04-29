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
    private SortedList<int, MemorySlot> allocatedSlots;
    private SortedList<int, MemorySlot> freeSlots;

    public Memory(int algorithm, int memorySize)
    {
      reset(algorithm, memorySize);
    }

    public void reset(int algorithm, int memorySize)
    {
      this.processes = new BindingList<Process>();
      this.allocatedSlots = new SortedList<int, MemorySlot>();
      this.freeSlots = new SortedList<int, MemorySlot>();
      this.algorithm = algorithm;
      this.memorySize = memorySize;

      addFreeSlot(new MemorySlot(0, memorySize));
    }

    public bool allocate(String name, int size)
    {
      MemorySlot freeSlot = findSlot(size);
      if (freeSlot != null)
      {
        int allocationStart = freeSlot.start;
        int remainingSize = freeSlot.size - size;
        int remainingStart = freeSlot.start + size;

        removeFreeSlot(freeSlot);
        if (remainingSize > 0)
          addFreeSlot(new MemorySlot(remainingStart, remainingSize));

        Process process = new Process(name, size);
        addAllocatedSlot(new MemorySlot(allocationStart, size, process));
        processes.Add(process);

        return true;
      }
      return false;
    }

    public void deallocate(int index)
    {
      Process process = processes[index];
      MemorySlot allocatedSlot = null;
      foreach (MemorySlot slot in allocatedSlots.Values.ToList())
      {
        if (slot.process == process)
        {
          allocatedSlot = slot;
          break;
        }
      }

      removeAllocatedSlot(allocatedSlot);

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
      return freeSlots.Values.ToList();
    }

    public int getMemorySize()
    {
      return memorySize;
    }

    public List<MemorySlot> getAllocatedSlots()
    {
      return allocatedSlots.Values.ToList();
    }

    private MemorySlot findSlot(int size)
    {
      MemorySlot slot = null;
      foreach (MemorySlot s in freeSlots.Values.ToList())
        if (s.size >= size)
        {
          slot = s;
          break;
        }

      return slot;
    }

    private void addAllocatedSlot(MemorySlot slot)
    {
      if (algorithm == FIRST_FIT)
        allocatedSlots.Add(slot.start, slot);
      else if (algorithm == BEST_FIT)
        allocatedSlots.Add(slot.size, slot);
      else if (algorithm == WORST_FIT)
        allocatedSlots.Add(memorySize - slot.start, slot);
    }

    private void removeAllocatedSlot(MemorySlot slot)
    {

    }

    private void removeFreeSlot(MemorySlot slot)
    {
      foreach (int k in freeSlots.Keys.ToList())
      {
        
      }
    }

    private void addFreeSlot(MemorySlot slot)
    {
      MemorySlot previousSlot = null;
      MemorySlot nextSlot = null;

      foreach (MemorySlot s in freeSlots.Values.ToList())
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
        //freeSlots.Remove(previousSlot);
      }
      if (nextSlot != null)
      {
        slot.size += nextSlot.size;
        //freeSlots.Remove(nextSlot);
      }

      if (algorithm == FIRST_FIT)
        freeSlots.Add(slot.start, slot);
      else if (algorithm == BEST_FIT)
        freeSlots.Add(slot.size, slot);
      else if (algorithm == WORST_FIT)
        freeSlots.Add(memorySize - slot.start, slot);

    }
  }
}
