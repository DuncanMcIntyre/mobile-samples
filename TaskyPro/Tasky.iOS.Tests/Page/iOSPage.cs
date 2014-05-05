using Xamarin.UITest.iOS;
using System;
using System.Linq;
using Xamarin.UITest.Queries;

namespace Tasky.iOS.Tests.Page
{
    /// <summary>
    /// Base class for all iOS page classes
    /// </summary>
    public abstract class iOSPage: IHaveTrait
    {
        protected iOSPage(iOSApp app)
        {
            App = app;
        }

        protected iOSApp App { get; set; }

        public abstract Func<AppQuery, AppQuery>  Trait { get; }

        public virtual T NavigateTo<T>(Action navigation) where T: iOSPage
        {
            var newpage = (iOSPage)Activator.CreateInstance(typeof(T), App);

            navigation();

            App.WaitForElement(newpage.Trait);
            return (T)newpage;
        }

        public void AssertCurrentPage()
        {
            if (App.Query(Trait).Any() )
            {
                throw new Exception("Could not find the trait " + Trait + " - you're on the wrong page.");
            }
        }
    }
}
