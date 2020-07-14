using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace WinAPI_Vulnerabity_Test
{
    class Program
    {
        [DllImport("ntdll.dll")]
        private static extern uint RtlAdjustPrivilege(
            int Privilege,
            bool bEnablePrivilege,
            bool IsThreadPrivilege,
            out bool PreviousValue
        );
        [DllImport("ntdll.dll")]
        private static extern uint NtRaiseHardError(
            uint ErrorStatus,
            uint NumberOfParameters,
            uint UnicodeStringParameterMask,
            IntPtr Parameters,
            uint ValidResponseOption,
            out uint Response
        );

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("WELCOME TO THE WINDOWS API VULNERABILITY TEST");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Do you want me to kill windows? [Y]es - [N]o:");
            Console.ForegroundColor = ConsoleColor.White;
            int x = Console.Read();
            try
            {
                char y = Convert.ToChar(x);
                if (y == 'Y' || y == 'y')
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Attempting to kill windows...");
                    RtlAdjustPrivilege(19, true, false, out bool t1);
                    NtRaiseHardError(0xc0000022, 0, 0, IntPtr.Zero, 6, out uint oul);
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
                else if (y != 'Y' || y != 'y')
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Understandable, have a great day :)");
                    System.Threading.Thread.Sleep(3000);
                    Environment.Exit(0);
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Woops! We caught an exception! Message: {0}", ex.Message);
                Console.WriteLine("The program will exit in 10 seconds.");
                System.Threading.Thread.Sleep(10000);
                Environment.Exit(1);
            }
        }
    }
}
