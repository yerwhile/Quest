using System;
using System.Collections.Generic;
using System.Linq;

// Every class in the program is defined within the "Quest" namespace
// Classes within the same namespace refer to one another without a "using" statement
namespace Quest
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a few challenges for our Adventurer's quest
            // The "Challenge" Constructor takes three arguments
            //   the text of the challenge
            //   a correct answer
            //   a number of awesome points to gain or lose depending on the success of the challenge
            Challenge twoPlusTwo = new Challenge("2 + 2?", 4, 10);
            Challenge theAnswer = new Challenge(
                "What's the answer to life, the universe and everything?", 42, 25);
            Challenge whatSecond = new Challenge(
                "What is the current second?", 1, 50);

            int randomNumber = new Random().Next() % 10;

            Challenge guessRandom = new Challenge("What number am I thinking of?", randomNumber, 25);

            Challenge currentYear = new Challenge("What year is it, genius?", 2023, 15);

            Challenge valsVacation = new Challenge("How many times did Val go to Japan?", 0, 20);

            Challenge favoriteBeatle = new Challenge(
                @"Who's your favorite Beatle?
    1) John
    2) Paul
    3) George
    4) Ringo
",
                3, 20
            );

            // New "Robe" instance
            Robe tricolor = new Robe() {
                Colors = new List<string>()
                    {
                        "blue", "red", "yellow"
                    },
                Length = 42
            };

            Hat AdventureHat = new Hat
                {
                    ShininessLevel = 6
                };

            Prize AdventurePrize = new Prize("a big honkin' hamburger");

            // "Awesomeness" is like our Adventurer's current "score"
            // A higher Awesomeness is better

            // Here we set some reasonable min and max values.
            //  If an Adventurer has an Awesomeness greater than the max, they are truly awesome
            //  If an Adventurer has an Awesomeness less than the min, they are terrible
            int minAwesomeness = 0;
            int maxAwesomeness = 100;

            // Make a new "Adventurer" object using the "Adventurer" class
            Console.WriteLine("What is your dumb name, Adventurer?: ");
            string userName = Console.ReadLine();
            Adventurer theAdventurer = new Adventurer(userName, tricolor, AdventureHat);

            string descript = theAdventurer.GetDescription();
            Console.WriteLine(descript);

            // A list of challenges for the Adventurer to complete
            // Note we can use the List class here because have the line "using System.Collections.Generic;" at the top of the file.
            List<Challenge> challenges = new List<Challenge>()
            {
                twoPlusTwo,
                theAnswer,
                whatSecond,
                guessRandom,
                favoriteBeatle,
                currentYear,
                valsVacation
            };

            // Loop through all the challenges and subject the Adventurer to them
            // foreach (Challenge challenge in challenges)
            // {
            //     challenge.RunChallenge(theAdventurer);
            // }
            Random randomIndex = new Random();
            foreach(int i in Enumerable.Range(0, 5).OrderBy(x => randomIndex.Next()))
            {
                challenges[i].RunChallenge(theAdventurer);
            }

            // This code examines how Awesome the Adventurer is after completing the challenges
            // And praises or humiliates them accordingly
            if (theAdventurer.Awesomeness >= maxAwesomeness)
            {
                Console.WriteLine("YOU DID IT! You are truly awesome!");
            }
            else if (theAdventurer.Awesomeness <= minAwesomeness)
            {
                Console.WriteLine("Get out of my sight. Your lack of awesomeness offends me!");
            }
            else
            {
                Console.WriteLine("I guess you did...ok? ...sorta. Still, you should get out of my sight.");
            }

            Console.Write(AdventurePrize.ShowPrize(theAdventurer));

            Console.WriteLine("Hey dummy, would you like to play again? (Y/N): ");
            string againAnswer = Console.ReadLine().ToLower();
            if(againAnswer == "n") {
                return;
            }
            else if(againAnswer == "y") {
                Main(args);
            }
            else {
                return;
            }
        }
    }
}