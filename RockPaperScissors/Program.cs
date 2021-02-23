using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors
{
    class Program
    {
        static void Main(string[] args)
        {
            StartGame();
        }

        private static void StartGame()
        {
            int numRounds = GetRounds();
            if (numRounds >= 1 && numRounds <= 10)
            {
                PlayGame(numRounds);
            }
            else
            {
                Console.WriteLine("Number is out of bounds. Press any key to exit");
                Console.ReadKey();
            }
        }

        private static int GetRounds()
        {
            int numRoundsToPlay;

            Console.WriteLine("How many rounds of rock, paper, scissors would you like to play? (1-10)");
            string roundsToPlay = Console.ReadLine();

            if (int.TryParse(roundsToPlay, out numRoundsToPlay))
            {
                return numRoundsToPlay;
            }
            else
            {
                Console.WriteLine("That is not a valid input");
                GetRounds();
                return numRoundsToPlay;
                
            }

        }

        private static void PlayGame(int numRounds)
        {
            int numSelection;
            int computerSelection;
            int wins = 0;
            int losses = 0;
            int ties = 0;
            string selectionString;
            string computerString;
            Random rng = new Random();
            int i = 0;

            while (i < numRounds)
            {
                computerSelection = rng.Next(3) + 1;
                Console.WriteLine("Enter a number to make your selection. \n1. Rock\n2. Paper\n3. Scissors");
                string selection = Console.ReadLine();

                if (int.TryParse(selection, out numSelection))
                {
                    
                }
                else
                {
                    Console.WriteLine("Invalid input, please try again");
                    continue;
                }

                if (numSelection < 1 || numSelection > 3)
                {
                    Console.WriteLine("Please enter a selection in range (1-3)");
                    continue;
                }
                
                switch (computerSelection)
                {
                    case 1:
                        computerString = "rock";
                        break;
                    case 2:
                        computerString = "paper";
                        break;
                    case 3:
                        computerString = "scissors";
                        break;
                    default:
                        computerString = "";
                        break;
                }

                switch (numSelection)
                {
                    case 1:
                        selectionString = "rock";
                        break;
                    case 2:
                        selectionString = "paper";
                        break;
                    case 3:
                        selectionString = "scissors";
                        break;
                    default:
                        selectionString = "";
                        break;
                }


                if (numSelection == computerSelection)
                {
                    Console.WriteLine(String.Format("This round has resulted in a draw. You and the computer both chose {0}", computerString));
                    ties++;
                    i++;
                    printRounds(wins, losses, ties);
                    continue;
                }

                switch (numSelection)
                {
                    case 1:
                        if (computerSelection == 2)
                        {
                            printLoss(selectionString, computerString);
                            losses++;
                            i++;
                            break;
                        } 
                        else
                        {
                            printWin(selectionString, computerString);
                            wins++;
                            i++;
                            break;
                        }
                    case 2:
                        if (computerSelection == 1)
                        {
                            printLoss(selectionString, computerString);
                            losses++;
                            i++;
                            break;
                        }
                        else
                        {
                            printWin(selectionString, computerString);
                            wins++;
                            i++;
                            break;
                        }
                    case 3:
                        if (computerSelection == 1)
                        {
                            printLoss(selectionString, computerString);
                            losses++;
                            i++;
                            break;
                        }
                        else
                        {
                            printWin(selectionString, computerString);
                            wins++;
                            i++;
                            break;
                        }
                    default:
                        break;
                }
                printRounds(wins, losses, ties);

                if (i  == numRounds)
                {
                    Console.WriteLine("All rounds finished, do you want to play again? \n1. Yes\n2. No");
                    string playAgain = Console.ReadLine();
                    if (playAgain == "1")
                    {
                        StartGame();
                    }
                }

            }
        }

        private static void printRounds(int wins, int losses, int ties)
        {
            Console.WriteLine(String.Format("Wins: {0} Losses: {1} Ties: {2} \n", wins, losses, ties));
        }

        private static void printWin(string selectionString, string computerString)
        {
            Console.WriteLine(string.Format("You win the round! You selected {0}, and the computer selected {1}.", selectionString, computerString));
        }

        private static void printLoss(string selectionString, string computerString)
        {
            Console.WriteLine(string.Format("You Lost the round! You selected {0}, and the computer selected {1}.", selectionString, computerString));
        }
    }
}
