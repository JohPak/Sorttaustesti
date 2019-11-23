using System;
using System.Collections.Generic;
using System.Linq;

namespace TRJA_harjoitustyo // Johanna Pakkala
{
    class Program
    {
        static void Main(string[] args)
        {




            do
            {

                Console.Clear();
                Console.WriteLine("Sorttaustestejä\n");


                /* QUICKSORT ***********************/

                int[] taulukko10 = CreateArray(10000);
                long alku = StartClock(); // otetaan alkuaika (ms)
                QuickSort(taulukko10, 0, taulukko10.Length-1);
                Console.WriteLine($"Quick Sort 10 000:\t {StopClock(alku)} ms \t(oli epäjärjestyksessä)");

                Array.Reverse(taulukko10); // käännetään järjestys laskevaksi

                alku = StartClock();
                QuickSort(taulukko10, 0, taulukko10.Length - 1);
                Console.WriteLine($"Quick Sort 10 000:\t {StopClock(alku)} ms \t(oli laskevassa järjestyksessä)");

                alku = StartClock();
                QuickSort(taulukko10, 0, taulukko10.Length - 1);
                Console.WriteLine($"Quick Sort 10 000:\t {StopClock(alku)} ms \t(oli nousevassa järjestyksessä)");

                int[] taulukko500 = CreateArray(500000);
                alku = StartClock();
                QuickSort(taulukko500, 0, taulukko500.Length - 1);
                Console.WriteLine($"\nQuick Sort 500 000:\t {StopClock(alku)} ms \t(oli epäjärjestyksessä)");

                Array.Reverse(taulukko500); // käännetään järjestys laskevaksi

                alku = StartClock();
                QuickSort(taulukko500, 0, taulukko500.Length - 1);
                Console.WriteLine($"Quick Sort 500 000:\t {StopClock(alku)} ms \t(oli laskevassa järjestyksessä)");

                alku = StartClock();
                QuickSort(taulukko500, 0, taulukko500.Length - 1);
                Console.WriteLine($"Quick Sort 500 000:\t {StopClock(alku)} ms \t(oli nousevassa järjestyksessä)");



                /* ARRAYSORT ***********************/

                taulukko10 = CreateArray(10000);
                alku = StartClock();
                Array.Sort(taulukko10);
                Console.WriteLine($"\nArray Sort 10 000:\t {StopClock(alku)} ms \t(oli epäjärjestyksessä)");

                alku = StartClock();
                Array.Sort(taulukko10);
                Console.WriteLine($"Array Sort 10 000:\t {StopClock(alku)} ms \t(oli nousevassa järjestyksessä)");

                Array.Reverse(taulukko10); // käännetään laskevaan järjestykseen
                alku = StartClock();
                Array.Sort(taulukko10);
                Console.WriteLine($"Array Sort 10 000:\t {StopClock(alku)} ms \t(oli laskevassa järjestyksessä)");

                taulukko500 = CreateArray(500000);
                alku = StartClock();
                Array.Sort(taulukko500);
                Console.WriteLine($"\nArray Sort 500 000:\t {StopClock(alku)} ms \t(oli epäjärjestyksessä)");

                alku = StartClock();
                Array.Sort(taulukko500);
                Console.WriteLine($"Array Sort 500 000:\t {StopClock(alku)} ms \t(oli nousevassa järjestyksessä)");

                Array.Reverse(taulukko500); // käännetään laskevaan järjestykseen
                alku = StartClock();
                Array.Sort(taulukko500);
                Console.WriteLine($"Array Sort 500 000:\t {StopClock(alku)} ms \t(oli laskevassa järjestyksessä)");


                /* MERGESORT ***********************/ 

                List<int> lista10 = CreateList(10000);

                alku = StartClock();
                MergeSort(lista10);
                Console.WriteLine($"\nMerge Sort 10 000:\t {StopClock(alku)} ms \t(oli epäjärjestyksessä)");

                alku = StartClock();
                MergeSort(lista10);
                Console.WriteLine($"Merge Sort 10 000:\t {StopClock(alku)} ms \t(oli nousevassa järjestyksessä)");

                lista10.Reverse(); // käännetään laskevaan järjestykseen

                alku = StartClock();
                MergeSort(lista10);
                Console.WriteLine($"Merge Sort 10 000:\t {StopClock(alku)} ms \t(oli nousevassa järjestyksessä)");


                List<int> lista500 = CreateList(500000);

                alku = StartClock();
                Console.WriteLine(StartClock());
                MergeSort(lista500);
                Console.WriteLine(StartClock());
                Console.WriteLine($"\nMerge Sort 500 000:\t {StopClock(alku)} ms \t(oli epäjärjestyksessä)");
                Console.WriteLine(StartClock());


                alku = StartClock();
                MergeSort(lista500);
                Console.WriteLine($"Merge Sort 500 000:\t {StopClock(alku)} ms \t(oli nousevassa järjestyksessä)");

                lista10.Reverse(); // käännetään laskevaan järjestykseen

                alku = StartClock();
                MergeSort(lista500);
                Console.WriteLine($"Merge Sort 500 000:\t {StopClock(alku)} ms \t(oli nousevassa järjestyksessä)");


                Console.WriteLine("\nPaina enter ajaaksesi uudelleen:");
            } while (Console.ReadLine() == "");



        }

