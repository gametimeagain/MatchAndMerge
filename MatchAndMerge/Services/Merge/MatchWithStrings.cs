using System.Collections.Generic;
using System.Linq;

namespace MatchAndMerge.Services.Merge {
    public class MatchWithStrings : MergeService {

        public MatchWithStrings() { }
        public MatchWithStrings(List<string> fragments) : base(fragments) { }

        public override (int, int) FindOverlap(string fragment1, string fragment2) {
            if (fragment1.IndexOf(fragment2) > 0)
                return (0, 0);

            char[] charArray2 = fragment2.ToArray();

            int nextMatch = fragment1.IndexOf(charArray2[0]);
            while (nextMatch > -1) {
                string suffix = fragment1.Substring(nextMatch, fragment1.Length - nextMatch);
                string prefix = fragment2.Substring(0, suffix.Length > fragment2.Length ? fragment2.Length : suffix.Length);
                if (prefix == suffix) {
                    return (suffix.Length, 0);
                }
                nextMatch = fragment1.IndexOf(charArray2[0], nextMatch + 1);
            }
            return (0, 0);
        }
    }
}
