using NUnit.Framework;

using Xamarin.UITest;
using Xamarin.UITest.iOS;
using Tasky.iOS.Tests.Page;

namespace Tasky.iOS.Tests
{

    [TestFixture]
    public class Test
    {
        [SetUp]
        public void SetUp()
        {
            _app = ConfigureApp
                .iOS
                .AppBundle("/Users/tom/work/xamarin/code/mobile-samples/TaskyPro/Tasky.iOS/bin/iPhoneSimulator/Debug/TaskyiOS.app")
                .StartApp();
        }

        iOSApp _app;

        [Test]
        public void CanCreateNewNote()
        {
            _app.WaitForElement(c => c.Marked("Add"));
            _app.Tap(c => c.Marked("Add"));
            _app.WaitForElement(c => c.Marked("Save"));

            //            Thread.Sleep(2000);  // <---- DANGER WILL ROBINSON!

            _app.Tap(c => c.Marked("Name"));
            _app.EnterText("My new task");
            _app.Tap(c => c.Marked("Save"));
        }
    }
}
