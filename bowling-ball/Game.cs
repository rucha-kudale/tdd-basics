using System;

namespace BowlingBall
{
    /// <summary>
    /// Class for game
    /// </summary>
    public class Game : IGame
    {
        private int score = 0;
        private static readonly int[] allRolls = new int[21];
        private int currentIndex = 0;
        private int frameIndex;

        /// <summary>
        /// Enter pins hit when you roll the ball        
        /// </summary>
        /// <param name="pins"></param>
        public void Roll(int pins)
        {
            allRolls[currentIndex++] = pins;
        }

        /// <summary>
        /// is for at the end of the game to give a total score
        /// </summary>
        /// <returns></returns>
        public int GetScore()
        {
            for (int frame = 0; frame < 10; frame++)
            {
                if (IsStrike(frameIndex))
                {
                    score += 10 + StrikeBonus(frameIndex);
                    frameIndex+=2;
                }
                else if (IsSpare(frameIndex))
                {
                    score += 10 + SpareBonus(frameIndex);
                    frameIndex += 2;
                }
                else
                {
                    score += SumOfBallsInFrame(frameIndex);
                    frameIndex += 2;
                }
            }

            return score;
        }
        public bool IsStrike(int frameIndex)
        {
            return allRolls[frameIndex] == 10;
        }

        public bool IsSpare(int frameindex)
        {
            return allRolls[frameindex] +
                   allRolls[frameindex + 1] == 10;
        }
        public int SumOfBallsInFrame(int frameIndex)
        {
            
            return allRolls[frameIndex] + allRolls[frameIndex + 1];
        }

        public int SpareBonus(int frameIndex)
        {
            return allRolls[frameIndex + 2];
        }

        public int StrikeBonus(int frameIndex)
        {
            int num = 0, sum= 0, i=2;
            while(num<2)
            {
                if (allRolls[frameIndex + i] >= 0)
                {
                    sum += allRolls[frameIndex + i];
                    num++;
                }              
                i++;
            }
            return sum;
        }
    }
}

