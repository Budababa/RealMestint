using RealMestint.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealMestint.StateRepresentations
{
    public class HorseGameOperator : Operator
    {
        public int X { get; set; }
        public int Y { get; set; }
        public char Player { get; set; }

        public HorseGameOperator(int x, int y, char player)
        {
            X = x;
            Y = y;
            Player = player;
        }

        public HorseGameOperator(char player)
        {
            Player = player;
        }

        public State Apply(State state)
        {
            if (state == null || !(state is HorseGameState))
            {
                throw new Exception("Not HorseyState");
            }

            HorseGameState newState = state.Clone() as HorseGameState;
            ChangeToInvalid(newState as HorseGameState);

            newState.Board[Y, X] = Player;

            newState.ChangePlayer();

            return newState;
        }

        private void ChangeToInvalid(HorseGameState state)
        {
            int x = 0, y = 0;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (state.Board[j, i] == state.CurrentPlayer)
                    {
                        y = j;
                        x = i;
                        break;
                    }
                }
            }
            state.Board[y, x] = HorseGameState.INVALID;
        }

        public bool IsApplicable(State state)
        {
            if (state == null || !(state is HorseGameState))
            {
                return false;
            }
            HorseGameState horseGameState = state as HorseGameState;
            List<int[]> ints = AvailableSpaces(horseGameState);
            bool canMove = false;
            foreach (var item in ints)
            {
                if (item[0] == Y && item[1] == X)
                {
                    canMove = true;
                }
            }
            return canMove && horseGameState.CurrentPlayer == Player;
        }

        public List<int[]> AvailableSpaces(HorseGameState state)
        {
            int x = 0, y = 0;
            List<int[]> availableCoords = new();
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (state.Board[j, i] == state.CurrentPlayer)
                    {
                        y = i;
                        x = j;
                        break;
                    }
                }
            }

            for (int i = 0; i < 2; i++)
            {
                try
                {
                    if (state.Board[x + (2 * i) - 1, y - 2] == HorseGameState.BLANK)
                    {
                        int[] coord = [x + (2 * i) - 1, y - 2];
                        availableCoords.Add(coord);
                    }
                }
                catch (Exception)
                {
                }
            }
            for (int i = 0; i < 2; i++)
            {
                try
                {
                    if (state.Board[x + 2, y + (2 * i) - 1] == HorseGameState.BLANK)
                    {
                        int[] coord = [x + 2, y + (2 * i) - 1];
                        availableCoords.Add(coord);
                    }
                }
                catch (Exception)
                {
                }
            }
            for (int i = 0; i < 2; i++)
            {
                try
                {
                    if (state.Board[x + (2 * i) - 1, y + 2] == HorseGameState.BLANK)
                    {
                        int[] coord = [x + (2 * i) - 1, y + 2];
                        availableCoords.Add(coord);
                    }
                }
                catch (Exception)
                {
                }
            }
            for (int i = 0; i < 2; i++)
            {
                try
                {
                    if (state.Board[x - 2, y + (2 * i) - 1] == HorseGameState.BLANK)
                    {
                        int[] coord = [x - 2, y + (2 * i) - 1];
                        availableCoords.Add(coord);
                    }
                }
                catch (Exception)
                {
                }
            }

            return availableCoords;
        }
    }
}