        public static int[] CreateArray(int koko)
        {
            int[] taulukko = new int[koko];
            Random arpa = new Random();

            //arpakone
            for (int ping = 0; ping < taulukko.Length; ping++)
            {
                taulukko[ping] = arpa.Next(0, 1000000);
            }
            return taulukko;
        }

        public static List<int> CreateList(int koko)
        {
            // lista johon arvotaan 100000 alkiota
            List<int> lista = new List<int>();
            Random arpa = new Random();

            //arpakone
            for (int ping = 0; ping < koko; ping++)
            {
                lista.Add(arpa.Next(0, 1000000));
            }
            return lista;
        }

        public static long StartClock()
        {
            return DateTime.Now.Millisecond;
        }

        public static long StopClock(long alku)
        {
            return DateTime.Now.Millisecond - alku;
        }

        public static void PrintArray(int[] taulukko)
        {
            foreach (var item in taulukko)
            {
                Console.Write(item + " ");
            }
        }

        private static void QuickSort(int[] a, int lo, int hi)
        {
            //  lo is the lower index, hi is the upper index
            //  of the region of array a that is to be sorted
            int i = lo, j = hi, h;

            // comparison element x
            int x = a[(lo + hi) / 2];

            //  partition
            do
            {
                while (a[i] < x) i++;
                while (a[j] > x) j--;
                if (i <= j)
                {
                    h = a[i];
                    a[i] = a[j];
                    a[j] = h;
                    i++; j--;
                }
            } while (i <= j);

            //  recursion
            if (lo < j) QuickSort(a, lo, j);
            if (i < hi) QuickSort(a, i, hi);
        }

        private static List<int> MergeSort(List<int> unsorted)
        {
            if (unsorted.Count <= 1)
                return unsorted;

            List<int> left = new List<int>();
            List<int> right = new List<int>();

            int middle = unsorted.Count / 2;
            for (int i = 0; i < middle; i++)  //Dividing the unsorted list
            {
                left.Add(unsorted[i]);
            }
            for (int i = middle; i < unsorted.Count; i++)
            {
                right.Add(unsorted[i]);
            }

            left = MergeSort(left);
            right = MergeSort(right);
            return Merge(left, right);
        }

        private static List<int> Merge(List<int> left, List<int> right)
        {
            List<int> result = new List<int>();

            while (left.Count > 0 || right.Count > 0)
            {
                if (left.Count > 0 && right.Count > 0)
                {
                    if (left.First() <= right.First())  //Comparing First two elements to see which is smaller
                    {
                        result.Add(left.First());
                        left.Remove(left.First());      //Rest of the list minus the first element
                    }
                    else
                    {
                        result.Add(right.First());
                        right.Remove(right.First());
                    }
                }
                else if (left.Count > 0)
                {
                    result.Add(left.First());
                    left.Remove(left.First());
                }
                else if (right.Count > 0)
                {
                    result.Add(right.First());

                    right.Remove(right.First());
                }
            }
            return result;
        }



    }
}

