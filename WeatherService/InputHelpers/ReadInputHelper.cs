namespace InputHelpers
{
    public class ReadInputHelper
    {
        public static int GetIntInput(string message)
        {
            Console.Write(message);
            int result;
            while (!int.TryParse(Console.ReadLine(), out result))
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
                Console.Write(message);
            }
            return result;
        }

        public static TEnum GetEnumInput<TEnum>(string message) where TEnum : struct
        {
            Console.Write(message);
            TEnum result;
            while (!Enum.TryParse(Console.ReadLine(), out result))
            {
                Console.WriteLine("Invalid input. Please enter a valid enum value.");
                Console.Write(message);
            }
            return result;
        }

        public static string GetStringInput(string message)
        {
            Console.Write(message);
            string? result = Console.ReadLine();
            return result ?? string.Empty;
        }

        public static decimal GetDecimalInput(string message)
        {
            Console.Write(message);
            decimal result;
            while (!decimal.TryParse(Console.ReadLine(), out result))
            {
                Console.WriteLine("Invalid input. Please enter a valid decimal number.");
                Console.Write(message);
            }
            return result;
        }
    }
}