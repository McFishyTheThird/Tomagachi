namespace Tomagachi;

public class Tomagachi
{
    private int hunger = 0;
    private int boredom = 0;
    private List<string> words;
    private bool isAlive = true;
    private Random generator;
    public string name;
    public void Feed()
    {
        hunger -= 20;
        if(hunger < 0)
        {
            hunger = 0;
        }
    }
    public void Hi()
    {
        int word = generator.Next(0, words.Count);
        if(words.Count == 0)
        {
            Console.WriteLine("No words learned");

        }
        else
        {
            Console.WriteLine($"{words[word]}");

        }

    }
    public void Teach(string word)
    {
        string teach = Console.ReadLine();
        words.Add($"{teach}");
        Console.WriteLine($"Your Tomagachi learned {teach}");
    }
    public void Tick()
    {
        if(boredom < 100)
        {

            hunger += 10;
        }
        else if(boredom > 100)
        {
            hunger += 10 * boredom/100;
        }
        
        
        boredom += 10;
    }
    public void PrintStats()
    {
        Console.WriteLine();
        Console.WriteLine();
        if(isAlive == true)
        {
            Console.WriteLine("your tomagachi is alive");
        }
        else
        {
            Console.WriteLine("You suck at this...");
        }
    }
    public void GetAlive()
    {
        if(isAlive == true)
        {

        }
        else
        {

        }
    }
    public void ReduceBoredom()
    {
        boredom -= 40;
        if(boredom > 200)
        {
            boredom = 200;
        }
    }


}
