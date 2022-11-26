using System;

class Program
{
    [Flags]
    public enum Allergen: int
    {
        Eggs = 1,
        Peanuts = 2,
        Shellfish = 4,
        Strawberry = 8,
        Tomatoes = 16,
        Chocolate = 32,
        FlowerPollen = 64,
        Cats = 128
    }

    public class Allergies
    {
        string name;
        int value;
        Allergen allergs;
        public Allergies(string Name, int value = 0)
        {
            this.name = Name;
            this.value = value;
            int cur = value % 2;
            var i = 1;
            while (value != 0)
            {
                if (cur == 1)
                    allergs |= (Allergen)i;
                i *= 2;
                value /= 2;
                cur = value % 2;
            }
        }

        public Allergies(string Name, string alls)
        {
            name = Name;
            value = 0;
            var allergsStrings = alls.Split(' ').ToList();
            Allergen allerg;
            foreach (var i in allergsStrings)
            {
                if (Enum.TryParse(i, out allerg))
                {
                    allergs |= allerg;
                    value += (int)allerg;
                }
            }
        }
        public string Name { get { return name; } }
        public int Score { get { return value; } }
        public override String ToString() {
            if (value == 0)
                return name + " hasn't got any allergies";
            return name + " has allergies on " + allergs.ToString().ToLower(); 
        }

        public bool IsAllergicTo(Allergen allergen)
        {
            return (allergs & allergen) != 0;
        }

        public bool IsAllergicTo(string al)
        {
            Allergen allergen;
            if (Enum.TryParse(al, out allergen))
                return IsAllergicTo(allergen); 
            return false;
        }

        public void AddAllergy(Allergen allergen)
        {
            allergs |= allergen;
        }

        public void AddAllergy(string al)
        {
            Allergen allergen;
            if (Enum.TryParse(al, out allergen))
                AddAllergy(allergen);
        }
        
        public void DeleteAllergy(Allergen allergen)
        {
            allergs &= ~allergen;
        }

        public void DeleteAllergy(string al)
        {
            Allergen allergen;
            if (Enum.TryParse(al, out allergen))
                DeleteAllergy(allergen);
        }

    }

    public static void Main()
    {
        var mary = new Allergies("Mary");
        var joe = new Allergies("Joe", 65);
        var rob = new Allergies("Rob", "Peanuts Chocolate Cats Strawberry");
        Console.WriteLine(mary.Name + "   " + mary.Score.ToString() + "  " + mary.ToString());
        Console.WriteLine(joe.Name + "   " + joe.Score.ToString() + "   " + joe.ToString());
        Console.WriteLine(rob.Name + "   " + rob.Score.ToString() + "   " + rob.ToString());
        Console.WriteLine("Rob is allergic to eggs : " + rob.IsAllergicTo("Eggs") + " " + rob.IsAllergicTo(Allergen.Eggs));
        Console.WriteLine("Rob is allergic to cats : " + rob.IsAllergicTo("Cats") + " " + rob.IsAllergicTo(Allergen.Cats));
        rob.AddAllergy("Eggs");
        rob.AddAllergy(Allergen.FlowerPollen);
        Console.WriteLine("Rob arter adding eggs and FlowerPollen allergy:  " + rob.ToString());
        rob.DeleteAllergy("Peanuts");
        rob.DeleteAllergy(Allergen.Cats);
        Console.WriteLine("Rob after deleting cats and peanuts allergy: " + rob.ToString());
    }
}