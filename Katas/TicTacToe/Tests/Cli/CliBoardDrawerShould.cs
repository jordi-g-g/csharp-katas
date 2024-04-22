using Katas.TicTacToe.App.Cli;
using NUnit.Framework;

namespace Katas.TicTacToe.Tests.Cli
{
    public class CliBoardDrawerShould
    {
        [Test]
        public void has_nine_fields_in_a_3x3_grid()
        {
            var game = new CliBoardDrawer();
        
            var drawnBoard = game.Draw();

            const string expected = """
                                    +---+---+---+
                                    | 1 | 2 | 3 |
                                    +---+---+---+
                                    | 4 | 5 | 6 |
                                    +---+---+---+
                                    | 7 | 8 | 9 |
                                    +---+---+---+
                                    """;
            Assert.That(expected, Is.EqualTo(drawnBoard));
        }
    }
}

