namespace FritzTheDog
{
  partial class ComponentControl
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
      this.panel1 = new System.Windows.Forms.Panel();
      this.uiDependenciesContainer = new System.Windows.Forms.FlowLayoutPanel();
      this.uiType = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.uiName = new System.Windows.Forms.TextBox();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // panel1
      // 
      this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.panel1.AutoSize = true;
      this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.panel1.BackColor = System.Drawing.SystemColors.Control;
      this.panel1.Controls.Add(this.uiDependenciesContainer);
      this.panel1.Controls.Add(this.uiType);
      this.panel1.Controls.Add(this.label1);
      this.panel1.Controls.Add(this.uiName);
      this.panel1.Location = new System.Drawing.Point(0, 14);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(188, 63);
      this.panel1.TabIndex = 0;
      // 
      // uiDependenciesContainer
      // 
      this.uiDependenciesContainer.AutoSize = true;
      this.uiDependenciesContainer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.uiDependenciesContainer.BackColor = System.Drawing.SystemColors.Control;
      this.uiDependenciesContainer.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
      this.uiDependenciesContainer.Location = new System.Drawing.Point(5, 60);
      this.uiDependenciesContainer.Name = "uiDependenciesContainer";
      this.uiDependenciesContainer.Size = new System.Drawing.Size(0, 0);
      this.uiDependenciesContainer.TabIndex = 5;
      // 
      // uiType
      // 
      this.uiType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.uiType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.uiType.Location = new System.Drawing.Point(8, 6);
      this.uiType.Name = "uiType";
      this.uiType.Size = new System.Drawing.Size(176, 13);
      this.uiType.TabIndex = 4;
      this.uiType.Text = "<set in code>";
      this.uiType.TextAlign = System.Drawing.ContentAlignment.TopRight;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(5, 31);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(38, 13);
      this.label1.TabIndex = 3;
      this.label1.Text = "Name:";
      // 
      // uiName
      // 
      this.uiName.Location = new System.Drawing.Point(49, 28);
      this.uiName.Name = "uiName";
      this.uiName.Size = new System.Drawing.Size(133, 20);
      this.uiName.TabIndex = 2;
      this.uiName.TextChanged += new System.EventHandler(this.uiName_TextChanged);
      // 
      // Component
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.AutoSize = true;
      this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
      this.Controls.Add(this.panel1);
      this.Name = "Component";
      this.Padding = new System.Windows.Forms.Padding(0, 14, 0, 0);
      this.Size = new System.Drawing.Size(188, 77);
      this.Load += new System.EventHandler(this.Component_Load);
      this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Component_MouseDown);
      this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Component_MouseMove);
      this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Component_MouseUp);
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox uiName;
    private System.Windows.Forms.Label uiType;
    private System.Windows.Forms.FlowLayoutPanel uiDependenciesContainer;
  }
}
