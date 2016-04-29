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
  public partial class MemoryInitializationForm : Form
  {
    private int algorithm;
    private int memorySize;
    private Memory memory;
    private List<MemorySlot> holes;
    public MemoryInitializationForm(int algorithm, int memorySize)
    {
      InitializeComponent();

      holes = new List<MemorySlot>();
      this.algorithm = algorithm;
      this.memorySize = memorySize;
    }

    private void button_add_Click(object sender, EventArgs e)
    {
      MemorySlot slot = new MemorySlot(int.Parse(textBox_start.Text), int.Parse(textBox_size.Text),new Process("Empty",int.Parse(textBox_size.Text)));
      holes.Add(slot);
      listBox_holes.Items.Add(slot);
    }

    private void button_Initialize_Click(object sender, EventArgs e)
    {
      memory = new Memory(algorithm, memorySize, holes);

      this.DialogResult = DialogResult.OK;
      this.Close();
    }

    public Object getMemory()
    {
      return memory;
    }
  }
}
