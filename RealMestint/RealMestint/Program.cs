using RealMestint.StateRepresentations;

namespace RealMestint
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HorseGamePlayer player = new HorseGamePlayer(Difficulty.RND);
            player.Play();
            Console.ReadLine();
        }
    }
}
