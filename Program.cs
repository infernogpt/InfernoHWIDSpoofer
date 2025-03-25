using System;
using Microsoft.Win32;

namespace HwidSpoofer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Original HWID: " + GetHWID());
            SpoofHWID("1234-5678"); // Example new serial number
            Console.WriteLine("Spoofed HWID: " + GetHWID());
        }

        static string GetHWID()
        {
            string hwid = "Unknown";
            try
            {
                RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Services\disk\Enum");
                if (key != null)
                {
                    hwid = key.GetValue("0").ToString();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return hwid;
        }

        static void SpoofHWID(string newSerial)
        {
            try
            {
                RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Services\disk\Enum", true);
                if (key != null)
                {
                    key.SetValue("0", newSerial);
                    Console.WriteLine("HWID spoofed successfully.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
