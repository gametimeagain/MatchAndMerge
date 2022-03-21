using MatchAndMerge.DataLayer;
using MatchAndMerge.Services.Merge;
using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace MatchAndMerge {
    class Program {
        static void Main(string[] args) {

            DataRepository fileManager = new();
            Stopwatch stopwatch = new();
            stopwatch.Start();
            int i = 1;
            while (i > 0) {
                var fragment = fileManager.LoadFragmentData(@"Data\Fragments\SomeOverlap.txt");

                MatchWithStrings mergeService = new(fragment);
                Console.WriteLine(mergeService.ReassembleFragments());
                i--;
            }
            stopwatch.Stop();
            Console.WriteLine("Mine: " + stopwatch.ElapsedMilliseconds);
            Console.ReadLine();
        }

    }
}
