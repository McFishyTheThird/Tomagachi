

public class Tomagachi
{
    private int hunger = 0;
    private int boredom = 0;
    private int criminality = 0;
    private int maxCrime = 10;
    private int depression = 0;
    private int money = 1000;
    private int loan = 0;
    private List<string> words = new List<string>();
    private bool isAlive = true;
    private Random generator = new();
    public string name;
    int word;
    string choice = "";
    string teach;
    bool willHeDoIt = true;
    bool choosenTheWay = false;
    private string crimeClass = "";
    
    public void Feed()
    {
        Console.WriteLine($"You feed {name}");
        hunger -= 20;
        if(hunger < 0)
        {
            hunger = 0;
        }
        money -= 100;
    }
    public void Hi()
    {
        if(words.Count == 0)
        {
            Console.WriteLine($"{name} is a dum dum like you and doesnt know any words");
        }
        else
        {
            word = generator.Next(0, words.Count);
            Console.WriteLine($" {name} says, {words[word]}");
            boredom -= 60;

        }
        money += 50;
    }
    public void Teach(int word)
    {
        Console.WriteLine($"What word/sentence do you want to teach {name}?");
        teach = Console.ReadLine();
        words.Add($"{teach}");
        Console.WriteLine("");
        Console.WriteLine($"Your Tomagachi learned {teach}");
        criminality--;
        if(criminality < 0)
        {
            criminality = 0;
        }
        if(crimeClass != "Homicidal Maniac")
        {
            depression++;
        }
        money -= 200;
    }
    public void Tick()
    {
        if(choice != "a")
        {
            if(boredom < 100)
            {

                hunger += 10;
            }
            else if(boredom > 100)
            {
                hunger += 10 * boredom/100;
            }
        }
        if (loan > 0)
        {
            money -= money * loan/1500;
            loan -= 100;
        }
        if(crimeClass != "Homicidal Maniac")
        {
            depression++;
        }
        if(choice != "b" && choice != "c")
        {
            if (depression < 3)
            {
                boredom+=30;
            }
            else
            {
                boredom += 30 * depression/2;

            }

        }
        if(choice != "c")
        {
            criminality += 1;
        }
        if(boredom > 200)
        {
            boredom = 200;
        }
        if (boredom <= 0)
        {
            boredom = 0;
        }
        if(depression > 10)
        {
            depression = 10;
        }
        if(criminality> maxCrime)
        {
            criminality = maxCrime;
        }
        if(crimeClass == "Drug Kingpin")
        {
            money += 50;
            if(name == "Walter White" || name == "Mr White" || name == "Waltuh")
            {
                money += 100;
            }
        }   
        if(crimeClass == "Homicidal Maniac")
        {
            money -= 50;
        }
        if(crimeClass == "Illegal Gambler")
        {
            int gambling = generator.Next(0,100);
            if(gambling <= 25)
            {
                money = money*3;
            }
            else if(gambling >= 50)
            {
                money = money/2;
            }
        }
    }

    public void Play()
    {
        int playtime = generator.Next(0,3);
        if(playtime == 3)
        {
            Console.WriteLine("You throw a ball that hits {name} in the face");

            if(crimeClass != "Homicidal Maniac")
            {
                depression++;
            }
        }
        else
        {
            Console.WriteLine("You play around");

            depression -= 3;
            boredom -= 20;
            if(depression <= 0)
            {
                depression = 0;
            }
        }
        if(boredom < 100)
        {

            hunger += 10;
        }
        else if(boredom > 100)
        {
            hunger += 10 * boredom/100;
        }
        money -= 50;
    }
    private void Wait()
    {
        Console.WriteLine("You wait and get some cash");
        Console.ReadLine();
        money += 250;
    }

