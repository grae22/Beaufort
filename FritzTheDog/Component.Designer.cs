namespace FritzTheDog
{
  partial class Component
  {
    /// <summary> 
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary> 
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose( bool disposing )
    {
      if( disposing && ( components != null ) )
      {
        components.Dispose();
      }
      base.Dispose( disposing );
    }

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.label1 = new System.Windows.Forms.Label();
      this.uiName = new System.Windows.Forms.TextBox();
      this.groupBox1.SuspendLayout();
      this.SuspendLayout();
      // 
      // groupBox1
      // 
      this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
      this.groupBox1.Controls.Add(this.label1);
      this.groupBox1.Controls.Add(this.uiName);
      this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.groupBox1.Location = new System.Drawing.Point(0, 10);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(188, 140);
      this.groupBox1.TabIndex = 0;
      this.groupBox1.TabStop = false;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(5, 18);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(38, 13);
      this.label1.TabIndex = 3;
      this.label1.Text = "Name:";
      // 
      // uiName
      // 
      this.uiName.Location = new System.Drawing.Point(49, 15);
      this.uiName.Name = "uiName";
      this.uiName.Size = new System.Drawing.Size(133, 20);
      this.uiName.TabIndex = 2;
      this.uiName.TextChanged += new System.EventHandler(this.uiName_TextChanged);
      // 
      // Component
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
      this.Controls.Add(this.groupBox1);
      this.Name = "Component";
      this.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
      this.Size = new System.Drawing.Size(188, 150);
      this.Load += new System.EventHandler(this.Component_Load);
      this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Component_MouseMove);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox uiName;
  }
}
