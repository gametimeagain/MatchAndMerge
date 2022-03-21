using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchAndMerge.DataLayer {
    public class DataRepository {
        public List<string> LoadFragmentData(string fileName) {
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
