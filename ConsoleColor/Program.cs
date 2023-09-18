using System.Text;

public static class Program
{
    static readonly Type ColorType = typeof(ConsoleColor);
    public static void Main()
    {
        bool start_check = true;
        string color = string.Empty;
        do
        {
            if (start_check == true) { 
                Console.Write($"Type color:\n>> ");
                color = ToTitleCase(Console.ReadLine());
                start_check = false;
            }
            try
            {
                Console.ForegroundColor = (ConsoleColor)Enum.Parse(ColorType, color);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"Wrong color, select one of this: {GetColors()}\n");
                Console.Write("Type color:\n>> ");
                color = ToTitleCase(Console.ReadLine());
                continue;
            }
            catch
            {
                Console.WriteLine("Lol");
                break;
            }
            Console.Write($"Color set to {color}\nPress \"Enter\" to stop, or start typing new color:\n>> ");
            var firstChar = Console.ReadKey().Key;
            if (firstChar == ConsoleKey.Enter)
            {
                Console.WriteLine("Bye!");
                break;
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(firstChar);
                sb.Append(Console.ReadLine());
                color = sb.ToString();
                start_check = false;
            }
        } while (true);
    }

    public static string ToTitleCase(string str)
    {
        if (str.Length > 1) {
            return char.ToUpper(str[0]) + str.Substring(1);
        }
        else {
            return str;
        }
    }

    public static string GetColors()
    {
        string result = string.Join(", ", Enum.GetNames(ColorType));
        return result;
       }
}