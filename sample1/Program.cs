namespace sample1;
using Newtonsoft.Json;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

class Program
{
    static void Main(string[] args)
    {
        var pers = new Personne("Bastien", 23);

        string output = JsonConvert.SerializeObject(pers, Formatting.Indented);
        
        Console.WriteLine(output);

        using (Image image = Image.Load(@"my_img.jpg"))
        {
            image.Mutate(x => x.Resize(image.Width / 2, image.Height / 2)); 

            image.Save(@"my_new_img.jpg"); 
        }
    }
}

class Personne 
{
    public string nom;

    public int age;

    public Personne(string nom, int age) {
        this.nom = nom;
        this.age = age;
    }

    public string Hello(bool isLowercase)
    {
        string message = $"hello {this.nom}, you are {this.age}";
        return isLowercase ? message.ToLower() : message.ToUpper();
    }
}

