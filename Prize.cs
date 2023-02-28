using System;
using System.Collections.Generic;

namespace Quest
{
    public class Prize
    {
        private string _text = "prize description";

        public Prize (string text)
        {
            _text = text;
        }

        public string ShowPrize(Adventurer adventurer)
        {
            string prizeMessage = "";

            if(adventurer.Awesomeness > 0) {
                for(int i = 0; i < adventurer.Awesomeness; i++) {
                    prizeMessage +=$" {_text}";
                }
            }
            else {
                prizeMessage = "To the victor go the spoils. To you go these jars o' spoiled mayonnaise.";
            }
            return prizeMessage;
        }
    }
}

