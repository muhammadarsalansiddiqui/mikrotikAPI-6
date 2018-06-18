using System;
using System.IO;
using System.Net.Sockets;

namespace mikrotikAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            MK mikrotik = new MK("10.155.108.15");
            if (!mikrotik.Login("admin", ""))
            {
                loginFail();
                mikrotik.Close();
                return;
            }
            mikrotik.Send("/system/identity/getall");
            mikrotik.Send(".tag=sss", true);
            foreach (string h in mikrotik.Read())
            {
                Console.WriteLine(h);

            }
            Console.ReadKey();


        }

        private static void loginFail()
        {
            Console.WriteLine("Could not log in");
        }
    }
}
