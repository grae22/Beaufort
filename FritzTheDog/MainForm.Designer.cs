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
      this.SuspendLayout();
      // 
      // uiComponentTypes
      // 
      this.uiComponentTypes.FormattingEnabled = true;
      this.uiComponentTypes.Location = new System.Drawing.Point(12, 12);
      this.uiComponentTypes.Name = "uiComponentTypes";
      this.uiComponentTypes.Size = new System.Drawing.Size(232, 95);
      this.uiComponentTypes.TabIndex = 0;
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(728, 538);
      this.Controls.Add(this.uiComponentTypes);
      this.Name = "MainForm";
      this.Text = "Fritz The Dog";
      this.Load += new System.EventHandler(this.MainForm_Load);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.ListBox uiComponentTypes;
  }
}

