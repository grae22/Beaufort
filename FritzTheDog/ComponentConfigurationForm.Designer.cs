namespace FritzTheDog
{
  partial class ComponentConfigurationForm
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
      this.uiConfigData = new System.Windows.Forms.TextBox();
      this.uiCancel = new System.Windows.Forms.Button();
      this.uiOK = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // uiConfigData
      // 
      this.uiConfigData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.uiConfigData.Location = new System.Drawing.Point(12, 12);
      this.uiConfigData.Multiline = true;
      this.uiConfigData.Name = "uiConfigData";
      this.uiConfigData.Size = new System.Drawing.Size(699, 232);
      this.uiConfigData.TabIndex = 0;
      // 
      // uiCancel
      // 
      this.uiCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.uiCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.uiCancel.Location = new System.Drawing.Point(640, 260);
      this.uiCancel.Name = "uiCancel";
      this.uiCancel.Size = new System.Drawing.Size(71, 26);
      this.uiCancel.TabIndex = 1;
      this.uiCancel.Text = "Cancel";
      this.uiCancel.UseVisualStyleBackColor = true;
      // 
      // uiOK
      // 
      this.uiOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.uiOK.Location = new System.Drawing.Point(563, 260);
      this.uiOK.Name = "uiOK";
      this.uiOK.Size = new System.Drawing.Size(71, 26);
      this.uiOK.TabIndex = 2;
      this.uiOK.Text = "OK";
      this.uiOK.UseVisualStyleBackColor = true;
      this.uiOK.Click += new System.EventHandler(this.uiOK_Click);
      // 
      // ComponentConfigurationForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.uiCancel;
      this.ClientSize = new System.Drawing.Size(724, 299);
      this.ControlBox = false;
      this.Controls.Add(this.uiOK);
      this.Controls.Add(this.uiCancel);
      this.Controls.Add(this.uiConfigData);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.Name = "ComponentConfigurationForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "<<<component name>>>";
      this.Load += new System.EventHandler(this.ComponentConfigurationForm_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox uiConfigData;
    private System.Windows.Forms.Button uiCancel;
    private System.Windows.Forms.Button uiOK;
  }
}