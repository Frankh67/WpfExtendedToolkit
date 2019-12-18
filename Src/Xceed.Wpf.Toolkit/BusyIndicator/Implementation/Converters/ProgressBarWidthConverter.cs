/*************************************************************************************
   
   Toolkit for WPF

   Copyright (C) 2007-2018 Xceed Software Inc.

   This program is provided to you under the terms of the Microsoft Public
   License (Ms-PL) as published at http://wpftoolkit.codeplex.com/license 

   For more features, controls, and fast professional support,
   pick up the Plus Edition at https://xceed.com/xceed-toolkit-plus-for-wpf/

   Stay informed: follow @datagrid on Twitter or Like http://facebook.com/datagrids

  ***********************************************************************************/

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace Xceed.Wpf.Toolkit.Converters
{
  public class ProgressBarWidthConverter : IMultiValueConverter
  {
    public object Convert( object[] values, Type targetType, object parameter, CultureInfo culture )
    { 
      try
      {
        var contentWidth = (double)values[0];
        var parentMinWidth = (double)values[1];

        return Math.Max(contentWidth, parentMinWidth);
      }
      catch (InvalidCastException)
      {
        // Solve a bug that may occur during a remote desktop connection.
        // In this error case the values array contains objects
        // of type  MS.Internal.NamedObject that are not convertable.

        // Return in this case the default value for unset values
        return DependencyProperty.UnsetValue;
      }
    }

    public object[] ConvertBack( object value, Type[] targetTypes, object parameter, CultureInfo culture )
    {
      throw new NotImplementedException();
    }
  }
}
