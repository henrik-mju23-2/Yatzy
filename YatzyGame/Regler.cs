using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yatzy.YatzyGame
{
    internal class Regler
    {
        private int[] dice;
        private int[] counts;

        // Upper section scores
        public int Ones { get; private set; }
        public int Twos { get; private set; }
        public int Threes { get; private set; }
        public int Fours { get; private set; }
        public int Fives { get; private set; }
        public int Sixes { get; private set; }
        public int UpperTotal => Ones + Twos + Threes + Fours + Fives + Sixes;
        public int UpperBonus => UpperTotal >= 63 ? 50 : 0;

        // Lower section flags and scores
        public bool IsPair { get; private set; }
        public bool IsTwoPair { get; private set; }
        public bool IsThreeOfAKind { get; private set; }
        public bool IsFourOfAKind { get; private set; }
        public bool IsFullHouse { get; private set; }
        public bool IsSmallStraight { get; private set; }
        public bool IsLargeStraight { get; private set; }
        public bool IsYatzy { get; private set; }

        public int SumOfPair { get; private set; }
        public int SumOfTwoPairs { get; private set; }
        public int SumOfThree { get; private set; }
        public int SumOfFour { get; private set; }
        public int FullHouseScore { get; private set; }
        public int YatzyScore { get; private set; }
        public int ChanceScore => dice.Sum();

        public Regler(int throw1, int throw2, int throw3, int throw4, int throw5)
        {
            dice = new int[] { throw1, throw2, throw3, throw4, throw5 };
            counts = new int[6];
            Analyze();
        }

        private void Analyze()
        {
            foreach (int value in dice)
            {
                counts[value - 1]++;
            }

            CalculateUpperSection();
            AnalyzeLowerSection();
            CheckStraights();
        }

        private void CalculateUpperSection()
        {
            Ones = counts[0] * 1;
            Twos = counts[1] * 2;
            Threes = counts[2] * 3;
            Fours = counts[3] * 4;
            Fives = counts[4] * 5;
            Sixes = counts[5] * 6;
        }

        private void AnalyzeLowerSection()
        {
            List<int> pairValues = new List<int>();
            int threeValue = 0;
            int fourValue = 0;

            bool foundThree = false, foundTwo = false;

            for (int i = 0; i < counts.Length; i++)
            {
                int value = i + 1;
                int count = counts[i];

                if (count == 2)
                {
                    IsPair = true;
                    pairValues.Add(value);
                    foundTwo = true;
                }
                if (count == 3)
                {
                    IsThreeOfAKind = true;
                    threeValue = value;
                    foundThree = true;
                }
                if (count == 4)
                {
                    IsFourOfAKind = true;
                    fourValue = value;
                }
                if (count == 5)
                {
                    IsYatzy = true;
                    YatzyScore = 50;
                }
            }

            if (pairValues.Count == 2)
            {
                IsTwoPair = true;
                SumOfTwoPairs = pairValues.Sum(v => v * 2);
            }
            else if (pairValues.Count == 1)
            {
                SumOfPair = pairValues[0] * 2;
            }

            if (IsThreeOfAKind)
            {
                SumOfThree = threeValue * 3;
            }

            if (IsFourOfAKind)
            {
                SumOfFour = fourValue * 4;
            }

            IsFullHouse = foundThree && foundTwo;
            if (IsFullHouse)
            {
                FullHouseScore = 28;
            }
        }

        private void CheckStraights()
        {
            bool[] present = new bool[7]; // 1-based, index 0 unused
            foreach (var value in dice)
            {
                present[value] = true;
            }

            IsSmallStraight = present[1] && present[2] && present[3] && present[4] && present[5];
            IsLargeStraight = present[2] && present[3] && present[4] && present[5] && present[6];
        }

        public void PrintResults()
        {
            Console.WriteLine("Upper Section:");
            Console.WriteLine($"Ones: {Ones}");
            Console.WriteLine($"Twos: {Twos}");
            Console.WriteLine($"Threes: {Threes}");
            Console.WriteLine($"Fours: {Fours}");
            Console.WriteLine($"Fives: {Fives}");
            Console.WriteLine($"Sixes: {Sixes}");
            Console.WriteLine($"Upper Total: {UpperTotal}");
            Console.WriteLine($"Bonus: {UpperBonus}");

            Console.WriteLine("\nLower Section:");
            Console.WriteLine($"Pair: {IsPair}, Sum: {SumOfPair}");
            Console.WriteLine($"Two Pair: {IsTwoPair}, Sum: {SumOfTwoPairs}");
            Console.WriteLine($"Three of a Kind: {IsThreeOfAKind}, Sum: {SumOfThree}");
            Console.WriteLine($"Four of a Kind: {IsFourOfAKind}, Sum: {SumOfFour}");
            Console.WriteLine($"Full House: {IsFullHouse}, Score: {FullHouseScore}");
            Console.WriteLine($"Small Straight: {IsSmallStraight}");
            Console.WriteLine($"Large Straight: {IsLargeStraight}");
            Console.WriteLine($"Yatzy: {IsYatzy}, Score: {YatzyScore}");
            Console.WriteLine($"Chance: {ChanceScore}");
        }
}
}
