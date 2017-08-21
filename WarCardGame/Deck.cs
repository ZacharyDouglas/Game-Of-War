using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WarCardGame
{
    public class Deck
    {


        const int NUM_OF_CARDS_IN_DECK = 52;
        const int NUM_OF_CARD_TYPES = 4;
        const int NUM_OF_DIFF_CARD_NUMS = 13;

        Random _random = new Random();

        public List<Card> DeckOfCards;
        string[] cardTypes = new String[] { "Aces", "Spades", "Diamonds", "Hearts" };

        public Deck()
        {
            /* Initializing the deck of 52 Cards.  4 Types. 13 Values */
            DeckOfCards = new List<Card>();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 13; j++)
                {
                    DeckOfCards.Add(new Card() { cardType = cardTypes[i].ToString(), cardValue = (CardNumber)j});
                }
            }
            
        }

        public void dealCards(Player playerOne, Player playerTwo)
        {
            /* Controls the loop for dealing cards.  While the dealer still has cards,
             * he continues to deal.  The dealer switches between players after each card.
             */

            const int PLAYER_ONE_TURN = 0;
            const int PLAYER_TWO_TURN = 1;

            int whoseTurn = PLAYER_ONE_TURN;
            int cardsLeftToDeal = NUM_OF_CARDS_IN_DECK;

            while(DeckOfCards.Count != 0)
            {
                if(whoseTurn == PLAYER_ONE_TURN)
                {
                    moveFromDealerDeckToPlayerDeck(playerOne, cardsLeftToDeal);
                    whoseTurn = PLAYER_TWO_TURN;
                    cardsLeftToDeal--;
                }else if(whoseTurn == PLAYER_TWO_TURN)
                {
                    moveFromDealerDeckToPlayerDeck(playerTwo,cardsLeftToDeal);
                    whoseTurn = PLAYER_ONE_TURN;
                    cardsLeftToDeal--;
                }
            }
        }
        
        public void moveFromDealerDeckToPlayerDeck(Player player, int cardsLeftInDeck)
        {
            /* Handles the removal of a random card from the dealer deck to the current player's deck*/

            int randomCardFromDeckIndex = _random.Next(0, cardsLeftInDeck);
            player.playersDeck.Add(DeckOfCards.ElementAt(randomCardFromDeckIndex));
            DeckOfCards.Remove(DeckOfCards.ElementAt(randomCardFromDeckIndex));
        }
    }

}
