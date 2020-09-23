using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            task3();
            task4();
            task5();
            task6();

        }

        private static void task6()
        {
           
        }

        private static void task5()
        {
            Console.WriteLine("5.Feladat\nAdd meg amit tudsz: ");
            string keres = Console.ReadLine();
            List<string> talalatok = new List<string>();
            keres = keres.ToLower();
            for (int j = 0; j < musor.Count; j++)
            {
                string zene = musor[j].szamEloado + ":" + musor[j].szamZeneszam;
                zene = zene.ToLower();
                int aktualis = 0;
                for (int i = 0; i < zene.Length; i++)
                {
                    if (keres[aktualis] == zene[i])
                    {
                        aktualis++; 
                    }
                    if(aktualis>=keres.Length)
                    {
                        talalatok.Add(zene);
                        break;
                    }
                }
            }

            StreamWriter sw = new StreamWriter("keres.txt");
            sw.WriteLine(keres);
            foreach (var item in talalatok)
            {
                sw.WriteLine(item);
            }
            sw.Flush();
            sw.Close();
        }

        private static void task4()
        {

            TimeSpan mennyiIdoTeltEl = new TimeSpan();
            int ezenAcsatinSzol = 0;
            for (int i = 0; i < musor.Count; i++)
            {
                if (musor[i].szamEloado == "Omega" && musor[i].szamZeneszam == "Legenda")
                {
                    Console.WriteLine("4.Feladat\nAz Omega:Legenda a " + musor[i].radioSorszam + ". csatornán hallható");
                    ezenAcsatinSzol = musor[i].radioSorszam;
                    break;
                }
            }
            for (int i = 0; i < musor.Count; i++)
            {
                if (musor[i].radioSorszam == ezenAcsatinSzol) mennyiIdoTeltEl += musor[i].szamhossza;
            }

            TimeSpan[] csati = new TimeSpan[3];
            for (int i = 1; i <=3; i++)
            {
                if (i!= ezenAcsatinSzol)
                {
                    foreach (var item in musor)
                    {
                        if (item.radioSorszam == i)
                        {
                            csati[i] += item.szamhossza;
                            if(csati[i]>= mennyiIdoTeltEl) 
                            {
                                Console.WriteLine("A(z)" + i + ". csatornán: " + item.szamEloado + ":" + item.szamZeneszam + " szól éppen.");
                                break;
                            }
                        }

                    }
                }
                
            }
        }

        private static void task3()
        {
            TimeSpan mennyiIdoTeltEl = new TimeSpan();

            int elso = 0;
            int utolso = 0;
            for (int i = 0; i < musor.Count; i++)
            {
                if (musor[i].szamEloado=="Eric Clapton" && musor[i].radioSorszam==1)
                {
                    elso = i;
                    break;
                }
            }
            for (int i = musor.Count-1; i > elso; i--)
            {
                if (musor[i].szamEloado == "Eric Clapton" && musor[i].radioSorszam == 1)
                {
                    utolso = i;
                    break;
                }
            }
            for (int i = elso; i <= utolso; i++)
            {
                if (musor[i].radioSorszam == 1)
                {
                    mennyiIdoTeltEl += musor[i].szamhossza;
                }
            }
            Console.WriteLine("3.Feladat\nEnnyi idő telt ez az első Eric Clapton kezdete és az utolsó vége között az 1. adón: " + mennyiIdoTeltEl);
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
                    szAzon += temp[i] + " ";

                }
                szAzon = szAzon.Trim();
                string[] temp2 = szAzon.Split(":");
                a.szamEloado = temp2[0];
                a.szamZeneszam = temp2[1];
                musor.Add(a);
            }

            sr.Close();
        }

    }
}