    private void Loan()
    {
        Console.WriteLine("You loan some money");
        Console.ReadLine();
        money += 1000;
        loan += 1000;
    }
    private void SayNo()
    {
        int noChance = generator.Next(0,100);
        if(noChance <= 40)
        {
            willHeDoIt = false;
        }
        else
        {
            willHeDoIt = true;
        }
    }
    public void PrintStats()
    {
        Console.WriteLine($"Money: {money}");
        if (crimeClass != "")
        {

        }
        Console.WriteLine($"Boredom: {boredom}/200");
        Console.WriteLine("");
        Console.WriteLine($"Depression: {depression}/10");
        Console.WriteLine("");
        Console.WriteLine($"criminality: {criminality}/{maxCrime}");
        Console.WriteLine("");
        Console.WriteLine($"Hunger: {hunger}/100");
        Console.WriteLine("");
        Console.WriteLine($"Debt: {loan}");
    }

    private void PrintAlive()
    {
        if (isAlive == true)
        {
            Console.WriteLine($"{name} is alive");
            Console.WriteLine("");
        }
        else
        {
            Console.WriteLine("You suck at this...");
            Console.WriteLine("");
        }
    }

    public void GetAlive()
    {
        if(hunger >= 100)
        {
            isAlive = false;
        }
    }
    public void Game()
    {
        Naming();
        while (isAlive == true)
        {
            PrintStats();
            if(criminality > 5 && criminality < 10)
            {
                SayNo();
            }
            if(willHeDoIt == true)
            {
                Choice();
                if (choice == "a")
                {
                    if (money >= 100)
                    {
                        Feed();
                    }
                    else
                    {
                        Console.WriteLine("You are too poor");
                    }
                }
                else if (choice == "b")
                {
                    Hi();
                }
                else if (choice == "c")
                {
                    if (money >= 200)
                    {
                        Teach(word);
                    }
                    else
                    {
                        Console.WriteLine("You are too poor");
                    }
                }
                else if (choice == "d")
                {

                    if (money >= 50)
                    {
                        Play();
                    }
                    else
                    {
                        Console.WriteLine("You are too poor");
                    }
                }
                else if (choice == "e")
                {
                    Wait();
                }
                else if (choice == "f" && loan == 0)
                {
                    Loan();
                }
                else
                {
                    WrongAnswers();
                }
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine($"{name} doesn't want to do anything");
            }
            Tick();
            GetAlive();
            Console.Clear();
            CrimeClass();
            PrintAlive();
        }
        Console.ReadLine();
    }

    private void CrimeClass()
    {
        while (criminality == 10 && choosenTheWay == false && crimeClass != "a" && crimeClass != "b" && crimeClass != "c")
        {
            Console.WriteLine("Choose one of the criminal classes");
            Console.WriteLine("A: Illegal Gambler (25% chance to triple money, 50% chance to lose 50% money)");
            Console.WriteLine("B: Drug Kingpin (+50 $ per round)");
            Console.WriteLine("C: Homicidal Maniac (depression is not an issue, lose 50 $ each round)");
            crimeClass = Console.ReadLine();
            if (crimeClass == "a")
            {
                crimeClass = "Illegal Gambler";
                choosenTheWay = true;
            }
            else if (crimeClass == "b")
            {
                crimeClass = "Drug Kingpin";
                choosenTheWay = true;
            }
            else if (crimeClass == "c")
            {
                crimeClass = "Homicidal Maniac";
                choosenTheWay = true;
            }
            Console.Clear();
        }
    }

    private void WrongAnswers()
    {
        Console.WriteLine($"{name} is confused and you are dum dum");
    }

    private void Naming()
    {
        Console.WriteLine("write your Tomagachis name");
        name = Console.ReadLine();
        if(name == "Benny" || name == "benny")
        {
            money += 2000;
        }
        Console.Clear();
    }

    private void Choice()
    {
        Console.WriteLine("Choose what to do");
        Console.WriteLine($"A: Feed {name} (-100 $)");
        Console.WriteLine($"B: Talk with {name} (+50 $)");
        Console.WriteLine($"C: Teach {name} a word (-200 $)");
        Console.WriteLine($"D: Play with {name} (-50 $)");
        Console.WriteLine("E: Wait (+250 $)");
        if(loan == 0)
        {
            Console.WriteLine("F: Loan (+1000 $)");
        }
        else
        {
            Console.WriteLine("Can't loan because you havent paid off your debt");
        }
        choice = Console.ReadLine().ToLower();
        Console.Clear();
    }
}
