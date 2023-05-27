using MemoApp.Search;
using Moq;
using NUnit.Framework;
using System.Text.RegularExpressions;

namespace Test {
    [TestFixture]
    public class RegexSearcherTest {
        [TestCase(0, "^.*\n", "aaa\nbbTestbb\ttest", "", 0, 0, false, Description = "normal")]
        public void Test_SearchForwardShouldReturnFirstHitIndex(int vExpected, string vSearchText, string vText, string vSelectedText, int vSelectionStart, int vSelectionLength, bool vIsDistinguishCase) {
            ISearcher wSearcher = new RegexSearcher(SearcherTest.MakeTestObject(vText, vSelectedText, vSelectionStart, vSelectionLength));
            wSearcher.PrepareSearch(SearchArg.CreateSearch(vSearchText, vIsDistinguishCase));
            Assert.AreEqual(vExpected, wSearcher.SearchForward());
        }
    }
}
