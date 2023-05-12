using MemoApp.Search;
using NUnit.Framework;
using Moq;
using NUnit.Framework.Constraints;

namespace Test
{
    /// <summary>
    /// 検索・置換テスト
    /// 観点
    // 1文字目から検索してヒットした場合(大文字小文字を区別する・しない、日本語)
    // 文字列の途中から検索してヒットした場合
    // 文字列の途中から検索してヒットしなかった場合(検索対象の文字列にヒットする文字列が含まれていること)
    // 検索対象の文字列にヒットする文字列が複数あり、すでにそのうちの1つがSelectedTextであれば、次の文字列にヒットすること
    // 検索文字列にヒットしない場合は、-1を返すこと
    /// </summary>
    [TestFixture]
    public class SearcherTest {
        private static ISearchTarget MakeTestObject(string vText, string vSelectedText, int vSelectionStart, int vSelectionLength, bool vIsDistinguishCase) {
            var wMock = new Mock<ISearchTarget>();
            wMock.Setup(x => x.Text).Returns(vText);
            wMock.Setup(x => x.SelectedText).Returns(vSelectedText);
            wMock.Setup(x => x.SelectionStart).Returns(vSelectionStart);
            wMock.Setup(x => x.SelectionLength).Returns(vSelectionLength);
            return wMock.Object;
        }

        [TestCase(6, "test", "aaa\nbbTestbb\ttest", "", 0, 0, false, Description = "normal")]
        [TestCase(13, "test", "aaa\nbbTestbb\ttest", "", 0, 0, true, Description = "distinguish case")]
        [TestCase(3, "テスト", "\n\n\tテストこれはテスト", "", 0, 0, default, Description = "japanese")]
        [TestCase(13, "test", "aaa\nbbtestbb\ttest", "", 7, 0, false, Description = "search from middle of text")]
        [TestCase(13, "test", "aaa\nbbtestbb\ttest", "test", 6, 4, false, Description = "search text is already selected")]
        [TestCase(-1, "テスト", "aaa\nbbtestbb\ttest", "test", 0, 0, false, Description = "not hit")]
        public void Test_SearchForwardShouldReturnFirstHitIndex(int vExpected, string vSearchText, string vText, string vSelectedText, int vSelectionStart, int vSelectionLength, bool vIsDistinguishCase) {
            ISearcher wSearcher = new Searcher(MakeTestObject(vText, vSelectedText, vSelectionStart, vSelectionLength, vIsDistinguishCase));
            wSearcher.PrepareSearch(SearchArg.CreateSearch(vSearchText, vIsDistinguishCase));
            Assert.AreEqual(vExpected, wSearcher.SearchForward());
        }
        [TestCase(13, "test", "aaa\nbbtestbb\tTest", "", 16, 0, false, Description = "ignore case")]
        [TestCase(6, "test", "aaa\nbbtestbb\tTest", "", 16, 0, true, Description = "distinguish case")]
        [TestCase(9, "テスト", "\n\n\tテストこれはテスト", "", 11, 0, default, Description = "japanese")]
        [TestCase(6, "test", "aaa\nbbtestbb\ttest", "", 10, 0, false, Description = "search from middle of text")]
        [TestCase(6, "test", "aaa\nbbtestbb\ttest", "test", 14, 4, false, Description = "search text is already selected")]
        [TestCase(-1, "テスト", "aaa\nbbtestbb\ttest", "test", 16, 0, false, Description = "not hit")]
        public void Test_SearchBackwardShouldReturnFirstHitIndex(int vExpected, string vSearchText, string vText, string vSelectedText, int vSelectionStart, int vSelectionLength, bool vIsDistinguishCase) {
            ISearcher wSearcher = new Searcher(MakeTestObject(vText, vSelectedText, vSelectionStart, vSelectionLength, vIsDistinguishCase));
            wSearcher.PrepareSearch(SearchArg.CreateSearch(vSearchText, vIsDistinguishCase));
            Assert.AreEqual(vExpected, wSearcher.SearchBackward());
        }
    }
}
