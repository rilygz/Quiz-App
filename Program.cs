using System;
using System.Collections.Generic;
//The use of this is to allow users to create strongly typed collections and list that provide better type safety and performance.


class QuizQuestion
{
    public string Question { get; set; }
    //This means that it can be accessed outside the class.
    public string Answer { get; set; }
}

class QuizApp
{
    static List<QuizQuestion> quizQuestions = new List<QuizQuestion>();
    static void Main()
    {
        PopulateDefaultQuestions();

        while (true)

        {
            string quiz = @"
 ██████╗ ██╗   ██╗██╗███████╗     █████╗ ██████╗ ██████╗ 
██╔═══██╗██║   ██║██║╚══███╔╝    ██╔══██╗██╔══██╗██╔══██╗
██║   ██║██║   ██║██║  ███╔╝     ███████║██████╔╝██████╔╝
██║▄▄ ██║██║   ██║██║ ███╔╝      ██╔══██║██╔═══╝ ██╔═══╝ 
╚██████╔╝╚██████╔╝██║███████╗    ██║  ██║██║     ██║     
 ╚══▀▀═╝  ╚═════╝ ╚═╝╚══════╝    ╚═╝  ╚═╝╚═╝     ╚═╝     
                                                         
                                                         ";
            Console.WriteLine(quiz);
            Console.WriteLine("\aMain Menu:");
            Console.WriteLine("1. Start Quiz");
            Console.WriteLine("2. Edit Questionnaire");
            Console.WriteLine("3. Exit");
            Console.Write("Enter a number you choice(1-3): ");

            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    Console.Clear();
                    StartQuiz();
                    break;
                case "2":
                    Console.Clear();
                    EditQuestionnaire();
                    break;
                case "3":
                    Console.Clear();
                    Environment.Exit(0);//To exit from the code immediately even if the other codes are running.
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Invalid input. Please enter a valid option...");
                    break;
            }
        }
    }
    static void StartQuiz()
    {
        Console.Clear();
        Console.WriteLine("Quiz Time!");
        Console.Write("Select mode you want to play:\n1.Easy\n2.Medium\n3.Hard\n4.Back to main menu\nEnter your choice(1-4): ");
        string mode = Console.ReadLine();

        switch (mode)
        {
            case "1":
                EasyMode();
                break;
            case "2":
                MediumMode();
                break;
            case "3":
                HardMode();
                break;
            case "4":
                Console.Clear();
                Main();
                return;
        }

    }
    static void EasyMode()
    {
        Console.Clear();
        Console.WriteLine("Easy Mode");
        Console.WriteLine("Instruction:Answer the given questions quickly as possible.");
        Console.WriteLine("It's okay if you input a Lower or Uppercase letter, as long as your answer is Correct.GOODLUCK!\n");
        Console.Write("Do you want to proceed? Press Y if yes and press any key if you want to quit...");
        string continuee = Console.ReadLine().ToUpper();
        Console.Clear();
        if (continuee != "Y")
        {
            Main();
        }
        string[] questions =
       { "Who develop the C# programming language?",
        "Who is the founder of C# prgramming language",
        "Which symbols are used to mark the beginning and end of a code block?"
      };

        string[] answers =
        {
          "A.Oracle\nB.Microsoft\nC.GNU project",
          "A.Anders Hejlsberg\nB. Douglas Crockford\nC. Rasmus Lerdorf",
          "A.Square Brackets[]\nB.Curly Braces{}\nC.Round Brackets"
      };
        int[] correctAnswers = { 1, 0, 1 };
        int playerScore = 0;
        int totalTime = 0;

        for (int i = 0; i < questions.Length; i++)
        {
            Console.WriteLine("\aQuestion " + (i + 1));
            Console.WriteLine(questions[i]);
            Console.WriteLine(answers[i]);

            // Record start time
            DateTime startTime = DateTime.Now;

            Console.Write("Please enter your answer ('A','B','C'): ");
            string playersAnswer = Console.ReadLine();
            Console.Clear();
            // Record end time
            DateTime endTime = DateTime.Now;

            //Calculate time taken          
            TimeSpan timeTaken = endTime - startTime;
            totalTime += (int)timeTaken.TotalSeconds;

            //validating answer 

            if (string.Equals(playersAnswer, "A", StringComparison.OrdinalIgnoreCase) && correctAnswers[i] == 0)
            {
                playerScore++;
            }
            else if (string.Equals(playersAnswer, "a", StringComparison.OrdinalIgnoreCase) && correctAnswers[i] == 0)
            {
                playerScore++;
            }
            else if (string.Equals(playersAnswer, "B", StringComparison.OrdinalIgnoreCase) && correctAnswers[i] == 1)
            {
                playerScore++;
            }
            else if (string.Equals(playersAnswer, "b", StringComparison.OrdinalIgnoreCase) && correctAnswers[i] == 1)
            {
                playerScore++;
            }


        }
        //print score of player
        Console.WriteLine("Congrats you completed the quiz!");

        if (playerScore < 2)
        {
            Console.WriteLine("You failed. Better shift next sem!");

        }
        else
        {
            Console.WriteLine("Congrats! You're a true IT student!");
        }
        Console.WriteLine("Your score is: " + playerScore + "/" + questions.Length);
        Console.WriteLine($"Total time taken: {totalTime} seconds");

        // Ask if the user wants to continue
        Console.Write("Do you want to play again?Press Y if yes and press any key if you want to quit...");
        string continueInput = Console.ReadLine().ToUpper();
        Console.Clear();
        if (continueInput != "Y")
        {
            Main();
        }

    }
    static void MediumMode()
    {
        Console.Clear();
        Console.WriteLine("\aWelcome to medium mode!");
        Console.WriteLine("Instruction:Guess the jumbled words.");
        Console.Write("Do you want to proceed? Press Y if yes and press any key if you want to quit...");
        string continuee = Console.ReadLine().ToUpper();
        Console.Clear();
        if (continuee != "Y")
        {
            Main();
        }
        string[] Jumbledletter =
       {
      "ACRIITTHME OSPREORAT\nThis operators are very useful thing in computing value.\nIt performs basic calculations as add, subtraction, multiplication, division and modulus.",
      "LHTEGN\nIt is used to get the total number of element in all the dimensions of the Array."
      };

        int playerScore = 0;
        int totalTime = 0;
        for (int i = 0; i < Jumbledletter.Length; i++)
        {
            Console.Write("Q" + (i + 1) + " ");
            Console.WriteLine(Jumbledletter[i]);

            DateTime startTime = DateTime.Now;

            Console.Write("Please enter your answer: ");
            string playersAnswer = Console.ReadLine();
            Console.Clear();

            // Record end time
            DateTime endTime = DateTime.Now;

            //Calculate time taken          
            TimeSpan timeTaken = endTime - startTime;
            totalTime += (int)timeTaken.TotalSeconds;

            //validating answer 

            if (playersAnswer == "ARITHMETIC OPERATORS" || playersAnswer == "arithmetic operators" || playersAnswer == "Arithmetic operators")
            {
                playerScore++;
            }
            else if (playersAnswer == "LENGTH" || playersAnswer == "length" || playersAnswer == "Length")
            {
                playerScore++;
            }

        }
        //print score of player
        Console.WriteLine("Congrats you completed the quiz!");
        Console.WriteLine("Your score is: " + playerScore + "/" + Jumbledletter.Length);
        Console.WriteLine($"Total time taken: {totalTime} seconds");

        // Ask if the user wants to continue
        Console.Write("Do you want to play again?Press Y if yes and press any key if you want to quit...");
        string continueInput = Console.ReadLine().ToUpper();
        Console.Clear();
        if (continueInput != "Y")
        {
            Main();
        }
    }

    static void HardMode()
    {
        Console.Clear();
        Console.WriteLine("\aHard Mode:");
        Console.WriteLine("Instruction: Give the correct answer on the given statement.");
        Console.Write("Do you want to proceed? Press Y if yes and press any key if you want to quit...");
        string continuee = Console.ReadLine().ToUpper();
        Console.Clear();
        if (continuee != "Y")
        {
            Main();
        }
        // Questions and answers
        string[] questions = { "It is used for storing data.", "It translate source code to object code." };
        string[] answers = { "data type", "compiler" };
        string[] capanswers = { "DATA TYPE", "COMPILER" };
        int score = 0;
        int totalTime = 0;

        // Loop through questions
        for (int i = 0; i < questions.Length; i++)
        {
            Console.WriteLine($"Question {i + 1}: {questions[i]}");

            // Record start time
            DateTime startTime = DateTime.Now;

            // Get user input
            Console.Write("Your answer: ");
            string userAnswer = Console.ReadLine();

            // Record end time
            DateTime endTime = DateTime.Now;

            // Calculate time taken
            TimeSpan timeTaken = endTime - startTime;
            totalTime += (int)timeTaken.TotalSeconds;

            // Check answer
            if (userAnswer.Equals(answers[i], StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Correct!");
                score++;
            }
            else if (userAnswer.Equals(capanswers[i], StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Correct!");
                score++;
            }
            else
            {
                Console.WriteLine($"Incorrect. The correct answer is: {answers[i]}/{capanswers[i]}");
            }

            Console.WriteLine($"Time taken: {timeTaken.TotalSeconds} seconds\n");
            // Ask if the user wants to continue
        }
        Console.Write("Do you want to play again?Press Y if yes and press any key if you want to quit...");
        string continueInput = Console.ReadLine().ToUpper();
        Console.Clear();
        if (continueInput != "Y")
        {

            Main();
        }
    }

    static void EditQuestionnaire()
    {
        while (true)
        {
            Console.WriteLine("\aQuestionnaire Editor Menu:");
            Console.WriteLine("1. View Questions");
            Console.WriteLine("2. Add Question");
            Console.WriteLine("3. Back to Main Menu");
            Console.Write("Enter your choice: ");
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    Console.Clear();
                    ViewQuestions();
                    break;
                case "2":

                    AddQuestion();
                    break;
                case "3":
                    Console.Clear();
                    return; // Go back to the main menu
                default:
                    Console.Clear();
                    Console.WriteLine("Invalid input. Please enter a valid option...");
                    break;
            }
        }
    }

    static void ViewQuestions()
    {
        Console.WriteLine("Current Questions:");
        Console.WriteLine("Easy Mode:");
        Console.WriteLine("Who develop the C# programming language? Answer: Microsoft");
        Console.WriteLine("Who is the founder of C# prgramming language? Answer: Anders Hejlsberg");
        Console.WriteLine("Which symbols are used to mark the beginning and end of a code block? Answer: Square brackets[]");
        Console.WriteLine("\nMedium Mode:");
        Console.WriteLine("This operators are very useful thing in computing value.\nIt performs basic calculations as add, subtraction, multiplication, division and modulus. Answer: Arithmetic Operators/ARITHMETIC OPERATORS");
        Console.WriteLine("It is used to get the total number of element in all the dimensions of the Array. Answer: Length/LENGTH");
        Console.WriteLine("\nHard Mode:");

        for (int i = 0; i < quizQuestions.Count; i++)
        {
            Console.WriteLine($"{i + 1}.{quizQuestions[i].Question}, Answer: {quizQuestions[i].Answer}");
        }

    }

    static void AddQuestion()
    {
        Console.Clear();
        Console.WriteLine("2.Adding question");
        Console.Write("Enter the new question:");
        string newQuestion = Console.ReadLine();

        Console.Write("Enter the answer to the new question:");
        string newAnswer = Console.ReadLine();

        quizQuestions.Add(new QuizQuestion { Question = newQuestion, Answer = newAnswer });

        Console.WriteLine("Question added successfully!");
        Console.Write("Do you want to go back on main menu? Press Y if yes and press any key if you want to quit...");
        string continueInput = Console.ReadLine().ToUpper();
        Console.Clear();
        if (continueInput != "Y")
        {
            Main();
        }
    }

    static void PopulateDefaultQuestions()
    {
        // Add some default questions for demonstration
        quizQuestions.Add(new QuizQuestion { Question = "It is used for storing data.", Answer = "data type" });
        quizQuestions.Add(new QuizQuestion { Question = "It translate source code to object code.", Answer = "compiler" });
    }
}




