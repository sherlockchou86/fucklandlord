using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace fucklandlord.engine
{
    /// <summary>
    /// main engine for the card game
    /// </summary>
    public class GameEngine
    {
        /// <summary>
        /// shuffle the cards. 
        /// </summary>
        /// <returns>a list of 54 cards. has color but disordered.</returns>
        public static List<String> Shuffle()
        {
            List<String> cards = EngineValues.Cards;

            Random rand = new Random(Guid.NewGuid().GetHashCode());
            List<String> newList = new List<String>();

            foreach (String card in cards)
            {
                newList.Insert(rand.Next(0, newList.Count), card);
            }

            // need reorder the first element
            newList.Remove(cards[0]);
            newList.Insert(rand.Next(0, newList.Count), cards[0]);

            return newList;
        }

        /// <summary>
        /// deal the cards for 3 parts, 17 cards for each part, another 3 cards will be asigned to the guy who is the landlord.
        /// </summary>
        /// <param name="original_cards">the original cards list, returned by Shuffle method.</param>
        /// <param name="first">the first part</param>
        /// <param name="second">the second part</param>
        /// <param name="third">the third part</param>
        /// <param name="last_cards">the last 3 cards</param>
        /// <returns>true if deal successfully</returns>
        public bool Deal(List<String> original_cards, List<String> first, List<String> second, List<String> third, List<String> last_cards)
        {
            // check if the parameters are valid
            if (original_cards == null 
                || original_cards.Count != 54
                || first == null
                || first.Count != 0
                || second == null
                || second.Count != 0
                || third == null
                || third.Count != 0
                || last_cards == null
                || last_cards.Count != 0)
            {
                return false;
            }

            // 
            for (int index = 0; index < 51; index = index + 3)
            {
                first.Add(original_cards[index]);
                second.Add(original_cards[index + 1]);
                third.Add(original_cards[index + 2]);
            }
            
            // the last 3 cards
            last_cards.Add(original_cards[51]);
            last_cards.Add(original_cards[52]);
            last_cards.Add(original_cards[53]);

            return true;
        }
    }
}
