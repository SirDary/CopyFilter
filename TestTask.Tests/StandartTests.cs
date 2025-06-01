namespace TestTask.Tests
{
    [TestClass]
    public sealed class StandartTests
    {
        [TestMethod]
        public void AddAdressInCopy()
        {
            List<string> to =
            [
                "q.qweshnikov@batut.com",
                "w.petrov@alfa.com"
            ];

            List<string> copy =
            [
                "f.patit@buisness.com"
            ];

            List<string> expected =
            [
                "f.patit@buisness.com",
                "v.vladislavovich@alfa.com"
            ];

            CopyFilter copyFilter = new CopyFilter();
            List<string> actual = copyFilter.Filter(to, copy);


            CollectionAssert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void HavExeption()
        {
            List<string> to =
            [
                "t.kogni@acl.com"
            ];

            List<string> copy =
            [
                "i.ivanov@tbank.ru"
            ];

            List<string> expected =
            [
                "i.ivanov@tbank.ru"
            ];

            CopyFilter copyFilter = new CopyFilter();
            List<string> actual = copyFilter.Filter(to, copy);


            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void HavExeptionAndDeleteAdress()
        {
            List<string> to =
            [
                "t.kogni@acl.com",
                "i.ivanov@tbank.ru"
            ];

            List<string> copy =
            [
                "e.gras@tbank.ru",
                "t.tbankovich@tbank.ru",
                "v.veronickovna@tbank.ru"
            ];

            List<string> expected =
            [
                "e.gras@tbank.ru"
            ];

            CopyFilter copyFilter = new CopyFilter();
            List<string> actual = copyFilter.Filter(to, copy);


            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DontChange()
        {
            List<string> to =
            [
                "z.xcy@email.com"
            ];

            List<string> copy =
            [
                "p.rivet@email.com"
            ];

            List<string> expected =
            [
                "p.rivet@email.com"
            ];

            CopyFilter copyFilter = new CopyFilter();
            List<string> actual = copyFilter.Filter(to, copy);


            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
