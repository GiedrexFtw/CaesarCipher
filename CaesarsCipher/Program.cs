using System;
using System.Text;

namespace CaesarsCipher
{
    public class Program
    {
        private const int ALPHABET_SIZE = 26;
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            string textPrintMessage = "Hello, please type the text you would like to encrypt/decrypt(Please use letters A-Z): ";
            string actionPrintMessage = "Please choose the action you would like to perform from the options below:\n" +
                "(To encrypt/decrypt text, please type \"encrypt/decrypt\" ";
            string keyPrintMessage = "Please enter the key for encryption/decryption: ";
            string wrongKeyPrintMessage = "The key you entered is invalid. Please try again";
            string wrongActionPrintMessage = "Entered text is not a valid action. Please try again";

            Phase1:
            Console.WriteLine(textPrintMessage);
            string text = Console.ReadLine();
            Console.WriteLine(keyPrintMessage);
            bool isInt = int.TryParse(Console.ReadLine(), out int key);
            if (!isInt)
            {
                Console.WriteLine(wrongKeyPrintMessage);
                goto Phase1;
            }
            Console.WriteLine(actionPrintMessage);
            string action = Console.ReadLine();
            string result;
            switch (action)
            {
                case("encrypt"):
                    result = Encipher(text, key);
                    break;
                    
                case ("decrypt"):
                    result = Decipher(text, key);
                    break;
                    
                default:
                    Console.WriteLine(wrongActionPrintMessage);
                    goto Phase1;
            }
            Console.WriteLine("Result is: " + result);
           
        }

        public static string Decipher(string text, int key)
        {
            return Encipher(text, -key);
        }

        public static string Encipher(string text, int key)
        {
            key %= ALPHABET_SIZE;
            StringBuilder encipheredText = new StringBuilder();
            foreach (char letter in text)
            {
                if (char.IsLower(letter))
                {
                    encipheredText.Append(GetLetter(letter, key, 'a', 'z'));
                }
                else if (char.IsUpper(letter))
                {
                    encipheredText.Append(GetLetter(letter, key, 'A', 'Z'));
                }
                else
                {
                    encipheredText.Append(letter);
                }
            }
            return encipheredText.ToString();
        }
        public static char GetLetter(char letter, int key, char lowest, char highest)
        {
            letter += (char)key;
            if (letter < lowest)
            {
                return (char)(letter + ALPHABET_SIZE);
            }
            if (letter > highest)
            {
                return (char)(letter - ALPHABET_SIZE);
            }
            return letter;
        }

    }
}
