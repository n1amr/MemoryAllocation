namespace MemoryAllocation
{
  partial class MemoryInitializationForm
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
      this.button_Initialize = new System.Windows.Forms.Button();
      this.label3 = new System.Windows.Forms.Label();
      this.textBox_size = new System.Windows.Forms.TextBox();
      this.listBox_holes = new System.Windows.Forms.ListBox();
      this.label1 = new System.Windows.Forms.Label();
      this.textBox_start = new System.Windows.Forms.TextBox();
      this.button_add = new System.Windows.Forms.Button();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.groupBox3 = new System.Windows.Forms.GroupBox();
      this.textBox_memorySize = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.comboBox_type = new System.Windows.Forms.ComboBox();
      this.label4 = new System.Windows.Forms.Label();
      this.groupBox1.SuspendLayout();
      this.groupBox3.SuspendLayout();
      this.SuspendLayout();
      // 
      // button_Initialize
      // 
      this.button_Initialize.Enabled = false;
      this.button_Initialize.Location = new System.Drawing.Point(12, 195);
      this.button_Initialize.Name = "button_Initialize";
      this.button_Initialize.Size = new System.Drawing.Size(363, 23);
      this.button_Initialize.TabIndex = 7;
      this.button_Initialize.Text = "Initialize";
      this.button_Initialize.UseVisualStyleBackColor = true;
      this.button_Initialize.Click += new System.EventHandler(this.button_Initialize_Click);
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(6, 52);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(47, 13);
      this.label3.TabIndex = 3;
      this.label3.Text = "Size (B):";
      this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // textBox_size
      // 
      this.textBox_size.Location = new System.Drawing.Point(59, 49);
      this.textBox_size.Name = "textBox_size";
      this.textBox_size.Size = new System.Drawing.Size(104, 20);
      this.textBox_size.TabIndex = 4;
      // 
      // listBox_holes
      // 
      this.listBox_holes.FormattingEnabled = true;
      this.listBox_holes.Location = new System.Drawing.Point(181, 12);
      this.listBox_holes.Name = "listBox_holes";
      this.listBox_holes.Size = new System.Drawing.Size(194, 173);
      this.listBox_holes.TabIndex = 8;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(6, 26);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(35, 13);
      this.label1.TabIndex = 9;
      this.label1.Text = "Start:";
      this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // textBox_start
      // 
      this.textBox_start.Location = new System.Drawing.Point(59, 23);
      this.textBox_start.Name = "textBox_start";
      this.textBox_start.Size = new System.Drawing.Size(104, 20);
      this.textBox_start.TabIndex = 10;
      this.textBox_start.Text = "0";
      // 
      // button_add
      // 
      this.button_add.Location = new System.Drawing.Point(9, 75);
      this.button_add.Name = "button_add";
      this.button_add.Size = new System.Drawing.Size(154, 23);
      this.button_add.TabIndex = 11;
      this.button_add.Text = "Add hole";
      this.button_add.UseVisualStyleBackColor = true;
      this.button_add.Click += new System.EventHandler(this.button_add_Click);
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.label1);
      this.groupBox1.Controls.Add(this.button_add);
      this.groupBox1.Controls.Add(this.textBox_size);
      this.groupBox1.Controls.Add(this.label3);
      this.groupBox1.Controls.Add(this.textBox_start);
      this.groupBox1.Location = new System.Drawing.Point(12, 89);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(169, 100);
      this.groupBox1.TabIndex = 12;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Holes";
      // 
      // groupBox3
      // 
      this.groupBox3.Controls.Add(this.label4);
      this.groupBox3.Controls.Add(this.comboBox_type);
      this.groupBox3.Controls.Add(this.label2);
      this.groupBox3.Controls.Add(this.textBox_memorySize);
      this.groupBox3.Location = new System.Drawing.Point(12, 12);
      this.groupBox3.Name = "groupBox3";
      this.groupBox3.Size = new System.Drawing.Size(169, 71);
      this.groupBox3.TabIndex = 10;
      this.groupBox3.TabStop = false;
      this.groupBox3.Text = "Memory";
      // 
      // textBox_memorySize
      // 
      this.textBox_memorySize.Location = new System.Drawing.Point(65, 43);
      this.textBox_memorySize.Name = "textBox_memorySize";
      this.textBox_memorySize.Size = new System.Drawing.Size(98, 20);
      this.textBox_memorySize.TabIndex = 4;
      this.textBox_memorySize.Text = "65536";
      this.textBox_memorySize.TextChanged += new System.EventHandler(this.textBox_memorySize_TextChanged);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(2, 46);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(47, 13);
      this.label2.TabIndex = 3;
      this.label2.Text = "Size (B):";
      this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
      this.comboBox_type.SelectedIndexChanged += new System.EventHandler(this.comboBox_type_SelectedIndexChanged);
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
      // MemoryInitializationForm
      // 
      this.AcceptButton = this.button_Initialize;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(387, 227);
      this.Controls.Add(this.groupBox3);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.listBox_holes);
      this.Controls.Add(this.button_Initialize);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "MemoryInitializationForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Memory Initialization";
      this.Load += new System.EventHandler(this.MemoryInitializationForm_Load);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.groupBox3.ResumeLayout(false);
      this.groupBox3.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button button_Initialize;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox textBox_size;
    private System.Windows.Forms.ListBox listBox_holes;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox textBox_start;
    private System.Windows.Forms.Button button_add;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.GroupBox groupBox3;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.ComboBox comboBox_type;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox textBox_memorySize;
  }
}