using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace MemoryAllocation
{
  public class Memory
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
      List<MemorySlot> free_slots = new List<MemorySlot>();
      free_slots.Add(new MemorySlot(0, memorySize));

      reset(algorithm, memorySize);
    }

    public void reset(int algorithm, int memorySize)
    {
      this.processes = new BindingList<Process>();
      this.allocatedSlots = new List<MemorySlot>();
      this.freeSlots = new List<MemorySlot>();
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

        removeSlot(freeSlot, freeSlots);

        if (remainingSize > 0)
          addFreeSlot(new MemorySlot(remainingStart, remainingSize));

        Process process = new Process(name, size);
        addSlot(new MemorySlot(allocationStart, size, process), allocatedSlots);
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

      removeSlot(allocatedSlot, allocatedSlots);

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
        removeSlot(previousSlot, freeSlots);
      }
      if (nextSlot != null)
      {
        slot.size += nextSlot.size;
        removeSlot(nextSlot, freeSlots);
      }

      addSlot(slot, freeSlots);
    }

    public void addSlot(MemorySlot slot, List<MemorySlot> slots)
    {
      if (slots.Count == 0)
        slots.Add(slot);
      else
      {
        for (int i = 0; i < slots.Count; i++)
        {
          if (algorithm == FIRST_FIT)
          {
            if (slot.start < slots[i].start)
            {
              slots.Insert(i, slot);
              return;
            }
          }
          else if (algorithm == BEST_FIT)
          {
            if (slot.size < slots[i].size)
            {
              slots.Insert(i, slot);
              return;
            }
          }
          else if (algorithm == WORST_FIT)
          {
            if (slot.start > slots[i].start)
            {
              slots.Insert(i, slot);
              return;
            }
          }

        }
        slots.Add(slot);
      }
    }

    public void removeSlot(MemorySlot slot, List<MemorySlot> slots)
    {
      slots.Remove(slot);
    }

    public void initialize(List<MemorySlot> free_slots)
    {
      processes = new BindingList<Process>();
      freeSlots = new List<MemorySlot>();
      allocatedSlots = new List<MemorySlot>();

      free_slots.Sort();
      int lastAddress = 0;
      foreach (MemorySlot slot in free_slots)
      {
        if (slot.start > lastAddress)
        {
          Process process = new Process("Allocated", slot.start - lastAddress);
          MemorySlot newSlot = new MemorySlot(lastAddress, slot.start - lastAddress, process);
          addSlot(newSlot, allocatedSlots);
          processes.Add(process);
        }
        addSlot(slot, freeSlots);
        lastAddress = slot.start + slot.size;
      }

      if (memorySize - lastAddress > 0)
      {
        Process process = new Process("Allocated", memorySize - lastAddress);
        MemorySlot newSlot = new MemorySlot(lastAddress, memorySize - lastAddress, process);
        addSlot(newSlot, allocatedSlots);
        processes.Add(process);
      }
    }
  }
}
