﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.CompilerServices;
using System.Diagnostics;

namespace FilmProject_VerzioKezelt
{
    internal class Program
    {
        static List<Film> filmek = new List<Film>();
        static void Main(string[] args)
        {
            //Halasi-Czalbert Tibor

            Fajlbeolvasasa("filmadatbazis.csv");
            foreach (var item in filmek)
            {
                Debug.WriteLine(item.Cim);
            }
            Feladat01();
            Feladat02();
            Feladat03();
            Feladat04();
            Feladat07();

            Console.ReadKey();
        }

        private static void Feladat07()
        {
            Console.WriteLine($"A leggyakoribb műfaj a(z) {GetLeggyakoribbMufaj()}");
        }

        private static object GetLeggyakoribbMufaj()
        {
            Dictionary<string, int> mufajokGyakorisaga = new Dictionary<string, int>();
            foreach (var film in filmek)
            {
                foreach (var mufaj in film.Mufaj)
                {
                    if (!mufajokGyakorisaga.ContainsKey(mufaj))
                    {
                        mufajokGyakorisaga.Add(mufaj, 1);
                    }
                    else
                    {
                        mufajokGyakorisaga[mufaj] += 1;
                    }
                }
            }
            /*
            foreach (KeyValuePair<string, int> mufaj in mufajokGyakorisaga)
            {
                Console.WriteLine($"{mufaj.Key} - {mufaj.Value}");
            }
            */
            int leggyakoribbDarab = int.MinValue;
            string leggyakoribbMufaj = "";
            foreach (var mufaj in mufajokGyakorisaga)
            {
                if (mufaj.Value > leggyakoribbDarab)
                {
                    leggyakoribbDarab = mufaj.Value;
                    leggyakoribbMufaj = mufaj.Key;
                }
            }
            return leggyakoribbMufaj;
        }

        private static void Feladat04()
        {
            Console.WriteLine("Adja meg a keresendő tartalmat:");
            string keresendo = Console.ReadLine();
            List<string> cimek = FilmReszKeres(keresendo);
            Console.WriteLine("A keresett részlet az alábbi filmek címében szerepel: ");
            foreach (var item in cimek)
            {
                Console.WriteLine("\t" + item);
            }
        }

        private static List<string> FilmReszKeres(string keresendo)
        {
            List<string> cimek = new List<string>();
            foreach (var film in filmek)
            {
                if (film.Cim.ToLower().Contains(keresendo.ToLower()))
                {
                    cimek.Add(film.Cim);
                }
            }
            return cimek;
        }

        private static void Feladat03()
        {
            Console.WriteLine("Adjon meg egy film címet:");
            string cim = Console.ReadLine();
            Film film = FilmKeres(cim);
            if (film == null)
            {
                Console.WriteLine("A megadott film nem található");
            }
            else
            {
                Console.WriteLine($"A megadott film {film.Hossz} perces");
            }
        }

        private static Film FilmKeres(string cim)
        {
            int i = 0;
            while (i < filmek.Count && filmek[i].Cim != cim)
            {
                i++;
            }
            if (i < filmek.Count)
            {
                return filmek[i];
            }
            else
            { 
                return null; 
            }
        }

        private static void Feladat02()
        {
            Film leghosszabbFilm = GetLeghosszabbFilm();

            Console.WriteLine($"2. A leghosszabb film: {leghosszabbFilm.Cim} - {leghosszabbFilm.Hossz} perc");
        }

        private static Film GetLeghosszabbFilm()
        {
            Film leghosszabbFilm = filmek[0];
            for (int i = 1; i < filmek.Count; i++)
            {
                if (filmek[i].Hossz > leghosszabbFilm.Hossz)
                {
                    leghosszabbFilm = filmek[i];
                }
            }
            return leghosszabbFilm;
        }

        private static void Feladat01()
        {
            Console.WriteLine($"1. Filmek átlagos hossza: {GetAtlagosHossz()} perc");
        }

        private static object GetAtlagosHossz()
        {
            int osszHossz = 0;
            foreach (var film in filmek) 
            {
                osszHossz += film.Hossz;
            }
            return osszHossz/filmek.Count;
        }

        private static void Fajlbeolvasasa(string fajlnev)
        {
            using (var fileReader = new StreamReader(fajlnev))
            {
                fileReader.ReadLine();
                while (!fileReader.EndOfStream)
                {
                    string sor = fileReader.ReadLine();
                    Film film = new Film(sor);
                    filmek.Add(film);
                }
            }
        }
    }
}
