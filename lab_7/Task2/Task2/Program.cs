using System;
using System.Linq.Expressions;

class Program
{
    public class Element
    {
        public string Name { get; set; }
    }

    public static void Main()
    {
        var elems = new List<Element>() { new Element { Name = "Bob" },
                                          new Element { Name = "Tom" },
                                          new Element { Name = "Vasya" },
                                          new Element { Name = "Artem" },
                                          new Element { Name = "Li" },
                                          new Element { Name = "Kristina" } };
        var filt_elems = elems.Where((x, index) => x.Name.Length > index); 
        foreach (Element el in filt_elems)
        {
            Console.WriteLine(el.Name);
        }
    }
}