using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoryAllocation.src
{
  public partial class MainForm : Form
  {
    private Controller controller;

    public MainForm()
    {
      InitializeComponent();

      controller = new Controller();
      listBox_processes.DataSource = controller.getProcesses();
    }

    private void button_allocate_Click(object sender, EventArgs e)
    {
      controller.allocate(textBox_name.Text, int.Parse(textBox_size.Text));
    }

    private void button_deallocate_Click(object sender, EventArgs e)
    {
      controller.deallocate(listBox_processes.SelectedIndex);
    }

  }
}
