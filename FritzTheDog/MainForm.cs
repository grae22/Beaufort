using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using System.Diagnostics;
using System.Linq;
using Beaufort;

namespace FritzTheDog
{
  public partial class MainForm : Form
  {
    //-------------------------------------------------------------------------

    public MainForm()
    {
      try
      {
        InitializeComponent();
      }
      catch( Exception ex )
      {
        ErrorMsg( ex );
      }
    }

    //-------------------------------------------------------------------------

    void ErrorMsg( Exception ex )
    {
      string callingMethodName = "Unknown";
      StackTrace trace = new StackTrace();
      if( trace.GetFrame( 1 ) != null )
      {
        callingMethodName = trace.GetFrame( 1 ).GetMethod().Name;
      }

      MessageBox.Show(
        string.Format(
          "Error in method '{0}':{1}{2}{3}",
          callingMethodName,
          Environment.NewLine,
          Environment.NewLine,
          ex.Message ),
        "Error",
        MessageBoxButtons.OK,
        MessageBoxIcon.Error );
    }

    //-------------------------------------------------------------------------

    void MainForm_Load( object sender, System.EventArgs e )
    {
      try
      {
        PopulateComponentTypesListBox();
      }
      catch( Exception ex )
      {
        ErrorMsg( ex );
      }
    }

    //-------------------------------------------------------------------------

    void PopulateComponentTypesListBox()
    {
      try
      {
        uiComponentTypes.Items.Clear();

        Dictionary<string, Type> componentTypes;

        ComponentUtils.GetComponents(
          Assembly.Load( "Components" ),
          out componentTypes );

        componentTypes.ToList().ForEach(
          x => uiComponentTypes.Items.Add( x.Key ) );
      }
      catch( Exception ex )
      {
        ErrorMsg( ex );
      }
    }

    //-------------------------------------------------------------------------
  }
}
