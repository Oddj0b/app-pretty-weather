using System;
using System.IO;
using System.Linq;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace PrettyWeather.UITest
{
    public class AppInitializer
    {
        public static IApp StartApp(Platform platform)
        {
            // TODO: If the iOS or Android app being tested is included in the solution 
            // then open the Unit Tests window, right click Test Apps, select Add App Project
            // and select the app projects that should be tested.
            //
            // The iOS project should have the Xamarin.TestCloud.Agent NuGet package
            // installed. To start the Test Cloud Agent the following code should be
            // added to the FinishedLaunching method of the AppDelegate:
            //
            //    #if ENABLE_TEST_CLOUD
            //    Xamarin.Calabash.Start();
            //    #endif
            if (platform == Platform.Android)
            {
                return ConfigureApp
                    .Android
                    //.ApkFile ("../../../Droid/bin/Debug/PrettyWeather.Android.app")
                    .StartApp();
            }

            return ConfigureApp
                .iOS
                .AppBundle("../../../PrettyWeather/PrettyWeather.iOS/bin/iPhoneSimulator/Debug/PrettyWeather.iOS.app")
                .DeviceIdentifier("741282D0-8F88-4F2C-BF8B-5F0114279870")
                .StartApp();
        }
    }
}
