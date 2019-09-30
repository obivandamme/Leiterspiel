using System;
using Xunit;
using System.IO;
using System.Text;
using Leiterspiel.Core;

namespace Leiterspiel.Tests
{
    public class GameTests
    {
        [Fact]
        public void Game_BoardOneAndAllDrawsAreFour_PlayerOneShouldWin()
        {
            // Arrange
            var consoleIn = string.Format("2{0}4{0}4{0}4{0}4{0}4{0}4{0}4{0}4{0}4{0}4{0}4{0}", Environment.NewLine);
            var consoleOut = new StringBuilder();
            Console.SetIn(new StringReader(consoleIn));
            Console.SetOut(new StringWriter(consoleOut));

            // Act
            var boardDescription = new FileBoardDescription(
                @"C:\Users\pascal.martin\Documents\Leiterspiel\Leiterspiel\leiterspielbrett1.txt");
            var loader = new BoardLoader(boardDescription);
            var game = new Game(loader.Load(), new ConsoleInput(), new ConsoleOutput());
            game.Start();

            // Assert
            Assert.Equal(@"Spielbrett mit 5 Zeilen und 6 Spalten. Sieger ist, wer zuerst Feld 30 erreicht hat
Neues Leiterspiel. Geben Sie zuerst die Anzahl an Spielern ein. [2 .. 4]
Spieler 0: Position 0. Gewürfelte Augenzahl: 

Spieler 1: Position 0. Gewürfelte Augenzahl: 

Spieler 0: Position 4. Gewürfelte Augenzahl: 

Spieler 1: Position 4. Gewürfelte Augenzahl: 

Spieler 0: Position 8. Gewürfelte Augenzahl: 

Spieler 1: Position 8. Gewürfelte Augenzahl: 

Spieler 0: Position 12. Gewürfelte Augenzahl: 

Spieler 1: Position 12. Gewürfelte Augenzahl: 

Spieler 0: Position 16. Gewürfelte Augenzahl: 

Spieler 1: Position 16. Gewürfelte Augenzahl: 

Spieler 0: Position 29. Gewürfelte Augenzahl: 

Spieler 0 hat gewonnen!!!! Gratulation. 
", consoleOut.ToString());
        }
    }
}