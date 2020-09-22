using System;
using System.Collections.Generic;
using System.IO;

namespace zene
{
    class adatok{
       
        public int radioSorszam;
        public TimeSpan szamhossza;
        public string szamEloado;
        public string szamZeneszam;
    }
    class Program
    {
        public static List<adatok> musor = new List<adatok>();
        public static int mennyiSzolt = 0;
        
        static void Main(string[] args)
        {
            task1();
            task2();
        }

        private static void task2()
        {
            int[] csati = new int[3];
            Console.WriteLine("Második feladat:");
            foreach (var item in musor)
            {
                csati[item.radioSorszam - 1]++;
            }

            for (int i = 0; i < csati.GetLength(0); i++)
            {
                Console.WriteLine("A/Az {0} cstornán: " + csati[i] + " számot lehetett meghalgatni", i+1);
            }
        }

        private static void task1()
        {
            StreamReader sr = new StreamReader("musor.txt");
            mennyiSzolt=(int.Parse(sr.ReadLine()));
            
            while (!sr.EndOfStream)
            {
                adatok a = new adatok();
                string ujSor = sr.ReadLine();
                string[] temp = ujSor.Split(" ");
                a.radioSorszam = int.Parse(temp[0]);
                a.szamhossza = TimeSpan.Parse("00:"+temp[1]+":"+temp[2]);
                string szAzon="";
                for (int i = 3; i < temp.GetLength(0); i++)
                {
                    szAzon += temp[i];
                }
                string[] temp2 = szAzon.Split(":");
                a.szamEloado = temp2[0];
                a.szamZeneszam = temp2[1];
                musor.Add(a);
            }

            sr.Close();
        }

    }
}
