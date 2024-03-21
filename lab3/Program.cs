using System;

// Базовий клас String
public class String
{
    public string characters; // Змінна для зберігання символів
    protected byte length;    // Довжина рядка

    // Конструктор без параметрів
    public String()
    {
        characters = ""; // Ініціалізація порожнього рядка
        length = 0;      // Довжина 0
    }

    // Конструктор, який приймає рядок у параметрі
    public String(string str)
    {
        characters = str;           // Зберігаємо переданий рядок
        length = (byte)str.Length;  // Визначаємо його довжину
    }

    // Конструктор, який приймає символ у параметрі
    public String(char ch)
    {
        characters = ch.ToString(); // Перетворюємо символ на рядок
        length = 1;                 // Довжина 1
    }

    // Метод для отримання довжини рядка
    public byte GetLength()
    {
        return length; // Повертаємо довжину
    }

    // Метод для очищення рядка
    public void Clear()
    {
        characters = ""; // Очищуємо рядок
        length = 0;      // Встановлюємо довжину 0
    }
}

// Похідний клас DecimalString від String
public class DecimalString : String
{
    // Конструктор, який приймає число у параметрі
    public DecimalString(decimal number)
    {
        characters = number.ToString(); // Перетворюємо число на рядок
        length = (byte)characters.Length; // Визначаємо довжину
    }

    // Метод для віднімання рядків
    public string SubtractStrings(string str)
    {
        decimal thisNumber, otherNumber;

        if (decimal.TryParse(characters, out thisNumber) && decimal.TryParse(str, out otherNumber))
        {
            decimal result = thisNumber - otherNumber; // Віднімаємо числа
            return result.ToString(); // Повертаємо результат у вигляді рядка
        }
        else
        {
            return "Invalid input"; // Повертаємо рядок "Недійсний ввід" у разі помилки
        }
    }

    // Метод для перевірки, чи цей рядок більший за інший рядок (за значенням)
    public bool IsGreaterThan(string str)
    {
        decimal thisNumber, otherNumber;

        if (decimal.TryParse(characters, out thisNumber) && decimal.TryParse(str, out otherNumber))
        {
            return thisNumber > otherNumber; // Повертаємо true, якщо це число більше іншого
        }
        else
        {
            return false; // Інакше повертаємо false
        }
    }

    // Метод для перевірки, чи цей рядок менший за інший рядок (за значенням)
    public bool IsLessThan(string str)
    {
        decimal thisNumber, otherNumber;

        if (decimal.TryParse(characters, out thisNumber) && decimal.TryParse(str, out otherNumber))
        {
            return thisNumber < otherNumber; // Повертаємо true, якщо це число менше іншого
        }
        else
        {
            return false; // Інакше повертаємо false
        }
    }
}

class Program
{
    static void Main(string[] args)

    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // Демонстрація
        Console.WriteLine("Введіть десяткове число:");
        decimal inputNumber;
        if (decimal.TryParse(Console.ReadLine(), out inputNumber))
        {
            DecimalString decimalString = new DecimalString(inputNumber);

            Console.WriteLine("Довжина Десяткового рядка: " + decimalString.GetLength());
            Console.WriteLine("Вміст Десяткового рядка: " + decimalString.characters);

            Console.WriteLine("Введіть число, яке потрібно відняти:");
            string subtractInput = Console.ReadLine();
            Console.WriteLine("Віднімаємо " + subtractInput + " від ДесятковогоРядка...");
            string result = decimalString.SubtractStrings(subtractInput);
            Console.WriteLine("Результат " + result);

            Console.WriteLine("Введіть число для порівняння:");
            string compareInput = Console.ReadLine();
            Console.WriteLine("Чи ДесятковийРядок більший за " + compareInput + "? " + decimalString.IsGreaterThan(compareInput));
            Console.WriteLine("Чи ДесятковийРядок менший за " + compareInput + "? " + decimalString.IsLessThan(compareInput));
        }
        else
        {
            Console.WriteLine("Недійсне введення для десяткового числа.");
        }
    }
}
