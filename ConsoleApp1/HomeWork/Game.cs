using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.March20
{
    public class Game
    {
        public Dictionary<string, string[]> questionsAnswers;
        public int questionIndex;
        public bool[] hintIsUsed;

        public Game(Dictionary<string, string[]> questionAnswers)
        {
            this.questionsAnswers = questionAnswers;
            questionIndex = 0;
            hintIsUsed = new bool[3];
        }

        public virtual string NextQuestion()
        {
            string question = questionsAnswers.ElementAt(questionIndex).Key;
            questionIndex++;
            return question;
        }

        public string[] GetAnswers()
        {
            string[] answer = questionsAnswers.ElementAt(questionIndex).Value;
            return answer;
        }

        public void StartGame()
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