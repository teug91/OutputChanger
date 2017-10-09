# OutputChanger <img align="right" src="OutputChanger/Resources/next_black.ico" width="128" style="margin:0px 30px">
Changes default audio device and primary display with hotkeys. Hotkeys can be changed by right clicking tray icon. Keep in mind that this will make it a GLOBAL hotkey, meaning it won't be usable by any other program.

Standard hotkeys are:
* Ctrl + F9 for display.
* Ctrl + F10 for audio.

I use this program in combination with [reWASD](https://www.rewasd.com/), which makes it possible to change make the display/audio changes with a gamedpad. 

## Credit
* [Hardcodet.NotifyIcon.Wpf](http://www.hardcodet.net/wpf-notifyicon) - Used for tray icon.
* [Stackoverflow post](https://stackoverflow.com/questions/195267/use-windows-api-from-c-sharp-to-set-primary-monitor) - Code for changing primary monitor.
* [AudioSwitcher](https://github.com/marcjoha/AudioSwitcher) - Some of the audio switching stuff is from this project, which is a wrapper around [AudioEndPointController](https://github.com/DanStevens/AudioEndPointController), which in turn is based on [Dave Amenta's excellent work](http://www.daveamenta.com/2011-05/programmatically-or-command-line-change-the-default-sound-playback-device-in-windows-7/). Also inspired (and very much helped out) from this [blog post](http://spikex.net/2011/05/programmatically-changing-the-default-audio-playback-device-on-windows-vista-windows-7/).
