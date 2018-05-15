using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Microsoft.Win32;


namespace SysMenu.Services
{
	public static class RunAtStartup //: IRunAtStartup
	{
		//HKCU\Software\Microsoft\Windows\CurrentVersion\Run
		//Launches a program automatically when a particular user logs in. This key is used when you always want to launch a program when a particular user is using a system.
		//HKCU\Software\Microsoft\Windows\CurrentVersion\RunOnce
		//Launches a program the next time the user logs in and removes its value entry from the registry. This key is typically used by installation programs.
		//HKLM\Software\Microsoft\Windows\CurrentVersion\Run
		//Launches a program automatically at system startup. This key is used when you always want to launch a program on a particular system.
		//HKLM\Software\Microsoft\Windows\CurrentVersion\RunOnce
		//Launches a program the next time the system starts and removes its value entry from the registry. This key is typically used by installation programs.
		//HKLM\Software\Microsoft\Windows\CurrentVersion\RunServices
		//Launches a service (a standard NT service or a background process) automatically at startup.An example of a service is a Web server such as Microsoft Internet Information Server.
		//HKLM\Software\Microsoft\Windows\CurrentVersion\RunServicesOnce
		//Launches a service (a standard NT service or a background process) the next time the system is started, then removes its value entry from the registry.

		public static void Set(bool runFlag, string appName, RasType rastype = RasType.CurrentUserRun)
		{
			var key = rastype.ToDescription();

			var keyHive = key.Substring(0, key.IndexOf('\\')).ToRegistryHive();


			var subKey = key.Substring(key.IndexOf('\\') + 1);

			//var t = Registry.GetValue(key, appName, null);

			var appPath = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;


			RegistryKey rkey = RegistryKey.OpenBaseKey(keyHive, RegistryView.Default).OpenSubKey(subKey, true);

			//var t1 = rkey.OpenSubKey(subKey);


			if (runFlag)
			{
				 rkey.SetValue(appName, appPath, Microsoft.Win32.RegistryValueKind.String);
			}
			else
			{
				rkey.DeleteValue(appName);
			}

		}
	}

	//public interface IRunAtStartup
	//{
	//	void Set(RasType rastype = RasType.CurrentUserRun);
	//	void UnSet(RasType rastype = RasType.CurrentUserRun);
	//}

	public enum RasType
	{
		[Description(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Run")]
		CurrentUserRun,
		[Description(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\RunOnce")]
		CurrentUserRunOnce,
		[Description(@"HKEY_LOCAL_MACHINE\Software\Microsoft\Windows\CurrentVersion\Run")]
		LocalMachineRun,
		[Description(@"HKEY_LOCAL_MACHINE\Software\Microsoft\Windows\CurrentVersion\RunOnce")]
		LocalMachineRunOnce,
		[Description(@"HKEY_LOCAL_MACHINE\Software\Microsoft\Windows\CurrentVersion\RunServices")]
		LocalMachineRunServices,
		[Description(@"HKEY_LOCAL_MACHINE\Software\Microsoft\Windows\CurrentVersion\RunServicesOnce")]
		LocalMachineRunServicesOnce
	}

	public static class ExtensionRegistry
	{
		public static RegistryHive ToRegistryHive(this string registryHive)
		{
			switch (registryHive)
			{
				case "HKEY_CURRENT_USER":
					return RegistryHive.CurrentUser;
				case "HKEY_LOCAL_MACHINE":
					return RegistryHive.LocalMachine;
				default:
					throw new ArgumentException("");
			}
		}

	}
}
