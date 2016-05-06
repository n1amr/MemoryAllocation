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

		private List<Process> processes;
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
			this.processes = new List<Process>();
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

		public void deallocate(Process process)
		{
			//Process process = processes[index];
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

			processes.Remove(process);
		}

		public List<Process> getProcesses()
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
					return freeSlots[i];

			return null;
		}

		private MemorySlot mergeSlots(MemorySlot slot1, MemorySlot slot2)
		{
			int start1 = slot1.start;
			int end1 = slot1.start + slot1.size;

			int start2 = slot2.start;
			int end2 = slot2.start + slot2.size;

			if (start1 > start2)
			{
				int tmp;

				tmp = start2;
				start2 = start1;
				start1 = tmp;

				tmp = end1;
				end1 = end2;
				end2 = tmp;
			}

			if (start2 > end1)
			{
				return null;
			}

			int start = start1;
			int end = end1 > end2 ? end1 : end2;

			return new MemorySlot(start, end - start);
		}

		private void addFreeSlot(MemorySlot slot)
		{
			addSlot(slot, freeSlots);

			List<MemorySlot> mergingList = new List<MemorySlot>();
			// Search for mergable slots
			foreach (MemorySlot s in freeSlots)
				if (mergeSlots(slot, s) != null)
					mergingList.Add(s);

			foreach (MemorySlot s in mergingList)
			{
				slot = mergeSlots(slot, s);
				removeSlot(s, freeSlots);
			}

			addSlot(slot, freeSlots);
		}

		private bool isBetter(MemorySlot s1, MemorySlot s2, int algorithm)
		{
			if (algorithm == FIRST_FIT)
				return (s1.start < s2.start);
			else if (algorithm == BEST_FIT)
				return (s1.size < s2.size);
			else if (algorithm == WORST_FIT)
				return (s1.start > s2.start);
			return false;
		}

		public void addSlot(MemorySlot slot, List<MemorySlot> slots)
		{
			if (slots.Count == 0)
				slots.Add(slot);
			else
			{
				for (int i = 0; i < slots.Count; i++)
				{
					if (isBetter(slot, slots[i], algorithm))
					{
						slots.Insert(i, slot);
						return;
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
			processes = new List<Process>();
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
				addFreeSlot(slot);
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
