﻿using System;
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
        static Dictionary<string, string> dhcp = new Dictionary<string, string>();
        static Dictionary<string, string> reserved = new Dictionary<string, string>();
        static List<string> commands = new List<string>();
        static void beolvasList(List<string>l,string filename)
        {
            try
            {
                StreamReader fajl = new StreamReader(filename);
                try
                {
                    while (!fajl.EndOfStream)
                    {
                        l.Add(fajl.ReadLine());
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
        static void beolvasDictionary(Dictionary<string, string> d, string filename)
        {
            try
            {
                StreamReader fajl = new StreamReader(filename);
                while (!fajl.EndOfStream)
                {
                    string[] adat = fajl.ReadLine().Split(';');
                    d.Add(adat[0], adat[1]);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        static void Feladat(string parancs)
        {
            //elősször csak a "request"
            /*megnézzük, hogy "request"-e*/
            if (parancs.Contains("request"))
            {
                Console.WriteLine("Ez oké");
            }
            else
            {
                Console.WriteLine("Nem oké");
            }
        }
        static void Feladatok()
        {
            foreach (var command in commands)
            {
                Feladat(command);
            }
        }
        static void Main(string[] args)
        {
            beolvasList(excluded,"excluded.csv");
            beolvasList(commands,"test.csv");
            beolvasDictionary(dhcp,"dhcp.csv");
            beolvasDictionary(reserved,"reserved.csv");
            Feladat("ebben van request");
            /*foreach (var i in commands)
            {
                Console.WriteLine(i);
            }*/
            Console.WriteLine("\nVége...");
            Console.WriteLine(EggyelNo("192.168.10.100"));
            Console.ReadLine();
        }
    }
}
