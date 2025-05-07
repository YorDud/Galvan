using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows;

namespace Prog3
{
	public static class DependencyObjectExtensions
	{
		public static T FindAncestor<T>(this DependencyObject dependencyObject) where T : DependencyObject
		{
			var parent = VisualTreeHelper.GetParent(dependencyObject);
			if (parent == null) return null;
			if (parent is T) return (T)parent;
			return parent.FindAncestor<T>();
		}
	}
}
