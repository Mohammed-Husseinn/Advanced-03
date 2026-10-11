#region  1,2,3, 4, 5, 6
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Exercise1();
        Exercise2();
        Exercise3();
        Exercise4();
        Exercise5();
        Exercise6();
    }

    static void PrintTitle(string title)
    {
        Console.WriteLine($"\n=== {title} ===");
    }

    static void Exercise1()
    {
        PrintTitle("Exercise 1: Student Grade Manager");

        List<int> grades = new List<int> { 85, 92, 78, 95, 88, 70, 100, 65 };

        Console.WriteLine("Grades: " + string.Join(", ", grades));
        Console.WriteLine("Count: " + grades.Count);
        Console.WriteLine("First grade: " + grades.First());
        Console.WriteLine("Last grade: " + grades.Last());

        grades.Sort();
        Console.WriteLine("Sorted grades: " + string.Join(", ", grades));

        int firstAbove90 = grades.First(g => g > 90);
        Console.WriteLine("First grade above 90: " + firstAbove90);

        List<int> failingGrades = grades.Where(g => g < 75).ToList();
        Console.WriteLine("Failing grades: " + string.Join(", ", failingGrades));

        grades.RemoveAll(g => g < 75);
        Console.WriteLine("After removing failing grades: " + string.Join(", ", grades));

        Console.WriteLine("Any grade equals 100? " + grades.Contains(100));

        List<string> gradeLabels = grades.Select(g => $"Grade: {g}").ToList();
        Console.WriteLine(string.Join(", ", gradeLabels));
    }

    static void Exercise2()
    {
        PrintTitle("Exercise 2: Leaderboard");

        SortedList<int, string> leaderboard = new SortedList<int, string>
        {
            { 500, "Ahmed" },
            { 200, "Sara" },
            { 800, "Ali" },
            { 350, "Mona" }
        };

        foreach (var entry in leaderboard)
            Console.WriteLine($"{entry.Key} = {entry.Value}");

        Console.WriteLine("First key: " + leaderboard.Keys[0]);
        Console.WriteLine("First value: " + leaderboard.Values[0]);

        Console.WriteLine("Score 500 exists? " + leaderboard.ContainsKey(500));

        if (leaderboard.TryGetValue(999, out string player))
            Console.WriteLine("Player with score 999: " + player);
        else
            Console.WriteLine("Player with score 999: Not Found");

        leaderboard.Remove(200);

        Console.WriteLine("After removing score 200:");
        foreach (var entry in leaderboard)
            Console.WriteLine($"{entry.Key} = {entry.Value}");
    }

    static void Exercise3()
    {
        PrintTitle("Exercise 3: Phone Book");

        Dictionary<string, string> phoneBook = new Dictionary<string, string>
        {
            { "Ahmed", "01011111111" },
            { "Sara", "01022222222" },
            { "Ali", "01033333333" },
            { "Mona", "01044444444" }
        };

        phoneBook["Omar"] = "01055555555";

        try
        {
            phoneBook.Add("Ahmed", "01999999999");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Add duplicate error: " + ex.Message);
        }

        bool added = phoneBook.TryAdd("Sara", "01888888888");
        Console.WriteLine("TryAdd duplicate succeeded? " + added);

        Console.WriteLine("Does Nada exist? " + phoneBook.ContainsKey("Nada"));

        string result = phoneBook.TryGetValue("Nada", out string number)
            ? number
            : "Not Found";

        Console.WriteLine("Nada phone: " + result);

        Console.WriteLine("Keys: " + string.Join(", ", phoneBook.Keys));
        Console.WriteLine("Values: " + string.Join(", ", phoneBook.Values));
    }

    static void Exercise4()
    {
        PrintTitle("Exercise 4: Unique Email Validator");

        HashSet<string> emails = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        emails.Add("ahmed@test.com");
        emails.Add("AHMED@test.com");
        emails.Add("sara@test.com");
        emails.Add("Sara@Test.Com");

        Console.WriteLine("Email count: " + emails.Count);
        Console.WriteLine("Only 2 are stored because the comparer ignores letter casing.");

        HashSet<int> setA = new HashSet<int> { 1, 2, 3, 4, 5 };
        HashSet<int> setB = new HashSet<int> { 4, 5, 6, 7, 8 };

        HashSet<int> union = new HashSet<int>(setA);
        union.UnionWith(setB);
        Console.WriteLine("Union: " + string.Join(", ", union));

        HashSet<int> intersection = new HashSet<int>(setA);
        intersection.IntersectWith(setB);
        Console.WriteLine("Intersection: " + string.Join(", ", intersection));

        HashSet<int> except = new HashSet<int>(setA);
        except.ExceptWith(setB);
        Console.WriteLine("Except: " + string.Join(", ", except));

        HashSet<int> smallSet = new HashSet<int> { 1, 2 };
        Console.WriteLine("{1,2} is subset of Set A? " + smallSet.IsSubsetOf(setA));
    }

    static void Exercise5()
    {
        PrintTitle("Exercise 5: Print Queue Simulator");

        Queue<string> printQueue = new Queue<string>();

        printQueue.Enqueue("Report.pdf");
        printQueue.Enqueue("Invoice.pdf");
        printQueue.Enqueue("Letter.docx");
        printQueue.Enqueue("Resume.pdf");
        printQueue.Enqueue("Photo.jpg");

        Console.WriteLine("Queue: " + string.Join(", ", printQueue));
        Console.WriteLine("Count: " + printQueue.Count);

        Console.WriteLine("Next document: " + printQueue.Peek());

        while (printQueue.Count > 0)
        {
            string document = printQueue.Dequeue();
            Console.WriteLine("Printing: " + document);
        }

        bool success = printQueue.TryDequeue(out string removed);
        Console.WriteLine("TryDequeue succeeded? " + success);
    }

    static void Exercise6()
    {
        PrintTitle("Exercise 6: Browser History");

        Stack<string> history = new Stack<string>();

        history.Push("google.com");
        history.Push("github.com");
        history.Push("stackoverflow.com");
        history.Push("youtube.com");
        history.Push("claude.ai");

        Console.WriteLine("Current page: " + history.Peek());

        for (int i = 0; i < 3; i++)
        {
            string leftPage = history.Pop();
            Console.WriteLine("Leaving: " + leftPage);
        }

        Console.WriteLine("Current page after going back: " + history.Peek());

        history.Clear();

        bool success = history.TryPop(out string page);
        Console.WriteLine("TryPop on empty stack succeeded? " + success);
    }
}




#endregion