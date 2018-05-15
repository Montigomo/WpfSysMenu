# WpfSysMenu
System menu for wpf projects

Simple system menu for WPF projects.

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
and 

![](http://192.243.125.218/images/wpf_sm_a.jpg)
