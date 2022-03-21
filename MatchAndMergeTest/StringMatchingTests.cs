using MatchAndMerge.DataLayer;
using MatchAndMerge.Services.Merge;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MatchAndMergeTest {
    [TestClass]
    public class StringMatchngTests {

        private readonly DataRepository _fileManager;
        private MatchWithStrings _mergeService;

        public StringMatchngTests() {
            _fileManager = new();
        }

        [TestMethod]
        public void TestOverlap() {
            string fragment1 = "all is well";
            string fragment2 = "s well th";

            _mergeService = new();
            (int overlap, _) = _mergeService.FindOverlap(fragment1, fragment2);
            Assert.AreEqual(overlap, 6);
        }

        [TestMethod]
        public void TestNoOverlap() {
            string fragment1 = "s well th";
            string fragment2 = "all is well";

            _mergeService = new();
            (int overlap, _) = _mergeService.FindOverlap(fragment1, fragment2);
            Assert.AreEqual(overlap, 0);
        }

        [TestMethod]
        public void Assignment() {
            var fragment = _fileManager.LoadFragmentDataFromString(@"all is well
ell that en
hat end
t ends well");
            string expected = "all is well that ends well";

            _mergeService = new(fragment);
            string result = _mergeService.ReassembleFragments();
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void AllOverlap() {
            var fragment = _fileManager.LoadFragmentDataFromString(@"Firs
First, hav
have a def
definite,
te, clear pr
ear pract
actical ideal;
deal; Seco
; Second, have
 have ever
 everythin
ything ne
ing necess
ecessary 
ssary to 
 to achieve y
eve your 
your ends; w
ds; wisdom, m
, money, m
, materials,
ls, and method
thods. Third
 Third, adjust
djust all yo
l your m
your mean
 means t
ans to th
to that end.
");
            string expected = "First, have a definite, clear practical ideal; Second, have everything necessary to achieve your ends; wisdom, money, materials, and methods. Third, adjust all your means to that end.";

            _mergeService = new(fragment);
            string result = _mergeService.ReassembleFragments();
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void NoOverlap() {
            var fragment = _fileManager.LoadFragmentDataFromString(@"I did
n't fail th
e test. I just fou
nd one hun
dred ways to d
o it wrong.");
            string expected = "I didn't fail the test. I just found one hundred ways to do it wrong.";

            _mergeService = new(fragment);
            string result = _mergeService.ReassembleFragments();
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void RandomOrder() {
            var fragment = _fileManager.LoadFragmentDataFromString(@"ds; wisdom, m
Firs
First, hav
have a def
te, clear pr
ear pract
actical ideal;
eve your 
deal; Seco
; Second, have
 have ever
definite,
 everythin
to that end.
ing necess
ecessary 
ssary to 
 to achieve y
ything ne
your ends; w
, money, m
, materials,
thods. Third
 Third, adjust
djust all yo
l your m
your mean
 means t
ans to th
ls, and method");
            string expected = "First, have a definite, clear practical ideal; Second, have everything necessary to achieve your ends; wisdom, money, materials, and methods. Third, adjust all your means to that end.";

            _mergeService = new(fragment);
            string result = _mergeService.ReassembleFragments();
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void SomeOverlap() {
            var fragment = _fileManager.LoadFragmentDataFromString(@"Firs
First, hav
have a 
definite,
 clear pr
ear pract
actical ideal;
deal; Seco
; Second, have
 have ever
 everythin
ything ne
ing necess
ecessary 
ssary to 
achieve 
your ends; w
ds; wisdom, m
, money, m
, materials,
ls, and method
thods. Third
 Third, adjust
djust all yo
l your m
your mean
 means t
ans to th
to that end.");
            string expected = "definite,achieve  clear practical ideal; Second, have everything necessary to First, have a your ends; wisdom, money, materials, and methods. Third, adjust all your means to that end.";

            _mergeService = new(fragment);
            string result = _mergeService.ReassembleFragments();
            Assert.AreEqual(expected, result);
        }

    }
}
