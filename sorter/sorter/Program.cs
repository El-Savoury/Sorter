using System;
using System.Collections.Generic;

namespace sorter
{
    class Program
    {
        //change text colour
        static void ColourText(string s)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write(s);
            Console.ForegroundColor = ConsoleColor.Cyan;
        }

        //prompt user for input
        static void InputPrompt(int spaces, string a)
        {
            string indent = new string(' ', spaces);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"\n{indent}[+] ");
            ColourText(a);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.ResetColor();
        }

        //highlight certain words in string to mimic IDE
        static void ShowCode(string code)
        {
            string[] codeArr = code.Split(' ');
            foreach (string i in codeArr)
            {
                if (i.Contains('¦'))
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write(i + ' ');
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                }
                else if (i == "else" || i == "if" || i == "for" || i == "foreach" || i.Contains("int") || i == "char" || i == "char[]" || i.Contains("string") || i == "0" || i == "1" || i == "return" || i == "true" || i == "false" || i == "static" || i == "bool")
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(i + ' ');
                }
                else if (i == "[<]" || i == "esc" || i == "+" || i == "-" || i == "<" || i == ">" || i == "(" || i == ")" || i == "in" || i == "{" || i == "}" || i == "=" || i == ";" || i == ":" || i == "," || i == "]" || i == "[" || i == "&&")
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write(i + ' ');
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write(i + ' ');
                }
            }
        }

        //colour string to look like comment in IDE 
        static void Comment(string comment)
        {
            string[] commentArr = comment.Split(' ');
            foreach (string i in commentArr)
            {
                if (i.Contains('¦'))
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write(i + ' ');
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write(i + ' ');
                }
            }
        }

        //convert chars to number equivelents and check which is alphabetically first
        static bool IsStringAlphabeticallyFirst(string str1, string str2)
        {
            for (int i = 0; i < str1.Length && i < str2.Length; i++)
            {
                int word1Letter = Convert.ToInt16(str1[i]);
                int word2Letter = Convert.ToInt16(str2[i]);

                if (word1Letter < word2Letter) { return true; }
                else if (word1Letter > word2Letter) { return false; }
            }
            if (str1.Length < str2.Length) { return true; }
            else { return false; }
        }

        static void Main()
        {
            Console.Title = "sorter";

            //define back button variable
            ConsoleKeyInfo back;

            //create main menu
            string page = "menu";
            switch (page)
            {
                #region menu
                case "menu":

                    //write menu to screen with coloured text and formatting
                    Console.Clear();
                    Console.WriteLine(@"
                                  __     ___    ___    ___   _____   ___   ___     __  
                                 ");
                    Console.Clear(); //weird console bug drawing start of title offscreen and this was only way to fix it

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    //write ascii title
                    Console.WriteLine(@"
                                  __     ___    ___    ___   _____   ___   ___     __
                                 / /    / __|  / _ \  | _ \ |_   _| | __| | _ \    \ \
                                < <     \__ \ | (_) | |   /   | |   | _|  |   /     > >  
                                 \_\    |___/  \___/  |_|_\   |_|   |___| |_|_\    /_/
                                                          
"); 
                    Console.Write("\n");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("                       [/]  ");
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    ColourText("Custom sorting algorithms created as an exercise to replicate");
                    Console.Write("  [\\]\n");
                    Console.Write("                       [\\]  ");
                    ColourText("C# built-in methods without using documentation or references");
                    Console.Write("  [/]\n\n\n\n");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("                       [+] ");
                    ColourText("Sorting Method :\n\n\n");
                    Console.Write("                       [1] ");
                    ColourText("Numerical\n\n");
                    Console.Write("                       [2] ");
                    ColourText("Alphabetical\n\n");
                    Console.Write("                       [3] ");
                    ColourText("Length\n\n");
                    Console.Write("                       [4] ");
                    ColourText("Reverse\n\n");
                    Console.ResetColor();
                    Console.Write("                       [>] ");

                    string input;
                    string[] inputArr;

                    //get user input and go to selected page
                    string choice = Console.ReadLine();
                    if (choice == "1") { goto case "numerical"; }
                    else if (choice == "2") { goto case "alphabetical"; }
                    else if (choice == "3") { goto case "length"; }
                    else if (choice == "4") { goto case "reverse"; }
                    else
                    {
                        Console.Clear();
                        goto case "menu"; // refresh menu on incorrect input
                    }
                #endregion

                #region numerical
                case "numerical":

                    Console.Clear();

                    //write algorithm as string
                    ShowCode(@"
  [<] esc          ¦       List<int>  sortList  =  new  List<int>()  {  numList [ 0 ]  }               ¦
                   ¦                                                                                   ¦
                   ¦       for  ( int  i  =  1 ;  i  <  numList.Count ;  i++ )                         ¦
                   ¦       {                                                                           ¦
                   ¦          int  currentNum   =   numList [ i ] ;                                    ¦
                   ¦          int  previousNum  =   numList [ i - 1 ] ;                                ¦
                   ¦          int  highestNum   =   sortList [ sortList.Count - 1 ] ;                  ¦
                   ¦          int  index        =   sortList.IndexOf ( previousNum ) ;                 ¦
                   ¦                                                                                   ¦
                   ¦          if  ( currentNum  >  highestNum ) { sortList.Add ( currentNum ) ; }      ¦
                   ¦          else  if  ( currentNum  >  previousNum )                                 ¦
                   ¦          {                                                                        ¦
                   ¦              while  ( sortList [ index + 1 ]  <  currentNum )                     ¦
                   ¦              { index++ ; }                                                        ¦
                   ¦              sortList.Insert ( index + 1 ,  currentNum ) ;                        ¦
                   ¦          }                                                                        ¦
                   ¦          else                                                                     ¦
                   ¦          {                                                                        ¦
                   ¦              while  ( index  >  0  &&  sortList [ index - 1 ]  >  currentNum )    ¦
                   ¦              { index-- ; }                                                        ¦
                   ¦              sortList.Insert ( index ,  currentNum ) ;                            ¦
                   ¦          }                                                                        ¦
                   ¦       }                                                                           ¦

");

                    //show input prompt
                    InputPrompt(19, "Enter numbers separated by spaces : ");

                    //put user input into array
                    input = Console.ReadLine();
                    inputArr = input.Split(' ');

                    //create integer list from input string
                    List<int> numList = new List<int>();

                    //check for valid input format and add numbers to list
                    for (int i = 0; i < inputArr.Length; i++)
                    {
                        int num;
                        bool validInput = Int32.TryParse(inputArr[i], out num);

                        if (validInput) { numList.Add(num); }
                        else { goto case "numerical"; } //refresh page on incorrect input
                    }

                    //initialise new list for sorted numbers
                    List<int> sortList = new List<int>() { numList[0] };

                    //sort numbers into numerical order
                    for (int i = 1; i < numList.Count; i++)
                    {
                        int currentNum = numList[i];
                        int previousNum = numList[i - 1];
                        int highestNum = sortList[sortList.Count - 1];
                        int index = sortList.IndexOf(previousNum);

                        if (currentNum > highestNum)
                        {
                            sortList.Add(currentNum);
                        }
                        else if (currentNum > previousNum)
                        {
                            while (sortList[index + 1] < currentNum)
                            {
                                index++;
                            }
                            sortList.Insert(index + 1, currentNum);
                        }
                        else
                        {
                            while (index > 0 && sortList[index - 1] > currentNum)
                            {
                                index--;
                            }
                            sortList.Insert(index, currentNum);
                        }
                    }

                    //print sorted list to console
                    Console.ResetColor();
                    Console.Write("\n                   [>] " + string.Join(' ', sortList) + ' ');

                    //press esc to go back to menu
                    back = Console.ReadKey();
                    if (back.Key == ConsoleKey.Escape)
                    {
                        Console.Clear();
                        goto case "menu";
                    }
                    else { goto case "numerical"; } //refresh page if another key is pressed
                #endregion

                #region alphabetical
                case "alphabetical":

                    Console.Clear();

                    //write algorithm as string
                    ShowCode(@"
  [<] esc        ¦    static  bool  IsStringAlphabeticallyFirst ( string  str1 ,  string  str2 )        ¦
                 ¦    {                                                                                 ¦
                 ¦        for  ( int  i  =  0 ;  i  <  str1.Length  &&  i  <  str2.Length ;  i++ )      ¦
                 ¦        {                                                                             ¦      
                 ¦            int  word1Letter  =  Convert.ToInt16 ( str1 [ i ] ) ;                     ¦
                 ¦            int  word2Letter  =  Convert.ToInt16 ( str2 [ i ] ) ;                     ¦
                 ¦                                                                                      ¦
                 ¦            if  ( word1Letter  <  word2Letter )  {  return  true ;  }                 ¦
                 ¦            else  if  ( word1Letter  >  word2Letter )  {  return  false ;  }          ¦
                 ¦        }                                                                             ¦
                 ¦                                                                                      ¦   
                 ¦        if ( str1.Length  <  str2.Length )  { return  true ; }                        ¦
                 ¦        else  { return  false ; }                                                     ¦
                 ¦    }                                                                                 ¦
                 ¦                                                                                      ¦
                 ¦    List<string> sortedWords = new List<string>() { inputArr[0] } ;                   ¦
");
                    Comment(@"                ¦                                                                                      ¦
                 ¦    /* use  numerical  sort  on  inputArr  with  IsStringAlphabeticallyFirst()        ¦
                 ¦    /  in  the  place  of  x > y  to  determine  index  in  list  e.g:                ¦
                 ¦    /                                                                                 ¦
                 ¦    /  if ( IsStringAlphabeticallyFirst ( currentWord ,  highestWord )  ==  false )   ¦
                 ¦    /  {                                                                              ¦
                 ¦    /      sortedWords.Add ( currentWord ) ;                                          ¦
                 ¦    /  } */                                                                           ¦
");

                    //prompt user for input
                    InputPrompt(17, "Enter words separated by spaces : ");

                    //put user input into array
                    input = Console.ReadLine();
                    inputArr = input.Split(' ');

                    //sort words into alphabetical order
                    List<string> sortedWords = new List<string>() { inputArr[0] };

                    for (int i = 1; i < inputArr.Length; i++)
                    {
                        string currentWord = inputArr[i];
                        string previousWord = inputArr[i - 1];
                        string highestWord = sortedWords[sortedWords.Count - 1];
                        int index = sortedWords.IndexOf(previousWord);

                        if (IsStringAlphabeticallyFirst(currentWord, highestWord) == false) //currentWord comes after highestWord alphabetically
                        {
                            sortedWords.Add(currentWord);
                        }
                        else if (IsStringAlphabeticallyFirst(currentWord, previousWord) == false) //currentWord comes after previousWord alphabetically
                        {
                            while (index < sortedWords.Count - 1 && IsStringAlphabeticallyFirst(sortedWords[index + 1], currentWord) == true) //while any words between previousWord and highestWord are before currentWord in alphabet, move currentWord up list
                            {
                                index++;
                            }
                            sortedWords.Insert(index + 1, currentWord);
                        }
                        else
                        {
                            while ((index > 0) && (IsStringAlphabeticallyFirst(sortedWords[index - 1], currentWord) == false)) //while currentWord is before previousWord or any words below, move currentWord down in list
                            {
                                index--;
                            }
                            sortedWords.Insert(index, currentWord);
                        }
                    }

                    //print sorted list
                    Console.ResetColor();
                    Console.Write("\n                 [>] " + string.Join(' ', sortedWords) + ' ');
                    Console.ReadKey();

                    // press esc to go back to menu
                    back = Console.ReadKey();
                    if (back.Key == ConsoleKey.Escape)
                    {
                        Console.Clear();
                        goto case "menu";
                    }
                    else { goto case "alphabetical"; } //refresh page if another key is pressed
                #endregion

                #region length
                case "length":

                    Console.Clear();

                    //write algorithm as string
                    ShowCode(@"
   [<] esc        ¦    List<int>  letterCountList  =  new  List<int>() ;                                 ¦
                  ¦                                                                                      ¦
                  ¦    foreach  ( string  word  in  inputArr )                                           ¦  
                  ¦    {                                                                                 ¦
                  ¦        int  letterCount   =  0 ;                                                     ¦
                  ¦        char[]  letterArr  =  word.ToCharArray() ;                                    ¦
                  ¦                                                                                      ¦
                  ¦        foreach  ( char  letter  in  letterArr )                                      ¦
                  ¦        { letterCount++ ; }                                                           ¦
                  ¦        letterCountList.Add ( letterCount ) ;                                         ¦
                  ¦    }                                                                                 ¦
                  ¦                                                                                      ¦
                  ¦    List<int>  sortletterCount    =  new  List<int>()  { letterCountList [ 0 ] } ;    ¦
                  ¦    List<string>  wordLengthList  =  new  List<string>()  { inputArr [ 0 ] } ;        ¦
                  ¦                                                                                      ¦");
                    Comment(@"                               ¦    /* use  numerical  sort  on  letterCountList  then  insert  corresponding         ¦
                  ¦    /  word  to  wordLengthList  using  the  matching  index  number  e.g:            ¦
                  ¦    /                                                                                 ¦
                  ¦    /  if  ( currentNum  >  highestNum )                                              ¦
                  ¦    /  {                                                                              ¦
                  ¦    /      sortletterCount.Add ( currentNum ) ;                                       ¦
                  ¦    /      wordLengthList.Add ( inputArr [ i ] ) ;                                    ¦
                  ¦    /  } */                                                                           ¦

");

                    //prompt user for input
                    InputPrompt(18, "Enter words separated by spaces : ");

                    //put user input into array
                    input = Console.ReadLine();
                    inputArr = input.Split(' ');

                    //calculate number of letters per word
                    List<int> letterCountList = new List<int>();

                    foreach (string word in inputArr)
                    {
                        int letterCount = 0;
                        char[] letterArray = word.ToCharArray();

                        foreach (char letter in letterArray)
                        {
                            letterCount++;
                        }
                        letterCountList.Add(letterCount);
                    }

                    //initialise list for sorted letter count and list for sorted words
                    List<int> sortletterCount = new List<int>() { letterCountList[0] };
                    List<string> wordLengthList = new List<string>() { inputArr[0] };

                    //use numerical sort on letterCountList then insert corresponding word from inputArr using the matching index number
                    for (int i = 1; i < letterCountList.Count; i++)
                    {
                        int currentNum = letterCountList[i];
                        int previousNum = letterCountList[i - 1];
                        int highestNum = sortletterCount[sortletterCount.Count - 1];
                        int index = sortletterCount.IndexOf(previousNum);

                        if (currentNum > highestNum)
                        {
                            sortletterCount.Add(currentNum);
                            wordLengthList.Add(inputArr[i]);
                        }
                        else if (currentNum > previousNum)
                        {
                            while (sortletterCount[index + 1] < currentNum)
                            {
                                index++;
                            }
                            sortletterCount.Insert(index + 1, currentNum);
                            wordLengthList.Insert(index + 1, inputArr[i]);
                        }
                        else
                        {
                            while (index > 0 && sortletterCount[index - 1] > currentNum)
                            {
                                index--;
                            }
                            sortletterCount.Insert(index, currentNum);
                            wordLengthList.Insert(index, inputArr[i]);
                        }

                    }

                    //print sorted list
                    Console.ResetColor();
                    Console.Write("\n                  [>] " + string.Join(' ', wordLengthList) + ' ');
                    Console.ReadKey();

                    // press esc to go back to menu
                    back = Console.ReadKey();
                    if (back.Key == ConsoleKey.Escape)
                    {
                        Console.Clear();
                        goto case "menu";
                    }
                    else { goto case "length"; } //refresh page if another key is pressed
                #endregion

                #region reverse
                case "reverse":

                    Console.Clear();


                    //write algorithm as string
                    ShowCode(@"
  [<] esc          ¦     string  input  =  Console.ReadLine() ;                                  ¦
                   ¦     string  output ;                                                        ¦
                   ¦                                                                             ¦
                   ¦     if  ( input.Contains ( '  ' ) )                                         ¦
                   ¦     {                                                                       ¦
                   ¦          string[]  reverseArr  =  input.Split ( '  ' ) ;                    ¦
                   ¦                                                                             ¦
                   ¦          for  ( int  i  =  reverseArr.Length  -  1 ;  i  >=  0 ;  i-- )     ¦
                   ¦          {                                                                  ¦
                   ¦              output  + =  reverseArr [ i ]  +  '  ' ;                       ¦
                   ¦          }                                                                  ¦
                   ¦     }                                                                       ¦
                   ¦     else                                                                    ¦
                   ¦     {                                                                       ¦
                   ¦          char[]  reverseArr  =  input.ToCharArray() ;                       ¦
                   ¦                                                                             ¦
                   ¦          for ( int  i  =  reverseArr.Length  -  1 ;  i  >=  0 ;  i-- )      ¦
                   ¦          {                                                                  ¦
                   ¦              output  + =  reverseArr [ i ]  ;                               ¦ 
                   ¦          }                                                                  ¦
                   ¦     }                                                                       

");

                    //prompt user for input
                    InputPrompt(18, "Enter list of words, numbers or letters : ");

                    //put user input into array
                    input = Console.ReadLine();
                    string output = "";

                    //check if user input is list of seperate words or just characters without spaces and reverse order
                    if (input.Contains(' '))
                    {
                        string[] reverseArr = input.Split(' ');

                        for (int i = reverseArr.Length - 1; i >= 0; i--)
                        {
                            output += reverseArr[i] + ' ';
                        }
                    }
                    else
                    {
                        char[] reverseArr = input.ToCharArray();

                        for (int i = reverseArr.Length - 1; i >= 0; i--)
                        {
                            output += reverseArr[i];
                        }
                    }

                    //print sorted list
                    Console.ResetColor();
                    Console.Write("\n                  [>] " + output + ' ');

                    // press esc to go back to menu
                    back = Console.ReadKey();
                    if (back.Key == ConsoleKey.Escape)
                    {
                        goto case "menu";
                    }
                    else { goto case "reverse"; } //refresh page if another key is pressed
                    #endregion
            }
        }
    }
}
