using MatchAndMerge.DataLayer;
using MatchAndMerge.Services.Merge;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace MatchAndMergeTest {
    [TestClass]
    public class CharacterMatchngTests {

        private readonly DataRepository _fileManager;
        private MatchWithChars _mergeService;

        public CharacterMatchngTests() {
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
            string expected = _fileManager.LoadRawData(@"Data\Expected\SomeOverlapChar.txt");

            _mergeService = new(fragment);
            string result = _mergeService.ReassembleFragments();
            Assert.AreEqual(expected, result);
        }
    }
}
