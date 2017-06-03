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
          x => uiComponentTypes.Items.Add( x.Value.Name ) );
      }
      catch( Exception ex )
      {
        ErrorMsg( ex );
      }
    }

    //-------------------------------------------------------------------------

    void uiComponentTypes_MouseDown( object sender, MouseEventArgs e )
    {
      try
      {
        if( uiComponentTypes.Items.Count == 0 )
        {
          return;
        }

        int index = uiComponentTypes.IndexFromPoint( e.X, e.Y );
        string componentTypeName = uiComponentTypes.Items[ index ].ToString();

        DragDropEffects effects = DoDragDrop( componentTypeName, DragDropEffects.Copy );
      }
      catch( Exception ex )
      {
        ErrorMsg( ex );
      }
    }

    //-------------------------------------------------------------------------

    private void uiCanvas_DragOver( object sender, DragEventArgs e )
    {
      try
      {
        e.Effect = DragDropEffects.Copy;
      }
      catch( Exception ex )
      {
        ErrorMsg( ex );
      }
    }

    //-------------------------------------------------------------------------

    private void uiCanvas_DragDrop( object sender, DragEventArgs e )
    {
      try
      {
        if( e.Data.GetDataPresent( DataFormats.StringFormat ) )
        {
          string componentTypeName = 
            (string)e.Data.GetData( DataFormats.StringFormat );

          
        }
      }
      catch( Exception ex )
      {
        ErrorMsg( ex );
      }
    }

    //-------------------------------------------------------------------------
  }
}
