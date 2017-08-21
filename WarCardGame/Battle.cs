using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WarCardGame
{
    public class Battle
    {

        public Player playerOne { get; set; }
        public Player playerTwo { get; set; }

        public Battle(Player firstPlayer, Player secondPlayer)
        {
            playerOne = firstPlayer;
            playerTwo = secondPlayer;
        }

        public Player handleDraw()
        {
            /* If there is a draw on the first flip, it loops through the next 4 cards laid and compares 
             * them until one player's card has a higher card value.
             */

            for (int i = 1; i < 5; i++)
            {
                if(playerOne.playersDeck.ElementAt(i).cardValue > playerTwo.playersDeck.ElementAt(i).cardValue)
                    return playerOne;
                else if(playerTwo.playersDeck.ElementAt(i).cardValue > playerOne.playersDeck.ElementAt(i).cardValue)
                    return playerTwo;   
            }

            return null;
        }

        public Player compareCards()
        {
            /* This handles comparing the card values of the first card flip of each round */

            if (playerOne.playersDeck.First().cardValue == playerTwo.playersDeck.First().cardValue) return null;
            else if (playerOne.playersDeck.First().cardValue > playerTwo.playersDeck.First().cardValue) return playerOne;
            else if (playerTwo.playersDeck.First().cardValue > playerOne.playersDeck.First().cardValue) return playerTwo;
            else return null;
        }


        public void moveOneCardFromLosersDeckToWinnersDeck(Player winner)
        {
            /* After a player wins the first draw, this handles removing 1 card from the top of the losers deck
             * and adding it to the bottom of the winner's deck
             */
            if (winner == playerOne)
            {
                winner.addLosersOneCardToBottomOfWinnersDeck(playerTwo.playersDeck.First());
                winner.moveOneCardToBottomOfDeck();
                playerTwo.removeOneCardFromTopOfDeck();
            }
            else if (winner == playerTwo)
            {
                winner.addLosersOneCardToBottomOfWinnersDeck(playerOne.playersDeck.First());
                winner.moveOneCardToBottomOfDeck();
                playerOne.removeOneCardFromTopOfDeck();
            }
        }

        public void moveFiveCardsFromLosersDeckToWinnersDeck(Player winner)
        {
            /* After a player wins the draw, this handles the removing 5 cards from the losers deck and 
             * adding them to the bottom of the winner's deck.
             * */
            if (winner == playerOne)
            {
                winner.addLosersFiveCardsToBottomOfWinnersDeck(playerTwo.playersDeck.GetRange(0, 5));
                playerTwo.removeFiveCardsFromTopOfDeck();
                winner.moveFiveCardsToBottomOfDeck();
            }else if(winner == playerTwo)
            {
                winner.addLosersFiveCardsToBottomOfWinnersDeck(playerOne.playersDeck.GetRange(0, 5));
                playerTwo.removeFiveCardsFromTopOfDeck();
                winner.moveFiveCardsToBottomOfDeck();
            }

        }

    }
}