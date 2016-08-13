using System;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows;

namespace OzCodeDemo
{
    [Export(typeof(IOzCodeDemo)), ExportMetadata("Demo", "Reveal")]
    public class RevealDemo : IOzCodeDemo
    {
        public void Start()
        {
            var assemblyWithManyTypes =
                (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                    orderby assembly.GetTypes().Length
                    select assembly).ToList();
            
           System.Diagnostics.Debugger.Break();

            //Want to see each assembly's file path in one view?
            //Select assemblyWithManyTypes and expand one instance,
            //check the star near the Location property.
            //Now open again the assemblyWithManyTypes collection.
            //Select All, Ctrl-C and pate it to notepad. Cool!!!
            
            //Try other properties, such as EntryPoint.
            //Do you have more than one assembly with Main()?

            //Reveal can surface inner property values as well, try this:
            //Hover over 'assemblyWithManyTypes' again and open one instance,
            //open the ManifestModule property and star ModuleVersionId.
            //Then star the ManifestModule property itself.
            //Now every time you look at the assemblyWithManyTypes collection, 
            //you'll see the inner ModuleVersionId property.


            var text = assemblyWithManyTypes.Aggregate(new StringBuilder(),
                (sb, assembly) =>
                {
                    sb.AppendFormat("{0}: {1} types)",
                        assembly.GetName().Name,
                        assembly.GetTypes().Length);
                    sb.AppendLine();
                    return sb;
                },
                sb => sb.ToString());

            App.Output.Lines.Add(text);

        }
    }
}