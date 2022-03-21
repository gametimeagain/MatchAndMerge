using MatchAndMerge.DataLayer;
using MatchAndMerge.Services.Merge;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace MatchAndMerge {
    class Program {
        static void Main(string[] args) {
            string[] listOfFiles = { "Assignment.txt", "AllOverlap.txt", "NoOverlap.txt", "RandomOrder.txt", "SomeOverlap.txt" };

            foreach (string fileName in listOfFiles) {
                Console.WriteLine($"Single tests for {fileName}:");
                RunSingleTest(fileName);
                Console.WriteLine("");
            }
            foreach (string fileName in listOfFiles) {
                Console.WriteLine($"Timing tests for {fileName}:");
                RunTimingTest(fileName);
                Console.WriteLine("");
            }
        }

        private static void RunSingleTest(string fileName) {
            DataRepository fileManager = new();
            var originalData = fileManager.LoadFragmentDataFromFile(@$"..\..\Data\Fragments\{fileName}");
            if (originalData != null) {
                MatchWithStrings stringService = new(new List<string>(originalData));
                Console.WriteLine($" - String matching result: {stringService.ReassembleFragments()}");
                
                MatchWithChars charService = new(new List<string>(originalData));
                Console.WriteLine($" - Character matching result: {charService.ReassembleFragments()}");
                Console.WriteLine("---");
            } else {
                Console.WriteLine("File not found");
            }
        }
        private static void RunTimingTest(string fileName) {
            DataRepository fileManager = new();
            var originalData = fileManager.LoadFragmentDataFromFile(@$"..\..\Data\Fragments\{fileName}");
            if (originalData == null) {
                Console.WriteLine("File not found");
                return;
            }

            string result = string.Empty;
            Stopwatch stopwatch = new();
            stopwatch.Start();
            int i = 10000;
            while (i > 0) {
                MatchWithStrings mergeService = new(new List<string>(originalData));
                result = mergeService.ReassembleFragments();
                i--;
            }
            stopwatch.Stop();
            Console.WriteLine($" - String matching result: {result}");
            Console.WriteLine($" - String matching time elapsed (ms): {stopwatch.ElapsedMilliseconds}");
            Console.WriteLine("");

            stopwatch = new();
            stopwatch.Start();
            i = 10000;
            while (i > 0) {
                MatchWithChars mergeService = new(new List<string>(originalData));
                result = mergeService.ReassembleFragments();
                i--;
            }
            stopwatch.Stop();
            Console.WriteLine($" - Character matching result: {result}");
            Console.WriteLine($" - Character matching time elapsed (ms): {stopwatch.ElapsedMilliseconds}");
            Console.WriteLine("");
        }

    }
}
