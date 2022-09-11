using System;
public class Lab1 
{
    public static string getPassword()
    {
        Random rnd = new Random();
        var lengthOfPassword = rnd.Next(6, 20);
        var numberOfNums = rnd.Next(Math.Min(5, lengthOfPassword - 3));
        var indexesOfNums = new List<int> { };
        var indexOfSpace = rnd.Next(lengthOfPassword);
        var numberOfUpper = rnd.Next(2, lengthOfPassword - 1 - numberOfNums);
        Console.WriteLine(numberOfUpper);
        var indexesOfUpper = new List<int> { };

        for (int i = 0; i < numberOfNums; i++)
        {   
            var index = rnd.Next(lengthOfPassword);
            while (indexesOfNums.Contains(index) || index == indexOfSpace) index = rnd.Next(lengthOfPassword);
            indexesOfNums.Add(index);
        }
        
        for (int i = 0; i < numberOfUpper; i++)
        {   
            var index = rnd.Next(lengthOfPassword);
            while (indexesOfNums.Contains(index) 
                || indexesOfUpper.Contains(index) 
                || index == indexOfSpace)
                    index = rnd.Next(lengthOfPassword);
            indexesOfUpper.Add(index);
        }
        
        var password = "";
        var lettersArr = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
        var numbers = "0123456789".ToCharArray();
        for (int i = 0; i < lengthOfPassword; i++)
        {
            if (i == indexOfSpace) password += '_';
            else
            {
                if (indexesOfNums.Contains(i))
                {
                    var number = numbers[rnd.Next(numbers.Length)];
                    while (password.Length != 0 && password[password.Length - 1] == number)
                        number = numbers[rnd.Next(numbers.Length)];
                    password += number;
                }
                else
                {
                    char symb = lettersArr[rnd.Next(lettersArr.Length)];
                    if (indexesOfUpper.Contains(i))
                        symb = char.ToUpper(symb);
                    password += symb;
                }
            }
        }
        return password.ToString();
    }

    public static void Main()
    {
        for (int i = 0; i < 10; i++)
            Console.WriteLine(getPassword());
    }
}