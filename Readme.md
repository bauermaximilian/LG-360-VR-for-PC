# LG 360 VR for PC

This repository consists of a tool to get the headset display activated on a PC or Laptop (see [LG360VRActivator]()) and a shader plugin for VLC player to render videos in the specific side-by-side-format required by those glasses (see [LGVR4VLC]()).

## Disclaimer

These programs were written using resources I found in various forums and lots of trial and error. If you are considering to buy yourself some of these glasses just to try this out here, **don't**. Even in my case, I can't get it running reliably on every try. So only if you got one of those glasses, too much time at your hand and no problem with failure, continue.

Oh yeah, and if you're from LG and don't like what I did here, please don't sue me. I don't have any money anyways. Just drop me a message and I'll remove it.

## What do I need?

- **Windows** (I developed and tested it with Windows 10)
- **An LG 360 VR headset**
- **An USB-C 3.1 connector on your PC/Laptop that has DisplayPort support** (so it can output video)
  I bought an extension PCI card for that, as my PC had an USB-C port on the front, but that didn't support video output. My tablet (Galaxy Book) has an USB-C 3.1 connector with video output support, but didn't recognize the glasses in 90% of the time, so it's kind of a gamble
- **[Zadig](https://zadig.akeo.ie/)** (free, required so that this tool can actually "talk" to the device)
- The **built executable** of the [LG360VRActivator]() project in the subfolder of this repository
- [VLC media player](https://www.videolan.org/) and the shader script in the subfolder "[LGVR4VLC]()"
- **Lots of patience** and knowledge about how to use command line applications and how to install drivers

## Overview

1. Follow the instructions in the [LG360VRActivator]() subfolder (and probably do some additional research on Google) to get the headset running
2. Configure your VLC player (with the instructions in the [LGVR4VLC]() subfolder) to watch movies on the VR headset
3. ???
4. Profit

## Thanks to

The guys over at the xda-developers forums for doing the hard part of reverse-engineering that thing and doing a lot of groundwork - especially [Supportit](https://forum.xda-developers.com/member.php?u=9090171) and [TheOnlyJoey](https://forum.xda-developers.com/member.php?u=5288169)! 