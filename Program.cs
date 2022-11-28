using System;
using static System.Console;
namespace MyNamespace
{
    class MyClass
    {
        
        static void Main()
        {
            int TotalPoints = 0;
            int points;
            string Console_Color = "Green";
            ForegroundColor = ConsoleColor.Green;
        program:
            {
                 points = 0;
                DrawBoard(20);
                //DrawElemnts(1, 's', 20); // level = i special 20
                Clear();
                Random random = new Random();
                char[] arr = { '!', '*', '%' };
                if (Console_Color == "Green")
                {
                    Console.WriteLine("(Design Suggestion): Do you Want The Text Color To Be Red? [Any Other Key][N]");
                }
                else
                {
                    Console.WriteLine("(Design Suggestion): Do you Want The Text Color To Be Green? [Any Other Key][N]");
                }
                var KeyPressed = Console.ReadKey(true).Key;
                if (KeyPressed != ConsoleKey.N && Console_Color == "Green")
                {
                    ForegroundColor = ConsoleColor.Red;
                    Console_Color = "Red";
                }else if (KeyPressed != ConsoleKey.N && Console_Color == "Red")
                {
                    ForegroundColor = ConsoleColor.Green;
                    Console_Color = "Green";
                }
                Clear();
                Write("How Many Rounds Do You Want To Play? ");
                int limit = GetIntFromUser();
                Clear();
                Console.WriteLine("Press Any Key To Start The Game.....");
                Console.ReadKey();
                for (int level = 0; level < limit; level++)
                {
                    Clear();
                    DrawBoard(20);
                    int IndexArr = random.Next(0, arr.Length); // אינקס מיוחד במערך arr
                    int IndexArr2 = random.Next(0, arr.Length); // האינקס של האיברים הלא שונים במערך arr
                    while (IndexArr == IndexArr2)
                    {
                        IndexArr2 = random.Next(0, arr.Length);
                    }
                    DrawElemnts(level, arr[IndexArr], 20, arr[IndexArr2]);
                    ReadKey(); // press *
                               // x -> @,!,$  
                    var letter = ConsoleKey.BrowserRefresh;
                    switch (arr[IndexArr])
                    {
                        case '!':
                            letter = ConsoleKey.D1;
                            break;
                        case '*':
                            letter = ConsoleKey.D8;
                            break;
                        case '%':
                            letter = ConsoleKey.D5;
                            break;
                    }
                    while (letter != Console.ReadKey().Key) { points--; };
                    points++;
                }
                Clear();
            }
            if (points < 0) Console.WriteLine($"-> You've earned {points} points in this game");

            else Console.WriteLine($"-> You've earned {points} points");

            TotalPoints+= points;
            Console.WriteLine();
            Console.WriteLine($"-> You Have on Total {TotalPoints} points in this game");
            Console.WriteLine();
            Console.WriteLine("-> Click On Any Key.....");
            ReadKey();
            Clear();
            Console.WriteLine("Do You Want To Start Again? [Y][Any OtherKey]");

            if (Console.ReadKey().Key == ConsoleKey.Y)
                goto program;
            else
                return;
        }
        static void DrawBoard(int lengh1)
        {
            for (int i = 0; i < lengh1*3; i++) // רוחב ימין
            {
                SetCursorPosition(i, 0);
                Write("+");
            }
            for (int i = 0; i < lengh1; i++) // אורך שמאל
            {
                SetCursorPosition(0, i);
                Write("+");
            }
            for (int i = 0; i < lengh1*3+1; i++) // רוחב למטה
            {
                SetCursorPosition(i, lengh1);
                Write("+");
            }
            for (int i = 0; i < lengh1; i++) // אורך ימין
            {
                SetCursorPosition(lengh1*3,i);
                Write("+"); 
            }
        }
        static void DrawElemnts(int level,char special_char,int lengh1,char defult)
        {
            Random random= new Random();
            int[] SpecialPosition = {random.Next(1,lengh1*3-1),random.Next(1,lengh1-1)};
            DrawSpecialChar(SpecialPosition, special_char);
            for (int i = 1; i < lengh1; i++) // lengh1 הוא הגובה
            {
                for (int x = 0; x < level; x++)
                {
                    int[] X_AxisT = GeneratePosition(lengh1, SpecialPosition, i);
                    int X_Axis = X_AxisT[0];
                    SetCursorPosition(X_Axis, i);
                    Write(defult);
                }
            }
            SetCursorPosition(0, lengh1+6);
            WriteLine("Press Twice On The Different Element On Your KeyBaord......");
            SetCursorPosition(0, lengh1+8);
            Write("Typed Elements On Your KeyBoard: ");
        }
        static int[] GeneratePosition(int lengh1, int[] GeneratedPosition,int i) // לנף1 => גובה
        {
            Random random= new Random();
            int X_Axis = random.Next(1,lengh1*3-1);
            while (X_Axis == GeneratedPosition[0] && i == GeneratedPosition[1])
            {
                X_Axis = random.Next(1, lengh1 * 3 - 1);
            }
            int[] arr = { X_Axis, i };
            return arr;
        }
        static void DrawSpecialChar(int[] position,char SpecialChar)
        {
            SetCursorPosition(position[0], position[1]);
            Write($"{SpecialChar}");
        }
        static int GetIntFromUser()
        {
            int x;
            gotoo: {}
            try
            {
              x = int.Parse(Console.ReadLine());
                if (x > 20 || x < 0)
                {
                    goto gotoo;
                }
            }
            catch (Exception)
            {
                Console.Write("-> Press Only One Integer Betwenn 0 To 20: ");
                goto gotoo;
            }
            return x;
        }
        
    }
}

