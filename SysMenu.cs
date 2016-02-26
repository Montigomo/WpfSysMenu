using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Interop;
using System.Windows.Markup;
using System.ComponentModel;
using System.Linq;

namespace SysMenu
{
	//_smiDictionary = new Dictionary<int, SysMenuItem> {
	//	{1,  new SysMenuItem(5, Win32.MenuFlags.MF_BYPOSITION | Win32.MenuFlags.MF_SEPARATOR, string.Empty) },
	//	{2,  new SysMenuItem(6, Win32.MenuFlags.MF_BYPOSITION , "Settings...", null) },
	//	{3,  new SysMenuItem(6, Win32.MenuFlags.MF_BYPOSITION , "About...", null) }
	//};

	public class SysMenuControl : Control
	{

		#region Constructors

		static SysMenuControl()
		{
			
			DefaultStyleKeyProperty.OverrideMetadata(typeof(SysMenuControl), new FrameworkPropertyMetadata(typeof(SysMenuControl)));
			_isInDesignMode = (bool)DependencyPropertyDescriptor.FromProperty(DesignerProperties.IsInDesignModeProperty, typeof(FrameworkElement)).Metadata.DefaultValue;
		}

		public SysMenuControl()
		{
			if (_isInDesignMode)
				return;
			this.Initialized += SysMenuControl_Initialized;
			this.Loaded += new RoutedEventHandler(MainView_Loaded);
		}

		#endregion

		#region Events

		private void SysMenuControl_Initialized(object sender, EventArgs e)
		{
			_window = Window.GetWindow(this);
			Window.SourceInitialized += Window_SourceInitialized;
		}

		void MainView_Loaded(object sender, RoutedEventArgs e)
		{
			Window parentWindow = Window.GetWindow(this);
		}

		#endregion

		#region Members


		private static bool _isInDesignMode = false;

		private bool IsInDesignMode
		{
			get
			{
				return _isInDesignMode;
			}
		}

		private Window _window;

		public Window Window
		{
			get
			{
				return _window;
			}
			private set
			{
				_window = value;
			}
		}

		public IntPtr Handle
		{
			get
			{
				return new WindowInteropHelper(Window).Handle;
			}
		}

		private IntPtr SysmenuHandle
		{
			get
			{
				return Win32.GetSystemMenu(this.Handle, false);
			}
		}

		private object _lock = new object();

		private int _commandID = 1000;
		private int CommandID
		{
			get
			{
				lock (_lock)
				{
					return _commandID++;
				}
			}
		}


		public const string CategoryName = "SysMenu";


		#region TrayPopupResolved

		///// <summary>
		///// TrayPopupResolved Read-Only Dependency Property
		///// </summary>
		//private static readonly DependencyPropertyKey TrayPopupResolvedPropertyKey
		//		= DependencyProperty.RegisterReadOnly("TrayPopupResolved", typeof(Popup), typeof(SysMenuControl), new FrameworkPropertyMetadata(null));

		///// <summary>
		///// A read-only dependency property that returns the <see cref="Popup"/>
		///// that is being displayed in the taskbar area based on a user action.
		///// </summary>
		//public static readonly DependencyProperty TrayPopupResolvedProperty = TrayPopupResolvedPropertyKey.DependencyProperty;

		///// <summary>
		///// Gets the TrayPopupResolved property. Returns
		///// a <see cref="Popup"/> which is either the
		///// <see cref="TrayPopup"/> control itself or a
		///// <see cref="Popup"/> control that contains the
		///// <see cref="TrayPopup"/>.
		///// </summary>
		//[Category(CategoryName)]
		//[Browsable(true)]
		//public Popup TrayPopupResolved
		//{
		//	get { return (Popup)GetValue(TrayPopupResolvedProperty); }
		//}

		///// <summary>
		///// Provides a secure method for setting the TrayPopupResolved property.  
		///// This dependency property indicates ....
		///// </summary>
		///// <param name="value">The new value for the property.</param>
		//protected void SetTrayPopupResolved(Popup value)
		//{
		//	SetValue(TrayPopupResolvedPropertyKey, value);
		//}

		#endregion

		#region ToolTipText dependency property

		///// <summary>
		///// A tooltip text that is being displayed if no custom <see cref="ToolTip"/>
		///// was set or if custom tooltips are not supported.
		///// </summary>
		//public static readonly DependencyProperty ToolTipTextProperty =
		//		DependencyProperty.Register("ToolTipText",
		//				typeof(string),
		//				typeof(SysMenuControl),
		//				new FrameworkPropertyMetadata(String.Empty, ToolTipTextPropertyChanged));


