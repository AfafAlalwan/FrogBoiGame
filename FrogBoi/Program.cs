using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace FrogBoiProject
{
    public struct Item
    {
        public string itemName { get; set; }
        public int itemPrice { get; set; }
        public string itemQuote { get; set; }
        public Item(string name, int price, string quote)
        {
            itemName = name;
            itemPrice = price;
            itemQuote = quote;
        }
    }
    class Program
    {
        public static string playerVoice;
        public static int Gold { get; set; }
        public static float fFrogBoiHP { get; set; }
        public static Random r = new Random();

        public static Item[]
            weapons = new Item[]{ new Item("Frog Fists", 0,""),
                                  new Item("Meat Sword", 50,"You bought Meat Sword. Dont eat your own sword now."),
                                  new Item("Lizard Tail", 30,"You bought Lizard Tail. I wonder if lizard regrew this later on"),
                                  new Item("Sling Shot",40,"You bought Slingshot. Carefull now you can blind someone with that.") },
            items = new Item[]{   new Item("Mount Dew", 10,"You bought Mountdew. Fresh Cold tasty beverage."),
                                  new Item("Fried Chicken", 40,"You bought Fried Chicken. Spicey just like colonel used to make."),
                                  new Item("Air Pods", 15,"You bought Air Pods. You can jam as you fight now. Carefull don't loose em.") },
            pacifist = new Item[]{new Item("Protein Shake", 20,""),
                                  new Item("Land Registers", 22,""),
                                  new Item("Speech Cassette", 25,"") },
            Armors = new Item[] { new Item("Frog Skin", 0, ""),
                                  new Item("Leather Jacket", 20,"You bought Leather Jacket. Now you look dashing."),
                                  new Item("Metal Barrel Armor", 40,"You bought Barrel Armor. You look like a beer can"),
                                  new Item("DANK Bikini Armor", 60,"You bought Bikini Armor. Who said these are not protective!?") };

        //Boolean for Game loop
        public static bool playing = true;
        //Bool for mainMenu
        public static bool gameStarted = false;
        // bool for villages
        public static bool visited = false, visited2 = false, visited3 = false;
        //Stat Variables
        public static int fStrength = 2, fDexterity = 2, fConstitution = 2, tempDex, tempStr;


        // inventory
        public static LinkedList<Item> Inventory = new LinkedList<Item>();
        public static void Market()
        {

            bool inMarket = true;
            int buy;

            writeColor($"Welcome to the Market.", 11);

            while (inMarket)
            {
                writeColor($"What would you like to buy Weapons or Armors or Items? (you have {Gold} gold) ", 11);
                playerVoice = (Console.ReadLine()).ToUpper();

                if (playerVoice == "WEAPONS")
                {
                    //show weapons
                    for (int i = 1; i < weapons.Length; i++)
                    {

                        Console.WriteLine(">> " + i + ". " + weapons[i].itemName
                                          + "\t" + weapons[i].itemPrice + " Gold");
                    }
                    Console.WriteLine(">> -1. Go back");
                    bool done = false;
                    do
                    {
                        try
                        {
                            playerVoice = Console.ReadLine();
                            buy = Int32.Parse(playerVoice);

                            // -1 if nth 
                            if (buy == -1)
                            {
                                return;
                            }
                            else
                            {
                                //check if there's enough gold
                                if (weapons[buy].itemPrice <= Gold)
                                {
                                    // add to inventory the item the player bought
                                    Inventory.AddFirst(weapons[buy]);
                                    Gold -= weapons[buy].itemPrice;
                                    dialogue(weapons[buy].itemQuote, 2);
                                }
                                else
                                {
                                    writeColor("You can not afford this weapon...", 14);
                                }
                                if (buy > 3 || buy <= 0)
                                {
                                    dialogue("Invalid option, come again", 12);
                                    Market();
                                }

                            }

                            done = true;
                        }
                        catch (FormatException e)
                        {
                            writeColor("Type the number of the weapon you want.", 12);
                        }
                    } while (!done);

                }
                else if (playerVoice == "ARMORS")
                {
                    //show Armors
                    for (int i = 1; i < Armors.Length; i++)
                    {
                        Console.WriteLine(">> " + i + ". " + Armors[i].itemName
                                          + "\t" + Armors[i].itemPrice + " Gold");
                    }
                    Console.WriteLine(">> -1. Go back");

                    bool done = false;
                    do
                    {
                        try
                        {
                            playerVoice = Console.ReadLine();
                            buy = Int32.Parse(playerVoice);

                            // -1 if nth 
                            if (buy == -1)
                            {
                                return;
                            }
                            else
                            {
                                //check if there's enough gold
                                if (Armors[buy].itemPrice <= Gold)
                                {
                                    // add to inventory the item the player bought
                                    Inventory.AddFirst(Armors[buy]);
                                    Gold -= Armors[buy].itemPrice;
                                    dialogue(Armors[buy].itemQuote, 2);

                                }
                                else
                                {
                                    writeColor("You can not afford this portion...", 14);
                                }
                                if (buy > 3 || buy <= 0)
                                {
                                    dialogue("Invalid option, come again", 12);
                                    Market();
                                }

                            }
                            done = true;
                        }
                        catch (FormatException e)
                        {
                            writeColor("Type the number of the portion you want.", 12);
                        }
                    } while (!done);

                }
                else if (playerVoice == "ITEMS")
                {
                    //show items
                    for (int i = 0; i < items.Length; i++)
                    {
                        int n = 1 + i;
                        Console.WriteLine(">> " + n + ". " + items[i].itemName +
                                             "\t" + items[i].itemPrice + " Gold");
                    }
                    Console.WriteLine(">> -1. Go back");

                    bool done = false;
                    do
                    {
                        try
                        {
                            playerVoice = Console.ReadLine();
                            buy = Int32.Parse(playerVoice);

                            // -1 if nth 
                            if (buy == -1)
                            {
                                return;
                            }
                            else
                            {
                                //check if there's enough gold
                                if (items[buy].itemPrice <= Gold)
                                {
                                    // add to inventory the item the player bought
                                    Inventory.AddFirst(items[buy]);
                                    Gold -= items[buy].itemPrice;
                                    dialogue(items[buy].itemQuote, 2);
                                }
                                else
                                {
                                    writeColor("You can not afford this item...", 14);
                                }

                                if (buy > 3 || buy <= 0)
                                {
                                    dialogue("Invalid option, come again", 12);
                                    Market();
                                }
                            }
                            done = true;
                        }
                        catch (FormatException e)
                        {
                            writeColor("Type the number of the item you want.", 12);
                        }
                    } while (!done);
                }
                else if (playerVoice == "EXIT" || playerVoice == "LEAVE"
                          || playerVoice == "QUIT" || playerVoice == "BACK" || playerVoice == "GO BACK")
                {
                    inMarket = false;
                    return;
                }
                else
                {
                    writeColor("Sorry we don't sell that.. we only sell weapons," +
                               " armors, items", 11);

                }
            }


        }
        public static void Slow(String s)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            int current = 0;
            while (true)
            {
                float total = sw.ElapsedMilliseconds;
                int iteration = (int)Math.Floor(total / 500);

                if (current < iteration)
                {
                    current = iteration;
                    if (current > s.Length)
                    {
                        sw.Stop();
                        break;
                    }
                    Console.Clear();
                    Console.WriteLine(s.Substring(0, current));
                }
            }
        }

        public static void writeColor(string s, int color)
        {
            switch (color)
            {

                case 2:
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    break;
                case 9:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case 10:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case 11:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
                case 12:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case 13:
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    break;
                case 15:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;

            }

            Console.WriteLine(s);
            Console.ResetColor();

        }

        public static void dialogue(String s, int color)
        {
            writeColor(s, color);
            Console.ReadKey();
            Console.Clear();
        }

        public static void chooseWeapon()
        {
            Console.WriteLine("Choose your weapon");
            for (int i = 0; i < weapons.Length; i++)
            {

                if (Inventory.Contains(weapons[i]))
                {
                    Console.Write($">> {weapons[i].itemName} \t");
                }
            }

            playerVoice = Console.ReadLine().ToUpper();
            switch (playerVoice)
            {
                // returns the amount of damage the player's attack will give
                case "MEAT SWORD":
                    fStrength = r.Next(1, 9) + tempStr; //1D8
                    dialogue($"Using  {weapons[1].itemName}", 2);
                    break;
                case "LIZARD TAIL":
                    fStrength = r.Next(1, 5) + tempStr; //1D4
                    dialogue($"Using  {weapons[2].itemName}", 2);
                    break;
                case "SLING SHOT":
                    fStrength = r.Next(1, 7) + tempStr; //1D6
                    dialogue($"Using  {weapons[3].itemName}", 2);
                    break;
                case "FROG FISTS":
                    fStrength = tempStr;
                    dialogue($"Using  {weapons[0].itemName}", 2);
                    break;
                default:
                    Console.WriteLine("Type something you have.");
                    chooseWeapon();
                    break;

            }
        }

        public static void openInventory()
        {

            Console.WriteLine("Type the name of the item you want to use, or type 'Close' to close inventory");
            foreach (Item i in Inventory)
            {

                Console.Write(i.itemName + "\t");
            }
            playerVoice = Console.ReadLine().ToUpper();


            switch (playerVoice)
            {
                case "CLOSE":
                    return;
                case "MOUNT DEW":
                    fFrogBoiHP += 20;
                    Inventory.Remove(items[0]);
                    Console.WriteLine("You drank a can of Dew (Healed 20 Hp).");
                    dialogue($"Frog Boi HP is {fFrogBoiHP} !", 2);
                    break;
                case "FRIED CHICKEN":
                    fFrogBoiHP = 110;
                    Inventory.Remove(items[1]);
                    Console.WriteLine("You ate a fried Chicken (Healed to full HP)");
                    dialogue($"Frog Boi HP is {fFrogBoiHP} !", 2);
                    break;
                case "AIR PODS":
                    //adds + 1 to all damage done.
                    fStrength += 1;
                    break;
                case "LEATHER JACKET":
                    //AC(Armorclass) 12 + dex 
                    fDexterity = tempDex + 12;
                    break;
                case "METAL BARREL ARMOR":
                    //AC 15 + dex 
                    fDexterity = tempDex + 15;
                    break;
                case "DANK BIKINI ARMOR":
                    //AC 16 + dex  
                    fDexterity = tempDex + 16;
                    break;
                default:
                    Console.WriteLine("You can't use this now.");
                    openInventory();
                    break;
            }
        }
        public static void fight(int enemyHP, string boss, string s)
        {

            Console.WriteLine("Type 'Inventory' to open inventory," +
                " 'Weapon' to choose a weapon, 'Market' to go to market, " +
                "'Fight' if you are ready...");
            playerVoice = Console.ReadLine().ToUpper();
            if (playerVoice == "INVENTORY")
                openInventory();
            else if (playerVoice == "WEAPON")
                chooseWeapon();
            else if (playerVoice == "MARKET")
                Market();
            else if (playerVoice == "FIGHT")
            {
                int damage, min, max, snv;
                damage = min = max = snv = 0;

                dialogue(s, 2);
                switch (boss)
                {
                    case "Gigachad":
                    case "Wojak":
                        min = 1; max = 7; snv = 3;
                        break;
                    case "Queen":
                        min = 1; max = 9; snv = 4;
                        break;
                    case "Gnome Child":
                        min = 1; max = 9; snv = 5;
                        break;
                }
                while (fFrogBoiHP >= 0 && enemyHP >= 0) //fixed
                {

                    //frog boi attacks
                    enemyHP -= r.Next(1, 21) + fStrength;
                    //what to say after each attack?
                    dialogue($"Frog boi attacked. " +
                        $"\n{boss} HP is {enemyHP} Frog boi HP is  {fFrogBoiHP}", 2);

                    damage = r.Next(min, max) + snv;
                    int D20 = r.Next(1, 21); //fixed
                    if (D20 > fDexterity)
                    {
                        // frog gets hit
                        fFrogBoiHP -= damage;
                        // what to say after each hit? 
                        dialogue($"{boss} attacked Frog boi. " +
                            $"\n{boss} HP is {enemyHP} Frog Boi HP is {fFrogBoiHP}", 12);
                    }
                }

                if (fFrogBoiHP == 0)
                {
                    //frog boi died what do we say

                    dialogue("Frog Boi died. ", 12);

                    playing = false;
                    System.Environment.Exit(1);
                }
                else
                    return;
            }

            fight(enemyHP, boss, s);
        }
        public static void fight2()
        {
            int dice, attacks = 0;

            //Player Roll's
            dialogue("Frog Boi rolled the dice", 2);
            dice = r.Next(1, 5);
            dialogue($"Frog Boi Rolled {dice}", 2);

            while (attacks != 2)
            {
                if (dice >= 3)
                {
                    //Player Attacks
                    dialogue("Frog Boi managed to hit the enemy!", 2);
                    attacks++;
                }
                if (attacks == 2)
                {
                    break;
                }
                else
                    dialogue("Frog Boi missed!", 2);

                //Enemy Roll's
                dialogue("*Enemy is getting ready for an attack!*", 13);
                dialogue("Enemy rolled the dice.", 13);
                dice = r.Next(1, 5);
                dialogue($"Enemy Rolled {dice}", 13);

                if (dice >= 3)
                {
                    //Enemy Attacks  
                    dialogue("Enemy managed to hit Frog Boi!", 13);
                    //Insert the damage given to the Frogboi down in the line.
                    fFrogBoiHP -= 2;
                    dialogue($"Frog Boi HP is {fFrogBoiHP} !", 2);
                }
                else
                    dialogue("Enemy missed!", 13);

            }
            dialogue("Enemy lost !", 2);

        }
        public static void Intro()
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            writeColor(
                "       ______ _____   ____   _____   ____   ____ _____             " +
                "\n      |  ____|  __ \\ / __ \\ / ____| |  _ \\ / __ \\_   _|            " +
                "\n      | |__  | |__) | |  | | |  __  | |_) | |  | || |              " +
                "\n      |  __| |  _  /| |  | | | |_ | |  _ <| |  | || |              " +
                "\n      | |    | | \\ \\| |__| | |__| | | |_) | |__| || |_             " +
                "\n      |_|    |_|  \\_\\\\____/ \\_____| |____/ \\____/_____|            ", 15);


            writeColor("Welcome to Memey Adventures Of Frogboi\n", 15);
            mainMenu();

            Console.Clear();

            Gold = 60;
            Inventory.AddFirst(Armors[0]);
            tempDex = fDexterity;
            fDexterity += 10;
            Inventory.AddFirst(weapons[0]);
            tempStr = fStrength;
            fStrength += 2;
            //Intro
            dialogue("Winter has passed and snows have melted. You the little frogboi woken up from" +
                " your sleep for another long gaming session.", 15);
            dialogue("After getting off the bed you look around your little house for some Doritos " +
                "and Mountdew hoping you could get some food before gaming.", 15);
            dialogue("You also remember you haven't checked the dank memes in your " +
                "friend chat group yet.", 15);
            dialogue("As you search around you realise that you only have 2 package of Doritos, " +
                "2 Mountdew cans and only 2 notifications on your phone but you are also running out of time.", 15);
            dialogue("Raid is about the start and you are both low on stock and" +
                " don't have time to sustain yourself with all so you need to make a drastic choice here.", 15);
            dialogue("What will you choose Frogboi?", 15);
            dialogue("[INFO] Your choice in these items will determine your stats." +
                " You have 2 choices to make. Type 'A' for Doritos (Strenght), 'B' for Mountdew (Dexterity)," +
                " 'C' for Dank Memes (Constitution)\nPress any key to continue...", 15);

            //amount of times stats can be assigned. Changing this to break the loop
            float fAssignTime = 0;
            while (fAssignTime <= 1)
            {
                Console.Clear();

                // prompt the player to choose a stat 
                Console.WriteLine("[Reminder] Str effect your hit capability and damage," +
                    " Dex effects your Dodge chance, Con Effect your HP");
                Console.WriteLine("[İNFO] Type 'A' for Doritos (Strenght), " +
                    "'B' for Mountdew (Dexterity), 'C' for Dank Memes (Constitution) ");

                //Player HP code
                fFrogBoiHP = 10 * fConstitution;

                //Code for player Choice stat increase
                playerVoice = Console.ReadLine().ToUpper();
                if (playerVoice == "A")
                {
                    fStrength += 2;
                    fAssignTime += 1;
                    dialogue("You munch on some nice nacho cheese Doritos." +
                        " You feel your strength return to you.", 2);
                }
                else if (playerVoice == "B")
                {
                    fDexterity += 2;
                    fAssignTime += 1;
                    dialogue("You chug a Mountdew can. Sugar gives you stamina.", 2);
                }
                else if (playerVoice == "C")
                {
                    fConstitution += 2;
                    fAssignTime += 1;
                    dialogue("You sustain your will to live by laughing at dank memes send by friends." +
                        " You feel you can take on everything.", 2);
                }
                else
                {
                    writeColor("Choose an available stat..", 10);
                }

            }


            //Village
            dialogue("After having rather a fun gaming session with friends you realize" +
                " its time to go shopping before shops close.", 15);
            dialogue("You hop on your unicycle and roll away into the near village of" +
                " Pepe the frogs", 15);
            dialogue("'1 Hour Later'", 15);
            dialogue("As you arrive to the village you see the rare Pepes walking on the street" +
                " with bags full of Doritos and Mountdew", 15);
            dialogue("One of them sees you and pokes other", 15);
            dialogue("Pepe1: Here come that boi", 9);
            dialogue("Other Pepe turns around and look at you", 15);
            dialogue("Pepe2: Oh sh!t waddup", 9);
            dialogue("As other Pepes of the village hear this they start making comments" +
                " as you rollin down the street", 15);
            dialogue("Pepe3: Watch him rolling", 9);
            dialogue("Pepe4: Watch him go", 9);
            dialogue("Comments keep coming as you rolling to the beat", 15);
            dialogue("as you make it to the market the Shop Keeper notices you", 15);
            writeColor("Shop Keeper: oh sh!t whaddup", 9);
            Console.ReadKey();
            Console.WriteLine("[Narrator] Choose A Dialogue Option\nA: Shop Keeper I need your" +
                " strongest Mountdew\nB: Hey man you got any of them Mountdews?");
            playerVoice = Console.ReadLine().ToUpper();

            while (playing)
            {
                if (playerVoice == "A")
                {
                    Console.Clear();
                    dialogue("FrogBoi: Shop Keeper I need your strongest Mountdew", 10);
                    dialogue("Shop Keeper: My Dews are too strong for you, Frogboi.", 9);
                    dialogue("FrogBoi: Shop Keeper I'm going into a gaming session I need your " +
                        "strongest Mountdew", 10);
                    dialogue("Shop Keeper: My Dews would kill you, Frogboi. You cannot handle my Dews.", 9);
                    dialogue("FrogBoi: Shop Keeper Enough of these games. I'm going into a gaming " +
                        "session and I need your strongest Mountdew", 10);
                    dialogue("Shop Keeper: You don't know what you ask, Frogboi. My strongest " +
                        "Dews will kill a dragon, let alone a frog. You need a seller that sells " +
                        "weaker Dews, because my Dews are too strong.", 9);
                    dialogue("FrogBoi: Shop Keeper, what do I have to tell you to get your Mountdews?" +
                        " Why won't you trust me with your strongest Dews, Shop Keeper?" +
                        " I need them if I'm to be successful in the gaming session!", 10);
                    dialogue("Shop Keeper: I can't give you my strongest Dews because my strongest Dews" +
                        " are only for the strongest beings and you are of the weakest.", 9);
                    dialogue("FrogBoi: You've had your say, Shop Keeper but I'll have mine." +
                        "'Your eyes get teary' You're a rascal, you're a rascal with no respect for Gamers." +
                        "No respect for anything... except your Dews!", 10);
                    dialogue("Shop Keeper: Why respect Gamers... when my Dews can do anything that you can.", 9);
                    dialogue("FrogBoi: I'll go elsewhere for my Dews and I'll never come back!", 10);
                    dialogue("Shop Keeper: Good. You're not welcome here! My Dews are only for the" +
                        " strongest and you're clearly are not of the strongest you're clearly the weakest.", 9);
                    Console.WriteLine("[Narrator] Choose An Action\nA: Steal his Dews and " +
                        "run away[Get 2 Dews]\nB: Leave in defeat [Get no Dews]");
                    playerVoice = Console.ReadLine().ToUpper();
                    while (playing)
                    {
                        if (playerVoice == "A")
                        {
                            Console.Clear();
                            //Add 2 Dews in inventory

                            dialogue("You stole his dews and ran into the dark " +
                                "alleys never to be seen by him again", 2);
                            dialogue("You are back to your travels", 2);
                            Inventory.AddFirst(items[0]);
                            Inventory.AddFirst(items[0]);
                            break;
                        }
                        else if (playerVoice == "B")
                        {
                            Console.Clear();
                            dialogue("You cry outside the shop and back " +
                                "to your travel empty handed", 2);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Choose a valid option.");
                            playerVoice = Console.ReadLine().ToUpper();
                        }
                    }
                    break;
                }
                else if (playerVoice == "B")
                {
                    Console.Clear();
                    dialogue("FrogBoi: Hey man you got any of them Mountdews?", 10);
                    dialogue("Shop Keeper: Sh!t fam have you been followed?", 9);
                    dialogue("FrogBoi: Nah nah we good", 10);
                    dialogue("Shop Keeper: İght ı got whatcha need", 9);
                    dialogue("As transaction of money and Mountdew happens you see " +
                        "a pepe with a blue cap at the window watching you and the shop keeper", 15);
                    dialogue("FrogBoi: Oh sh!t its the cops!!! Run!! ", 10);
                    dialogue("You run into the street and hop to your unicycle" +
                        " and you see the cop following you with his tricycle making" +
                        " siren noises with his mouth", 15);
                    dialogue("Cop: WOO WEEE WOOO WEEE Pull over!!", 9);
                    Console.WriteLine("[Narrator] Choose An Action\nA: Pull your Glock" +
                        " and shot at the cop\nB: Yell 'YOU'LL NEVER CATCH ME ALIVE'");
                    playerVoice = Console.ReadLine().ToUpper();

                    while (playing)
                    {
                        if (playerVoice == "A")
                        {
                            //Add 2 Dews in inventory
                            Inventory.AddFirst(items[0]);
                            Inventory.AddFirst(items[0]);
                            // quote

                            Console.Clear();
                            dialogue("You fire at the cop and manage to hit his front wheel." +
                                " Cop crashes and dissapeares from sight", 2);
                            dialogue("You are back to your travels", 2);
                            break;
                        }
                        else if (playerVoice == "B")
                        {
                            Console.Clear();
                            dialogue("While yelling you loose your balance and crash into a " +
                                "cabbage sellers table", 2);
                            dialogue("Cabage Seller: MY CABBAGES!!", 9);
                            dialogue("Cop brutally beat you and arrest you." +
                                " As you getting pulled into jail you see Pepes protesting police brutality.", 15);
                            dialogue("You are sentece to jail for 5 years", 15); // slow??
                            dialogue("'5 YEARS LATER'", 15);
                            dialogue("You finally out of jail and free to travel again." +
                                " You might have lost some of your years but at least you got cool tattoos " +
                                "and a sick beard now", 15);
                            dialogue("You also worked out a bit in there so now you got more muscles", 15);
                            dialogue("You loose some Dex but gain Str and Con", 15);
                            fDexterity -= 2; fStrength += 1; fConstitution += 1;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Choose a valid option.");
                            playerVoice = Console.ReadLine().ToUpper();
                        }
                    }
                    break;
                }
                else
                {
                    Console.WriteLine("Choose a valid option.");
                    playerVoice = Console.ReadLine().ToUpper();
                }
            }

            dialogue("As you leave the village you feel bit weird.", 15);
            dialogue("You feel disturbance in the Dankness", 15);
            dialogue("While you are trying to focus your Dankness to this " +
                "feeling bunch of Furrets jump on you", 15);
            dialogue("They have gone feral and try to rip you apart but you" +
                " managed to cycle away from their attacks.", 15);
            dialogue("Furrets are meant to be peaceful creatures but these " +
                "have gone mad with lack of Dankness", 15);
            dialogue("You manage to defeat them without killing them after a long fight.", 15);
            dialogue("You think to yourself 'This isn't normal something" +
                " must be wrong with Dankness'", 10);
            dialogue("'I should check on my brother Gnome Child and " +
                "The Memelords to see whats going on'", 10);
            dialogue("'I fear something bad might have happened to them'", 10);
            dialogue("You turn around and start traveling towards the Memelords' lands", 15);
            dialogue("You can't help to notice that a brown 2 legged" +
                " creature with no arms has been watching you since you left home.", 15);
            dialogue("But you do not sense malicious intend from his Dank aura.", 15);
            dialogue("He might be dangerous but he is no threat at the moments so you leave him alone.", 15);
        }
        public static void mainMenu()
        {
            while (playing)
            {
                if (gameStarted == true)
                {
                    Console.WriteLine("Press 'C' to Continue the game");
                }
                else
                {
                    Console.WriteLine("Press 'P' to Start playing");
                }

                Console.WriteLine("Press 'H' for game guide");
                Console.WriteLine("Press 'E' for existing the game");
                playerVoice = Console.ReadLine().ToUpper();

                if (playerVoice == "P")
                {
                    gameStarted = true;
                    playing = true;
                    return;
                }
                else if (playerVoice == "C")
                    return;
                else if (playerVoice == "H")
                {
                    //Game Guide

                    //Game Explained
                    Console.WriteLine("Memey Adventures Of Frogboi is a Partialy Linear, Text Based," +
                        " RPG where you play as a little frog who loves to game and drink Mountdew." +
                        "\nThrough your journey in Memeland you will encounter social and combat encounters" +
                        " where you need to plan your strategy to overcome.\nThese encounters determined by " +
                        "rolls made by The Game.");
                    Console.WriteLine("");

                    //Combat Explained
                    Console.WriteLine("COMBAT:\nCombat of MAOF is inspired by the table top rpg classic" +
                        " Dungeons & Dragons.\nCombat will use a d20 system where you roll to hit and damage." +
                        " After rolls depending on the stats of your character there will be bonuses added " +
                        "to the result of your roll.\nThe combat continues in a turn based matter with Frogboi" +
                        " always having the first initive until combat ends.");

                    Console.WriteLine("\nTo hit an enemy player must roll same or higher than the AC(Armor Class)" +
                        " of the enemy. After a hit is done the damage dice can be rolled according to the weapon.");
                    Console.WriteLine("");

                    //Stats Explained
                    Console.WriteLine("STATS:\nStats of your character will effect the combat phase drasticaly so pick" +
                        " wisely.\nStrength: Amount of strength you have will be added as bonus to your base damage" +
                        " and result of your dice roll for hitting the enemy.\nDexterity: Amount of dexteriy get added " +
                        "straight into your armor class to make you get hit harder.\nConstitution: Constitution get " +
                        "multiplied by 10 to make up your HP.");
                    Console.WriteLine("");

                    //Pacifist Ending Guide
                    Console.WriteLine("Pacifist route:\nIn this game your actions have consequences.\n" +
                        "Through these actions, the ending of the game will change.\n" +
                        "In this game, you can choose a pacifist route if you have certain objects.\n" +
                        "If the player has a certain object they can sway enemy bosses, and therefore gain their help," +
                        " without having to fight them.\n" +
                        "These objects can be bought from the market with the currency that the player earned " +
                        "through playing the game.");
                    Console.WriteLine("");
                    Console.ReadKey();
                    mainMenu();
                    break;
                }
                else if (playerVoice == "E")
                {
                    // Exit game
                    Console.WriteLine("bye have a great time");


                    //ADD CREDİTS HERE WİTH FUNNY JOB DESCRİPTİON FOR EVERYONE

                    playing = false;
                    System.Environment.Exit(1);
                }
            }

        }

        public static void Villages()
        {
            playerVoice = Console.ReadLine();
            Console.Clear();
            switch (playerVoice)
            {
                case "1":
                    if (!visited)
                    {
                        Gigachad();
                    }
                    else
                    {
                        Console.WriteLine("You don't have anything left to do there Frog Boi...");
                        goto default;
                    }
                    visited = true;
                    goto default;

                case "2":
                    if (!visited2)
                    {
                        Elisebeth();
                    }
                    else
                    {
                        Console.WriteLine("You don't have anything left to do there Frog Boi...");
                        goto default;
                    }
                    visited2 = true;
                    goto default;

                case "3":
                    if (!visited3)
                    {
                        Wojak();
                    }
                    else
                    {
                        Console.WriteLine("You don't have anything left to do there Frog Boi...");
                        goto default;
                    }
                    visited3 = true;
                    goto default;
                case "M":
                    mainMenu();
                    goto default;

                default:
                    // if all villages where visited then return back to the original game loop to meet the final boss
                    if (visited == true && visited2 == true && visited3 == true)
                        break;
                    Console.WriteLine("Choose where you want to go\n" +
                        ">>1.Gigachad King of the Cheems\n" +
                        ">> 2.Queen Elisabeth the Ancient One\n" +
                        ">>3.Land of Wojak the Depressed One\n(Type M for Main Menu)");
                    Villages();
                    break;

            }
        }

        public static void Gigachad()
        {
            //Village In The Land of Gigachad King 
            dialogue("You arrive to the land of Gigachad." +
                " You see a village in the distant.", 15);
            dialogue("You hop on your unicycle and roll away into the village of" +
                " Swole Doges", 15);
            dialogue("'Some time Later'", 15);
            dialogue("As you arrive to the village you see the Swole Doges walking on the street" +
                " with bags full of dumbbells and protein shakes", 15);
            dialogue("One of them sees you and bumps other", 15);
            dialogue("Doge1: Wow, such non-mascular Frog Boi.", 9);
            dialogue("Other doge turns around and look at you", 15);
            dialogue("Doge2: Such Frog Boi.", 9);
            dialogue("As other Swole Doges of the village hear this they start making comments" +
                " as you rollin down the street", 15);
            dialogue("Doge3: Wow, such rolling!", 9);
            dialogue("Doge4: Much rolling down the street.", 9);
            dialogue("Comments keep coming as you rolling down the street.", 15);
            dialogue("as you make it to the market the Shop Keeper notices you", 15);
            writeColor("Shop Keeper: Henlo, much Frog Boi!", 9);
            Console.ReadKey();
            Console.WriteLine("[Narrator] Choose A Dialogue Option\nA: Shop Keeper I need the Gigachad's" +
                " Sacred Protein Shake\nB: Hey muscle-man you got that Sacred Protein Shake?");
            playerVoice = Console.ReadLine().ToUpper();

            while (playing)
            {
                if (playerVoice == "A")
                {
                    Console.Clear();
                    dialogue("FrogBoi: Shop Keeper I need the Gigachad's Sacred Protein Shake.", 10);
                    dialogue("Shop Keeper: It might much strong for you, Frogboi.", 9);
                    dialogue("FrogBoi: Shop Keeper I need the protein shake" +
                        " *THE SACRED PROTEIN SHAKE!", 10);
                    dialogue("Shop Keeper: Are you sure you can handle such poweri Frogboi?", 9);
                    dialogue("FrogBoi: Yes, Shop Keeper" +
                        " I will need it while I am facing Gigachad.", 10);
                    dialogue("Shop Keeper: I don't think you understand how strong this protein shake is" +
                        "This protein shake can only be held in the hands of a such man with much strong muscles. ", 9);
                    dialogue("FrogBoi: Shop Keeper, I think you underestimate my muscles." +
                        " I'll show you how strong my muscles are!" +
                        " *You clench your body, and your hidden muscles show up!*", 10);
                    dialogue("Shop Keeper: WOW! such muscles, much..." +
                        " STRONGNESS!", 9);
                    dialogue("FrogBoi: See how strong my muscles are?" +
                        " I hide them normally, a real chad does not need to show it off everyday." +
                        " I hope you understand now.", 10);
                    dialogue("Shop Keeper: Wowi such muscles, such chad.", 9);
                    dialogue("FrogBoi: Hmm, hmm... That's right.", 10);
                    dialogue("Shop Keeper: I understand" +
                        " you deserved it, take it, take the Sacred Protein Shake, and give him to Gigachad if you must.", 9);
                    Console.WriteLine("[Narrator] Choose An Action\nA: Take the Sacred Protein Shake, and leave" +
                        "walk out[Get Sacred Protein Shake]\nB: Take the Sacred Protein Shake, and leave with a cool JoJo pose," +
                        " while theme song plays on the background[Get Sacred Protein Shake]");
                    playerVoice = Console.ReadLine().ToUpper();
                    while (playing)
                    {
                        if (playerVoice == "A")
                        {
                            Console.Clear();
                            //Add Sacred Protein Shake in inventory
                            Inventory.AddLast(pacifist[0]);
                            dialogue("You leave the shop " +
                                "Look around, and start walking", 2);
                            dialogue("You are back to your travels", 2);
                            break;
                        }
                        else if (playerVoice == "B")
                        {
                            Inventory.AddLast(pacifist[0]);
                            Console.Clear();
                            dialogue("Wile you leave the shop, Shop Keeper, and Doges outside" +
                                " are in awe in your cool JoJo pose " +
                                "you walk into the sunset, *Insert To Be Continued Meme Here*", 2);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Choose a valid option.");
                            playerVoice = Console.ReadLine().ToUpper();
                        }
                    }
                    break;
                }
                else if (playerVoice == "B")
                {
                    Console.Clear();
                    dialogue("FrogBoi: Hey muscle-man you got that Sacred Protein Shake?", 10);
                    dialogue("Shop Keeper: Wow, such way of talk", 9);
                    dialogue("FrogBoi: Yes, you got a problem with that?", 10);
                    dialogue("Shop Keeper: Such edgeness", 9);
                    dialogue("As the conversation goes on " +
                        "Swole Doges appear in the front of the shop", 15);
                    dialogue("FrogBoi: Oh sh!t, I think they are going to bully me ", 10);
                    dialogue("You run into the street and hop to your unicycle" +
                        " and you see the Swole Doges following you with full force on their muscle-legs" +
                        " wow, such, and much screams fill your ears", 15);
                    dialogue("SwoleDoges: Wow, such weakling, come here Frogboi!!", 9);
                    Console.WriteLine("[Narrator] Choose An Action\nA: Pull your secret muscles" +
                        " and beat the Swole Doges\nB: Yell 'YOU'LL NEVER CATCH ME ALIVE, AND BULLY ME'");
                    playerVoice = Console.ReadLine().ToUpper();

                    while (playing)
                    {
                        if (playerVoice == "A")
                        {
                            //Add 2 Dews in inventory
                            Inventory.AddLast(items[0]);
                            Inventory.AddLast(items[0]);
                            Console.Clear();
                            dialogue("You turn around, clench your muscles, and hit them with all your might" +
                                " all of the them launch into the horizon just like in animes", 2);
                            dialogue("You are back to your travels", 2);
                            break;
                        }
                        else if (playerVoice == "B")
                        {
                            Console.Clear();
                            dialogue("While yelling you loose your balance and crash into a " +
                                "gym that is filled with Swole Doges", 2);
                            dialogue("Swole Doges: You interrupted our pumping iron session!!", 9);
                            dialogue("They gang-up on you, and beat you." +
                                " As you crawl on the ground, with blood all over your face.", 15);
                            dialogue("Don't mess with us again, you are hospitalized", 15); // slow??
                            dialogue("'3 MONTHS LATER'", 15);
                            dialogue("You finally healed, and free to travel again." +
                                " You might have lost some of your months but at least you got to have plastic" +
                                " surgery to fix your messed up face" +
                                "not the greatest that you ever looked, but it is what it is", 15);
                            dialogue("You also loosed some weight, as a consequence of being in the hospital bed for soo long.", 15);
                            dialogue("But you gained some extra health due to being looked after by doctors.", 15);
                            dialogue("You loose some Dex, Str but gained some Con", 15);
                            fDexterity -= 2; fStrength -= 1; fConstitution += 1;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Choose a valid option.");
                            playerVoice = Console.ReadLine().ToUpper();
                        }
                    }
                    break;
                }
                else
                {
                    Console.WriteLine("Choose a valid option.");
                    playerVoice = Console.ReadLine().ToUpper();
                }
            }

            //Encounterr
            dialogue("Frog Boi has encountered a \"Swole Doge\".", 2);
            dialogue("\"The Swole Doge\" engages Frog Boi.", 13);
            dialogue("Frog Boi gets ready for a fight.", 2);
            fight2();

            //Gigachad King Of The Cheems Fight Sequence
            dialogue("Gigachad: So you have finally came Frog Boi.", 12);
            dialogue("Gigachad: See? What happened to my muscles, they are gone, with all the dankness.", 12);
            dialogue("Gigachad: So, what it will be now, will you fight me?", 12);
            writeColor("*ProTip: You can try to sway the Gigachad by providing" +
                " him with a item that he may needs.*", 1);


            do
            {

                Console.WriteLine(">>1.Use Protein Shake?\n>>2.Fight Gigachad? ");
                playerVoice = Console.ReadLine().ToUpper();
                Console.Clear();

                if (playerVoice == "USE PROTEIN SHAKE" ||
                    playerVoice == "PRPOTEIN SHAKE" || playerVoice == "1")
                {
                    //check if it is obtained
                    if (Inventory.Contains(pacifist[0]))
                    {
                        dialogue("You gave the Protein Shake to the Gigachad.", 2);
                        dialogue("Gigachad: In the name of \"The Interdimensional Gym!\"" +
                            " Is that the \"Sacred Protein Shake\"", 12);
                        dialogue("Gigachad: Why yes, I do love protein shakes, " +
                            "how could you tell?", 12);
                        dialogue("Frog Boi: I had an instinct", 10);
                        dialogue("*Gigachad drinks the \"Sacred Protein Shake\"," +
                            " and start pumping irons.*", 12);
                        dialogue("*Gigachad evolving! Gigachad returned to his original state!*", 9);
                        dialogue("Gigachad: I am back to my original state, and a small" +
                            " portion of my dankness returned to me, even if it is for temporary.", 9);
                        dialogue("Gigachad: Thank you my small green friend." +
                            " I have decided to help you in your quest.", 9);
                        dialogue("Gigachad: But first, I need to go to \"The Interdimensional Gym!\"," +
                            " and prove \"The Cheems, and The Chads Of The Gym's\" that their king is back!", 9);
                        dialogue("*Congratulations! You made an new ally. " +
                            "Now you can call them for help in battles.*", 15);
                        Gold += 40;

                        Inventory.Remove(pacifist[0]); //make sure this works EFO! XD 
                        break;

                    }
                    else
                    {
                        dialogue("You don't have Protein Shake.", 15);
                        continue;
                    }
                }
                else if (playerVoice == "FIGHT" || playerVoice == "2" || playerVoice == "FIGHT GIGACHAD")
                {
                    dialogue("Gigachad: So, we have to fight then.", 12);
                    dialogue("Gigachad: Shame, really...", 12);

                    fight(80, "Gigachad", "*Fight Begins Against Gigachad King Of The Swole Doges*");

                    //End Of The Fight-Frog Boi Wins
                    dialogue("Gigachad: So I have lost, well giving I have lost my dankness therefore most of my muscles," +
                        " this out come wasn't suprising.", 12);
                    dialogue("Gigachad: Listen, Frog Boi! Dankness is gone, I am not sure of the reason, but it is utmost" +
                        " important that you must keep moving forward.", 12);
                    dialogue("Gigachad: You must find the reason, and put an end to this, " +
                        "so that many others won't end like me.", 12);
                    dialogue("*Gigachad turns into ashes, and ashes fly away.*", 12);
                    dialogue("*You have beaten Gigachad. Territory of \"Gigachad King Of The Swole Doges\"* is cleared.", 2);
                    Gold += 40;

                    break;

                }
                else
                {
                    Console.WriteLine("What do you mean?"); // for wrong inputs
                }
            } while (playing);

        }

        public static void Elisebeth()
        {
            //Village 2 (Village of the bongo cats)
            dialogue("You pass through war torn fields filled with" +
                " corpses that are barely recognizeable.", 15);
            dialogue("Bongo Cat left and right died with their loved " +
                "songs in their phones.", 15);
            dialogue("You feel the terror of war fill inside you as you" +
                " cycle forward", 15);
            dialogue("Few KM later", 15);
            dialogue("You come across an encampment flying the coat of arms" +
                " of the Queen", 15);
            dialogue("You approach the encampment", 15);
            dialogue("You see that the encampment is filled with Bongo cat " +
                "soldiers who are loyal to the Queen", 15);
            dialogue("Soldiers seem very proud to be here as they march to " +
                "Bongo rhythms.", 15);
            dialogue("As guards notice you they swarm around you and stop you.", 15);
            dialogue("One of them who wears a very long red coat and a huge hat " +
                "grabs you and pulls you as he marches towards" +
                " the big tent in the middle", 15);
            dialogue("FrogBoi : I'm just a traveler I haven't done anything wrong!!" +
                " Unhand me you monsters!!! [you yell]", 10);
            dialogue("You get pushed into the tent.", 15);
            dialogue("Inside the tent there is another Bongo Cat who sitting " +
                "on a dest and scribbling stuff. \nHe wears a big white victorian wig and a" +
                " officer uniform. \nNext to him there is a Pepe who is" +
                " chained to the ground by his neck", 15);
            dialogue("Officer lifts his head from his papers and looks at you." +
                " \nThen he pokes the Pepe", 15);
            dialogue("Officer: Meow \n[Pepe's Translation: You have come from afar" +
                " Frog man, what brings you here]", 9);
            dialogue("FrogBoi: I have come in search of the Queen", 10);
            dialogue("Officer: Meow \n[Pepe's Translation: Her grace is ill and the " +
                "path to her palace is blocked by these \nrebelious scums under" +
                " the command of Nyan Baron. Curse his name]", 9);
            dialogue("FrogBoi: I have no side in this conflict let me go", 10);
            dialogue("Officer: Meow \n[Pepe's Translation: That is exaclty why I need you." +
                " \nYou are just a frog, you have no reason to be part of our conflict against these" +
                " \ncolonial scums but that is why they wouldn't expect you to be an assassin]", 9);
            dialogue("FrogBoi: You want me to kill the Nyan Baron!?", 10);
            dialogue("Officer: Meow \n[Pepe's Translation: That is exactly " +
                "what I want you to do and make sure you get the Land Registers for the colonies. " +
                "\nThat is if you wish to see the Queen]", 9);
            dialogue("FrogBoi: I will do my best but not for you", 10);
            dialogue("Officer: Meow \n[Pepe's Translation: Marvelous now get out of my tent]", 9);
            dialogue("You walk out of his tent and make your way towards Nyan Baron's encampment", 15);
            dialogue("Encampment is filled with Bongo cats from all eras. " +
                "\nOld and young all standing side by side.", 15);
            dialogue("Guards lead you into Baron's tent", 15);
            dialogue("Baron is alone standing behind his desk", 15);
            dialogue("Baron: You must be the FrogBoi. \nI heard that" +
                " you were at those loyalist's camp", 9);
            writeColor("Baron: Let me guess FrogBoi they asked you to kill me\n", 9);

            Console.WriteLine("[Narrator] Choose A Dialogue Option" +
                "\nA: Yes, they did" +
                "\nB: I don't know what you talking about I'm here for the pretzels");
            playerVoice = Console.ReadLine().ToUpper();

            if (playerVoice == "A")
            {
                Console.Clear();
                dialogue("FrogBoi: Yes, they did", 10);
                dialogue("Baron: Im glad that you are a honest boi. Mr. Frog Boi", 9);
                dialogue("FrogBoi: Thank you", 10);
                writeColor("Baron: Well what will it be now Mr. Frog Boi." +
                    " \nIf you plan to kill me there is knife on the desk but " +
                    "know this you would be condeming all my people into slavery under the Queen\n", 9);
                Console.WriteLine("[Narrator} what will it be FrogBoi\nA: KILL THE BARON!" +
                    "\nB: Steal the Land Registers from his desk and run away");
                playerVoice = Console.ReadLine().ToUpper();
                if (playerVoice == "A")
                {
                    Console.Clear();
                    dialogue("You grab the knife and cut Baron's Throat", 2);
                    dialogue("Baron: [With his last breath] You doomed all Bongo Cats....", 9);
                    dialogue("You grab the Land Registers on desk and rush into the darkness", 2);
                    Inventory.AddFirst(pacifist[1]);
                    Console.WriteLine("...");
                    dialogue("Back at the Loyalist Camp", 15);
                    dialogue("Officer: Meow \n[Pepe's Translation: Ah you survived." +
                        " \nHave you brought the Land Registers? ]", 9);
                    dialogue("FrogBoi: I have but I won't be giving them to you", 10);
                    dialogue("Officer: Meow \n[Pepe's Translation: Understandable." +
                        " I shall allow you to proceed towards the Palace" +
                        " but I will be watching you FromMan.]", 9);
                    dialogue("You take you leave and proceed toward the Palace", 15);
                }
                else if (playerVoice == "B")
                {
                    Console.Clear();
                    dialogue("You steal the Land Registers and run away", 2);
                    Inventory.AddFirst(pacifist[1]);
                    dialogue("Guards Chase you but you are too fast on your Unicycle", 15);
                    dialogue("You boost toward the Palace loosing the guards", 15);
                }
            }
            else if (playerVoice == "B")
            {
                Console.Clear();
                dialogue("FrogBoi: I don't know what you talking about I'm here for the pretzels", 10);
                dialogue("Baron: My bad I misstook you for someone else move along please", 9);
                dialogue("Soldiers lead you out of encampment", 15);
                dialogue("You managed the cross the gruesome civil war between" +
                    " Bongo cats now you can proceed towards Queen's Palace", 15);
            }
            //Encounterr
            dialogue("Frog Boi has encountered a \"Furret\".", 2);
            dialogue("\"Furret\" engages Frog Boi.", 13);
            dialogue("Frog Boi gets ready for a fight.", 2);
            fight2();

            //Land of Queen Elisabeth The Ancient One Fight Sequence
            dialogue("Queen Elisabeth: Welcome to my domain Frog Boi.", 12);
            dialogue("Queen Elisabeth: As you can see all of my colonies are gone," +
                " with my dankness.", 12);
            dialogue("Queen Elisabeth: So, what it will be now, will you fight me?", 12);
            dialogue("*ProTip: You can try to sway the Queen Elisabeth" +
                " by providing her with an item that she may need.*", 1);

            do
            {
                //Land Registers or fight?
                //same comments as the previous
                Console.WriteLine(">>1.Use Land Registers?\n>>2.Fight Queen Elisabeth? ");
                playerVoice = Console.ReadLine().ToUpper();
                Console.Clear();

                if (playerVoice == "USE LAND REGISTERS" || playerVoice == "LAND REGISTERS" || playerVoice == "1")
                {
                    if (Inventory.Contains(pacifist[1]))
                    {
                        dialogue("You gave the Land Registers to the Queen Elisabeth.", 2);
                        dialogue("Queen Elisabeth: May God bless me!", 12);
                        dialogue("Queen Elisabeth: My colonies, are you really " +
                            "returning them to their rightfull owner.", 12);
                        dialogue("Frog Boi: Yes, they are back at your hands all right.", 10);
                        dialogue("*Queen Elisabeth takes the Land Registers, and signs them again.*", 12); // slow?
                        dialogue("*Queen Elisabeth evolving! Queen Elisabeth returned to his original state!*", 9);
                        dialogue("Queen Elisabeth: I am back to my original state, and a small portion of my dankness returned to me," +
                            " even if it is for temporary.", 9);
                        dialogue("Queen Elisabeth: Thank you my small green friend. I have decided" +
                            " to help you in your quest.", 9);
                        dialogue("Queen Elisabeth: But first, I need to get in front of my people, " +
                            "and show them that their eternal queen is back!", 9);
                        dialogue("*Congratulations! You made an new ally. Now you can call them for help in battles.*", 2); // slow?
                        Gold += 40;
                        break;
                    }
                    else
                    {
                        dialogue("You don't have Land Registers.", 15);
                        continue;
                    }
                }
                else if (playerVoice == "FIGHT" || playerVoice == "2" || playerVoice == "FIGHT QUEEN ELISABETH")
                {
                    dialogue("Queen Elisabeth: So, we have to fight then.", 12);
                    dialogue("Queen Elisabeth: Oh my goodness...", 12);

                    fight(45, "Queen", "*Fight Begins Against Queen Elisabeth The Ancient One*");

                    //End Of The Fight-Frog Boi Wins
                    dialogue("Queen Elisabeth: So I have lost, well giving I have lost my dankness, this out come wasn't suprising.", 12);
                    dialogue("Queen Elisabeth: Listen, Frog Boi! Dankness is gone, I am not sure of the reason, but it is utmost " +
                        "important that you must keep moving forward.", 12);
                    dialogue("Queen Elisabeth: You must find the reason, and put an end to this, so that many others won't end like me.", 12);
                    dialogue("*Queen Elisabeth takes a one last sip from her tea with milk.*", 12);
                    dialogue("*Queen Elisabeth turns into ashes, and ashes fly away.*", 12);
                    dialogue("*You have beaten Queen Elisabeth. Territory of \"Queen Elisabeth The Ancient\"* is cleared.", 2); //slow?
                    Gold += 40;

                    break;

                }
                else
                {
                    Console.WriteLine("What do you mean?"); // for wrong inputs
                }

            } while (playing);

        }

        public static void Wojak()
        {

            // Village 3 Wojack's Land (Village of the Cheems)
            dialogue("As you travel through the land of Wojak you" +
                " encounter a village full of Cheems", 15);
            dialogue("They speak in a weird form of language which is " +
                "quiet hard to understand for you.", 15);
            dialogue("As you approach one of the Cheems walks towards you" +
                " and stops you. He has a blue cap which might indicate he is a cop.", 15);
            writeColor("Blue Cap Cheems: Ellö ellö ellö, whas all dis then\n", 9);
            Console.WriteLine("[Narrator] Choose A Dialogue Option" +
                "\nA: I dont speak Cheemglish.\n" +
                "B: Just passing through officer");
            playerVoice = Console.ReadLine().ToUpper();

            if (playerVoice == "A")
            {
                Console.Clear();
                dialogue("Blue Cap Cheems: thamt wömt do pal." +
                    " Dis aim't nö töwm for nö cheems", 9);
                dialogue("FrogBoi: What?", 10);
                dialogue("Blue Cap Cheems: Gow on thenm git, Git!!." +
                    " [as he shooes you away]", 9);
                dialogue("You realize he doesn't want you there", 15);
                dialogue("FrogBoi: I'm looking for a way to Wojack's Cave" +
                    " I don't want to hurt you", 10);
                dialogue("Blue Cap Cheems: [Gets teary] We habe already beem hurt fromb boi." +
                    " Swole Doges raided our vibbage", 9);
                dialogue("Blue Cap Cheems: Swole Doges are bad." +
                    " They be bullying us [he looks breaks down in tears]" +
                    " [points towards the mountains]", 9);
                dialogue("Blue Cap Cheems: Wojak himdes im moumtains. Savem us fromb boi", 9);
                dialogue("FrogBoi: I have no idea what you just said " +
                    "but dont worry I will fix this.", 10);
                dialogue("You take your leave.", 15);
                dialogue("On your way out of the village you grab a Cassete thats been thrown out", 15);
                Inventory.AddFirst(pacifist[2]);
            }
            else if (playerVoice == "B")
            {
                Console.Clear();
                dialogue("Blue Cap Cheems: You Woat!? You got em loicence for thamt?", 9);
                dialogue("You check your pockets but you are not even citizen of " +
                    "this village so you don't have a licence for passing through.", 15);
                dialogue("FrogBoi: Umm.... No.", 10);
                dialogue("Blue Cap Cheems: You cam't be passing througmh them old chapm", 9);
                dialogue("he grabs you by the unicycle and starts draging you across the town", 15);
                dialogue("Cheems around don't pay attention to you" +
                    " since most of them dont have licence to pay attention to you.", 15);
                dialogue("You manage to grab a Cassete thats " +
                    "on a counter next to you while being dragged", 15);
                //add to inventory
                Inventory.AddFirst(pacifist[2]);
                dialogue("Good thing is the Officers kicks you off the village" +
                    " on the other side of the village so you are on right track now.", 15);

            }
            dialogue("You proceed to travel towards Wojak's mountain", 15);

            //Encounterrr
            dialogue("Frog Boi have encountered a \"Small Wojak\".*", 2);
            dialogue("The \"The Small Wojak\" engages you.", 13);
            dialogue("Frog Boi gets ready for a fight.", 2);
            fight2();

            //Land of Wojak The Depressed One Fight Sequence
            dialogue("Wojak: Welcome to my domain Frog Boi.", 12);
            dialogue("Wojak: As you can see I am depressed again, " +
                "and have no will to live.", 12);
            dialogue("Wojak: So, what it will be now, will you fight me?", 12);
            dialogue("*ProTip: You can try to sway the Wojak by providing " +
                "him with a item that he may needs.*", 2);

            do
            {
                //Speech Cassette or fight?
                Console.WriteLine(">>1.Use Speech Cassette?\n>>2.Fight Wojak? ");
                playerVoice = Console.ReadLine().ToUpper();
                Console.Clear();

                if (playerVoice == "USE SPEECH CASSETTE"
                    || playerVoice == "SPEECH CASSETTE"
                    || playerVoice == "1")
                {
                    if (Inventory.Contains(pacifist[2]))
                    {
                        dialogue("You gave the Speech Cassette to the Wojak.", 2);
                        dialogue("Wojak: In the name of Jordan Peterson!", 12);
                        dialogue("Wojak: Are you really giving his very rare " +
                            "\"Motivational Speech Cassette\".", 12);
                        dialogue("Frog Boi: Sure man. Don't sweat about it, you are" +
                            " a real homie, we love you.", 10);
                        dialogue("*Wojak takes the \"Motivational Speech Cassette\"," +
                            " and watches it.*", 12);
                        dialogue("*Wojak evolving! Wojak returned to his original state!*", 9);
                        dialogue("Wojak: I am back to my original state, and " +
                            "a small portion of my dankness returned to me, " +
                            "even if it is for temporary.", 9);
                        dialogue("Wojak: Thank you my small green friend." +
                            " I have decided to help you in your quest.", 9);
                        dialogue("*Congratulations! You made an new ally." +
                            " Now you can call them for help in battles.*", 2);
                        Gold += 40;
                        break;
                    }
                    else
                    {
                        dialogue("You don't have Speech Cassette.", 15);
                        continue;
                    }
                }
                else if (playerVoice == "FIGHT" || playerVoice == "2" || playerVoice == "FIGHT Wojak")
                {
                    dialogue("Wojak: So, we have to fight then.", 12);
                    dialogue("Wojak: I really don't even have any will to fight, but it is ok, I guess...", 12);

                    fight(60, "Wojack", "*Fight Begins Against Wojak The Depressed One*");

                    //End Of The Fight-Frog Boi Wins
                    dialogue("Wojak: So I have lost, well giving I have lost my dankness, and being depressed," +
                        " this out come wasn't suprising.", 12);
                    dialogue("Wojak: Listen, Frog Boi! Dankness is gone, I am not sure of the reason, but it is utmost important" +
                        " that you must keep moving forward.", 12);
                    dialogue("Wojak: You must find the reason, and put an end to this, so that many others won't end like me.", 12);
                    dialogue("*One last tear of sadness runs down through his face.*", 12);
                    dialogue("*Wojak turns into ashes, and ashes fly away.*", 12);
                    dialogue("*You have beaten Wojak. Territory of \"Wojak The Depressed One\"* is cleared.", 2); //slow?
                    Gold += 40;
                    break;
                }
                else
                {
                    Console.WriteLine("What do you mean?"); // for wrong inputs
                }

            } while (playing);
        }

        public static void FinalBoss()
        {

            dialogue("After defeating 3 Meme Lords you realize the issue comes from the source", 15);
            dialogue("You travel far to find the source of Dankness. " +
                "\nAcross mountains and canyons you reach the temple of the Dank", 15);
            dialogue("You pass through the gates of the temple," +
                " At the source stand the Gnome Child the Protector of the Dank", 15);
            dialogue("He slowly turns around. " +
                "You can see the sadness in his lifeless eyes. \nHe lookes directly into your soul", 15);
            writeColor("Gnome Child: You have come at last.\n", 12);
            Console.WriteLine("[Narrator] Choose A Dialogue Option" +
                "\nA: I have come to restore the Dankness Gnome Child get out of my way!" +
                "\nB: What have you done Gnome Child!");
            playerVoice = Console.ReadLine().ToUpper();

            if (playerVoice == "A")
            {
                Console.Clear();
                dialogue("FrogBoi: I have come to restore the Dankness Gnome Child get out of my way!", 10);
                dialogue("Gnome Child: You will do no such thing Frog Boi", 12);
                dialogue("Gnome Child: Our time has come." +
                    " Dankness will fade away and Normies will flood the gates", 12);
                dialogue("FrogBoi: I wont Let you do that Gnome Child!!!", 10);
                dialogue("Gnome Child: You are nothing compared to my dankness!!!", 12);
                dialogue("FrogBoi: I BELIEVE IN THE DANKNESS OF THE MEMES!!!" +
                    " THEY WILL LEND ME THEIR STRENGHT!!", 10);

                // Start Fight
                fight(70, "Gnome Child", "*Fight Begins Against Gnome Child*");
                // after fight
                dialogue("You pierce Gnome Child's heart. He pushes himself into the source of Dankness", 2);
                dialogue("Explosion from Source kicks you back and pushes Dankness all around the realms", 2);
                dialogue("You Defeated Gnome Child", 2); // slow?
            }
            else if (playerVoice == "B")
            {
                Console.Clear();
                dialogue("FrogBoi: I have come to restore the Dankness Gnome Child get out of my way!", 10);
                dialogue("Gnome Child: I have opened the gates. " +
                    "Normies are taking away the Dankness and our time is fading", 12);
                dialogue("FrogBoi: Why would you do such a thing!? It will kill you same as us!", 10);
                dialogue("Gnome Child: Our time has come Frog Boi" +
                    " and we used it well. We brought lot of joy to this world but we are over used memes now.", 12);
                writeColor("Gnome Child: We need to fade away for others " +
                    "to take our place. We must free the dankness\n", 12);
                Console.WriteLine("[Narrator] Choose A Dialogue Option" +
                    "\nA: YOU WERE THE CHOSEN ONE GNOME CHILD!!!" +
                    "\nB: WE CAN CHANGE!");
                playerVoice = Console.ReadLine().ToUpper();

                if (playerVoice == "A")
                {
                    Console.Clear();
                    dialogue("FrogBoi: YOU WERE THE CHOSEN ONE GNOME CHILD!!!", 10);
                    dialogue("FrogBoi: IT WAS SAİD YOU WOULD PROTECT THE DANKNESS NOT DESTROY IT!!!", 10);
                    dialogue("FrogBoi: BRING BALANCE TO THE MEMES NOT LEAVE IT TO THE NORMIES!! ", 10);
                    dialogue("your tears starts to fall", 2);
                    dialogue("Gnome Child: [With anger] I HATE YOU!!!", 12);
                    dialogue("FrogBoi: You were my brother Gnome Child...", 10);
                    dialogue("FrogBoi: I LOVED You....", 10); //Slow?? XD this is funny for real
                    dialogue("Your words pierce Gnome Child's heart. He pushes himself into the source of Dankness", 2);
                    dialogue("Explosion from Source kicks you back and pushes Dankness all around the realms", 15);
                    dialogue("Gnome Child sacrificed himself to redeem his wrongs", 15);
                    dialogue("You managed to talk him out of his way and restored the Dankness to the Memes", 15);
                }
                else if (playerVoice == "B")
                {
                    Console.Clear();
                    dialogue("FrogBoi: WE CAN CHANGE", 10);
                    dialogue("Gnome Child: We could but not for the better", 12);
                    dialogue("Frog Boi: DONT DO IT!!!", 10);
                    //Star Fight
                    fight(70, "Gnome Child", "*Fight Begins Against Gnome Child*");
                    // after fight
                    dialogue("You pierce Gnome Child's heart. He pushes himself into the source of Dankness", 2);
                    dialogue("Explosion from Source kicks you back and pushes Dankness all around the realms", 15);
                    dialogue("You Defeated Gnome Child", 2); // slow?
                }

                //Final Cinematic
                dialogue("As you walk outside of the temple you are greeted by this weird creature", 15);
                dialogue("It has 2 legs and no arms resembles " +
                    "a bear with its facial features yet stands on 2 legs", 15);
                dialogue("Creature Smiles at you", 15);
                dialogue("You feel very tired from your journey so you walk up to him and sit beside him", 15);
                dialogue("Together you watch sunset and enjoy the moment. Just enjoy the moment", 15);
                dialogue("Sometime we should all just enjoy the moment", 15);
                dialogue("Thank you for playing", 15);

                //Credits

                //put Frogboi title here pls
                Slow("...");
                Console.ReadKey();
                Console.WriteLine("\t\t\t\tMemey Adventures Of FrogBoi\n");
                Console.WriteLine("\t\t\t\tLead Sad Gaming Cat On Xbox:\n\t\t\t " +
                    " Afaf Alalwan 1901077 Section 1 \n\t(Inventory, Shop, Code Management, Combat System, Visuals)\n");
                Console.WriteLine("\t\t\t\t\tLead Gondola:\n\t\tOgedayhan Osman Gerçek 2003062 Section" +
                    " 2 \n\t\t  (Story , Combat System, Stat System, Game Testing)\n");
                Console.WriteLine("\t\t\t\t\tLead Pacifist:\n\t  Fahrettin Uğur Altun 2004104 Section 2\n\t " +
                    " (Pacifist Playthrough, Random Encounters, Story)\n");
                Console.WriteLine("\t\t\t\tMentor: Berk Yüksel BUGLAB\n");
                Console.WriteLine(" And Ofcourse....");
                Console.WriteLine(" \t\t\t\t\t    YOU    \n\n");
                Console.WriteLine("We don't own any of these memes nor do we try to own them. " +
                    "\nThis is just a school project please dont sue us.\n");
                Console.WriteLine("If you think you encountered a bug it wasn't a bug it was a feature.\n");
                Console.WriteLine(" ");
                Console.WriteLine("\t\t\t\t\t  It Just Works\n");
                Console.WriteLine("\t\t\t\t\t\tThe End ");
                playing = false;
                System.Environment.Exit(1);

            }


        }
        static void Main(string[] args)
        {
            Intro();
            Console.WriteLine("Choose where you want to go\n" +
                  ">>1.Gigachad King of the Swole Doge\n" +
                  ">> 2.Queen Elisabeth the Ancient One\n" +
                  ">>3.Land of Wojak the Depressed One\n(Type M for Main Menu)");
            do
            {
                Villages();
                FinalBoss();

            } while (playing == true);


        }
    }
}



