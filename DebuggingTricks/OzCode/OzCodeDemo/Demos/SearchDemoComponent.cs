using System.ComponentModel.Composition;

namespace OzCodeDemo
{
    [Export(typeof(ISearchDemoComponent))]
    public class SearchDemoComponent : ISearchDemoComponent
    {
        public string Test 
        {
            get
            {
                return "Works!";
            }
        }
    }
}