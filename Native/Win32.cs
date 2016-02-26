using System;
using System.Text;
using System.Runtime.InteropServices;

namespace SysMenu
{
  public class Win32
  {
		public const int BM_CLICK = 0x00F5,
												WM_SYSCOMMAND = 0x0112,
												SC_CLOSE = 0xF060,
												WM_SETTEXT = 0x000C,
												WM_LBUTTONDOWN = 0x0201,
												WM_LBUTTONUP = 0x0202,
												WM_LBUTTONDBLCLK = 0x0203,
												MK_LBUTTON = 0x0001;

		public const int WM_KEYDOWN = 0x100,
												WM_KEYUP = 0x101,
												WM_CHAR = 0x0102,
												WM_SYSKEYDOWN = 0x104,
												WM_SYSKEYUP = 0x105;

		public const uint MAPVK_VK_TO_VSC = 0x00,
												MAPVK_VSC_TO_VK = 0x01,
												MAPVK_VK_TO_CHAR = 0x02,
												MAPVK_VSC_TO_VK_EX = 0x03,
												MAPVK_VK_TO_VSC_EX = 0x04;

		[DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
    public static extern uint GetWindowModuleFileName(IntPtr hwnd, [Out] [MarshalAs(UnmanagedType.LPWStr)] StringBuilder lpszFileName, uint cchFileNameMax);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="hWnd"></param>
    /// <param name="lpdwProcessId"></param>
    /// <returns></returns>
    [DllImport("user32.dll", SetLastError = true)]
    public static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

    [DllImport("user32.dll")]
    public static extern bool ShowWindow(IntPtr hWnd, WindowShowStyle nCmdShow);

    [DllImport("user32.dll")]
    public static extern bool ShowWindowAsync(IntPtr hWnd, WindowShowStyle nCmdShow);

    [DllImport("user32.dll")]
    public static extern bool IsIconic(IntPtr hWnd);

    /// <summary>Enumeration of the different ways of showing a window using 
    /// ShowWindow</summary>
    public enum WindowShowStyle : uint
    {
      /// <summary>Hides the window and activates another window.</summary>
      /// <remarks>See SW_HIDE</remarks>
      Hide = 0,
      /// <summary>Activates and displays a window. If the window is minimized 
      /// or maximized, the system restores it to its original size and 
      /// position. An application should specify this flag when displaying 
      /// the window for the first time.</summary>
      /// <remarks>See SW_SHOWNORMAL</remarks>
      ShowNormal = 1,
      /// <summary>Activates the window and displays it as a minimized window.</summary>
      /// <remarks>See SW_SHOWMINIMIZED</remarks>
      ShowMinimized = 2,
      /// <summary>Activates the window and displays it as a maximized window.</summary>
      /// <remarks>See SW_SHOWMAXIMIZED</remarks>
      ShowMaximized = 3,
      /// <summary>Maximizes the specified window.</summary>
      /// <remarks>See SW_MAXIMIZE</remarks>
      Maximize = 3,
      /// <summary>Displays a window in its most recent size and position. 
      /// This value is similar to "ShowNormal", except the window is not 
      /// actived.</summary>
      /// <remarks>See SW_SHOWNOACTIVATE</remarks>
      ShowNormalNoActivate = 4,
      /// <summary>Activates the window and displays it in its current size 
      /// and position.</summary>
      /// <remarks>See SW_SHOW</remarks>
      Show = 5,
      /// <summary>Minimizes the specified window and activates the next 
      /// top-level window in the Z order.</summary>
      /// <remarks>See SW_MINIMIZE</remarks>
      Minimize = 6,
      /// <summary>Displays the window as a minimized window. This value is 
      /// similar to "ShowMinimized", except the window is not activated.</summary>
      /// <remarks>See SW_SHOWMINNOACTIVE</remarks>
      ShowMinNoActivate = 7,
      /// <summary>Displays the window in its current size and position. This 
      /// value is similar to "Show", except the window is not activated.</summary>
      /// <remarks>See SW_SHOWNA</remarks>
      ShowNoActivate = 8,
      /// <summary>Activates and displays the window. If the window is 
      /// minimized or maximized, the system restores it to its original size 
      /// and position. An application should specify this flag when restoring 
      /// a minimized window.</summary>
      /// <remarks>See SW_RESTORE</remarks>
      Restore = 9,
      /// <summary>Sets the show state based on the SW_ value specified in the 
      /// STARTUPINFO structure passed to the CreateProcess function by the 
      /// program that started the application.</summary>
      /// <remarks>See SW_SHOWDEFAULT</remarks>
      ShowDefault = 10,
      /// <summary>Windows 2000/XP: Minimizes a window, even if the thread 
      /// that owns the window is hung. This flag should only be used when 
      /// minimizing windows from a different thread.</summary>
      /// <remarks>See SW_FORCEMINIMIZE</remarks>
      ForceMinimized = 11
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct COPYDATASTRUCT
    {
      public IntPtr dwData;       // Specifies data to be passed
      public int cbData;          // Specifies the data size in bytes
      public IntPtr lpData;       // Pointer to data to be passed
    }

    [DllImport("user32.dll")]
    public static extern IntPtr SetFocus(IntPtr hWnd);

    [DllImport("User32.dll")]
    public static extern int SetForegroundWindow(IntPtr hWnd);

    [DllImport("User32.dll", EntryPoint = "UpdateWindow", CharSet = CharSet.Auto)]
    public static extern bool UpdateWindow(IntPtr hWnd);

    [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SendMessage")]
    public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

    public const int WM_COPYDATA = 0x004A;


		[DllImport("user32.dll")]
		public static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

		[DllImport("user32.dll")]
		public static extern bool InsertMenu(IntPtr hMenu, Int32 wPosition, Int32 wFlags, Int32 wIDNewItem, string lpNewItem);

		[Flags]
		public enum MenuFlags : uint
		{
			MF_STRING				= 0x0000,
			MF_MF_BYCOMMAND = 0x0000,
			MF_BYPOSITION		= 0x0400,
			MF_SEPARATOR		= 0x0800,
			MF_REMOVE				= 0x1000,
		}


	}
}