		///// <summary>
		///// A property wrapper for the <see cref="ToolTipTextProperty"/>
		///// dependency property:<br/>
		///// A tooltip text that is being displayed if no custom <see cref="ToolTip"/>
		///// was set or if custom tooltips are not supported.
		///// </summary>
		//[Category(CategoryName)]
		//[Description("Alternative to a fully blown ToolTip, which is only displayed on Vista and above.")]
		//public string ToolTipText
		//{
		//	get { return (string)GetValue(ToolTipTextProperty); }
		//	set { SetValue(ToolTipTextProperty, value); }
		//}


		///// <summary>
		///// A static callback listener which is being invoked if the
		///// <see cref="ToolTipTextProperty"/> dependency property has
		///// been changed. Invokes the <see cref="OnToolTipTextPropertyChanged"/>
		///// instance method of the changed instance.
		///// </summary>
		///// <param name="d">The currently processed owner of the property.</param>
		///// <param name="e">Provides information about the updated property.</param>
		//private static void ToolTipTextPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		//{
		//	SysMenuControl owner = (SysMenuControl)d;
		//	owner.OnToolTipTextPropertyChanged(e);
		//}


		///// <summary>
		///// Handles changes of the <see cref="ToolTipTextProperty"/> dependency property. As
		///// WPF internally uses the dependency property system and bypasses the
		///// <see cref="ToolTipText"/> property wrapper, updates of the property's value
		///// should be handled here.
		///// </summary>
		///// <param name="e">Provides information about the updated property.</param>
		//private void OnToolTipTextPropertyChanged(DependencyPropertyChangedEventArgs e)
		//{
		//	////do not touch tooltips if we have a custom tooltip element
		//	//if (TrayToolTip == null)
		//	//{
		//	//	ToolTip currentToolTip = TrayToolTipResolved;
		//	//	if (currentToolTip == null)
		//	//	{
		//	//		//if we don't have a wrapper tooltip for the tooltip text, create it now
		//	//		CreateCustomToolTip();
		//	//	}
		//	//	else
		//	//	{
		//	//		//if we have a wrapper tooltip that shows the old tooltip text, just update content
		//	//		currentToolTip.Content = e.NewValue;
		//	//	}
		//	//}

		//	//WriteToolTipSettings();
		//}

		#endregion

		#region SysMenuItems

		private static readonly DependencyProperty SysMenuItemsProperty =
		DependencyProperty.Register("AquariumContents", typeof(List<SysMenuItem>), typeof(SysMenuControl), new PropertyMetadata(new List<SysMenuItem>()));

		[Category(CategoryName)]
		[Browsable(true)]
		public List<SysMenuItem> SysMenuItems
		{
			get { return (List<SysMenuItem>)GetValue(SysMenuItemsProperty); }
			set { SetValue(SysMenuItemsProperty, (List<SysMenuItem>)value); }
		}

		#endregion

		#endregion

		#region Methods

		private void AddItem(SysMenuItem item)
		{
			if ((item.MenuFlags & Win32.MenuFlags.MF_SEPARATOR) == Win32.MenuFlags.MF_SEPARATOR)
			{
				Win32.InsertMenu(SysmenuHandle, item.Index, (int)item.MenuFlags, 0, string.Empty);
			}
			else
			{
				Win32.InsertMenu(SysmenuHandle, item.Index, (int)item.MenuFlags, item.CmdId, item.CommandText);
			}
		}

		private void Window_SourceInitialized(object sender, EventArgs e)
		{
			foreach (var item in SysMenuItems)
				AddItem(item);
			// Attach our WndProc handler to this Window
			HwndSource source = HwndSource.FromHwnd(this.Handle);
			source.AddHook(new HwndSourceHook(WndProc));
		}


		private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
		{
			// Check if a System Command has been executed
			if (msg == Win32.WM_SYSCOMMAND)
			{
				// Execute the appropriate code for the System Menu item that was clicked
				int cmdID = wParam.ToInt32();
				var SmItem = SysMenuItems.FirstOrDefault(it => it.CmdId == cmdID);
        if (SmItem != null)
				{
					SmItem.OnItemClick();
					handled = true;
				}
			}

			return IntPtr.Zero;
		}

		#endregion

	}
}
