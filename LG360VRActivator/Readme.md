# LG 360 VR Activator

## What is this?

An experimental tool to get the LG 360 VR glasses to activate when plugged in a PC.

## What is this not?

A fancy and feature-rich program that enables you to use that headset for video games or do other things with the built-in sensors. It literally just turns that thing on - that's it.

## Instructions

1. Plug in your headset
2. Download and open [Zadig](https://zadig.akeo.ie/) 
  * Under "Options", check "List All Devices"
  * Select "LGE Custom Human interface" from the dropdown list below
  * Select "WinUSB" (tested with v6.1.7600.16385, but later versions should work as well) as driver
  * Click on "Replace Driver" and wait until it finished successfully
3. Download a pre-compiled [release](https://github.com/bauermaximilian/LG-360-VR-for-PC/releases/) or build the project by yourself
4. Put down the glasses and don't move them.
5. Run ```"LG360VRActivator.exe"``` and wait.

If you're lucky, the display should turn on after a second or two - depending on your display configuration, it might still be black (but a different black than before, like... not pitch black, but the black of a screen which is turned on but doesn't have an image to display yet). So the next step is to go to your display settings, extend your desktop to that new screen (make sure to pick the correct resoultion of 1440x960) and then you should see your desktop background (cut and flipped) in the glasses.

## Troubleshooting

- "I can't see the display in my display settings"
  Make sure your USB-C connector actually supports video output. If yes, try reconnecting the VR glasses and rebooting your PC a few times. If that screen (something like "PnP screen" or "PnP monitor" in your device manager) doesn't show up, this activator application can't really help you much
- "I executed your application without errors, changed my display configuration, but the glasses are still pitch black"
  Check if there's a difference in the "black brightness" after unplugging the device. If there's no difference, make sure you are using the most recent release of this activator. You can also try going into your device manager, then search for "LGE Custom Human interface". Right click on it, deactivate the device and reenable it. 
- "Still doesn't work."
  Have you tried turning it off and on again?
- "Yeah."
  Then... I'm really sorry, but these glasses are an enigma to many and weren't designed to work on a PC. They are only supposed to work with a very specific model of LG smartphones. So getting them to work on a computer is a matter of luck.

## License

This program is, just like the whole repository, licensed under the MIT license. This program uses the NuGet package "[LibUsbDotNet](https://github.com/LibUsbDotNet/LibUsbDotNet/)", created by the authors Travis Robinson, Stevie-O and Quamotion and is licensed under the [GNU Lesser General Public License v3.0](https://github.com/LibUsbDotNet/LibUsbDotNet/blob/master/LICENSE).
