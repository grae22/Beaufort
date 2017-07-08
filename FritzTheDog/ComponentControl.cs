// TODO:
// x Dependency names (when selected in dropdown list) should update when component's name is changed.

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using Beaufort;
using System.Reflection;

namespace FritzTheDog
{
  public partial class ComponentControl : UserControl
  {
    //-------------------------------------------------------------------------

    IComponent TargetComponent;
    IComponentContainer ComponentContainer;
    Color NormalBackColour;
    Point MouseClickPosition;
    bool IsMoving;

    //-------------------------------------------------------------------------

    public ComponentControl( IComponent targetComponent,
                             IComponentContainer componentContainerInfo )
    {
      try
      {
        TargetComponent = targetComponent;
        ComponentContainer = componentContainerInfo;

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

        PopulateOutputValues();
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

    void PopulateOutputValues()
    {
      try
      {
        Dictionary<string, object> valuesByName;

        ComponentUtils.GetOutputValues( TargetComponent, out valuesByName );

        foreach( var output in valuesByName )
        {
          string name = output.Key;
          object value = output.Value;

          AddOutputValueLabels( name, value );
        }
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

                AddDependencyDropdownList(
                  dependencyName,
                  dependencyTypesByName[ dependencyName ],
                  dependencyComponentInstance );
              }
            );
      }
      catch( Exception ex )
      {
        MainForm.ErrorMsg( ex );
      }
    }


    //-------------------------------------------------------------------------

    void AddOutputValueLabels( string outputName,
                               object value )
    {
      var layout =
        new FlowLayoutPanel
        {
          FlowDirection = FlowDirection.LeftToRight,
          AutoSize = true
        };

      layout.Controls.Add(
        new Label
        {
          Text = outputName + ':',
          AutoSize = true,
          Font = new Font( Font, FontStyle.Bold )
        }
      );

      layout.Controls.Add(
        new Label
        {
          Text = value.ToString(),
          AutoSize = true
        }
      );

      uiDependenciesContainer.Controls.Add( layout );
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

    void AddDependencyDropdownList( string dependencyName,
                                    Type dependencyType,
                                    IComponent dependencyComponentInstance )
    {
      var dropDownList =
        new ComboBox
        {
          DisplayMember = "Name",
          DropDownStyle = ComboBoxStyle.DropDownList,
          Tag = dependencyName
        };

      if( dependencyComponentInstance != null )
      {
        dropDownList.Items.Add( dependencyComponentInstance );
        dropDownList.SelectedItem = dependencyComponentInstance;
      }

      PopulateDependencyDropdownList( dependencyType, dropDownList );

      dropDownList.SelectedValueChanged += ( object sender, EventArgs args ) =>
      {
        ComboBox dropDownList2 = (ComboBox)sender;
        string dependencyName2 = (string)dropDownList2.Tag;

        PropertyInfo info = TargetComponent.GetType().GetProperty( dependencyName2 );
        info.SetMethod.Invoke( TargetComponent, new object[] { dropDownList2.SelectedItem } );
      };

      uiDependenciesContainer.Controls.Add( dropDownList );
    }

    //-------------------------------------------------------------------------

    void PopulateDependencyDropdownList( Type dependencyType,
                                         ComboBox dropDownList )
    {
      dropDownList.DropDown += ( object sender, EventArgs args ) =>
      {
        var list = (ComboBox)sender;

        object selected = list.SelectedItem;

        List<IComponent> components;

        ComponentUtils.GetComponentsAssignableToType(
          dependencyType,
          ComponentContainer.Components,
          out components );

        list.Items.Clear();

        components.ForEach( c => list.Items.Add( c ) );

        if( selected != null &&
            list.Items.Contains( selected ) )
        {
          list.SelectedItem = selected;
        }
      };
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
