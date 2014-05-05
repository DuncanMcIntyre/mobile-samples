using Xamarin.UITest.iOS;
using System.Linq;
using System;
using Xamarin.UITest.Queries;

namespace Tasky.iOS.Tests.Page
{
    public class TaskyProPage : iOSPage 
    {
        static readonly Func<AppQuery, AppQuery> AddButton = q => q.Raw("view marked:'Add'");

        public TaskyProPage(iOSApp app): base(app)
        {
        }

        public override Func<AppQuery, AppQuery> Trait { get {return AddButton; }}

        public bool HasTask(Tasky.BL.Task task)
        {
            AssertCurrentPage();

            var hasTask = App.Query(LabelWithText(task.Name)).Any() && App.Query(LabelWithText(task.Notes)).Any();

            return hasTask;
        }

        static Func<AppQuery, AppQuery> LabelWithText(string text)
        {
            var calabashSelector = string.Format("label marked:'{0}'", text);
            return q => q.Raw(calabashSelector);
        }
        public void SelectTask(string taskName)
        {
            
        }

        public void DeleteTask(string taskName)
        {
        }

        public void TapAddTaskButton()
        {
            App.Tap(AddButton);
        }
    }
    
}
