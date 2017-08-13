using System;
using System.Windows.Forms;
using Beaufort;
using Beaufort.Configuration;

namespace FritzTheDog
{
  public partial class ComponentConfigurationForm : Form
  {
    //-------------------------------------------------------------------------

    public string ConfigurationData { get; } = "";

    private IConfiguredObject _component;

    //-------------------------------------------------------------------------

    public ComponentConfigurationForm(IConfiguredObject component)
    {
      _component = component;

      InitializeComponent();
    }

    //-------------------------------------------------------------------------

    private void ComponentConfigurationForm_Load(object sender, EventArgs e)
    {
      Text = (_component as IComponent)?.Name ?? "(Unknown name - not a component)";
      uiConfigData.Text = _component.GetConfigurationData();
    }

    //-------------------------------------------------------------------------

    private void uiOK_Click(object sender, EventArgs e)
    {
      try
      {
        //_component.C
      }
      catch (Exception exception)
      {
        Console.WriteLine(exception);
        throw;
      }
    }

    //-------------------------------------------------------------------------

    private void uiCancel_Click(object sender, EventArgs e)
    {
      Close();
    }

    //-------------------------------------------------------------------------
  }
}
