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
