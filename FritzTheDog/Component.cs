using System.Windows.Forms;
using Beaufort;

namespace FritzTheDog
{
  public partial class Component : UserControl
  {
    //-------------------------------------------------------------------------

    IComponent Target;

    //-------------------------------------------------------------------------

    public Component( IComponent targetComponent )
    {
      Target = targetComponent;

      InitializeComponent();
    }

    //-------------------------------------------------------------------------

    void Component_Load( object sender, System.EventArgs e )
    {
      uiName.Text = Target.Name;
    }

    //-------------------------------------------------------------------------
  }
}
