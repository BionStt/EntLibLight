namespace Infrastructure.Tests
{
    using System;
    using System.Linq;

    using EntLibExtensions.Infrastructure;

    using Moq;

    using NUnit.Framework;

    [TestFixture]
    public class ApplicationTests
    {
        [Test]
        public void ApplicationCtor()
        {
            Application app = new Application(null);
            Assert.AreEqual(0, app.Args.Length);

            app = new Application(new string[] { "qwe1", "qwe2" });
            Assert.AreEqual("qwe1", app.Args.ElementAt(0));
            Assert.AreEqual("qwe2", app.Args.ElementAt(1));
        }

        [Test]
        public void RunApplication()
        {
            string[] args = { "a1", "a2" };
            Application app = new Application(args);
            int anyState = 1;
            bool a1 = false;
            bool a2 = false;
            
            app.RunApplication(
                strings =>
                    {
                        a1 = true;
                        Assert.AreSame(args, strings);
                        return anyState;
                    },
                (strings, i) =>
                    {
                        a2 = true;
                        Assert.AreSame(args, strings);
                        Assert.AreEqual(anyState, i);
                    });

            Assert.AreEqual(true, a1);
            Assert.AreEqual(true, a2);
        }

        [Test]
        public void RunApplicationExceptions()
        {
            Exception e1 = new Exception("be");
            Exception e2 = new Exception("re");

            Application app = new Application(null);
            Exception res = Assert.Throws<Exception>(
                () => app.RunApplication<int>(
                    s =>
                        {
                            throw e1;
                        },
                    (strings, i) =>
                        {
                            throw e2;
                        }));

            Assert.AreSame(e1, res);

            res = Assert.Throws<Exception>(
                () => app.RunApplication<int>(
                    s => 1,
                    (strings, i) =>
                        {
                            throw e2;
                        }));

            Assert.AreSame(e2, res);
        }
    }
}