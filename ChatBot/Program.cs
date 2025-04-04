
using System;
using System.Media;
using System.Speech.Synthesis;


namespace ChatBot
{

    class Program
    {
        public static void VoiceGreeting()//This method is for greeting the user
        {
            string audio = @"C:\Users\RC_Student_lab\Documents\ST10452412 KEEBINE M.H\ChatBot\Cybersecurity bot.wav";
            SoundPlayer sound = new SoundPlayer(audio);
            sound.PlaySync();
        }

        public static void ImageDisplay()//This method displays the ASCII represantation of the logo
        {
            Console.WriteLine(@"  ____      _                                        _ _               
 / ___|   _| |__   ___ _ __ ___  ___  ___ _   _ _ __(_) |_ _   _    
| |  | | | | '_ \ / _ \ '__/ __|/ _ \/ __| | | | '__| | __| | | |   
| |__| |_| | |_) |  __/ |  \__ \  __/ (__| |_| | |  | | |_| |_| |  
 \____\__, |_.__/ \___|_|  |___/\___|\___|\__,_|_|  |_|\__|\__, | 
      |___/                                                |___/   ");
            Console.WriteLine(@"    _                                               ____        _ 
   / \__      ____ _ _ __ ___ _ __   ___  ___ ___  | __ )  ___ | |_ 
  / _ \ \ /\ / / _` | '__/ _ \ '_ \ / _ \/ __/ __| |  _ \ / _ \| __|
 / ___ \ V  V / (_| | | |  __/ | | |  __/\__ \__ \ | |_) | (_) | |_ 
/_/   \_\_/\_/ \__,_|_|  \___|_| |_|\___||___/___/ |____/ \___/ \__|");
        }
        public static void UserInteraction()//This method is for the user interaction 
        {
            SpeechSynthesizer sound = new SpeechSynthesizer();
            sound.Volume = 100;// set volume
            sound.Rate = 0;// set speesking rate
            Console.ForegroundColor = ConsoleColor.Blue;
            PrintWithDelay("BOT: What is your name? ");
            sound.SpeakAsync(" What is your name?");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("YOU: ");
            string name = Console.ReadLine();

            while (string.IsNullOrEmpty(name))
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                PrintWithDelay("BOT: Please enter a valid name.");
                sound.SpeakAsync("Please enter a valid name.");
                Console.ForegroundColor = ConsoleColor.Green;

                Console.Write("YOU: ");
                name = Console.ReadLine().Trim();
            }
            Console.ForegroundColor = ConsoleColor.Blue;
            PrintWithBorder(" HELLO " + name + ", I'M YOUR PERSONAL CYBERSECURITY AWARENESS BOT! NICE TO MEET YOU ");
            sound.Speak("HELLO " + name + ", I'M YOUR PERSONAL CYBERSECURITY AWARENESS BOT! NICE TO MEET YOU ");
        }

        static void PrintWithBorder(string message)//This method prints the border lines arround the welcoming message 
        {
            string border = new string('═', message.Length);
            Console.WriteLine("╔" + border + "╗");
            Console.WriteLine("║" + message + "║");
            Console.WriteLine("╚" + border + "╝");
        }

        public static void BasicResponse()//This method is for responding the users basic questions 
        {
            SpeechSynthesizer sound = new SpeechSynthesizer();
            sound.Volume = 100;// set volume
            sound.Rate = 0;// set speesking rate

            Console.ForegroundColor = ConsoleColor.Blue;
            PrintWithDelay("\nBOT: Ask me anything OR enter 'exit' to exit the application! ");
            sound.Speak("Ask me anything OR enter 'exit' to exit the application!");

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("YOU: ");
                string user = Console.ReadLine().Trim();

                switch (user)
                {
                    case "How are you?":

                        Console.ForegroundColor = ConsoleColor.Blue;
                        PrintWithDelay("BOT: Im doing well, thank you for asking! How can I help you?");
                        sound.SpeakAsync("I'm doing well, thank you for asking! How can I help you?");

                        break;

                    case "What's your purpose?":

                        Console.ForegroundColor = ConsoleColor.Blue;
                        PrintWithDelay("BOT: My purpose is to help you stay safe online!");
                        sound.SpeakAsync("My purpose is to help you stay safe online!");

                        break;

                    case "What can I ask you about?":

                        Console.ForegroundColor = ConsoleColor.Blue;
                        PrintWithDelay("BOT: You can ask me about password safety, phishing and safe browsing!");
                        sound.SpeakAsync("You can ask me about password safety, phishing and safe browsing!");

                        break;
                    case "Tell me about password safety":
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Password security refers to the various practices used to establish and verify the identity of the user" +
                            " and to ensure that your password is strong and safe to use,make sure that it contains letters, numbers and symbols");
                        break;
                    case "What is phishing?":
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Phishing is a cybercrime where attackers deceive individuals into revealing sensitive" +
                            " information. It can be done through fraudulent emails, text messages, phone calls, or websites. " +
                            "The goal is to steal data such as passwords, credit card details, and personally identifiable " +
                            "information.");
                        break;

                    case "What is safe browsing?":
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Safe browsing is a service that catalogs fraudulent or malicious websites." +
                            "It allows client application to check URLs against Google's constantly updated lists of unsafe web resources, such as social engineering sites and sites that host malware or unwanted software.");
                        break;

                    case "exit":
                        Console.ForegroundColor = ConsoleColor.Blue;
                        PrintWithDelay("Bot: Goodbye! Stay safe online!!!");
                        sound.SpeakAsync("Goodbye! Stay safe online!!!");

                        Console.ResetColor();
                        Environment.Exit(0);
                        break;
                    default:

                        if (string.IsNullOrEmpty(user) || user != "")
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            PrintWithDelay("BOT: I did't quite understand that.Could you please rephrase?");
                            sound.SpeakAsync("I did't quite understand that.Could you please rephrase?");
                        }
                        break;
                }
            }
        }
        public static void PrintWithDelay(string message)//This method is for printing the chatbots output in a delaying format
        {
            foreach (char h in message)
            {
                Console.Write(h);
                Thread.Sleep(12);
            }
            Console.WriteLine();
        }


        public static void Main(String[] args)
        {
            ImageDisplay();

            VoiceGreeting();

            UserInteraction();

            BasicResponse();

        }
    }


}