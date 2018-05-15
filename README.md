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
<br/>
![main window](https://user-images.githubusercontent.com/1889961/40053313-74e5c05e-5849-11e8-8eb1-af17546eb444.png)<br/>
![wpf_sm_a](https://user-images.githubusercontent.com/1889961/40053348-94e02322-5849-11e8-8084-2b2fc1b7953c.jpg)
