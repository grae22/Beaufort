// TODO: InputComponentControl shouldn't inherit from ComponentControl (in its
//       form) - there's functionality in ComponentControl that we don't need
//       here. ComponentControl needs to decomposed into an abstract control
//       and a concrete 'general' component class (which would contain the
//       functionality InputComponentControl doesn't use).

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Beaufort;
using Beaufort.Input;

namespace FritzTheDog
{
  class InputComponentControl : ComponentControl
  {
    //-------------------------------------------------------------------------

    public InputComponentControl( IComponent targetComponent,
                                  IComponentContainer componentContainerInfo )
    :
      base( targetComponent, componentContainerInfo )
    {
    }

    //-------------------------------------------------------------------------

    protected override void Component_Load( object sender, EventArgs e )
    {
      base.Component_Load( sender, e );

      BackColor = Color.Green;
    }

    //-------------------------------------------------------------------------

    protected override void CreateOutputsUi( Panel panel )
    {
      try
      {
        // TODO: Support other iputs.
        var input = TargetComponent as DiscreteInput;

        if( input == null )
        {
          return;
        }

        foreach( var state in input.StateNamesByValue )
        {
          byte value = state.Key;
          string name = state.Value;

          AddOutputValueButton( name, value, panel );
        }
      }
      catch( Exception ex )
      {
        MainForm.ErrorMsg( ex );
      }
    }

    //-------------------------------------------------------------------------

    void AddOutputValueButton( string stateName,
                               object stateValue,
                               Panel panel )
    {
      var button = new Button
      {
        Text = stateName,
        Tag = stateValue
      };

      button.Click += ( object sender, EventArgs args ) =>
      {
        var component = TargetComponent as IInput;

        if( component == null )
        {
          return;
        }

        component.UpdateValue( button.Tag );
      };

      panel.Controls.Add( button );
    }

    //-------------------------------------------------------------------------
  }
}
