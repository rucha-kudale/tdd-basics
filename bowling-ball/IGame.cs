using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingBall
{
    interface IGame
    {
        void Roll(int pins);
        int GetScore();
      
    }
}
