using System.ComponentModel.Composition;
using OzCodeDemo.ObjectId;

namespace OzCodeDemo
{
    [Export(typeof(IOzCodeDemo)), ExportMetadata("Demo", "ObjectID")]
    public class ObjectIdDemo : IOzCodeDemo
    {
        public void Start()
        {
            var studentsWindow = new StudentsWindow();
            studentsWindow.ShowDialog();
        }
    }
}