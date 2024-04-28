--- SXLWrench Dev Notes ---
this space is reserved for instructions as of February 11th 2024

SXLWrench is the name of this tool (WIP) to extrapolate angular data from SkaterXL gameplay

Order of data on screen (updated April 27, 2024)

0.) clip id
1.) frame since loaded (or reset)
2.) skateboard x axix rotation (length)
3.) skateboard y axis rotation (height)
4.) skateboard z axis rotation (width)
5.) meters camera center point is from skateboard center point
6.) screen space x position of skateboard center point (ref bottom left corner 0,0)
7.) screen space y position of skateboard center point (ref bottom left corner 0,0)



Installation Instructions:
1.) Copy or fork "SXLWrenchMod_v1.0.0_for_SkaterXL_1.2.7.8" folder to your Documents folder
2.) Send to Zip (a.k.a. now called Compress to Zip)
3.) Install with UMM like any other SXL Mod
4.) Press W key to toggle ON and OFF


Concept of development:

Work-flow:
dnSpy 
MelonLoader then Unity UnityExplorer
Harmony for class injection   https://github.com/pardeike/Harmony
Packaging for UMM   appearently found here https://wiki.nexusmods.com/index.php/Category:Unity_Mod_Manager?_gl=1*1895nwe*_ga*MTQwMDU2MDU1OC4xNzA3NzEwNTQz*_ga_N0TELNQ37M*MTcwODIzODEzMC41LjEuMTcwODIzODE2NC4wLjAuMA..


Notes:
The following resources were found to be usefull references for this project

YouTube videos (in order of viewing):
https://www.youtube.com/watch?v=P5pgdnjrJ1c   Lumpology/dnSpy
https://www.youtube.com/watch?v=_8B80owys4w   pt.1 by Hazzy
https://www.youtube.com/watch?v=F7kuby5JuJI   pt.2 by Hazzy

Nexus links:
https://wiki.nexusmods.com/index.php/Unity_modding_tools

RapidGUI
https://www.youtube.com/watch?v=_8B80owys4w&list=PL5ylc__3Y9CHfx2i1fqmgz7diIVp0MMbw
https://github.com/fuqunaga/RapidGUI

Harmony 2
https://harmony.pardeike.net/articles/intro.html

Reference Gits
XLEscapeMod
https://github.com/M4cs/XLEscapeMod

UnityExplorer
https://github.com/sinai-dev/UnityExplorer

MelonLoader
https://melonwiki.xyz/#/README

