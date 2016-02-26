using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Interop;
using System.Windows.Markup;
using System.ComponentModel;
using System.Text;
using System.Drawing.Design;

namespace SysMenu
{
	
	public class SysMenuItem : DependencyObject
	{

		private static Type _typeofThis = typeof(SysMenuItem);

		private const string _category = "System menu";

		[Category(_category)]
		[Browsable(true)]
		[Description("Type: UINT The menu item before which the new menu item is to be inserted, as determined by the uFlags parameter.")]
		public int Index { get; set; }

		[Category(_category)]
		[Browsable(true)]
		[Description("uIDNewItem[in] Type: UINT_PTR - The identifier of the new menu item or, if the uFlags parameter has the MF_POPUP flag set, a handle to the drop-down menu or submenu.")]
		public int CmdId { get; set; }

		[Category(_category)]
		[Browsable(true)]
		[Description("Text command.")]
		public string CommandText { get; set; }

		[Category(_category)]
		[Browsable(true)]
		public Win32.MenuFlags MenuFlags { get; set; }

		static SysMenuItem()		{		}

		public SysMenuItem()		{		}

		public SysMenuItem(int index, Win32.MenuFlags flags, string commandText)
		{ 
			MenuFlags = flags;
			CommandText = commandText;
			Index = index;
		}

		#region ItemClick

		public event EventHandler ItemClick;

		public void OnItemClick()
		{
			if (ItemClick != null)
				ItemClick.Invoke(this, null);
		}

		#endregion

	}

	internal static class Utils
	{
		internal static bool IsLegalHandler(this RoutedEvent revent, Delegate handler)
		{
			Type type = handler.GetType();
			if (!(type == revent.HandlerType))
				return type == typeof(RoutedEventHandler);
			return true;
		}
	}

}
