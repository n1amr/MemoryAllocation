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
      this.SuspendLayout();
      // 
      // button_Initialize
      // 
      this.button_Initialize.Location = new System.Drawing.Point(12, 276);
      this.button_Initialize.Name = "button_Initialize";
      this.button_Initialize.Size = new System.Drawing.Size(151, 23);
      this.button_Initialize.TabIndex = 7;
      this.button_Initialize.Text = "Initialize";
      this.button_Initialize.UseVisualStyleBackColor = true;
      this.button_Initialize.Click += new System.EventHandler(this.button_Initialize_Click);
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(12, 51);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(47, 13);
      this.label3.TabIndex = 3;
      this.label3.Text = "Size (B):";
      this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // textBox_size
      // 
      this.textBox_size.Location = new System.Drawing.Point(65, 48);
      this.textBox_size.Name = "textBox_size";
      this.textBox_size.Size = new System.Drawing.Size(98, 20);
      this.textBox_size.TabIndex = 4;
      this.textBox_size.Text = "8192";
      // 
      // listBox_holes
      // 
      this.listBox_holes.FormattingEnabled = true;
      this.listBox_holes.Location = new System.Drawing.Point(12, 110);
      this.listBox_holes.Name = "listBox_holes";
      this.listBox_holes.Size = new System.Drawing.Size(151, 160);
      this.listBox_holes.TabIndex = 8;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 25);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(35, 13);
      this.label1.TabIndex = 9;
      this.label1.Text = "Start:";
      this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // textBox_start
      // 
      this.textBox_start.Location = new System.Drawing.Point(65, 22);
      this.textBox_start.Name = "textBox_start";
      this.textBox_start.Size = new System.Drawing.Size(98, 20);
      this.textBox_start.TabIndex = 10;
      this.textBox_start.Text = "0";
      // 
      // button_add
      // 
      this.button_add.Location = new System.Drawing.Point(15, 74);
      this.button_add.Name = "button_add";
      this.button_add.Size = new System.Drawing.Size(148, 23);
      this.button_add.TabIndex = 11;
      this.button_add.Text = "Add hole";
      this.button_add.UseVisualStyleBackColor = true;
      this.button_add.Click += new System.EventHandler(this.button_add_Click);
      // 
      // MemoryInitializationForm
      // 
      this.AcceptButton = this.button_Initialize;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(176, 307);
      this.Controls.Add(this.button_add);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.textBox_start);
      this.Controls.Add(this.listBox_holes);
      this.Controls.Add(this.button_Initialize);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.textBox_size);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "MemoryInitializationForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Memory Initialization";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button button_Initialize;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox textBox_size;
    private System.Windows.Forms.ListBox listBox_holes;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox textBox_start;
    private System.Windows.Forms.Button button_add;
  }
}