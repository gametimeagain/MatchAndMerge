
namespace MatchAndMerge.Models {
    public class FragmentIndex {
        public int Source1 { get; set; }
        public int Source2 { get; set; }
        public int Overlap { get; set; }
        public int OverlapStart { get; set; }
        public bool Deleted { get; set; }
    }
}
