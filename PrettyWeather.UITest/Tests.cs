using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using PrettyWeather.UITest;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace Prettyeather.UITest
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class Tests
    {
        IApp app;
        Platform platform;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        [Category("Critical")]
        public void AppLaunches()
        {
            app.Screenshot("First screen.");
            //app.Repl();
        }

        [Test]
        [Category("Shallow")]
        public void FindUILabels()
        {
            app.Screenshot("See UILabels");
            AppResult[] results = app.Query(c => c.Class("UILabel").Text("Sunny"));
            Assert.IsTrue(results.Any(), "It's not sunny");
        }

        private string eq1;
        private string eq2;
        private string neq;

        [Test]
        public void TestEquality()
        {
            Assert.AreEqual(eq1, eq2);
            if (eq1 != null && eq2 != null)
                Assert.AreEqual(eq1.GetHashCode(), eq2.GetHashCode());
        }

        [Test]
        public void TestInequality()
        {
            Assert.AreNotEqual(eq1, neq);
            if (eq1 != null && neq != null)
                Assert.AreNotEqual(eq1.GetHashCode(), neq.GetHashCode());
        }
    }
   
}
