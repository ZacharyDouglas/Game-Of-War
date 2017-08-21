using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WarCardGame
{
    public partial class Default : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void playButton_Click(object sender, EventArgs e)
        {
            /* This handles the initializing of the deck and dealing of the cards.
             * Also, it houses the condition at which to end the game.  Which is currently
             * after 5 rounds
             */
            var dealerDeck = new Deck();
            var playerOne = new Player();
            var playerTwo = new Player();
            var battleObj = new Battle(playerOne, playerTwo);
            dealerDeck.dealCards(playerOne, playerTwo);
            var numberOfTurns = 0;
            while(numberOfTurns < 5)
            {
                displayFirstCardFlip(battleObj);
                playTurn(battleObj);
                numberOfTurns++;
            }
        }

        protected void playTurn(Battle battleObj)
        {
            /* This handles each turn of the game.  
             * If the winner is null, the first cards flipped have the same value.  This leads to a 
             * tiebreaker where each player lays down 4 more cards and flips them one at a time.
             * The winner of that takes all the cards.  
             * If there is a winner after the first draw, the winner takes both cards and places 
             * them on the bottom of his deck.
             */

            var winnerPlayerObj = battleObj.compareCards();
            if (winnerPlayerObj == null)
            {
                winnerPlayerObj = battleObj.handleDraw();
                displayFourCardFlip(battleObj);
                displayWinnerMessage(winnerPlayerObj, battleObj);
                battleObj.moveFiveCardsFromLosersDeckToWinnersDeck(winnerPlayerObj);
            }
            else
            {
                battleObj.moveOneCardFromLosersDeckToWinnersDeck(winnerPlayerObj);
                displayWinnerMessage(winnerPlayerObj, battleObj);
            }
        }
        

        protected void displayFirstCardFlip(Battle battleObj)
        {
            /* Display message of the type and value of the first card that each player lays */

            resultLabel.Text += String.Format("Player One Flips Card: {0} of {1} </br> Player Two Flips Card:  {2} of {3}</br>",
                battleObj.playerOne.playersDeck.First().cardValue, battleObj.playerOne.playersDeck.First().cardType,
                battleObj.playerTwo.playersDeck.First().cardValue, battleObj.playerOne.playersDeck.First().cardType);
        }

        protected void displayFourCardFlip(Battle battleObj)
        {
            /* Display message of the type and value of each player's four cards that he lays 
             * if there is a draw during the first card flip
             */
            resultLabel.Text += "Player One Flips Four Cards: </br>";
            for (int i = 1; i < 5; i++)
            {
                resultLabel.Text += String.Format("{0} of {1} </br>", 
                    battleObj.playerOne.playersDeck.ElementAt(i).cardValue, 
                    battleObj.playerOne.playersDeck.ElementAt(i).cardType);
            }
            resultLabel.Text += "Player Two Flips Four Cards: </br>";
            for (int i = 1; i < 5; i++)
            {
                resultLabel.Text += String.Format("{0} of {1} </br>", 
                    battleObj.playerTwo.playersDeck.ElementAt(i).cardValue, 
                    battleObj.playerTwo.playersDeck.ElementAt(i).cardType);
            }
        }

        protected void displayWinnerMessage(Player winnerPlayerObj, Battle battleObj)
        {
            /* Displays the winner of the round */

            if (winnerPlayerObj == battleObj.playerOne) resultLabel.Text += "Player One Wins!</br>";
            else if (winnerPlayerObj == battleObj.playerTwo) resultLabel.Text += "Player Two Wins! </br>";
        }

    }
}