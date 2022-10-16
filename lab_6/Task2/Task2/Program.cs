using System;

class Program
{
    class Person: IComparable<Person>
    {
        public string Name;
        public int age;
        public Person(string name, int age)
        {
            this.Name = name;
            this.age = age;
        }
        public int CompareTo(Person? person)
        {
            if (Name.Length != person.Name.Length)
                return Name.Length - person.Name.Length;
            return Name.ToLower()[0] - person.Name.ToLower()[0];
        }
    }

    public static void Main()
    {
        var person1 = new Person("Vasya", 10);
        var person2 = new Person("Kolya", 14);
        var person3 = new Person("Ivan", 5);
        var person4 = new Person("Sergey", 21);
        Person[] persons = new Person[] { person1, person2, person3, person4 };
        Console.WriteLine("Sort by Name");
        Array.Sort(persons);
        foreach (var person in persons)
            Console.Write(person.Name + ' ');
        Console.WriteLine("\nSort by age");
        Array.Sort(persons, (x, y) => x.age - y.age);
        foreach (var person in persons)
            Console.Write(person.Name + ' ');
    }
}