﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppQuest_Schrittzaehler.Pages
{
	public class InvertBooleanConverter : IValueConverter
	{
			#region IValueConverter implementation

			public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
			{
				if (value is bool)
				{

					return !(bool)value;
				}
				return value;
			}

			public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
			{
				return !(bool)value;
			}

			#endregion
		}
	}

