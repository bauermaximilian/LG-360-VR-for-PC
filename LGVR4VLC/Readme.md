# LG 360 VR for VLC

A HLSL shader for the Direct3D9 video output module for VLC, which turns a normal video input into a side-by-side image for the LG 360 VR glasses.

## How to use

This shader was created and tested for VLC 3.0.11, but I suppose it would work with other versions as well. 

Open the advanced preferences in VLC (Tools > Preferences, then set "Show Settings" to "All"), then navigate to "Video" > "Output modules" and set the current video output module to "Direct3D9 video output". Then, navigate to the submenu  "Direct3D9" in "Output modules" (on the left), set "Pixel Shader" to "HLSL File" and specify the "LGVR4VLC.hlsl" file in this folder under "Path to HLSL file". 

After restarting VLC, the video output should be in a side-by-side-view suitable for the LG 360 VR. Change the aspect ratio to 16:9 (if needed), move the VLC window to the screen of the VR glasses, hit "F" for fullscreen and enjoy the movie!

Alternatively, this could also be used to display your desktop (and applications like a web browser) on the VR glasses with the source "screen://" and the additional options ":screen-fps=25.000000 :live-caching=0 :screen-left=1920" (where the "screen-left" option needs to be adapted to your specific screen width and alignment).

## Known issues

This script was created in one evening without prior knowledge about how to create HLSL scripts for VLC - so consider it experimental. One issue I experienced that sometimes, when switching to another video, the image freezes and doesn't change anymore. For now, this can be solved by just restarting the VLC player.
