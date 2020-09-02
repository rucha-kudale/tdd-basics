using System;
using Xunit;
using BowlingBall;
namespace BowlingBall.Tests
{

    /// <summary>
    /// Test Cases for Game
    /// </summary>
    public class GameFixture
    {
        private readonly Game g;

        public GameFixture()
        {
            g = new Game();
        }
        private void RollMany(int rolls, int pins)
        {
            for (int i = 0; i < rolls; i++)
            {
                g.Roll(pins);
            }
        }
        private void RollStrike()
        {
            g.Roll(10);
            g.Roll(-1);
        }
        private void RollSpare()
        {
            g.Roll(4);
            g.Roll(6);
        }
        
        [Fact]
        //All Zeroes Works
        public void TestAllZeroRolls()
        {
            for (int i = 0; i < 20; i++)
                g.Roll(0);
            Assert.Equal(0, g.GetScore());
        }
        [Fact]
        //All One Works
        public void TestAllOneRolls()
        {
            for (int i = 0; i < 20; i++)
                g.Roll(1);
            Assert.Equal(20, g.GetScore());
        }

        [Fact]
        public void TestOneSpareRoll()
        {
            RollSpare();
            g.Roll(3);
            RollMany(17, 0);
            Assert.Equal(16, g.GetScore());
        }

        [Fact]
        public void TestOneStrike()
        {
            RollStrike();
            g.Roll(3);
            g.Roll(4);
            RollMany(16, 0);
            Assert.Equal(24, g.GetScore());
        }

        [Fact]
        public void TestAllStrike()
        {
            for (int i = 0; i < 6; i++)
            {
                RollStrike();                
            }            
            Assert.Equal(150, g.GetScore());
        }

        [Theory]
        [InlineData(new int[] { 8, 0, 7, 0, 5, 3, 9, 1, 9, 1, 10, -1, 8, 0, 5, 1, 3, 7, 9, 0 }, 122)]
        [InlineData(new int[] { 7, 2, 4, 2, 4, 6, 3, 1, 5, 4, 2, 7, 4, 3, 4, 5, 6, 4, 3, 7, 5 }, 94)]
        [InlineData(new int[] { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 10 }, 155)]
        [InlineData(new int[] { 5, 5, 10, -1, 10, -1, 6, 3, 6, 4, 7, 3, 2, 6, 4, 3, 2, 7, 5, 4 }, 136)]
        [InlineData(new int[] { 10, -1, 9, 1, 5, 5, 7, 2, 10, -1, 10, -1, 10, -1, 9, 0, 8, 2, 9, 1, 10 }, 187)]
        public void TestForRandomPins(int[] inputPins, int expected)
        {
            Game game = new Game();
            for (int i = 0; i < inputPins.Length; i++)
            {
                game.Roll(inputPins[i]);
            }

            Assert.Equal(expected, game.GetScore());
        }
        
    }
}