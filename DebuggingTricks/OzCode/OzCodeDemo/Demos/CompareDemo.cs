using System.ComponentModel.Composition;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace OzCodeDemo
{
    [Export(typeof(IOzCodeDemo)), ExportMetadata("Demo", "Compare")]
    public class CompareDemo : IOzCodeDemo
    {
        public void Start()
        {
            var phoneBook = new PhoneBook();
            phoneBook.AddPerson(new Person
                                {
                                    FirstName = "Alon",
                                    LastName = "Fliess",
                                    Age = 44
                                });

            phoneBook.AddPerson(new Person
            {
                FirstName = "Pavel",
                LastName = "Yosifovich",
                Age = 42
            });


            using (var memoryStream = new MemoryStream())
            {
                System.Diagnostics.Debugger.Break();
                phoneBook.Save(memoryStream);
                memoryStream.Seek(0, SeekOrigin.Begin);

                var loadedPhoneBook = PhoneBook.CreateFromStream(memoryStream);

                //Use the compare to local variable and compare phonebook to loadedPhonebook
                //Check the "Show only differences"
                //Search deeper. Now goto _age and see why it was not serialized
                Trace.Assert(phoneBook == loadedPhoneBook, "Something went wrong!!!");
            }

            using (var memoryStream = new MemoryStream())
            {
               System.Diagnostics.Debugger.Break();
                int age = phoneBook.Persons.First(p => p.FirstName == "Alon").Age;
                phoneBook.Save(memoryStream);
                memoryStream.Seek(0, SeekOrigin.Begin);

                //Save the values of phoneBook
                phoneBook.Load(memoryStream);
                //Now compare the new value of phoneBook with the saved value.

                int ageAfterLoad = phoneBook.Persons.First(p => p.FirstName == "Alon").Age;

                Trace.Assert(age == ageAfterLoad, "Something went wrong!!!");
            }
            
        }
    }
}