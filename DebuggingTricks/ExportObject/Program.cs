using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common.StackOverflow;

namespace ExportObject
{
    class Program
    {
       
        static void Main(string[] args)
        {
            var featuredQuestions = StackOverflowClient.GetFeaturedQuestions();

            Debugger.Break();

            var analyzer = new QuestionsAnalyzer(featuredQuestions);

            var mostUsedTag = analyzer.GetMostUsedTag();

            MessageBox.Show("The most used tag is: " + mostUsedTag);

            if (analyzer.HasQuestionsWithTag("c#"))
            {
                var questionList = analyzer.FindQuestionsByTag("c#");

                MessageBox.Show("Selected questions: " + string.Join("\n", questionList.ToArray()));
            }
        }
    }
}
