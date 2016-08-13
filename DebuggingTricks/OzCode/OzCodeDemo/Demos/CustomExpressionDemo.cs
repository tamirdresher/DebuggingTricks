using System;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows;

// ReSharper disable PossibleNullReferenceException

namespace OzCodeDemo
{
    [Export(typeof (IOzCodeDemo)), ExportMetadata("Demo", "CustomExpression")]
    public class CustomExpressionDemo : IOzCodeDemo
    {
        public void Start()
        {
            var functionsWithManyParameters =
                (from assembly in AppDomain.CurrentDomain.GetAssemblies().Take(2)
                    from type in assembly.GetTypes()
                    from method in
                        type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance |
                                        BindingFlags.Static)
                 orderby method.GetParameters().Length descending 
                 group method by method.Name into g
                 select g.First()).ToList();

           System.Diagnostics.Debugger.Break();
            //Try to watch the result list. Can you see the number of parameters of each function?
            //Open functionsWithManyParameters collection, open the first element ([0]) 
            //and add the following custom expression:
            //[obj].DeclaringType.Assembly.FullName.Split(',')[0] + '.' + [obj].Name + "  #Params: " + [obj].GetParameters().Count() //FullName
            //Flag the custom expression with the star option (Reveal) and close the [0] instance
            //Notice the custom name, FullName: that you've added with the comments at the end of the expression.

            var text = functionsWithManyParameters.Aggregate(new StringBuilder(), 
                (sb, mi) =>
                {
                    sb.AppendFormat("{0}.{1}: ({2})",

                    mi.DeclaringType.FullName.Replace('+', '.'),
                    mi.Name,
                    mi.GetParameters().Length);
                    sb.AppendLine();
                    return sb;
                },
                sb => sb.ToString());

				App.Output.Lines.Add(text);

        }
    }
}