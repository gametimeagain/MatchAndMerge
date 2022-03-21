using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchAndMerge.Services.Merge {
    public class MatchWithChars : MergeService {
        public MatchWithChars(List<string> fragments) : base(fragments) { }

        protected override (int, int) FindOverlap(string fragment1, string fragment2) {
            char[] charArray1 = fragment1.ToArray();
            char[] charArray2 = fragment2.ToArray();

            int innerIndex = 0;
            int startPosition = fragment1.IndexOf(charArray2[0]);
            if (startPosition > -1) {
                int outerIndex = startPosition;
                while (outerIndex < charArray1.Length && startPosition > -1) {
                    if (charArray1[outerIndex] != charArray2[innerIndex]) {
                        innerIndex = 0;
                        outerIndex = fragment1.IndexOf(charArray2[0], startPosition + 1);
                        startPosition = outerIndex;
                        continue;
                    }
                    innerIndex++;
                    outerIndex++;

                    if (innerIndex == charArray2.Length)
                        return (charArray2.Length, 0);

                    if (outerIndex == charArray1.Length)
                        break;

                }
            }
            return (innerIndex, fragment1.Length - innerIndex);
        }

    }
}
