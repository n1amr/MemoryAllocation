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

      comboBox_type.SelectedIndex = 0;
      textBox_memorySize.Text = "65536";

      memory = new Memory(comboBox_type.SelectedIndex, int.Parse(textBox_memorySize.Text));
      listBox_processes.DataSource = memory.getProcesses();

      refresh();
    }

    private void initialize(Memory memory)
    {
      if (memory != null)
      {
        listBox_processes.DataSource = memory.getProcesses();
        listBox_processes.Refresh();
      }
    }

    private void button_Initialize_Click(object sender, EventArgs e)
    {
      MemoryInitializationForm form = new MemoryInitializationForm(comboBox_type.SelectedIndex, int.Parse(textBox_memorySize.Text));
      form.ShowDialog();
      initialize((Memory)form.getMemory());
    }

    private void button_allocate_Click(object sender, EventArgs e)
    {
      bool successful = memory.allocate(textBox_name.Text, int.Parse(textBox_size.Text));
      if (!successful)
        MessageBox.Show("No enough memory space!");

      c++;
      refresh();
    }

    private void button_deallocate_Click(object sender, EventArgs e)
    {
      if (listBox_processes.Items.Count > 0)
      {
        memory.deallocate(listBox_processes.SelectedIndex);
        refresh();
      }
    }

    private int c = 0;
    private void refresh()
    {
      textBox_name.Text = "Process " + c.ToString();
      panel_memory.Refresh();
    }

    private void panel_memory_Paint(object sender, PaintEventArgs e)
    {
      base.OnPaint(e);
      using (Graphics g = e.Graphics)
      {
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

      int VMargin = 50;
      int totalHeight = panel.Height - VMargin * 2;

      int slotWidth = panel.Width * 60 / 100;
      int slotHeight = totalHeight * (endAddress - startAddress) / memorySize;

      Point leftTop = new Point(panel.Width * 5 / 100, VMargin + totalHeight * startAddress / memorySize);
      Point leftBottom = new Point(leftTop.X, leftTop.Y + slotHeight);
      Point rightBottom = new Point(leftTop.X + slotWidth, leftTop.Y + slotHeight);
      Point rightTop = new Point(leftTop.X + slotWidth, leftTop.Y);

      Point centerPoint = new Point(leftTop.X + slotWidth / 2, leftTop.Y + slotHeight / 2);
      Point nameTextPosition = centerPoint;
      Point addressPosition = new Point(rightBottom.X + 10, rightBottom.Y - 10);

      // Draw slot borders
      g.DrawLine(pen, leftTop, leftBottom);
      g.DrawLine(pen, rightTop, rightBottom);
      g.DrawLine(pen, leftTop, rightTop);
      g.DrawLine(pen, leftBottom, rightBottom);

      // Fill slot background
      g.FillRectangle(new SolidBrush(color), leftTop.X, leftTop.Y, slotWidth, slotHeight);

      // Print process name
      if (slotText.Count() * 6 > slotWidth)
        slotText = "..";
      nameTextPosition.X += (int)(slotText.Count() * 6 / 2);
      nameTextPosition.Y -= 6;
      g.DrawString(slotText, this.Font, textBrush, nameTextPosition, sf);

      // Print address label
      String addressText = "0x" + endAddress.ToString("X");
      if ((addressText.Count() + 1) * 6 > slotWidth && endAddress != 0)
        addressText = "";
      addressPosition.X += addressText.Count() * 6;
      g.DrawString(addressText, this.Font, addressBrush, addressPosition, sf);
    }

    private void MainForm_SizeChanged(object sender, EventArgs e)
    {
      refresh();
    }
  }
}
