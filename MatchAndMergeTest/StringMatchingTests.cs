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
        public void Assignment() {
            var fragment = _fileManager.LoadFragmentData(@"Data\Fragments\Assignment.txt");
            string expected = _fileManager.LoadRawData(@"Data\Expected\Assignment.txt");

            _mergeService = new(fragment);
            string result = _mergeService.ReassembleFragments();
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void AllOverlap() {
            var fragment = _fileManager.LoadFragmentData(@"Data\Fragments\AllOverlap.txt");
            string expected = _fileManager.LoadRawData(@"Data\Expected\AllOverlap.txt");

            _mergeService = new(fragment);
            string result = _mergeService.ReassembleFragments();
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void NoOverlap() {
            var fragment = _fileManager.LoadFragmentData(@"Data\Fragments\NoOverlap.txt");
            string expected = _fileManager.LoadRawData(@"Data\Expected\NoOverlap.txt");

            _mergeService = new(fragment);
            string result = _mergeService.ReassembleFragments();
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void RandomOrder() {
            var fragment = _fileManager.LoadFragmentData(@"Data\Fragments\RandomOrder.txt");
            string expected = _fileManager.LoadRawData(@"Data\Expected\RandomOrder.txt");

            _mergeService = new(fragment);
            string result = _mergeService.ReassembleFragments();
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void SomeOverlap() {
            var fragment = _fileManager.LoadFragmentData(@"Data\Fragments\SomeOverlap.txt");
            string expected = _fileManager.LoadRawData(@"Data\Expected\SomeOverlapString.txt");

            _mergeService = new(fragment);
            string result = _mergeService.ReassembleFragments();
            Assert.AreEqual(expected, result);
        }
    }
}
