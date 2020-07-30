using LibUsbDotNet;
using LibUsbDotNet.Main;
using System;
using System.Text;
using System.Threading;

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
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;

            Console.WriteLine("=======================");
            Console.WriteLine("=  LG360VR Activator  =");
            Console.WriteLine("=======================");
            Console.WriteLine();

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
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: The device couldn't be opened ("
                    + exc.Message + ").");
                Console.WriteLine("Please make sure the device is " +
                    "connected and its default drivers have been replaced " +
                    "with current WinUSB drivers (>=6.1).");
                Console.WriteLine("Any key to exit.");
                Console.ReadKey(true);
                return;
            }

            Console.WriteLine("Device found! Attempting to enable display...");

            try
            {
                ErrorCode code;

                // First, listen to everything the device has to say.
                // As it turns out, if we're not gonna do that, the device 
                // will pout and refuse to listen to what we have to say.
                byte[] buffer = new byte[1024];
                using (UsbEndpointReader reader =
                    device.OpenEndpointReader(ReadEndpointID.Ep01))
                {
                    int readCount;
                    do { code = reader.Read(buffer, 1000, out readCount); }
                    while (readCount > 0);
                }

                if (code != ErrorCode.Success && code != ErrorCode.IoTimedOut)
                    throw new Exception("Transfer read error '" +
                        code.ToString() + "'");

                // After reading everything what we could from the device, we
                // will send commands to both disable the proximity sensor and
                // then turn on the displays. After this, the display should
                // be turned on.
                using (UsbEndpointWriter writer =
                    device.OpenEndpointWriter(WriteEndpointID.Ep01))
                {
                    code = writer.Write(BuildCommand("Sleep Disable"), 
                        1000, out _);
                    if (code != ErrorCode.Success)
                        throw new Exception("Transfer write error '" +
                            code.ToString() + "'");
                    code = writer.Write(BuildCommand("VR App Start"), 
                        2000, out _);
                    if (code != ErrorCode.Success)
                        throw new Exception("Transfer write error '" +
                            code.ToString() + "'");
                    writer.Flush();
                }
            }
            catch (Exception exc)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: Communication failure ("
                    + exc.Message + ").");
                Console.WriteLine("Any key to exit.");
                Console.ReadKey(true);
                return;
            } 
            finally
            {
                device.Close();
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Process completed - the display should " +
                "now be turned on.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Program will close in 2 seconds.");
            Thread.Sleep(2000);
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
