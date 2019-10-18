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
        public void AppLaunches()
        {
            app.Screenshot("First screen.");
        }
    }
}
