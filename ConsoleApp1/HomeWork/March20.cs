using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
                 {Const.Question1, new string[]{ "A)Earth", "B)Venus", "C)Mars", "D)Jupiter" } }, // Jupiter
                 {Const.Question2, new string[]{ "A)France", "B)Italy", "C)Spain", "D)Greece" } },
                 {Const.Question3, new string[]{ "A)Amazon", "B)Nile", "C)Yangtze", "D)Mississippi" } },//Nile
                 {Const.Question4, new string[]{ "A)H2O", "B)Wa", "C)W", "D)H2" } },
                 {Const.Question5, new string[]{ "A)Canberra", "B)Sydney", "C)Melbourne", "D)Brisbane" } },//Canberra
                 {Const.Question6, new string[]{ "A) Vincent van Gogh", "B)Pablo Picasso", "C)Leonardo da Vinci", "D)Michelangelo" } },//Leonardo da Vinci
                 {Const.Question7, new string[]{ "A)Earth", "B)Mercury", "C)Venus", "D)Mars " } },//Mars
                 {Const.Question8, new string[]{ "A)Mount Kilimanjaro", "B)Mount Everest", "C)Mount Fuji", "D)Mount McKinley" } },
                 {Const.Question9, new string[]{ "A)G", "B)AG", "C)Au", "D)Fe" } },//Au
                 {Const.Question10, new string[]{ "A)Oxygen", "B)Carbon", "C)Nitrogen", "D)Chlorine" } } //Carbon
            };

            MainClass game = new MainClass(questionsAnswers);
            game.StartGame();
        }
    }
}
