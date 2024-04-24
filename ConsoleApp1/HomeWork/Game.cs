using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.March20
{
    public class Game
    {
        public Dictionary<string, string[]> QuestionAndAnswers;
        public int QuestionIndex;
        public bool[] HintUsed;

        public Game(Dictionary<string, string[]> questionAnswers)
        {
            this.QuestionAndAnswers = questionAnswers;
            QuestionIndex = 0;
            HintUsed = new bool[3];
        }

        public virtual string NextQuestion()
        {
            string question = QuestionAndAnswers.ElementAt(QuestionIndex).Key;
            QuestionIndex++;
            return question;
        }

        public string[] GetAnswers()
        {
            string[] answer = QuestionAndAnswers.ElementAt(QuestionIndex).Value;
            return answer;
        }

        public void GameRules()
        {
            Console.WriteLine("Welcome to Who Wants to Be a Millionaire!");
            Console.WriteLine("Rules:");
            Console.WriteLine(" - You will be asked 10 questions.");
            Console.WriteLine(" - You have 3 hints: 50/50, Phone a Friend, and Ask the Audience.");
            Console.WriteLine(" - If you answer incorrectly, you lose the game.");
            Console.WriteLine(" - You have guaranteed prizes at questions 3, 6, and 9.");
            Console.WriteLine("Let's begin!\n");
        }
    }
}