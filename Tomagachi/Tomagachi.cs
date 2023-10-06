

public class Tomagachi
{
    private int hunger = 0;
    private int boredom = 0;
    private int criminality = 0;
    private int depression = 0;
    private List<string> words = new List<string>();
    private bool isAlive = true;
    private Random generator = new();
    public string name;
    int word;
    string choice = "";
    string teach;
    bool willHeDoIt = true;
    
    public void Feed()
    {
        Console.WriteLine($"You feed {name}");
        hunger -= 20;
        if(hunger < 0)
        {
            hunger = 0;
        }
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
        if(choice == "c")
        {
            depression++;
        }

        depression ++;

        if(depression > 10)
        {
            depression = 10;
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
        
        if(boredom > 200)
        {
            boredom = 200;
        }

        if(choice != "c")
        {
            criminality += 1;
            if(criminality> 10)
            {
                criminality = 10;
            }
        }

    }
    private void SayingNo()
    {
        if(criminality >= 8)
        {
            int crime = generator.Next(0, 100);
            if(crime < 40)
            {
                willHeDoIt = true;
            }
            else 
            {
                willHeDoIt = false;
            }
        }
    }
    public void Play()
    {
        int playtime = generator.Next(0,3);
        if(playtime == 3)
        {
            Console.WriteLine("You throw a ball that hits {name} in the face");

            depression++;
        }
        else
        {
            Console.WriteLine("You play around");

            depression -= 3;
            boredom -= 20;
        }
        if(boredom < 100)
        {

            hunger += 10;
        }
        else if(boredom > 100)
        {
            hunger += 10 * boredom/100;
        }
    }
    public void PrintStats()
    {
        if(boredom >= 100)
        {
            Console.WriteLine($"{name} is bored");
            Console.WriteLine($"Boredom: {boredom}/200");
            Console.WriteLine("");
        }
        else
        {
            Console.WriteLine($"{name} is not bored");
            Console.WriteLine($"Boredom: {boredom}/200");
            Console.WriteLine("");
        }
        if(depression >= 3)
        {
            Console.WriteLine($"{name} is sad");
            Console.WriteLine($"Depression: {depression}/10");
            Console.WriteLine("");
        }
        else
        {
            Console.WriteLine($"{name} is happy");
            Console.WriteLine($"Depression: {depression}/10");
            Console.WriteLine("");
        }
        if(criminality >= 8)
        {
            Console.WriteLine($"{name} is a criminal");
            Console.WriteLine($"criminality: {criminality}/10");
            Console.WriteLine("");
        }
        else
        {
            Console.WriteLine($"{name} is calm");
            Console.WriteLine($"criminality: {criminality}/10");
            Console.WriteLine("");
        }
        if(hunger >= 50)
        {
            Console.WriteLine($"{name} is hungry");
            Console.WriteLine($"Hunger: {hunger}/100");
            Console.WriteLine("");
        }
        else
        {
            Console.WriteLine($"{name} is pleased");
            Console.WriteLine($"Hunger: {hunger}/100");
            Console.WriteLine("");
        }
        if(isAlive == true)
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
            Choice();
            if (choice == "a")
            {
                SayingNo();
                if(willHeDoIt == true)
                {
                    Feed();
                }
                else
                {
                    Console.WriteLine($"{name} says no");
                }
            }
            else if (choice == "b")
            {
                SayingNo();
                if(willHeDoIt == true)
                {
                    Hi();
                }
                else
                {
                    Console.WriteLine($"{name} says no");
                }
            }
            else if (choice == "c")
            {
                SayingNo();
                if(willHeDoIt == true)
                {
                    Teach(word);
                }
                else
                {
                    Console.WriteLine($"{name} says no");
                }
            }
            else if (choice == "d")
            {
                SayingNo();
                if(willHeDoIt == true)
                {
                    Play();
                }
                else
                {
                    Console.WriteLine($"{name} says no");
                }
            }
            else
            {
                WrongAnswers();
            }
            Console.ReadLine();

            Tick();
            GetAlive();
            Console.Clear();
        }
        Console.ReadLine();
    }

    private void WrongAnswers()
    {
        Console.WriteLine($"{name} is confused and you are dum dum");
    }

    private void Naming()
    {
        Console.WriteLine("write your Tomagachis name");
        name = Console.ReadLine();
        Console.Clear();
    }

    private void Choice()
    {
        Console.WriteLine("Choose what to do");
        Console.WriteLine($"A: Feed {name}");
        Console.WriteLine($"B: Talk with {name}");
        Console.WriteLine($"C: Teach {name} a word");
        Console.WriteLine($"D: Play with {name}");
        choice = Console.ReadLine().ToLower();
        Console.Clear();
    }
}
