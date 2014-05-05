using System;
using NUnit.Framework;
using Tasky.iOS.Tests.Page;

namespace Tasky.iOS.Tests
{
    [TestFixture]
    public class AddTaskTest: iOSTest
    {
        TaskyProPage _taskyProPage;

        [SetUp]
        public  override void SetUp()
        {
            base.SetUp();
            _taskyProPage = new TaskyProPage(App);
        }

        [Test]
        public void AddTask()
        {
            var editpage = _taskyProPage.NavigateTo<TaskDetailsPage>(() => _taskyProPage.TapAddTaskButton());

            var task = editpage.EnterNewTask("New Task", "New Notes");

            App.WaitForElement(_taskyProPage.Trait, timeout: new TimeSpan(0, 0, 20));

            Assert.IsTrue(_taskyProPage.HasTask(task));
        }
    }
}
