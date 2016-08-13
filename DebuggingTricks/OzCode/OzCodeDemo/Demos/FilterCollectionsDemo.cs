using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows;

namespace OzCodeDemo
{
    [Export(typeof (IOzCodeDemo)), ExportMetadata("Demo", "FilterCollections")]
    public class FilterCollectionsDemo : IOzCodeDemo
    {
        private static int _nextName;
        public void Start()
        {
            var commonAmericanNames = new List<Person>();
            AddPersons(commonAmericanNames, 10);
            GC.Collect();
            AddPersons(commonAmericanNames, 10);
            GC.Collect();
            AddPersons(commonAmericanNames, 10);

           System.Diagnostics.Debugger.Break();

            //Take commonAmericanNames and try the following filters (Edit Filter):
            //GC.GetGeneration([obj]) == 0
            //GC.GetGeneration([obj]) == 1
            //GC.GetGeneration([obj]) == 2
            //Cool, isn't it!
            //Now try these filters:
            //[obj]._age > 20
            //[obj].LastName == "Taylor"
            //[obj].FirstName == "Elizabeth"

            var text = commonAmericanNames.Aggregate(new StringBuilder(),
                (sb, person) =>
                {
                    sb.AppendFormat("{0} {1}",
                        person.FirstName,
                        person.LastName);
                    sb.AppendLine();
                    return sb;
                },
                sb => sb.ToString());

				App.Output.Lines.Add(text);
        }

        private void AddPersons(List<Person> namesList, int amount)
        {
            var surnames = new[]
                           {
                               "Smith", "Anderson", "Johnson", "Davis", "Miller", "Wilson",
                               "Brown", "Moore", "Taylor", "Lopez","Lee"
                           };
            var firstName = new[]
                           {
                               "James", "John", "Robert", "Michael", "David", "Mary",
                               "Linda", "Barbara", "Elizabeth", "Jennifer", "Daniel",
                               "Mark", "Sarah"
                           };
            
            for (int i = 0; i < amount; i++, _nextName++)
            {
                var p = new Person
                        {
                            Age = 20 + _nextName,
                            FirstName = firstName[_nextName % firstName.Length],
                            LastName = surnames[_nextName % surnames.Length]
                        };
                namesList.Add(p);
            }
        }
    }
}