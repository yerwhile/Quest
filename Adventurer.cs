using System;
using System.Collections.Generic;
using System.Linq;

namespace Quest
{
    // An instance of the Adventurer class is an object that will undergo some challenges
    public class Adventurer
    {
        // This is an "immutable" property. It only has a "get".
        // The only place the Name can be set is in the Adventurer constructor
        // Note: the constructor is defined below.
        public string Name { get; }
        public Robe ColorfulRobe { get; }

        // This is a mutable property it has a "get" and a "set"
        //  So it can be read and changed by any code in the application
        public int Awesomeness { get; set; }

        public Hat AdventureHat { get; set; }

        // A constructor to make a new Adventurer object with a given name
        public Adventurer(string name, Robe robe, Hat hat)
        {
            Name = name;
            Awesomeness = 50;
            ColorfulRobe = robe;
            AdventureHat = hat;
        }

        // This method returns a string that describes the Adventurer's status
        // Note one way to describe what this method does is:
        //   it transforms the Awesomeness integer into a status string
        public string GetAdventurerStatus()
        {
            string status = "okay";
            if (Awesomeness >= 75)
            {
                status = "great";
            }
            else if (Awesomeness < 25 && Awesomeness >= 10)
            {
                status = "not so good";
            }
            else if (Awesomeness < 10 && Awesomeness > 0)
            {
                status = "barely hanging on";
            }
            else if (Awesomeness <= 0)
            {
                status = "not gonna make it";
            }

            return $"Adventurer, {Name}, is {status}";
        }
        public string GetDescription()
        {
            List<string> colors = ColorfulRobe.Colors;
            string colorsList = colors[0];
            for(int i = 1; i < colors.Count - 1; i++) {
                colorsList += $", {colors[i]}";
            }
            colorsList += $", and {colors.Last()}";
            string description = $"{Name} has a {colorsList} robe that is {ColorfulRobe.Length} inches long, and a hat that is {AdventureHat.ShininessDescription()}.";
            return description;
        }
    }
}