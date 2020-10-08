using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace dhcp_szimulacio
{
    class Program
    {
        static List<string> excluded = new List<string>();
        static void beolvasExclude()
        {
            try
            {
                StreamReader fajl = new StreamReader("excluded.csv");
                try
                {
                    while (!fajl.EndOfStream)
                    {
                        excluded.Add(fajl.ReadLine());
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex); ;
                }
                finally
                {
                    fajl.Close();
                }
                fajl.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        static string EggyelNo(string cim)
        {
            //192.168.10.100 --> 192.168.10.101
            /*szétvágni
             * utolsót int-é konvertálni
             * egyet hozzáadni (<255)
             * összefűzni*/
            string[] adat = cim.Split('.');
            //okt1,2,3 felesleges amúgy
            string okt1 = adat[0];
            string okt2 = adat[1];
            string okt3 = adat[2];
            int okt4 = int.Parse(adat[3]);
            if (okt4 < 255) 
            {
                okt4++;
            }
            string vissza = okt1+"." + okt2+"." + okt3+"." + okt4.ToString();
            return vissza;
        }
        static void Main(string[] args)
        {
            beolvasExclude();
            foreach (var i in excluded)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("\nVége...");
            Console.WriteLine(EggyelNo("192.168.10.100"));
            Console.ReadLine();
        }
    }
}
