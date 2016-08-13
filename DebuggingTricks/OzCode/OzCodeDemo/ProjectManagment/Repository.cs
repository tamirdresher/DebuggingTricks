using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace OzCodeDemo.ProjectManagment
{
    public static class Repository
    {
        public static IEnumerable<Project> GetAllProjects()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Projects));
            using (StreamReader reader = new StreamReader(@"ProjectManagment\projects.xml"))
            {
                var deserialize = (Projects)serializer.Deserialize(reader);

                return deserialize.Project;
            }
        }
        public static IEnumerable<Employee> GetAllEmployees()
        {
            XmlSerializer serializer = new XmlSerializer(typeof (Employees));
            using (StreamReader reader = new StreamReader(@"ProjectManagment\employees.xml"))
            {
                var deserialize = (Employees)serializer.Deserialize(reader);

                return deserialize.Employee;
            }
        }
    }
}