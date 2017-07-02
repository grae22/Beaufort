using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using Beaufort;

namespace FritzTheDog
{
  public partial class ComponentControl : UserControl
  {
    //-------------------------------------------------------------------------

    IComponent TargetComponent;
    Color NormalBackColour;
    Point MouseClickPosition;
    bool IsMoving;

    //-------------------------------------------------------------------------

    public ComponentControl( IComponent targetComponent )
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

        PopulateDependencies();

        uiName.Focus();
        uiName.SelectAll();
      }
      catch( Exception ex )
      {
        MainForm.ErrorMsg( ex );
      }
    }

    //-------------------------------------------------------------------------

    void PopulateDependencies()
    {
      try
      {
        Dictionary<string, Type> dependencyTypesByName;
        Dictionary<string, IComponent> dependenciesByName;

        ComponentUtils.GetDependencyDetails(
          TargetComponent,
          out dependencyTypesByName,
          out dependenciesByName );

        dependenciesByName
          .ToList()
          .ForEach(
            dependency =>
              {
                string dependencyName = dependency.Key;
                IComponent dependencyComponentInstance = dependency.Value;

                AddDependencyNameLabel( dependencyName );
                AddDependencyDropdownList( dependencyComponentInstance );
              }
            );
      }
      catch( Exception ex )
      {
        MainForm.ErrorMsg( ex );
      }
    }


    //-------------------------------------------------------------------------

    void AddDependencyNameLabel( string dependencyComponentName )
    {
      uiDependenciesContainer.Controls.Add(
        new Label
        {
          Text = dependencyComponentName,
          AutoSize = true,
          Font = new Font( Font, FontStyle.Bold )
        } );
    }

    //-------------------------------------------------------------------------

    void AddDependencyDropdownList( IComponent dependencyComponentInstance )
    {
      var dropDownList =
        new ComboBox
        {
          DisplayMember = "Name",
          DropDownStyle = ComboBoxStyle.DropDownList,
        };

      if( dependencyComponentInstance != null )
      {
        dropDownList.Items.Add( dependencyComponentInstance );
        dropDownList.SelectedItem = dependencyComponentInstance;
      }

      dropDownList.DropDown += ( object sender, EventArgs args ) =>
      {

      };

      uiDependenciesContainer.Controls.Add( dropDownList );
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
