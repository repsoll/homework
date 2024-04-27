using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Test.March20
{
    public class MainClass : Game
    {
        public MainClass(Dictionary<string, string[]> questionsAnswers) : base(questionsAnswers) { }

        public override string NextQuestion()
        {
            string[] answer = GetAnswers();
            string question = base.NextQuestion();
            Console.WriteLine(question);
            Console.WriteLine(answer[0]);
            Console.WriteLine(answer[1]);
            Console.WriteLine(answer[2]);
            Console.WriteLine(answer[3]);
            return question;
        }

        public void StartGame()
        {
            GameRules();
            bool isGameFinished = false;

            do
            {
                var question = NextQuestion();
                Console.WriteLine(question);
                bool userLost = AskQuestion(question);

                if (!userLost)
                {
                    if (QuestionIndex == QuestionAndAnswers.Count)
                    {
                        Console.WriteLine("Congratulations! You won!");
                        isGameFinished = true;
                    }
                    else
                    {
                        Console.WriteLine("Do you want to continue the game? (Y/N)");
                        string continueGame = Console.ReadLine();
                        if (continueGame.ToUpper() != "Y")
                        {
                            isGameFinished = true;
                        }
                    }
                }
                else
                {
                    isGameFinished = true;
                }


            } while (!isGameFinished);
        }

        private bool AskQuestion(string question)
        {
            Dictionary<string, string> rightAnswer = new Dictionary<string, string>()
            {
                {Const.Question1, "D"},
                {Const.Question2, "B"},
                {Const.Question3, "B"},
                {Const.Question4, "A"},
                {Const.Question5, "A"},
                {Const.Question6, "C"},
                {Const.Question7, "D"},
                {Const.Question8, "B"},
                {Const.Question9, "C"},
                {Const.Question10, "B"}
            };

            Console.WriteLine("Do you want to use a hint? (Y/N)");
            string userHint = Console.ReadLine();

            if (userHint.ToUpper() == "Y")
            {
                UseHint();
            }

            Console.WriteLine("Enter your answer (A/B/C/D): ");
            string userAnswer = Console.ReadLine().ToUpper();

            bool isCorrect = userAnswer == rightAnswer[question];


            if (isCorrect)
            {
                Console.WriteLine("Correct! You advance to the next question.");
            }
            else
            {
                Console.WriteLine("Incorrect! The correct answer was: " + rightAnswer[question]);
                Console.WriteLine("Game over.");
            }
            return !isCorrect;
        }

        private void UseHint()
        {
            Console.WriteLine("Choose a hint:");
            Console.WriteLine("1) 50/50");
            Console.WriteLine("2) Phone a Friend");
            Console.WriteLine("3) Ask the Audience");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    if (!HintUsed[0])
                    {
                        Console.WriteLine("You choose 50/50 hint.We remove 2 incorrect answers");
                        FiftyFiftyHint();
                        HintUsed[0] = true;
                    }
                    else
                    {
                        Console.WriteLine("50/50 hint already used.");
                    }
                    break;
                case 2:
                    if (!HintUsed[1])
                    {
                        Console.WriteLine("You choose Phone a Friend hint.");
                        CallFriendHint();
                        HintUsed[1] = true;
                    }
                    else
                    {
                        Console.WriteLine("Phone a Friend hint already used.");
                    }
                    break;
                case 3:
                    if (!HintUsed[2])
                    {
                        Console.WriteLine("You choose Ask the Audience hint logic.");
                        AudienceHint();
                        HintUsed[2] = true;
                    }
                    else
                    {
                        Console.WriteLine("Ask the Audience hint already used.");
                    }
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }

        private void FiftyFiftyHint()
        {
            string[] answer = GetAnswers();
            string correctAnswer = answer[0];

            List<string> incorrectAnswers = answer.Skip(1).Where(answ => answ != correctAnswer).ToList();
            incorrectAnswers.RemoveAt(0);
            incorrectAnswers.RemoveAt(0);

            Console.WriteLine("50/50 hint removed two incorrect answers:");
            foreach (var answers in incorrectAnswers)
            {
                Console.WriteLine(answers);
            }
        }

        private void CallFriendHint()
        {
            string[] answer = GetAnswers();
            Random rnd = new Random();
            int index = rnd.Next(answer.Length);
            Console.WriteLine("Your friend suggests answer: " + answer[index]);
        }

        private void AudienceHint()
        {
            string[] answer = GetAnswers();
            string correctAnswer = answer[0];
            Random rnd = new Random();
            int[] votes = new int[4];

            votes[0] = rnd.Next(70, 100);
            int remainingPercentage = 100 - votes[0];
            int remainingPercentagePerAnswer = remainingPercentage / 3;

            for (int i = 1; i < 4; i++)
            {
                votes[i] = rnd.Next(remainingPercentagePerAnswer - 5, remainingPercentagePerAnswer + 6);
                remainingPercentage -= votes[i];
            }

            for (int i = 0; i < votes.Length; i++)
            {
                int temp = votes[i];
                int randomIndex = rnd.Next(i, votes.Length);
                votes[i] = votes[randomIndex];
                votes[randomIndex] = temp;
            }

            Console.WriteLine("Audience votes:");
            for (int i = 0; i < answer.Length; i++)
            {
                Console.WriteLine(answer[i] + ": " + votes[i] + "%");
            }
        }
    }
}