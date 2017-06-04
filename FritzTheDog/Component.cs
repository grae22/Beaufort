using System;
using System.Drawing;
using System.Windows.Forms;
using Beaufort;

namespace FritzTheDog
{
  public partial class Component : UserControl
  {
    //-------------------------------------------------------------------------

    IComponent TargetComponent;
    Color NormalBackColour;
    Point MouseClickPosition;
    bool IsMoving;

    //-------------------------------------------------------------------------

    public Component( IComponent targetComponent )
    {
      try
      {
        TargetComponent = targetComponent;

        InitializeComponent();

        NormalBackColour = uiName.BackColor;
      }
      catch( Exception ex )
      {
        MainForm.ErrorMsg( ex );
      }
    }

    //-------------------------------------------------------------------------

    void Component_Load( object sender, EventArgs e )
    {
      try
      {
        uiType.Text = TargetComponent.GetType().Name;
        uiName.Text = TargetComponent.Name;

        uiName.Focus();
        uiName.SelectAll();
      }
      catch( Exception ex )
      {
        MainForm.ErrorMsg( ex );
      }
    }

    //-------------------------------------------------------------------------

    void uiName_TextChanged( object sender, EventArgs e )
    {
      try
      {
        bool result = TargetComponent.SetName( uiName.Text );

        if( result )
        {
          uiName.BackColor = NormalBackColour;
        }
        else
        {
          uiName.BackColor = Color.Red;
        }
      }
      catch( Exception ex )
      {
        MainForm.ErrorMsg( ex );
      }
    }

    //-------------------------------------------------------------------------
    
    void Component_MouseMove( object sender, MouseEventArgs e )
    {
      try
      {
        if( e.Button != MouseButtons.Left )
        {
          return;
        }

        Location =
          new Point(
            Location.X + e.X - MouseClickPosition.X,
            Location.Y + e.Y - MouseClickPosition.Y );
      }
      catch( Exception ex )
      {
        MainForm.ErrorMsg( ex );
      }
    }

    //-------------------------------------------------------------------------

    void Component_MouseDown( object sender, MouseEventArgs e )
    {
      try
      {
        if( IsMoving == false )
        {
          MouseClickPosition = e.Location;
        }

        IsMoving = true;

        Cursor.Current = Cursors.SizeAll;
      }
      catch( Exception ex )
      {
        MainForm.ErrorMsg( ex );
      }
    }

    //-------------------------------------------------------------------------

    void Component_MouseUp( object sender, MouseEventArgs e )
    {
      try
      {
        IsMoving = false;

        Cursor.Current = Cursors.Default;
      }
      catch( Exception ex )
      {
        MainForm.ErrorMsg( ex );
      }
    }

    //-------------------------------------------------------------------------
  }
}
