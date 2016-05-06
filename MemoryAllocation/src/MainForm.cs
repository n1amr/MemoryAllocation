using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoryAllocation
{
	public partial class MainForm : Form
	{
		private Memory memory;

		public MainForm()
		{
			InitializeComponent();
		}

		private void button_Initialize_Click(object sender, EventArgs e)
		{
			MemoryInitializationForm form = new MemoryInitializationForm();
			form.ShowDialog();

			if (form.DialogResult == System.Windows.Forms.DialogResult.OK)
			{
				memory = form.getMemory();
				processCounter++;
			}
			refresh();
		}

		private void button_allocate_Click(object sender, EventArgs e)
		{
			bool successful = memory.allocate(textBox_name.Text, int.Parse(textBox_size.Text));
			if (successful)
			{
				processCounter++;
				refresh();
			}
			else
				MessageBox.Show("No enough memory space!");
		}

		private void button_deallocate_Click(object sender, EventArgs e)
		{
			int index = listBox_processes.SelectedIndex;
			if (index >= 0 && index < listBox_processes.Items.Count)
			{
				Process process = (Process)listBox_processes.Items[index];
				memory.deallocate(process);
				refresh();
				if (index < listBox_processes.Items.Count)
					listBox_processes.SelectedIndex = index;
				else if (listBox_processes.Items.Count != 0)
					listBox_processes.SelectedIndex = listBox_processes.Items.Count - 1;
			}
		}

		private int processCounter = 0;
		private void refresh()
		{
			listBox_processes.Items.Clear();
			foreach (Process p in memory.getProcesses())
				listBox_processes.Items.Add(p);

			textBox_name.Text = "Process " + processCounter.ToString();
			panel_memory.Refresh();
		}

		private void panel_memory_Paint(object sender, PaintEventArgs e)
		{
			base.OnPaint(e);
			using (Graphics g = e.Graphics)
			{
				DrawSlot(g, panel_memory, new MemorySlot(0, 0), memory.getMemorySize(), Color.LightGray);

				List<MemorySlot> slots = new List<MemorySlot>();
				slots.AddRange(memory.getFreeSlots());
				slots.AddRange(memory.getAllocatedSlots());
				slots.Sort();
				foreach (MemorySlot slot in slots)
					DrawSlot(g, panel_memory, slot, memory.getMemorySize(), slot.process == null ? Color.White : Color.LightGray);
			}
		}

		private void DrawSlot(Graphics g, Panel panel, MemorySlot slot, int memorySize, Color color)
		{
			int startAddress = slot.start;
			int endAddress = slot.start + slot.size;
			string slotText = "(Empty)";
			if (slot.process != null)
				slotText = slot.process.name;

			Pen pen = new Pen(Color.Black, 2);

			SolidBrush textBrush = new SolidBrush(Color.FromArgb(255 - color.R, 255 - color.G, 255 - color.B));
			SolidBrush addressBrush = new SolidBrush(Color.Black);

			StringFormat sf = new StringFormat();
			sf.FormatFlags = StringFormatFlags.DirectionRightToLeft;

			int VMargin = 10;
			int totalHeight = panel.Height - VMargin * 2;

			int slotWidth = panel.Width * 60 / 100;
			int slotHeight = totalHeight * (endAddress - startAddress) / memorySize;

			Point leftTop = new Point(panel.Width * 5 / 100, VMargin + totalHeight * startAddress / memorySize);
			Point leftBottom = new Point(leftTop.X, leftTop.Y + slotHeight);
			Point rightBottom = new Point(leftTop.X + slotWidth, leftTop.Y + slotHeight);
			Point rightTop = new Point(leftTop.X + slotWidth, leftTop.Y);

			Point centerPoint = new Point(leftTop.X + slotWidth / 2, leftTop.Y + slotHeight / 2);
			Point slotTextPosition = centerPoint;
			Point addressPosition = new Point(rightBottom.X + 10, rightBottom.Y - 10);

			// Draw slot borders
			g.DrawLine(pen, leftTop, leftBottom);
			g.DrawLine(pen, rightTop, rightBottom);
			g.DrawLine(pen, leftTop, rightTop);
			g.DrawLine(pen, leftBottom, rightBottom);

			// Fill slot background
			g.FillRectangle(new SolidBrush(color), leftTop.X, leftTop.Y, slotWidth, slotHeight);

			// Print process name
			if (slotHeight > 16)
			{
				slotTextPosition.X += slotText.Count() * 6 / 2;
				slotTextPosition.Y -= 8;
				g.DrawString(slotText, this.Font, textBrush, slotTextPosition, sf);
			}

			// Print address label
			String addressText = "0x" + endAddress.ToString("X");
			if (slotHeight > 8)
			{
				addressPosition.X += addressText.Count() * 6;
				g.DrawString(addressText, this.Font, addressBrush, addressPosition, sf);
			}
		}

		private void MainForm_SizeChanged(object sender, EventArgs e)
		{
			int VMargin = 10;
			panel_memory.Height = this.Height - 6 * VMargin;
			panel_memory.Top = VMargin;
			refresh();
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			MemoryInitializationForm form = new MemoryInitializationForm();
			form.ShowDialog();

			if (form.DialogResult == System.Windows.Forms.DialogResult.OK)
			{
				memory = form.getMemory();
				refresh();
			}
			else
				this.Close();
		}
	}
}
