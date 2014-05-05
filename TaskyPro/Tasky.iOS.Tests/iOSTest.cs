using NUnit.Framework;

using Xamarin.UITest;
using Xamarin.UITest.iOS;

namespace Tasky.iOS.Tests
{

    public abstract class iOSTest
    {
        protected iOSApp App { get; set; }

        public virtual void SetUp()
        {
            App = ConfigureApp
                .iOS
                .AppBundle("/Users/tom/work/xamarin/code/mobile-samples/TaskyPro/Tasky.iOS/bin/iPhoneSimulator/Debug/TaskyiOS.app")
                .StartApp();
        }
    }
    
}
