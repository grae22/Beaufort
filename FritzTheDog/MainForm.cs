using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using System.Diagnostics;
using System.Linq;
using System.Drawing;
using System.Threading;
using Beaufort;

namespace FritzTheDog
{
  public partial class MainForm : Form
  {
    //-------------------------------------------------------------------------

    public static void ErrorMsg( Exception ex )
    {
      string callingMethodName = "Unknown";
      var trace = new StackTrace();

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

    struct ComponentInfo
    {
      public string FriendlyName;
      public string FullTypeName;

      public override string ToString()
      {
        return FriendlyName;
      }
    }

    //-------------------------------------------------------------------------

    ComponentContainer Components = new ComponentContainer( "Default" );
    Thread UpdateThread;
    bool UpdateThreadIsAlive;

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

    void MainForm_Load( object sender, EventArgs e )
    {
      try
      {
        PopulateComponentTypesListBox();
        InitialiseUpdateThread();
      }
      catch( Exception ex )
      {
        ErrorMsg( ex );
      }
    }

    //-------------------------------------------------------------------------

    void MainForm_FormClosing( object sender, FormClosingEventArgs e )
    {
      try
      {
        ShutdownUpdateThread();
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
          x =>
          {
            var info = new ComponentInfo
            {
              FriendlyName = x.Value.Name,
              FullTypeName = x.Value.AssemblyQualifiedName
            };

            uiComponentTypes.Items.Add( info );
          } );
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

    void uiCanvas_DragOver( object sender, DragEventArgs e )
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

    void uiCanvas_DragDrop( object sender, DragEventArgs e )
    {
      try
      {
        if( e.Data.GetDataPresent( DataFormats.StringFormat ) )
        {
          var info = (ComponentInfo)uiComponentTypes.SelectedItem;

          ComponentControl componentControl =
            CreateComponent(
              info.FullTypeName,
              info.FriendlyName );

          if( componentControl == null )
          {
            return;
          }

          componentControl.Location = uiCanvas.PointToClient( new Point( e.X, e.Y ) );

          uiCanvas.Controls.Add( componentControl );
        }
      }
      catch( Exception ex )
      {
        ErrorMsg( ex );
      }
    }

    //-------------------------------------------------------------------------

    ComponentControl CreateComponent( string typeName, string name )
    {
      try
      {
        IComponent newComponent = Components.AddComponent( typeName, name );

        return new ComponentControl( newComponent, Components );
      }
      catch( Exception ex )
      {
        ErrorMsg( ex );
      }

      return null;
    }

    //-------------------------------------------------------------------------

    void InitialiseUpdateThread()
    {
      try
      {
        var threadStart = new ThreadStart( UpdateLoop );
        UpdateThread = new Thread( threadStart );
        UpdateThread.Start();
      }
      catch( Exception ex )
      {
        ErrorMsg( ex );
      }
    }

    //-------------------------------------------------------------------------

    void ShutdownUpdateThread()
    {
      try
      {
        UpdateThreadIsAlive = false;
        UpdateThread.Join( 1000 );
      }
      catch( Exception ex )
      {
        ErrorMsg( ex );
      }
    }

    //-------------------------------------------------------------------------

    void UpdateLoop()
    {
      try
      {
        UpdateThreadIsAlive = true;

        var updateComponentControls =
          new UpdateComponentControlsDelegate( UpdateComponentControls );

        while( UpdateThreadIsAlive )
        {
          try
          {
            Components.Update( 100 );

            updateComponentControls.Invoke();

            Thread.Sleep( 100 );
          }
          catch( ThreadInterruptedException )
          {
            // Ignore.
          }
        }
      }
      catch( Exception ex )
      {
        ErrorMsg( ex );
      }
    }

    //-------------------------------------------------------------------------

    delegate void UpdateComponentControlsDelegate();

    void UpdateComponentControls()
    {
      try
      {
        foreach( Control control in uiCanvas.Controls )
        {
          if( control is ComponentControl == false )
          {
            continue;
          }

          var componentControl = (ComponentControl)control;
          componentControl.DoUpdate();
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
