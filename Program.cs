using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chris_Parker_Assign1
{
    class Program
    {
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
                set { type = 0; }
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

            public Item ()
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

            public Item(uint id, string name, ItemType type, uint ilvl, uint primary, uint stamina, uint requirement,string flavor)
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

            public int CompareTo (Object alpha)
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
        static void Main(string[] args)
        {
            Item test = new Item ();
            test.Name = "Big Fucking Sword";

            Item test2 = new Item();
            test2.Name = "Rusty Dagger";

            Item test3 = new Item();
            test3.Name = "Merc Treads";

            List<Item> items = new List<Item>
            {
                test, test2, test3
            };

            items.Sort();
            items.ForEach(Item => Console.WriteLine(Item.ToString()));

        }
    }
}
