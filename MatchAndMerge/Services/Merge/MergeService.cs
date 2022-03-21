using MatchAndMerge.Models;
using System.Collections.Generic;
using System.Linq;

namespace MatchAndMerge.Services.Merge {

    public abstract class MergeService {

        public int MinimumOverlap { get; set; } = 1;

        protected List<string> _fragments;
        protected readonly List<FragmentIndex> _overlapIndex = new();

        public MergeService() {}

        public MergeService(List<string> fragments) {
            _fragments = fragments;
        }

        public string ReassembleFragments() {
            do {
                FindOverlaps();
                MergeLargestOverlap();
            } while (_fragments.Where(x => x.Length > 0).Count() > 1);

            return _fragments.Where(x => x.Length > 0).FirstOrDefault();
        }

        private void FindOverlaps() {
            int fragmentCount = _fragments.Count - 1;
            for (int i = fragmentCount; i >= 0; i--) {
                for (int j = fragmentCount; j >= 0; j--) {
                    if (i != j) {
                        if (_fragments[i].Length > 0 && _fragments[j].Length > 0) {
                            (int overlap, int start) = FindOverlap(_fragments[i], _fragments[j]);
                            if (overlap == _fragments[j].Length) {
                                RemoveFragment(j);
                            } else if (overlap > MinimumOverlap) {
                                _overlapIndex.Add(new FragmentIndex { Source1 = i, Source2 = j, Overlap = overlap, OverlapStart = start });
                            }
                        }
                    }
                }
            }
        }

        abstract public (int, int) FindOverlap(string fragment1, string fragment2);

        private void MergeLargestOverlap() {
            if (_overlapIndex.Count == 0) {
                MergeAllFragments();
                return;
            }

            var largestOverlap = _overlapIndex.Aggregate((max, x) => x.Overlap > max.Overlap ? x : max);
            if (largestOverlap != null) {
                AddFragment(largestOverlap);
                RemoveFragment(largestOverlap.Source1);
                RemoveFragment(largestOverlap.Source2);
                return;
            }
        }

        private void MergeAllFragments() {
            string combined = string.Join("", _fragments.ToArray());
            _fragments = new();
            _fragments.Add(combined);
        }
        private void AddFragment(FragmentIndex largestOverlap) {
            _fragments.Add(_fragments[largestOverlap.Source1].Substring(0, _fragments[largestOverlap.Source1].Length - largestOverlap.Overlap) + _fragments[largestOverlap.Source2]);
        }
        private void RemoveFragment(int index) {
            _fragments[index] = "";
            _overlapIndex.RemoveAll(x => x.Source1 == index || x.Source2 == index);
        }

    }
}
