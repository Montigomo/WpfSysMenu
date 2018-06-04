# WpfSysMenu

Simple system menu for WPF projects.<br/>
https://www.nuget.org/packages/Agitech.Wpf.SysMenu/ <br/>
Just add the reference in your project, then some code like this:

```xml
    		<SysMenu:SysMenuControl HorizontalAlignment="Left" Height="24" Margin="-2,288,0,-42" VerticalAlignment="Top" Width="100">
			<SysMenu:SysMenuControl.SysMenuItems>
				<SysMenu:SysMenuItem CommandText="" CmdId="1" Index="5" MenuFlags="MF_BYPOSITION, MF_SEPARATOR"/>
				<SysMenu:SysMenuItem CommandText="Settings" CmdId="2" Index="6" MenuFlags="MF_BYPOSITION" ItemClick="SysMenuItem_ItemClick_1"/>
				<SysMenu:SysMenuItem CommandText="About" CmdId="3" Index="6" MenuFlags="MF_BYPOSITION" />
			</SysMenu:SysMenuControl.SysMenuItems>
		</SysMenu:SysMenuControl>
```


<br/>

![sysmenu1](https://user-images.githubusercontent.com/1889961/40053642-b7e6b40c-584a-11e8-9bf0-f258f663818e.png)<br/>
![sysmenu2](https://user-images.githubusercontent.com/1889961/40053659-c70c9e2e-584a-11e8-9b51-1ab5a1355489.png)
