using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.March20
{
    public class MainClass : Game
    {
        public MainClass(Dictionary<string, string[]> questionsAnswers) : base(questionsAnswers) { }

        public override string NextQuestion()
        {
            string question = base.NextQuestion();
            string[] answer = GetAnswers();
            Console.WriteLine(question);
            Console.WriteLine("A) " + answer[0]);
            Console.WriteLine("B) " + answer[1]);
            Console.WriteLine("C) " + answer[2]);
            Console.WriteLine("D) " + answer[3]);
            return question;
        }

        public void StartGame1()
        {
            StartGame();
            bool isGameFinished = false;

            do
            {

                var question = NextQuestion();
                Console.WriteLine(question);
                bool userLost = AskingQuestions(question);

                if (!userLost)
                {
                    if (questionIndex == questionsAnswers.Count)
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

        private bool AskingQuestions(string question)
        {
            Console.WriteLine("Do you want to use a hint? (Y/N)");
            string userHint = Console.ReadLine();

            if (userHint.ToUpper() == "Y")
            {
                UseHint();
            }

            Console.WriteLine("Enter your answer (A/B/C/D): ");
            string userAnswer = Console.ReadLine().ToUpper();

            string[] answers = questionsAnswers[question];
            string rightAnswer = answers[0]; 

            bool isCorrect = userAnswer == rightAnswer;

            if (isCorrect)
            {
                Console.WriteLine("Correct! You advance to the next question.");
            }
            else
            {
                Console.WriteLine("Incorrect! The correct answer was: " + rightAnswer);
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
                    if (!hintIsUsed[0])
                    {
                        Console.WriteLine("You choose 50/50 hint.We remove 2 incorrect answers");
                        Hint1();
                        hintIsUsed[0] = true;
                    }
                    else
                    {
                        Console.WriteLine("50/50 hint already used.");
                    }
                    break;
                case 2:
                    if (!hintIsUsed[1])
                    {
                        Console.WriteLine("You choose Phone a Friend hint.");
                        Hint2();
                        hintIsUsed[1] = true;
                    }
                    else
                    {
                        Console.WriteLine("Phone a Friend hint already used.");
                    }
                    break;
                case 3:
                    if (!hintIsUsed[2])
                    {
                        Console.WriteLine("You choose Ask the Audience hint logic.");
                        Hint3();
                        hintIsUsed[2] = true;
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

        private void Hint1()
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

        private void Hint2()
        {
            string[] answer = GetAnswers();
            Random rnd = new Random();
            int index = rnd.Next(answer.Length);
            Console.WriteLine("Your friend suggests answer: " + answer[index]);
        }

        private void Hint3()
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