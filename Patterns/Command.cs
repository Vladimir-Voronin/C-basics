using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Patterns
{
    //Impliment request for something Event
    class Program3
    {
        public static void CommandMain()
        {
            //Create Reciver, class with many different methods
            Player player1 = new Player();

            //Create commands, for one or pare command (pare in that case) for different methods in class Player
            CommandSwitch comswitch = new CommandSwitch();
            CommandHealth comhealth = new CommandHealth();

            //Assignment reciever for commands
            comswitch.SetReciver(player1);
            comhealth.SetReciver(player1);
            
            //Assignment command for Invoker object (pult in this case)
            //This object can be button in interface or keyboard. It also can be emulator, which we can manage with
            //some commands in our code
            Pult pult = new Pult();
            pult.SetCommand(comswitch);

            //Manage commands from pult
            pult.PushButtonUP();
            pult.PushButtonDown();

            pult.SetCommand(comhealth);

            for (int i = 0; i < 30; i++)
            {
                pult.PushButtonUP();
            }
        }

        private abstract class ICommand
        {
            public abstract void Execute();
            public abstract void Undo();
        }

        private class CommandSwitch : ICommand
        {
            Player r;
            public void SetReciver(Player r)
            {
                this.r = r;
            }

            public override void Execute()
            {
                r.SwitchOn();
            }
            public override void Undo()
            {
                r.SwitchOff();
            }
        }

        private class CommandHealth : ICommand
        {
            Player r;
            public void SetReciver(Player r)
            {
                this.r = r;
            }

            public override void Execute()
            {
                r.HealthUp();
            }
            public override void Undo()
            {
                r.HealthDown();
            }
        }

        private class Player
        {
            public int Health { get; set; } = 50;

            public void SwitchOn()
            {
                Console.WriteLine("Switched on");
            }
            public void SwitchOff()
            {
                Console.WriteLine("Switched off");
            }

            public void HealthUp()
            {
                if (Health < 100)
                { 
                    Health++;
                    Console.WriteLine($"Current Health: {Health}");
                } 
            }

            public void HealthDown()
            {
                if (Health > 1)
                {
                    Health--;
                    Console.WriteLine($"Current Health: {Health}");
                }   
            }
        }
   

        private class Pult
        {
            ICommand com;
            public void SetCommand(ICommand command)
            {
                com = command;
            }
            public void PushButtonUP()
            {
                com.Execute();
            }
            public void PushButtonDown()
            {
                com.Undo();
            }
        }
    }
}