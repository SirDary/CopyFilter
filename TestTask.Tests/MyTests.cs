namespace TestTask.Tests;

[TestClass]
public class MyTests
{
    [TestMethod]
    public void ZeroInput()
    {
        List<string> to = [];

        List<string> copy = [];

        List<string> expected = [];

        CopyFilter copyFilter = new CopyFilter();
        List<string> actual = copyFilter.Filter(to, copy);


        CollectionAssert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void CopyHaveAllAddressInSubstitute()
    {
        List<string> to =
        [
            "t.kogni@acl.com",
            "i.superuserv@tbank.ru"
        ];

        List<string> copy =
        [
            "e.gras@tbank.ru",
            "t.tbankovich@tbank.ru",
            "v.veronickovna@tbank.ru"
        ];

        List<string> expected =
        [
            "e.gras@tbank.ru",
            "t.tbankovich@tbank.ru",
            "v.veronickovna@tbank.ru"
        ];

        CopyFilter copyFilter = new CopyFilter();
        List<string> actual = copyFilter.Filter(to, copy);


        CollectionAssert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void MoreExeptions()
    {
        List<string> to =
        [
            "t.kogni@acl.com",
            "i.ivanov@tbank.ruu"
        ];

        List<string> copy =
        [
            "e.gras@tbank.ru",
            "a.andreev@alfa.com",
            "v.vladislavovich@alfa.com"
        ];

        List<string> expected =
        [
            "e.gras@tbank.ru",
            "a.andreev@alfa.com"
        ];

        CopyFilter copyFilter = new CopyFilter();
        List<string> actual = copyFilter.Filter(to, copy);

        CollectionAssert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void AllDeleteInCopy()
    {
        List<string> to =
        [
            "t.kogni@acl.com",
            "i.ivanov@tbank.ru"
        ];

        List<string> copy =
        [
            "t.tbankovich@tbank.ru",
            "v.veronickovna@tbank.ru"
        ];

        List<string> expected =
        [ ];

        CopyFilter copyFilter = new CopyFilter();
        List<string> actual = copyFilter.Filter(to, copy);

        CollectionAssert.AreEqual(expected, actual);
    }
}
