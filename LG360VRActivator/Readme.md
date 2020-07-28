# LG 360 VR Activator

## What is this?

An experimental tool to get the LG 360 VR glasses to activate when plugged in a PC.

## What is this not?

A fancy and easy-to-use program that enables you to use that headset for video games. It literally just turns that thing on - if you're lucky.

## Instructions

1. Plug in your headset
2. Download and open [Zadig](https://zadig.akeo.ie/) 
   2.1. Under "Options", check "List All Devices"
   2.2. Select "LGE Custom Human interface" from the dropdown list below
   2.3. Select "WinUSB" (tested with v6.1.7600.16385) as driver
   2.4. Click on "Replace Driver" and wait until it finished successfully
3. Open a command prompt in the directory with the executable of the LG360VRActivator
4. Optional: Run ```"LG360VRActivator.exe" /alwayson``` and/or cover the proximity sensor over the nose support inside the glasses to prevent problems with the display only being turned on when you have it on your head (which makes troubleshooting harder)
5. Run ```"LG360VRActivator.exe"``` .

If you're lucky, the display should now be turned on - depending on your display configuration, it might still be black (but a different black than before, like... not pitch black, but the black of a screen which is turned on but doesn't have an image to display yet). So the next step is to go to your display settings, extend your desktop to that new screen and then you should see your desktop background (cut and flipped) in the glasses.

## Troubleshooting

- "I can't see the display in my display settings"
  Make sure your USB-C connector actually supports video output. If yes, try reconnecting the VR glasses and rebooting your PC a few times.
- "I executed your application without errors, changed my display configuration, but the glasses are still pitch black"
  Try going into your device manager, then search for "LGE Custom Human interface". Right click on it, deactivate the device and reenable it.
- "Still doesn't work."
  Have you tried turning it off and on again?
- "Yeah."
  Then... I'm really sorry, but these glasses are an enigma to many and weren't designed to work on a PC. They are only supposed to work with a very specific model of LG smartphones. So getting them to work on a computer is a matter of luck. I can just tell you that most of the times, I got it to work after several attempts of unplugging, restarting, disabling and reenabling drivers.