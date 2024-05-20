using RealMestint.Interface;
using RealMestint.StateRepresentations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealMestint.StateRepresentations
{
    public enum Difficulty
    {
        RND
    }

    public class HorseGamePlayer
    {
        public Solver Solver { get; set; }

        public HorseGamePlayer(Difficulty difficulty)
        {
            switch (difficulty)
            {
                case Difficulty.RND:
                    {
                        Solver = new TrialAndError(new HorseGameOperatorGenerator());
                        break;
                    }
                default:
                    {
                        throw new ArgumentOutOfRangeException("The selected difficulty does not exsist!");
                    }
            }
        }

        public void Play()
        {
            State state = new HorseGameState();
            Console.WriteLine(state);

            while (state.GetStatus() == Status.PLAYING)
            {
                Operator o;
                do
                {
                    int x = 0;
                    do
                    {
                        Console.WriteLine("X: ");
                    } while (!int.TryParse(Console.ReadLine(), out x));

                    int y = 0;
                    do
                    {
                        Console.WriteLine("Y: ");
                    } while (!int.TryParse(Console.ReadLine(), out y));
                    o = new HorseGameOperator(x - 1, y - 1, HorseGameState.PLAYER1);
                } while (!o.IsApplicable(state));

                state = o.Apply(state);
                Console.WriteLine(state);
                if (CheckStatus(state))
                {
                    break;
                }
                state = Solver.NextMove(state);
                Console.WriteLine(state);
                if (CheckStatus(state))
                {
                    break;
                }
            }
        }

        private bool CheckStatus(State state)
        {
            if (state.GetStatus() == Status.PLAYER1WINS)
            {
                Console.WriteLine("Player 1 won");
                return true;
            }
            if (state.GetStatus() == Status.PLAYER2WINS)
            {
                Console.WriteLine("Player 2 won");
                return true;
            }
            return false;
        }
    }
}
