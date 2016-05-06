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
		private Memory memory;

		private int algorithm;
		private int memorySize;

		private List<MemorySlot> holes;

		public MemoryInitializationForm()
		{
			InitializeComponent();

			memorySize = 65536;
			algorithm = Memory.FIRST_FIT;

			holes = new List<MemorySlot>();
		}

		private void button_add_Click(object sender, EventArgs e)
		{
			int start = int.Parse(textBox_start.Text);
			int size = int.Parse(textBox_size.Text);
			MemorySlot slot = new MemorySlot(start, size);
			holes.Add(slot);
			listBox_holes.Items.Add(slot);
			button_Initialize.Enabled = listBox_holes.Items.Count != 0;
			if (start + size > int.Parse(textBox_memorySize.Text))
				textBox_memorySize.Text = (start + size).ToString();
		}

		private void button_Initialize_Click(object sender, EventArgs e)
		{
			memory = new Memory(algorithm, memorySize);
			memory.initialize(holes);

			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void MemoryInitializationForm_Load(object sender, EventArgs e)
		{
			comboBox_type.SelectedIndex = 0;
			textBox_size.Text = textBox_memorySize.Text;
		}

		private void comboBox_type_SelectedIndexChanged(object sender, EventArgs e)
		{
			algorithm = comboBox_type.SelectedIndex;
		}

		private void textBox_memorySize_TextChanged(object sender, EventArgs e)
		{
			memorySize = int.Parse(textBox_memorySize.Text);
		}

		public Memory getMemory()
		{
			return memory;
		}
	}
}
