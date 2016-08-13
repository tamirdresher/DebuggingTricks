using System.ComponentModel.Composition;

namespace OzCodeDemo
{
    [Export(typeof(ISearchDemoComponent))]
    public class AnotherSearchDemoComponent : ISearchDemoComponent
    {
        public string Test
        {
            get
            {
                return "Also Works!";
            }
        }
    }
}