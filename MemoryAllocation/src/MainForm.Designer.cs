namespace MemoryAllocation
{
  partial class MainForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.listBox_processes = new System.Windows.Forms.ListBox();
      this.label1 = new System.Windows.Forms.Label();
      this.textBox_size = new System.Windows.Forms.TextBox();
      this.button_allocate = new System.Windows.Forms.Button();
      this.textBox_name = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.button_deallocate = new System.Windows.Forms.Button();
      this.panel_memory = new System.Windows.Forms.Panel();
      this.groupBox3 = new System.Windows.Forms.GroupBox();
      this.label4 = new System.Windows.Forms.Label();
      this.comboBox_type = new System.Windows.Forms.ComboBox();
      this.label3 = new System.Windows.Forms.Label();
      this.textBox_memorySize = new System.Windows.Forms.TextBox();
      this.button_Initialize = new System.Windows.Forms.Button();
      this.groupBox1.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.groupBox3.SuspendLayout();
      this.SuspendLayout();
      // 
      // listBox_processes
      // 
      this.listBox_processes.FormattingEnabled = true;
      this.listBox_processes.Location = new System.Drawing.Point(6, 19);
      this.listBox_processes.Name = "listBox_processes";
      this.listBox_processes.Size = new System.Drawing.Size(148, 212);
      this.listBox_processes.TabIndex = 0;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(6, 48);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(47, 13);
      this.label1.TabIndex = 1;
      this.label1.Text = "Size (B):";
      this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // textBox_size
      // 
      this.textBox_size.Location = new System.Drawing.Point(53, 45);
      this.textBox_size.Name = "textBox_size";
      this.textBox_size.Size = new System.Drawing.Size(105, 20);
      this.textBox_size.TabIndex = 2;
      this.textBox_size.Text = "8192";
      // 
      // button_allocate
      // 
      this.button_allocate.Location = new System.Drawing.Point(6, 76);
      this.button_allocate.Name = "button_allocate";
      this.button_allocate.Size = new System.Drawing.Size(152, 23);
      this.button_allocate.TabIndex = 3;
      this.button_allocate.Text = "Allocate";
      this.button_allocate.UseVisualStyleBackColor = true;
      this.button_allocate.Click += new System.EventHandler(this.button_allocate_Click);
      // 
      // textBox_name
      // 
      this.textBox_name.Location = new System.Drawing.Point(53, 19);
      this.textBox_name.Name = "textBox_name";
      this.textBox_name.Size = new System.Drawing.Size(105, 20);
      this.textBox_name.TabIndex = 5;
      this.textBox_name.Text = "Process Name";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(15, 22);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(38, 13);
      this.label2.TabIndex = 4;
      this.label2.Text = "Name:";
      this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.label1);
      this.groupBox1.Controls.Add(this.textBox_name);
      this.groupBox1.Controls.Add(this.textBox_size);
      this.groupBox1.Controls.Add(this.label2);
      this.groupBox1.Controls.Add(this.button_allocate);
      this.groupBox1.Location = new System.Drawing.Point(17, 119);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(163, 105);
      this.groupBox1.TabIndex = 6;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Allocation";
      // 
      // groupBox2
      // 
      this.groupBox2.Controls.Add(this.button_deallocate);
      this.groupBox2.Controls.Add(this.listBox_processes);
      this.groupBox2.Location = new System.Drawing.Point(17, 230);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(163, 269);
      this.groupBox2.TabIndex = 7;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Deallocation";
      // 
      // button_deallocate
      // 
      this.button_deallocate.Location = new System.Drawing.Point(6, 240);
      this.button_deallocate.Name = "button_deallocate";
      this.button_deallocate.Size = new System.Drawing.Size(148, 23);
      this.button_deallocate.TabIndex = 1;
      this.button_deallocate.Text = "Deallocate";
      this.button_deallocate.UseVisualStyleBackColor = true;
      this.button_deallocate.Click += new System.EventHandler(this.button_deallocate_Click);
      // 
      // panel_memory
      // 
      this.panel_memory.Location = new System.Drawing.Point(187, 7);
      this.panel_memory.Name = "panel_memory";
      this.panel_memory.Size = new System.Drawing.Size(272, 495);
      this.panel_memory.TabIndex = 8;
      this.panel_memory.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_memory_Paint);
      // 
      // groupBox3
      // 
      this.groupBox3.Controls.Add(this.button_Initialize);
      this.groupBox3.Controls.Add(this.label4);
      this.groupBox3.Controls.Add(this.comboBox_type);
      this.groupBox3.Controls.Add(this.label3);
      this.groupBox3.Controls.Add(this.textBox_memorySize);
      this.groupBox3.Location = new System.Drawing.Point(12, 13);
      this.groupBox3.Name = "groupBox3";
      this.groupBox3.Size = new System.Drawing.Size(169, 100);
      this.groupBox3.TabIndex = 9;
      this.groupBox3.TabStop = false;
      this.groupBox3.Text = "Memory";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(2, 22);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(57, 13);
      this.label4.TabIndex = 6;
      this.label4.Text = "Allocation:";
      this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // comboBox_type
      // 
      this.comboBox_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.comboBox_type.FormattingEnabled = true;
      this.comboBox_type.Items.AddRange(new object[] {
            "First fit",
            "Best fit",
            "Worst fit"});
      this.comboBox_type.Location = new System.Drawing.Point(65, 19);
      this.comboBox_type.Name = "comboBox_type";
      this.comboBox_type.Size = new System.Drawing.Size(98, 21);
      this.comboBox_type.TabIndex = 5;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(2, 46);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(47, 13);
      this.label3.TabIndex = 3;
      this.label3.Text = "Size (B):";
      this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // textBox_memorySize
      // 
      this.textBox_memorySize.Location = new System.Drawing.Point(65, 43);
      this.textBox_memorySize.Name = "textBox_memorySize";
      this.textBox_memorySize.Size = new System.Drawing.Size(98, 20);
      this.textBox_memorySize.TabIndex = 4;
      // 
      // button_Initialize
      // 
      this.button_Initialize.Location = new System.Drawing.Point(5, 69);
      this.button_Initialize.Name = "button_Initialize";
      this.button_Initialize.Size = new System.Drawing.Size(158, 23);
      this.button_Initialize.TabIndex = 7;
      this.button_Initialize.Text = "Initialize";
      this.button_Initialize.UseVisualStyleBackColor = true;
      this.button_Initialize.Click += new System.EventHandler(this.button_Initialize_Click);
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(471, 511);
      this.Controls.Add(this.groupBox3);
      this.Controls.Add(this.panel_memory);
      this.Controls.Add(this.groupBox2);
      this.Controls.Add(this.groupBox1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "MainForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Memory Allocation";
      this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.groupBox2.ResumeLayout(false);
      this.groupBox3.ResumeLayout(false);
      this.groupBox3.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.ListBox listBox_processes;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox textBox_size;
    private System.Windows.Forms.Button button_allocate;
    private System.Windows.Forms.TextBox textBox_name;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.Button button_deallocate;
    private System.Windows.Forms.Panel panel_memory;
    private System.Windows.Forms.GroupBox groupBox3;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.ComboBox comboBox_type;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox textBox_memorySize;
    private System.Windows.Forms.Button button_Initialize;
  }
}