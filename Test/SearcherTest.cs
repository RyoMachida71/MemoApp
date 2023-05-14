using MemoApp.Search;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace Test
{
    [TestFixture]
    public class SearcherTest {
        private static ISearchTarget MakeTestObject(string vText, string vSelectedText, int vSelectionStart, int vSelectionLength) {
            var wMock = new Mock<ISearchTarget>();
            wMock.Setup(x => x.Text).Returns(vText);
            wMock.SetupProperty(x => x.SelectedText, vSelectedText);
            wMock.SetupProperty(x => x.SelectionStart, vSelectionStart);
            wMock.SetupProperty(x => x.SelectionLength, vSelectionLength);
            wMock.Setup(x => x.Select(It.IsAny<int>(), It.IsAny<int>())).Callback((int vvSelectionStart, int vvSelectionLength) => {
                wMock.Object.SelectionStart = vvSelectionStart;
                wMock.Object.SelectionLength = vvSelectionLength;
                wMock.Object.SelectedText = vText.Substring(vvSelectionStart, vvSelectionLength);
            });
            return wMock.Object;
        }

        [TestCase(6, "test", "aaa\nbbTestbb\ttest", "", 0, 0, false, Description = "normal")]
        [TestCase(13, "test", "aaa\nbbTestbb\ttest", "", 0, 0, true, Description = "distinguish case")]
        [TestCase(3, "テスト", "\n\n\tテストこれはテスト", "", 0, 0, default, Description = "japanese")]
        [TestCase(13, "test", "aaa\nbbtestbb\ttest", "", 7, 0, false, Description = "search from middle of text")]
        [TestCase(13, "test", "aaa\nbbtestbb\ttest", "test", 6, 4, false, Description = "search text is already selected")]
        [TestCase(-1, "テスト", "aaa\nbbtestbb\ttest", "test", 0, 0, false, Description = "not hit")]
        public void Test_SearchForwardShouldReturnFirstHitIndex(int vExpected, string vSearchText, string vText, string vSelectedText, int vSelectionStart, int vSelectionLength, bool vIsDistinguishCase) {
            ISearcher wSearcher = new Searcher(MakeTestObject(vText, vSelectedText, vSelectionStart, vSelectionLength));
            wSearcher.PrepareSearch(SearchArg.CreateSearch(vSearchText, vIsDistinguishCase));
            Assert.AreEqual(vExpected, wSearcher.SearchForward());
        }
        [Test]
        public void Test_SearchForwardShouldReturnHitIndexes() {
            ISearchTarget wSearchTarget = MakeTestObject("aaa\nbbtestbb\ttest", "", 0, 0);
            ISearcher wSearcher = new Searcher(wSearchTarget);
            wSearcher.PrepareSearch(SearchArg.CreateSearch("test", false));
            var wResults = new List<int>();
            int wSearchCount = 2;
            for (int i = 0; i < wSearchCount; ++i) {
                wResults.Add(wSearcher.SearchForward());
            }
            Assert.AreEqual(new List<int> { 6, 13 }, wResults);
        }
        [TestCase(13, "test", "aaa\nbbtestbb\tTest", "", 16, 0, false, Description = "ignore case")]
        [TestCase(6, "test", "aaa\nbbtestbb\tTest", "", 16, 0, true, Description = "distinguish case")]
        [TestCase(9, "テスト", "\n\n\tテストこれはテスト", "", 11, 0, default, Description = "japanese")]
        [TestCase(6, "test", "aaa\nbbtestbb\ttest", "", 10, 0, false, Description = "search from middle of text")]
        [TestCase(6, "test", "aaa\nbbtestbb\ttest", "test", 14, 4, false, Description = "search text is already selected")]
        [TestCase(-1, "テスト", "aaa\nbbtestbb\ttest", "test", 16, 0, false, Description = "not hit")]
        public void Test_SearchBackwardShouldReturnFirstHitIndex(int vExpected, string vSearchText, string vText, string vSelectedText, int vSelectionStart, int vSelectionLength, bool vIsDistinguishCase) {
            ISearcher wSearcher = new Searcher(MakeTestObject(vText, vSelectedText, vSelectionStart, vSelectionLength));
            wSearcher.PrepareSearch(SearchArg.CreateSearch(vSearchText, vIsDistinguishCase));
            Assert.AreEqual(vExpected, wSearcher.SearchBackward());
        }
        [Test]
        public void Test_SearchBackwardShouldReturnHitIndexes() {
            var wSearchTarget = MakeTestObject("aaa\nbbtestbb\ttest", "", 16, 0);
            ISearcher wSearcher = new Searcher(wSearchTarget);
            wSearcher.PrepareSearch(SearchArg.CreateSearch("test", false));
            var wResults = new List<int>();
            int wSearchCount = 2;
            for (int i = 0; i < wSearchCount; ++i) {
                wResults.Add(wSearcher.SearchBackward());
            }
            Assert.AreEqual(new List<int> { 13, 6 }, wResults);
        }
        [Test]
        public void Test_SearchAllShouldReturnFirstHitIndexKeepingSelectionPosition() {
            ISearchTarget wSearchTarget = MakeTestObject("aaa\nbbtestbb\ttesttest", "", 10, 0);
            ISearcher wSearcher = new Searcher(wSearchTarget);
            wSearcher.PrepareSearch(SearchArg.CreateSearch("test", false));
            Assert.AreEqual(-1, wSearcher.SearchAll());
            Assert.AreEqual(10, wSearchTarget.SelectionStart);
        }
    }
}
