using System;
using Xamarin.UITest.Queries;

namespace Tasky.iOS.Tests
{
    public interface IHaveTrait
    {
        Func<AppQuery, AppQuery> Trait {get; }
    }
    
}
