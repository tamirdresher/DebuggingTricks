using System.IO;
using System.Reflection;
using Newtonsoft.Json;

namespace Common.StackOverflow
{
    public class StackOverflowClient
    {
        public static Rootobject GetFeaturedQuestions()
        {
            var assembly = Assembly.GetExecutingAssembly();
            using (var stream = assembly.GetManifestResourceStream("Common.json.SO_Featured.json"))
            using (var reader = new StreamReader(stream))
            {
                var json = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<Rootobject>(json);
            }
        }
    }
}