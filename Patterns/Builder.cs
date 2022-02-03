using System;
using System.Collections.Generic;
using System.Text;

namespace Patterns
{
    //For example - Character Creation
    class Program2
    {
        public static void BuilderMain()
        {
            AmericanBuilder americanbuilder = new AmericanBuilder();
            Workshop shop1 = new Workshop(americanbuilder);
            //make americans characters
            TheCharacter char1 = shop1.CreateCharacter("Biff");
            TheCharacter char2 = shop1.CreateCharacter("Jeff");
        }

        private class Workshop
        {
            Builder builder;
            public Workshop(Builder builder)
            {
                this.builder = builder;
            }

            public TheCharacter CreateCharacter(string name)
            {
                builder.Create();
                builder.SetHair();
                builder.SetHeight();
                builder.Character.Name = name;
                return builder.Character;
            }
        }

        private abstract class Builder
        {
            public TheCharacter Character { get; set; }
            public void Create()
            {
                Character = new TheCharacter();
            }
            public abstract Hair SetHair();
            public abstract Height SetHeight();
        }

        private class AmericanBuilder : Builder
        {
            public override Hair SetHair()
            {
                this.Character.MyHair.Color = "black";
                return this.Character.MyHair;
            }
            public override Height SetHeight()
            {
                this.Character.MyHeight.HeightCM = 170;
                return this.Character.MyHeight;
            }
        }

        private class Hair 
        {
            public string Color { get; set; }
        }

        private class Height
        {
            public int HeightCM { get; set; }
        }

        private class TheCharacter
        {
            public Hair MyHair { get; set; }
            public Height MyHeight { get; set; }
            public string Name { get; set; }
        }
    }

    
}
