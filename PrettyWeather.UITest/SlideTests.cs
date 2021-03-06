﻿using System;
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
    public class SlideTests
    {
        IApp app;
        Platform platform;

        public SlideTests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        [Category("Shallow")]
        public void AppLaunches()
        {
            app.Screenshot("First screen.");
            //app.Repl();
        }
        [Test]
        [Category("Critical")]
        public void SeeMaxTemp()
        {
            app.Screenshot("First screen");
            app.WaitForElement(c => c.Marked("SEATTLE"));
            app.SwipeRightToLeft(c => c.Marked("Wind Speed"));
            app.WaitForElement(c => c.Marked("Max Temp"));
            app.Screenshot("Swiped to Max Temp");
        }
    
    }
   
}
