namespace FritzTheDog
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
    protected override void Dispose( bool disposing )
    {
      if( disposing && ( components != null ) )
      {
        components.Dispose();
      }
      base.Dispose( disposing );
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.uiComponentTypes = new System.Windows.Forms.ListBox();
      this.uiCanvas = new System.Windows.Forms.Panel();
      this.SuspendLayout();
      // 
      // uiComponentTypes
      // 
      this.uiComponentTypes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
      this.uiComponentTypes.FormattingEnabled = true;
      this.uiComponentTypes.Location = new System.Drawing.Point(12, 12);
      this.uiComponentTypes.Name = "uiComponentTypes";
      this.uiComponentTypes.Size = new System.Drawing.Size(232, 511);
      this.uiComponentTypes.TabIndex = 0;
      this.uiComponentTypes.MouseDown += new System.Windows.Forms.MouseEventHandler(this.uiComponentTypes_MouseDown);
      // 
      // uiCanvas
      // 
      this.uiCanvas.AllowDrop = true;
      this.uiCanvas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.uiCanvas.BackColor = System.Drawing.Color.White;
      this.uiCanvas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.uiCanvas.Location = new System.Drawing.Point(250, 12);
      this.uiCanvas.Name = "uiCanvas";
      this.uiCanvas.Size = new System.Drawing.Size(730, 511);
      this.uiCanvas.TabIndex = 1;
      this.uiCanvas.DragDrop += new System.Windows.Forms.DragEventHandler(this.uiCanvas_DragDrop);
      this.uiCanvas.DragOver += new System.Windows.Forms.DragEventHandler(this.uiCanvas_DragOver);
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(992, 538);
      this.Controls.Add(this.uiCanvas);
      this.Controls.Add(this.uiComponentTypes);
      this.Name = "MainForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Fritz The Dog";
      this.Load += new System.EventHandler(this.MainForm_Load);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.ListBox uiComponentTypes;
    private System.Windows.Forms.Panel uiCanvas;
  }
}

