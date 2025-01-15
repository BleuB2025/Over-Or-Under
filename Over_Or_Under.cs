namespace Over_Or_Under
{
    internal class Program
    {
        static void checkHealth(int health, int level) //Method To Check Health
        {
            if (health <= 0)
            {
                Console.Clear();
                Console.WriteLine("You Lose!\n");
                Console.WriteLine($"Died On Level: {level}\n");
                Environment.Exit(0);
            }
        }
       
        static void Main(string[] args)
        {
            //Variables
            string option;
            int health = 100;
            int points = 0;
            int rng1;
            int rng2;
            int level = 1;
            string guess;
            int nextLvlPrice = 100;
            string storeOption;
            int gambleAmount;

            //Store
            Dictionary<string, int> Store = new Dictionary<string, int>()
            {
                {"1. Small Health Potion (+10 Health)", 20},
                {"2. Medium Health Potion (+50 Health)", 100},
                {"3. Large Health Potion (+100 Health)", 200},
            };

            //Menu
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=========================");
                Console.WriteLine("Welcome To Over Or Under");
                Console.WriteLine("=========================\n");
                Console.WriteLine("Start (S)\n");
                Console.WriteLine("How To Play / Game Rules (H)\n");
                option = Console.ReadLine();

                if (option.ToLower() == "s")
                {
                    //Main Game
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine($"Level: {level}");
                        Console.WriteLine("=================");
                        Console.WriteLine($"Health: {health}");
                        Console.WriteLine($"Points: {points}");
                        Console.WriteLine("=================\n");
                        Console.WriteLine("Generate Number (G)\n");
                        Console.WriteLine("Enter Store (S)\n");
                        Console.WriteLine($"Proceed To Next Level (Costs: {nextLvlPrice}) (N)\n");
                        Console.WriteLine("Return To Start Menu (R)\n");
                        option = Console.ReadLine();

                        if (option.ToLower() == "g")
                        {
                            //Number Generator
                            while (true)
                            {
                                Console.Clear();
                                Console.WriteLine($"Points: {points}");
                                Console.WriteLine("=========");
                                Console.WriteLine("Generator");
                                Console.WriteLine("=========\n");
                                Console.WriteLine("Generate Number (G)\n");
                                Console.WriteLine("(Gamble) Generate Number (E)\n");
                                Console.WriteLine("Return (R)\n");
                                option = Console.ReadLine();

                                if (option.ToLower() == "g")
                                {
                                    Console.Clear();
                                    Random random = new Random();
                                    rng1 = random.Next(1, 21);
                                    rng2 = random.Next(1, 21);

                                    Console.WriteLine($"The number is: {rng1}\n");

                                    Console.WriteLine("Over (O) or Under (U)\n");
                                    guess = Console.ReadLine();
                                    Console.WriteLine();
                                    if (guess.ToLower() == "o" && rng1 < rng2)
                                    {
                                        Console.WriteLine($"The 2nd Number Was: {rng2}, You Win!");
                                        points += 10;
                                        Console.WriteLine("+10 Points");
                                        Console.WriteLine($"You Now Have {points} Points!");
                                        Console.WriteLine("Press Any Key To Continue...\n");
                                        Console.ReadKey();
                                    }
                                    else if (guess.ToLower() == "o" && rng1 > rng2)
                                    {
                                        Console.WriteLine($"The 2nd Number Was: {rng2}, You Lose!");
                                        health -= 25;
                                        Console.WriteLine("-25 Health");
                                        Console.WriteLine($"Your Health Is Now: {health}");
                                        Console.WriteLine("Press Any Key To Continue...\n");
                                        Console.ReadKey();
                                        checkHealth(health, level);
                                    }
                                    else if (guess.ToLower() == "u" && rng1 > rng2)
                                    {
                                        Console.WriteLine($"The 2nd Number Was: {rng2}, You Win!");
                                        points += 10;
                                        Console.WriteLine("+10 Points");
                                        Console.WriteLine($"You Now Have {points} Points!");
                                        Console.WriteLine("Press Any Key To Continue...\n");
                                        Console.ReadKey();
                                    }
                                    else if (guess.ToLower() == "u" && rng1 < rng2)
                                    {
                                        Console.WriteLine($"The 2nd Number Was: {rng2}, You Lose!");
                                        health -= 25;
                                        Console.WriteLine("-25 Health");
                                        Console.WriteLine($"Your Health Is Now: {health}");
                                        Console.WriteLine("Press Any Key To Continue...\n");
                                        Console.ReadKey();
                                        checkHealth(health, level);
                                    }
                                    else if (rng1 == rng2)
                                    {
                                        Console.WriteLine($"The 2nd Number Was: {rng2}, You Lose!");
                                        health -= 25;
                                        Console.WriteLine("-25 Health");
                                        Console.WriteLine($"Your Health Is Now: {health}");
                                        Console.WriteLine("Press Any Key To Continue...\n");
                                        Console.ReadKey();
                                        checkHealth(health, level);
                                    }
                                }

                                //Number Generator (Gamble)
                                else if (option.ToLower() == "e")
                                {
                                    if (points == 0)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("You Don't Have Any Points To Gamble\n");
                                        Console.WriteLine("Press Any Key To Continue...\n");
                                        Console.ReadKey();
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine($"Points: {points}\n");
                                        Console.Write("Enter The Amount You Want To Gamble: ");

                                        try //Exception Handling
                                        {
                                            gambleAmount = Convert.ToInt32(Console.ReadLine());

                                            if (gambleAmount > points)
                                            {
                                                Console.WriteLine($"\nYou Dont Have {gambleAmount} Points!\n");
                                                Console.WriteLine("Press Any Key To Continue...\n");
                                                Console.ReadKey();

                                            }
                                            else if (gambleAmount <= 0)
                                            {
                                                Console.WriteLine("\nInvalid Amount!\n");
                                                Console.WriteLine("Press Any Key To Continue...\n");
                                                Console.ReadKey();
                                            }
                                            else
                                            {
                                                Random random = new Random();
                                                rng1 = random.Next(1, 21);
                                                rng2 = random.Next(1, 21);

                                                Console.WriteLine($"\nThe number is: {rng1}\n");

                                                Console.WriteLine("Over (O) or Under (U)\n");
                                                guess = Console.ReadLine();
                                                Console.WriteLine();
                                                if (guess.ToLower() == "o" && rng1 < rng2)
                                                {
                                                    Console.WriteLine($"The 2nd Number Was: {rng2}, You Win!");
                                                    points += gambleAmount;
                                                    Console.WriteLine($"+{gambleAmount} Points");
                                                    Console.WriteLine($"You Now Have {points} Points!");
                                                    Console.WriteLine("Press Any Key To Continue...\n");
                                                    Console.ReadKey();
                                                }
                                                else if (guess.ToLower() == "o" && rng1 > rng2)
                                                {
                                                    Console.WriteLine($"The 2nd Number Was: {rng2}, You Lose!");
                                                    health -= 25;
                                                    points -= gambleAmount;
                                                    Console.WriteLine($"-{gambleAmount} Points");
                                                    Console.WriteLine("-25 Health");
                                                    Console.WriteLine($"You Now Have {points} Points");
                                                    Console.WriteLine($"Your Health Is Now: {health}");
                                                    Console.WriteLine("Press Any Key To Continue...\n");
                                                    Console.ReadKey();
                                                    checkHealth(health, level);
                                                }
                                                else if (guess.ToLower() == "u" && rng1 > rng2)
                                                {
                                                    Console.WriteLine($"The 2nd Number Was: {rng2}, You Win!");
                                                    points += gambleAmount;
                                                    Console.WriteLine($"+{gambleAmount} Points");
                                                    Console.WriteLine($"You Now Have {points} Points!");
                                                    Console.WriteLine("Press Any Key To Continue...\n");
                                                    Console.ReadKey();
                                                }
                                                else if (guess.ToLower() == "u" && rng1 < rng2)
                                                {
                                                    Console.WriteLine($"The 2nd Number Was: {rng2}, You Lose!");
                                                    health -= 25;
                                                    points -= gambleAmount;
                                                    Console.WriteLine($"-{gambleAmount} Points");
                                                    Console.WriteLine("-25 Health");
                                                    Console.WriteLine($"You Now Have {points} Points");
                                                    Console.WriteLine($"Your Health Is Now: {health}");
                                                    Console.WriteLine("Press Any Key To Continue...\n");
                                                    Console.ReadKey();
                                                    checkHealth(health, level);
                                                }
                                                else if (rng1 == rng2)
                                                {
                                                    Console.WriteLine($"The 2nd Number Was: {rng2}, You Lose!");
                                                    health -= 25;
                                                    points -= gambleAmount;
                                                    Console.WriteLine($"-{gambleAmount} Points");
                                                    Console.WriteLine("-25 Health");
                                                    Console.WriteLine($"You Now Have {points} Points");
                                                    Console.WriteLine($"Your Health Is Now: {health}");
                                                    Console.WriteLine("Press Any Key To Continue...\n");
                                                    Console.ReadKey();
                                                    checkHealth(health, level);
                                                }
                                            }
                                        }
                                        catch
                                        {
                                            Console.WriteLine("\nInvalid Input!\n");
                                            Console.WriteLine("Press Any Key To Continue...\n");
                                            Console.ReadKey();

                                        }
                                    }
                                }

                                //Return To Game Menu
                                if (option.ToLower() == "r")
                                {
                                    break;
                                }
                            }
                        }

                        //Proceed To Next Level
                        else if (option.ToLower() == "n")
                        {
                            if (level == 4 && points >= nextLvlPrice)
                            {
                                Console.Clear();
                                Console.WriteLine("You Win!");
                                Environment.Exit(0);
                            }
                            else if (points >= nextLvlPrice)
                            {
                                points -= nextLvlPrice;
                                level += 1;
                                nextLvlPrice += 100;
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine($"You Do Not Have Enough Points To Proceed To Level: {level + 1}\n");
                                Console.WriteLine("Press Any Key To Continue...\n");
                                Console.ReadKey();
                            }
                        }

                        //Store
                        else if (option.ToLower() == "s")
                        {
                            while (true)
                            {
                                Console.Clear();
                                Console.WriteLine($"Points: {points}\n");
                                Console.WriteLine("=======================================================");
                                Console.WriteLine("Store (Type The Number Of The Item You Wish To Purchase)");
                                Console.WriteLine("=======================================================");
                                foreach (var item in Store)
                                {
                                    Console.WriteLine(item.Key + ": " + item.Value);
                                }
                                Console.WriteLine("\nReturn (R)\n");
                                storeOption = Console.ReadLine();
                                Console.Clear();

                                //Small Health Potion
                                if (storeOption == "1")
                                {
                                    if (points >= 20)
                                    {
                                        points -= 20;
                                        health += 10;
                                        Console.WriteLine("Small Health Potion Purchased");
                                        Console.WriteLine("-20 Points");
                                        Console.WriteLine("+10 Health\n");
                                        Console.WriteLine("Press Any Key To Continue...\n");
                                        Console.ReadKey();
                                    }
                                    else
                                    {
                                        Console.WriteLine("You Do Not Have Enough Points To Purchase This Item!\n");
                                        Console.WriteLine("Press Any Key To Continue...\n");
                                        Console.ReadKey();
                                    }
                                }
                                //Medium Health Potion
                                else if (storeOption == "2")
                                {
                                    if (points >= 100)
                                    {
                                        points -= 100;
                                        health += 50;
                                        Console.WriteLine("Medium Health Potion Purchased");
                                        Console.WriteLine("-100 Points");
                                        Console.WriteLine("+50 Health\n");
                                        Console.WriteLine("Press Any Key To Continue...\n");
                                        Console.ReadKey();
                                    }
                                    else
                                    {
                                        Console.WriteLine("You Do Not Have Enough Points To Purchase This Item!\n");
                                        Console.WriteLine("Press Any Key To Continue...\n");
                                        Console.ReadKey();
                                    }
                                }
                                //Large Health Potion
                                else if (storeOption == "3")
                                {
                                    if (points >= 200)
                                    {
                                        points -= 200;
                                        health += 100;
                                        Console.WriteLine("Large Health Potion Purchased");
                                        Console.WriteLine("-200 Points");
                                        Console.WriteLine("+100 Health\n");
                                        Console.WriteLine("Press Any Key To Continue...\n");
                                        Console.ReadKey();
                                    }
                                    else
                                    {
                                        Console.WriteLine("You Do Not Have Enough Points To Purchase This Item!\n");
                                        Console.WriteLine("Press Any Key To Continue...\n");
                                        Console.ReadKey();
                                    }
                                }
                                else if (storeOption.ToLower() == "r")
                                {
                                    break;
                                }
                            }
                        }
                        else if (option.ToLower() == "r")
                        {
                            break;
                        }
                    }
                }

                //Game Info
                else if (option.ToLower() == "h")
                {
                    Console.Clear();
                    Console.WriteLine("In This Game A Random Number Between 1 and 20 Is Generated.");
                    Console.WriteLine("You Will Then Have To Guess If The Next Generated Number Will Be Over");
                    Console.WriteLine("Or Under The Value Of The First Generated Number. If You Guess Wrong You");
                    Console.WriteLine("Will Lose Health And If You Guess Right You Will Gain Points. These Points");
                    Console.WriteLine("Can Be Spent On Either Proceeding To The Next Level Or Restoring Your Health.");
                    Console.WriteLine("Once You Have Accumulated Some Points You Can Choose To Gamble Them, Which Will");
                    Console.WriteLine("Allow You To Progess Quicker. Once You Reach Level 5 You Win. If Your Health");
                    Console.WriteLine("Reaches 0 You Lose.\n");
                    Console.WriteLine("Extra Info: If The Generated Numbers Are The Same You Automatically Lose.\n");


                    Console.WriteLine("Press Any Key To Return...\n");
                    Console.ReadKey();
                }
            }
        }
    }
}
