using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace SysMenu
{
  public class WindowActivator
  {

    public static void Activate(IntPtr hWnd)
    {
      if (hWnd != IntPtr.Zero)
      {
        if (Win32.IsIconic(hWnd))
          Win32.ShowWindowAsync(hWnd, Win32.WindowShowStyle.ShowNormal); // Restore the Window 
        else
          Win32.ShowWindowAsync(hWnd, Win32.WindowShowStyle.Restore); // Restore the Window 

        Win32.SetForegroundWindow(hWnd);
        Win32.UpdateWindow(hWnd);
        //AgtNative.EnableWindow(hWnd, true);
        Win32.SetFocus(hWnd);
      }
    }

    public static void Activate()
    {
      IntPtr hWnd = IntPtr.Zero;

      Process current = Process.GetCurrentProcess();
      foreach (Process process in Process.GetProcessesByName(current.ProcessName))
      {
        if (process.Id != current.Id)
        {
          hWnd = process.MainWindowHandle;
          break;
        }
      }

      if (hWnd == IntPtr.Zero)
        return;

      MsgStruct myStruct;
      myStruct.Message = "Show Up";
      int myStructSize = Marshal.SizeOf(myStruct);
      IntPtr pMyStruct = Marshal.AllocHGlobal(myStructSize);
      try
      {
        Marshal.StructureToPtr(myStruct, pMyStruct, true);
        Win32.COPYDATASTRUCT cds = new Win32.COPYDATASTRUCT();
        cds.cbData = myStructSize;
        cds.lpData = pMyStruct;
        IntPtr pCds = Marshal.AllocHGlobal(Marshal.SizeOf(cds));
        Marshal.StructureToPtr(cds, pCds, false);
        Win32.SendMessage(hWnd, Win32.WM_COPYDATA, new IntPtr(), pCds);
        Marshal.FreeHGlobal(pCds);
        int result = Marshal.GetLastWin32Error();
        if (result != 0)
        {
        }
      }
      finally
      {
        Marshal.FreeHGlobal(pMyStruct);
      }
    }
  }

	
  [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
  public struct MsgStruct
  {
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
    public string Message;
  }

}
