using System;
using System.Collections.Generic;
using System.IO;

namespace MatchAndMerge.DataLayer {
    public class DataRepository {
        public List<string> LoadFragmentDataFromFile(string fileName) {
            try {
                List<string> localFragments = new();
                using StreamReader sr = new(fileName); while (!sr.EndOfStream) {
                    localFragments.Add(sr.ReadLine());
                }
                return localFragments;
            } catch {
                return null;
            }
        }

        public List<string> LoadFragmentDataFromString(string data) {
            try {
                string[] splitData = data.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
                return new List<string>(splitData);
            } catch {
                return null;
            }
        }

        public string LoadRawData(string fileName) {
            try {
                string localFragments = string.Empty;
                using StreamReader sr = new(fileName); while (!sr.EndOfStream) {
                    localFragments = sr.ReadToEnd();
                }
                return localFragments;
            } catch {
                return null;
            }
        }

        public void SaveToFile(List<string> data, string path) {
            File.WriteAllLines(path, data);
        }
    }
}
