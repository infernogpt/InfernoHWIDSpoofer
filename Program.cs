using System;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Win32;

namespace HwidSpoofer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Original HWID: " + GetHWID());
            string randomHWID = GenerateRandomHWID();
            SpoofHWID(randomHWID);
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

        static string GenerateRandomHWID()
        {
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                byte[] randomBytes = new byte[4];
                rng.GetBytes(randomBytes);
                uint randomUint = BitConverter.ToUInt32(randomBytes, 0);
                return randomUint.ToString("X8");
            }
        }
    }
}
