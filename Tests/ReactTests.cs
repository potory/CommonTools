using CommonTools.Extensions;
using NUnit.Framework;

namespace Tests
{
    public class ReactTests
    {
        [Test]
        public void Do_While_Finishes()
        {
            string str = ""
                .Do(x => x + "a")
                .While(x => x.Length < 5);

            Assert.AreEqual(5, str.Length);
            Assert.AreEqual("aaaaa", str);
        }

        [Test]
        public void Do_While_Out()
        {
            var a = 0;

            string str = ""
                .Do(x => x + "a")
                .While(x =>
                {
                    a++;
                    return a < 6;
                });

            Assert.AreEqual(5, str.Length);
            Assert.AreEqual("aaaaa", str);
        }

        [Test]
        public void Do_For_Steps_Finishes()
        {
            string str = ""
                .Do(x => x + "a")
                .For(5);

            Assert.AreEqual(5, str.Length);
            Assert.AreEqual("aaaaa", str);
        }

        [Test]
        public void Do_For_Start_End_Finishes()
        {
            string str = ""
                .Do(x => x + "a")
                .For(0, 5);

            Assert.AreEqual(5, str.Length);
            Assert.AreEqual("aaaaa", str);
        }

        [Test]
        public void Do_For_Start_End_Step_Finishes()
        {
            string str = ""
                .Do(x => x + "a")
                .For(0, 10, 2);

            Assert.AreEqual(5, str.Length);
            Assert.AreEqual("aaaaa", str);
        }

        [Test]
        public void Do_If_Finishes_WhenTrue()
        {
            string a = string.Empty.Do(x => x + "a").If(true);

            Assert.AreEqual(1, a.Length);
            Assert.AreEqual("a", a);
        }

        [Test]
        public void Do_If_Finishes_WhenFalse()
        {
            string a = string.Empty.Do(x => x + "a").If(false);

            Assert.AreEqual(0, a.Length);
            Assert.AreEqual(string.Empty, a);
        }

        [Test]
        public void Do_If_Finishes_WhenCondition()
        {
            static bool IsS()
            {
                return true;
            }

            string a = string.Empty.Do(x => x + "a").If(_ => IsS());

            Assert.AreEqual(1, a.Length);
            Assert.AreEqual("a", a);
        }
    }
}