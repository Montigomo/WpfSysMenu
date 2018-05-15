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
<img src="https://user-images.githubusercontent.com/1889961/40048449-ef5099f4-583a-11e8-8c40-db81b1c5263f.png" width="70%"></img> <br/>
