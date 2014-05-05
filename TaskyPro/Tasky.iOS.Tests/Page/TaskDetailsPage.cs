using Xamarin.UITest.iOS;
using System;
using Xamarin.UITest.Queries;
using System.Threading.Tasks;
using System.Threading;

namespace Tasky.iOS.Tests.Page
{
    public class TaskDetailsPage: iOSPage
    {
        static readonly Func<AppQuery, AppQuery> SaveButton = c => c.Raw("view marked:'Save'");
        static readonly Func<AppQuery, AppQuery> TaskNameTextField = c => c.Raw("textField index:0");
        static readonly Func<AppQuery, AppQuery> TaskNotesTextField = c => c.Raw("textField placeholder:'other task info'");

        public TaskDetailsPage(iOSApp app) : base(app)
        {
        }

        public override Func<AppQuery, AppQuery> Trait { get { return SaveButton; } }

        public Tasky.BL.Task EnterNewTask(string name, string notes)
        {
            var task = new Tasky.BL.Task
            {
                Name = name,
                Notes = notes,
                Done = false
            };

            App.EnterText(TaskNotesTextField, notes);
            App.EnterText(TaskNameTextField, name);
            App.Tap(SaveButton);

            return task;
        }
    }
}
