using System;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Markup;

class Program
{
    public static int DefaultValue = 0;

    public class BlackBox
    {
        private int innerValue;
        private BlackBox(int innerValue)
        {
            this.innerValue = 0;
        }
        private BlackBox()
        {
            this.innerValue = DefaultValue;
        }
        private void Add(int addend)
        {
            this.innerValue += addend;
        }
        private void Subtract(int subtrahend)
        {
            this.innerValue -= subtrahend;
        }
        private void Multiply(int multiplier)
        {
            this.innerValue *= multiplier;
        }
        private void Divide(int divider)
        {
            this.innerValue /= divider;
        }
    }

    public static void Main()
    {
   
        Type type = typeof(BlackBox);
        const BindingFlags bindFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static;
        Object bb = Activator.CreateInstance(typeof(BlackBox), true);
        var innerValueField = type.GetField("innerValue", bindFlags);
        String command = Console.ReadLine();
        var args = command.Replace(')', '(').Split("(");
        
        while (type.GetMethod(args[0],bindFlags) is not null)
        {
            MethodInfo method = type.GetMethod(args[0], bindFlags);
            int arg = int.Parse(args[1]);
            method.Invoke(bb, new object[] { arg });
            Console.WriteLine(innerValueField.GetValue(bb));
            command = Console.ReadLine();
            args = command.Replace(')', '(').Split("(");
        }
    }
}