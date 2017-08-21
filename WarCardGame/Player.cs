using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WarCardGame
{
    public class Player
    {
        public List<Card> playersDeck { get; set; }

        public Player()
        {
            playersDeck = new List<Card>();
        }

        public void moveOneCardToBottomOfDeck()
        {
            /* If the player won the first card flip, he takes his card and places it at the bottom of his deck. */
            playersDeck.Add(playersDeck.First());
            playersDeck.Remove(playersDeck.First());
        }

        public void moveFiveCardsToBottomOfDeck()
        {
            /* If there is a draw and the player wins, he moves all 5 of the cards that he has played to the bottom of his deck */

            playersDeck.AddRange(playersDeck.GetRange(0, 5));
            playersDeck.RemoveRange(0, 5);

        }

        public void removeOneCardFromTopOfDeck()
        {
            playersDeck.Remove(playersDeck.First());
        }

        public void addLosersOneCardToBottomOfWinnersDeck(Card card)
        {
            playersDeck.Add(card);
        }

        public void addLosersFiveCardsToBottomOfWinnersDeck(List<Card> fiveCards)
        {
            playersDeck.AddRange(fiveCards);
        }

        public void removeFiveCardsFromTopOfDeck()
        {
            playersDeck.RemoveRange(0, 5);
        }

    }
}