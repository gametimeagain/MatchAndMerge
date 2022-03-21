using MatchAndMerge.DataLayer;
using MatchAndMerge.Services.Merge;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MatchAndMergeTest {
    [TestClass]
    public class CharacterMatchngTests {

        private readonly DataRepository _fileManager;
        private MatchWithChars _mergeService;

        private readonly string rootPath = @"..\..\Data\";

        public CharacterMatchngTests() {
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
            var fragment = _fileManager.LoadFragmentDataFromFile(@$"{rootPath}\Fragments\Assignment.txt");
            string expected = _fileManager.LoadRawData(@$"{rootPath}\Expected\Assignment.txt");

            _mergeService = new(fragment);
            string result = _mergeService.ReassembleFragments();
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void AllOverlap() {
            var fragment = _fileManager.LoadFragmentDataFromFile(@$"{rootPath}\Fragments\AllOverlap.txt");
            string expected = _fileManager.LoadRawData(@$"{rootPath}\Expected\AllOverlap.txt");

            _mergeService = new(fragment);
            string result = _mergeService.ReassembleFragments();
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void NoOverlap() {
            var fragment = _fileManager.LoadFragmentDataFromFile(@$"{rootPath}\Fragments\NoOverlap.txt");
            string expected = _fileManager.LoadRawData(@$"{rootPath}\Expected\NoOverlap.txt");

            _mergeService = new(fragment);
            string result = _mergeService.ReassembleFragments();
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void RandomOrder() {
            var fragment = _fileManager.LoadFragmentDataFromFile(@$"{rootPath}\Fragments\RandomOrder.txt");
            string expected = _fileManager.LoadRawData(@$"{rootPath}\Expected\RandomOrder.txt");

            _mergeService = new(fragment);
            string result = _mergeService.ReassembleFragments();
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void SomeOverlap() {
            var fragment = _fileManager.LoadFragmentDataFromFile(@$"{rootPath}\Fragments\SomeOverlap.txt");
            string expected = _fileManager.LoadRawData(@$"{rootPath}\Expected\SomeOverlapChar.txt");

            _mergeService = new(fragment);
            string result = _mergeService.ReassembleFragments();
            Assert.AreEqual(expected, result);
        }

    }
}
