using LibUsbDotNet;
using LibUsbDotNet.Main;
using System;
using System.Text;

namespace LG360VRActivator
{
    class Program
    {
        /// <summary>
        /// Defines the USB ID of the LG 360 VR device.
        /// </summary>
        private const int DeviceVID = 0x1004, DevicePID = 0x6374;

        /// <summary>
        /// The main entry point of the application.
        /// </summary>
        static void Main(string[] args)
        {
            Console.WriteLine("=======================");
            Console.WriteLine("=  LG360VR Activator  =");
            Console.WriteLine("=======================");
            Console.WriteLine();

            // Check if any command line parameters are provided and assign the
            // command to be sent to the device accordingly (or just print out
            // some information and terminate).
            byte[] currentCommand;

            if (args.Length == 0)
            {
                Console.WriteLine("Hint: Use /help for additional commands.");
                Console.WriteLine();

                currentCommand = BuildCommand("VR App Start");
            }
            else if (args.Length > 0 && args[0].ToLower() == "/help")
            {
                Console.WriteLine("/help:     This information.");
                Console.WriteLine("/reboot:   Attempt to reboot the device.");
                Console.WriteLine("/alwayson: Disable sleep mode of device.");
                Console.WriteLine("Default:   Activate device/display.");
                return;
            }
            else if (args.Length > 0 && args[0].ToLower() == "/reboot")
            {
                currentCommand = BuildCommand("Reboot");
            }
            else if (args.Length > 0 && args[0].ToLower() == "/alwayson")
            {
                currentCommand = BuildCommand("Sleep Disable");
            } 
            else
            {
                Console.WriteLine("Error: Invalid command.");
                Console.WriteLine("See /help for valid commands.");
                return;
            }

            // Attempt to open the device using its VID/PID.
            Console.WriteLine("Searching for device...");
            UsbDevice device;
            try
            {
                device = UsbDevice.OpenUsbDevice(
                    new UsbDeviceFinder(DeviceVID, DevicePID));
                if (device == null)
                    throw new Exception("Device not found.");
            }
            catch (Exception exc)
            {
                Console.WriteLine("Error: The device couldn't be opened ("
                    + exc.Message + ").");
                Console.WriteLine("Please make sure the device is " +
                    "connected and its default drivers have been replaced " +
                    "with current WinUSB drivers (>=6.1).");
                Console.WriteLine("Any key to exit.");
                Console.ReadKey(true);
                return;
            }

            Console.WriteLine("Device found! Sending command to device...");

            // Send the command to the device and close the application.
            try
            {
                ErrorCode errorCode;
                using (UsbEndpointWriter writer =
                    device.OpenEndpointWriter(WriteEndpointID.Ep01))
                    errorCode = writer.Write(currentCommand, 2000, out _);

                device.Close();

                if (errorCode != ErrorCode.Success)
                    throw new Exception("Transfer error '" +
                        errorCode.ToString() + "'");
            }
            catch (Exception exc)
            {
                Console.WriteLine("Error: The command couldn't be sent ("
                    + exc.Message + ").");
                Console.WriteLine("Any key to exit.");
                Console.ReadKey(true);
                return;
            }

            Console.WriteLine("Command sent successfully.");
            Console.WriteLine("Any key to exit.");
            Console.ReadKey(true);
            return;
        }

        private static byte[] BuildCommand(string command)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));

            byte[] commandPrefix = { 3, 12 };
            byte[] commandStringBytes = Encoding.ASCII.GetBytes(command);

            byte[] commandBytes =
                new byte[commandPrefix.Length + commandStringBytes.Length];

            commandPrefix.CopyTo(commandBytes, 0);
            commandStringBytes.CopyTo(commandBytes, commandPrefix.Length);

            return commandBytes;
        }
    }
}
