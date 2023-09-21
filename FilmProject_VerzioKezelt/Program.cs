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
            Console.ReadKey();
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
