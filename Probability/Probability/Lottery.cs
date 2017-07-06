using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Probability
{
    public static class Lottery
    {
        public static bool PlayLottery(double odds)
        {
            odds = Math.Min(1d, odds);
            odds = Math.Max(0, odds);
            var ticks = TimeSpan.FromTicks(new Random().Next());
            Random rand = new Random(DateTime.Now.Subtract(ticks).GetHashCode());
            var randomValue = rand.NextDouble();

            return randomValue < odds;
        }

        public static string PlayLottery(int numberOfTimes, double odds)
        {
            Random rand = new Random();

            double wins = 0;
            double losses = 0;

            for (int i = 0; i < numberOfTimes; i++)
            {
                odds = Math.Min(1d, odds);
                odds = Math.Max(0, odds);

                var randomValue = rand.NextDouble();

                var result = randomValue < odds;

                if (result)
                {
                    wins++;
                }
                else
                {
                    losses++;
                }
            }

            return
                $"Wins: {wins} Losses: {losses} \tExpected Win Ratio: {odds} Actual Win Ratio: {wins / (double)numberOfTimes}";
        }
    }
}
