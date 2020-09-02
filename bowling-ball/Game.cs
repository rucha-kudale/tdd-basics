using System;

namespace BowlingBall
{
    /// <summary>
    /// Class for game
    /// </summary>
    public class Game : IGame
    {        
        private static readonly int[] allRolls = new int[21];
       
        /// <summary>
        /// Enter pins hit when you roll the ball        
        /// </summary>
        /// <param name="pins"></param>
        public void Roll(int pins)
        {

        }
        public int GetScore()
        {
            return -1;

        }

    }
}

