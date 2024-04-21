using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace Test.March20
{
    public class March20
    {
        public void Run()
        {

            Dictionary<string, string[]> questionsAnswers = new Dictionary<string, string[]>()
                {
                     {"Question 1", new string[]{ "A", "B", "C", "D" } },
                     { "Question 2", new string[]{ "A", "B", "C", "D" } },
                     { "Question 3", new string[]{ "A", "B", "C", "D" } },
                     { "Question 4", new string[]{ "A", "B", "C", "D" } },
                     { "Question 5", new string[]{ "A", "B", "C", "D" } },
                     { "Question 6", new string[]{ "A", "B", "C", "D" } },
                     { "Question 7", new string[]{ "A", "B", "C", "D" } },
                     { "Question 8", new string[]{ "A", "B", "C", "D" } },
                     { "Question 9", new string[]{ "A", "B", "C", "D" } },
                     { "Question 10", new string[]{ "A", "B", "C", "D" } }
                };

            MainClass game = new MainClass(questionsAnswers);
            game.StartGame1();
        }
    }
}
