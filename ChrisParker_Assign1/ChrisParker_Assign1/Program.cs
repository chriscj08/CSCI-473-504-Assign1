using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChrisParker_Assign1
{
    class Program
    {
        static void Main(string[] args)
        {
            var exitStatements = new string[] { "10", "q", "Q", "quit", "Quit", "exit", "Exit" }; //All possible ways a user can quit the program
            string userInput = ""; //Variable to hold user input
            do
            {
                System.Console.WriteLine("Welcome to the World of ConflictCraft: Testing Enviroment \n");
                System.Console.WriteLine("Please select an option from the list below: ");
                System.Console.WriteLine("\t 1) Print All Players ");
                System.Console.WriteLine("\t 2) Print All Guilds ");
                System.Console.WriteLine("\t 3) List all Gear ");
                System.Console.WriteLine("\t 4) Print Gear List for Player ");
                System.Console.WriteLine("\t 5) Leave Guild ");
                System.Console.WriteLine("\t 6) Join Guild ");
                System.Console.WriteLine("\t 7) Equip Gear ");
                System.Console.WriteLine("\t 8) Unequip Gear ");
                System.Console.WriteLine("\t 9) Award Experience ");
                System.Console.WriteLine("\t 10) Quit ");

                userInput = Console.ReadLine(); //Reads input from console

                switch (userInput)
                {
                    case "1":
                        System.Console.WriteLine("1");
                        //void printAllPlayers();
                        break;
                    case "2":
                        System.Console.WriteLine("2");
                        //void printAllGuilds();
                        break;
                    case "3":
                        System.Console.WriteLine("3");
                        //void printAllGear();
                        break;
                    case "4":
                        System.Console.WriteLine("4");
                        //void printGearList();
                        break;
                    case "5":
                        System.Console.WriteLine("5");
                        //void leaveGuild();
                        break;
                    case "6":
                        System.Console.WriteLine("6");
                        //void joinGuild();
                        break;
                    case "7":
                        System.Console.WriteLine("7");
                        //void equipGear();
                        break;
                    case "8":
                        System.Console.WriteLine("8");
                        //void unequipGear();
                        break;
                    case "9":
                        System.Console.WriteLine("9");
                        //void awardExperience();
                        break;
                    case "T":
                        System.Console.WriteLine("T");
                        //void icomparable();
                        break;
                    case "10":
                        System.Console.WriteLine("Exiting: Good Bye");
                        break;
                    case "q":
                        System.Console.WriteLine("Exiting: Good Bye");
                        break;
                    case "Q":
                        System.Console.WriteLine("Exiting: Good Bye");
                        break;
                    case "quit":
                        System.Console.WriteLine("Exiting: Good Bye");
                        break;
                    case "Quit":
                        System.Console.WriteLine("Exiting: Good Bye");
                        break;
                    case "exit":
                        System.Console.WriteLine("Exiting: Good Bye");
                        break;
                    case "Exit":
                        System.Console.WriteLine("Exiting: Good Bye");
                        break;
                    default:
                        System.Console.WriteLine("Invalid Input: Please enter an option from the list above");
                        break;
                }
                
            } while (!exitStatements.Contains(userInput));

        }
        public enum ItemType
        {
            Helmet, Neck, Shoulders, Back, Chest,
            Wrist, Gloves, Belt, Pants, Boots,
            Ring, Trinket
        };

        public enum Race { Orc, Troll, Tauren, Forsaken };

        private static uint MAX_ILVL = 360;
        private static uint MAX_PRIMARY = 200;
        private static uint MAX_STAMINA = 275;
        private static uint MAX_LEVEL = 60;
        private static uint GEAR_SLOTS = 14;
        private static uint MAX_INVENTORY_SIZE = 20;


        public class Item : IComparable
        {
            private readonly uint id;
            private string name;
            private ItemType type;
            private uint ilvl;
            private uint primary;
            private uint stamina;
            private uint requirement;
            private string flavor;

            public uint Id
            {
                get { return id; }
            }

            public string Name
            {
                get { return name; }
                set { name = value; }
            }

            public ItemType Type
            {
                get { return type; }
                set { type = value; }
            }

            public uint Ilvl
            {
                get { return ilvl; }

                set
                {
                    if (value <= 0)
                    {
                        ilvl = 0;
                    }
                    else if (value >= MAX_ILVL)
                    {
                        ilvl = MAX_ILVL;
                    }
                    else
                    {
                        ilvl = value;
                    }
                }

            }

            public uint Primary
            {
                get { return primary; }
                set
                {
                    if (value <= 0)
                    {
                        primary = 0;
                    }
                    else if (value >= MAX_PRIMARY)
                    {
                        primary = MAX_PRIMARY;
                    }
                    else
                    {
                        primary = value;
                    }
                }
            }

            public uint Stamina
            {
                get { return stamina; }
                set
                {
                    if (value <= 0)
                    {
                        stamina = 0;
                    }
                    else if (value >= MAX_STAMINA)
                    {
                        stamina = MAX_STAMINA;
                    }
                    else
                    {
                        stamina = value;
                    }
                }
            }

            public uint Requirement
            {
                get { return requirement; }
                set
                {
                    if (value <= 0)
                    {
                        requirement = 0;
                    }
                    else if (value >= MAX_LEVEL)
                    {
                        requirement = MAX_LEVEL;
                    }
                    else
                    {
                        requirement = value;
                    }
                }
            }

            public string Flavor
            {
                get { return flavor; }
                set { flavor = value; }
            }

            public Item()
            {
                this.id = 0;
                this.name = "";
                this.type = 0;
                this.ilvl = 0;
                this.primary = 0;
                this.stamina = 0;
                this.requirement = 0;
                this.flavor = "";
            }

            public Item(uint id, string name, ItemType type, uint ilvl, uint primary, uint stamina, uint requirement, string flavor)
            {
                this.id = id;
                this.name = name;
                this.type = type;
                this.ilvl = ilvl;
                this.primary = primary;
                this.stamina = stamina;
                this.requirement = requirement;
                this.flavor = flavor;
            }

            public int CompareTo(Object alpha)
            {
                if (alpha == null)
                { return 1; }

                Item comp = alpha as Item;

                if (comp != null)
                    return name.CompareTo(comp.name);
                else
                    throw new ArgumentException("[Item]:CompareTo argument is not an Item.");
            }

            public override string ToString()
            {
                return this.name;
            }
        } 

        

        public class Player : IComparable
        {
            private readonly uint playerId; //Player ID
            private readonly string playerName; //Player Name
            private readonly Race race; //Player Race. int because will be indexed to enum
            private uint playerLevel; //Player level
            private uint exp; //player xp
            private uint guildID; //Player GuildID
            private uint[] gear; //Player gear array
            private List<uint> inventory; //Player inventory list

            public uint PlayerId
            {
                get { return playerId; }                
            }

            public string PlayerName
            {
                get { return playerName; }                
            }

            public Race Race
            {
                get { return race; }                
            }

            public uint PlayerLevel
            {
                get { return playerLevel; }
                set
                {
                    if (value <= 0)
                    {
                        playerLevel = 0;
                    }
                    else if (value >= MAX_LEVEL)
                    {
                        playerLevel = MAX_LEVEL;
                    }
                    else
                    {
                        playerLevel = value;
                    }
                }
            }

            public uint Exp
            {
                get { return exp; }
                set
                {
                    exp += value;
                    while (exp > PlayerLevel * 1000)
                    {
                        this.PlayerLevel++;
                    }

                }

            }

            public uint GuildID
            {
                get { return guildID; }
                set { guildID = value; }
            }
            public uint this[uint index]
            {
                get { return gear[index]; }
                set { gear[index] = value; }
            }

            public int CompareTo(Object alpha)
            {
                if (alpha == null)
                { return 1; }

                Player comp = alpha as Player;

                if (comp != null)
                    return playerName.CompareTo(comp.playerName);
                else
                    throw new ArgumentException("[Item]:CompareTo argument is not an Item.");
            }

            public override string ToString()
            {
                return this.playerName;
            }

            public void EquipGear(uint newGearID)
            {
                
            }

            public void UnequipGear(int gearSlot)
            {

            }

            public Player()
            {
                this.playerId = 0;
                this.playerName = "";
                this.race = 0;
                this.playerLevel = 0;
                this.exp = 0;
                this.guildID = 0;
                this.gear = new uint[GEAR_SLOTS]; 
                this.inventory = new List<uint>(new uint[MAX_INVENTORY_SIZE]); 
            }

            public Player(uint playerId, string playerName, Race race, uint playerLevel, uint exp, uint guildID, uint[] gear, List<uint> inventory)
            {
                this.playerId = playerId;
                this.playerName = playerName;
                this.race = race;
                this.playerLevel = playerLevel;
                this.exp = exp;
                this.guildID = guildID;
                this.gear = new uint[GEAR_SLOTS]; 
                this.inventory = new List<uint>(new uint[MAX_INVENTORY_SIZE]); 
            }
            
        }

    }
}