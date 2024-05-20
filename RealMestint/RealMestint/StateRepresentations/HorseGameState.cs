using RealMestint.Interface;
using RealMestint.StateRepresentations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealMestint.StateRepresentations
{
    public class HorseGameState : State
    {
        public const char BLANK = ' ';
        public const char PLAYER1 = 'P';
        public const char PLAYER2 = 'C';
        public const char INVALID = 'X';
        public char[,] Board { get; set; }

        public HorseGameState()
        {
            Board = new char[8, 8]
            {
                {BLANK, BLANK, BLANK, BLANK, BLANK, BLANK, PLAYER2, BLANK },
                {BLANK, BLANK, BLANK, BLANK, BLANK, BLANK, BLANK, BLANK },
                {BLANK, BLANK, BLANK, BLANK, BLANK, BLANK, BLANK, BLANK },
                {BLANK, BLANK, BLANK, BLANK, BLANK, BLANK, BLANK, BLANK },
                {BLANK, BLANK, BLANK, BLANK, BLANK, BLANK, BLANK, BLANK },
                {BLANK, BLANK, BLANK, BLANK, BLANK, BLANK, BLANK, BLANK },
                {BLANK, BLANK, BLANK, BLANK, BLANK, BLANK, BLANK, BLANK },
                {BLANK, PLAYER1, BLANK, BLANK, BLANK, BLANK, BLANK, BLANK }
            };
            CurrentPlayer = PLAYER1;
        }

        public void ChangePlayer()
        {
            if (CurrentPlayer == PLAYER1)
            {
                CurrentPlayer = PLAYER2;
            }
            else
            {
                CurrentPlayer = PLAYER1;
            }
        }

        public override object Clone()
        {
            HorseGameState newState = new();
            newState.Board = Board.Clone() as char[,];
            newState.CurrentPlayer = CurrentPlayer;
            return newState;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || !(obj is HorseGameState))
            {
                return false;
            }

            HorseGameState other = obj as HorseGameState;

            if (CurrentPlayer != other.CurrentPlayer)
            {
                return false;
            }

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (Board[j, i] != other.Board[j, i])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public override string ToString()
        {
            StringBuilder sb = new();
            sb.AppendLine("    1   2   3   4   5   6   7   8");
            for (int i = 0; i < 8; i++)
            {
                sb.AppendLine("   +---+---+---+---+---+---+---+---+");
                sb.Append(string.Format(" {0} |", i + 1));
                for (int j = 0; j < 8; j++)
                {
                    sb.Append(string.Format(" {0} |", Board[i, j]));
                }
                sb.AppendLine();
            }
            sb.AppendLine("   +---+---+---+---+---+---+---+---+");
            sb.AppendLine("Current player: " + CurrentPlayer);
            return sb.ToString();
        }

        public override Status GetStatus()
        {
            HorseGameOperator horseyOperator = new HorseGameOperator(CurrentPlayer);
            if (CurrentPlayer == PLAYER1)
            {
                if (!horseyOperator.AvailableSpaces(this).Any())
                {
                    return Status.PLAYER2WINS;
                }
            }
            if (CurrentPlayer == PLAYER2)
            {
                if (!horseyOperator.AvailableSpaces(this).Any())
                {
                    return Status.PLAYER1WINS;
                }
            }
            return Status.PLAYING;
        }

    }
}
