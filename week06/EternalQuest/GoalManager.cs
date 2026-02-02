public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    private int _level = 1;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        string choice = "";

        while (choice != "6")
        {
            Console.WriteLine();
            Console.WriteLine($"You have {_score} points.");
            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goal Details");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");

            choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;

                case "2":
                    ListGoalDetails();
                    break;

                case "3":
                    Console.Write("What is the filename for the goal file? ");
                    string saveFile = Console.ReadLine();
                    SaveGoals(saveFile);
                    break;

                case "4":
                    Console.Write("What is the filename for the goal file? ");
                    string loadFile = Console.ReadLine();
                    LoadGoals(loadFile);
                    break;

                case "5":
                    RecordEvent();
                    break;

                case "6":
                    Console.WriteLine("Goodbye!");
                    break;

                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
    }

    public void DisplayPlayerInfo()
    {
    }

    public void ListGoalNames()
    {
        Console.WriteLine("The goals are:");

        if (_goals.Count == 0)
        {
            Console.WriteLine("  No goals have been created yet.");
            return;
        }

        int index = 1;
        foreach (Goal goal in _goals)
        {
            Console.WriteLine($"  {index}. {goal.GetShortName()}");
            index++;
        }
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("The goals are:");

        if (_goals.Count == 0)
        {
            Console.WriteLine("  No goals have been created yet.");
            return;
        }

        int index = 1;
        foreach (Goal goal in _goals)
        {
            Console.WriteLine($"  {index}. {goal.GetDetailsString()}");
            index++;
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");

        string choice = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();

        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case "1":
                _goals.Add(new SimpleGoal(name, description, points));
                break;
            
            case "2":
                _goals.Add(new EternalGoal(name, description, points));
                break;

            case "3":
                Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                int target = int.Parse(Console.ReadLine());

                Console.Write("What is the bonus for completing it that many times? ");
                int bonus = int.Parse(Console.ReadLine());

                _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                break;

            default:
                Console.WriteLine("Invalid choice. No goal created.");
                break;
        }
    }

    public void RecordEvent()
    {
        Console.WriteLine("Which goal did you accomplish?");
        ListGoalNames();

        Console.Write("Enter the number of the goal: ");
        int index = int.Parse(Console.ReadLine()) - 1;

        if (index < 0 || index >= _goals.Count)
        {
            Console.WriteLine("Invalid selection.");
            return;
        }

        Goal goal = _goals[index];

        goal.RecordEvent();

        int pointsEarned = CalculatePoints(goal);

        _score += pointsEarned;

        Console.WriteLine($"Congratulations! You earned {pointsEarned} points!");
        Console.WriteLine($"Your total score is now {_score}");

        CheckLevelUp();
    }

    public void SaveGoals(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(_score);

            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }

        Console.WriteLine("Goals saved successfully.");
    }

    public void LoadGoals(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        string[] lines = File.ReadAllLines(filename);

        _goals.Clear();

        _score = int.Parse(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            string line = lines[i];
            string[] parts = line.Split(':');

            string goalType = parts[0];
            string[] data = parts[1].Split(',');

            switch (goalType)
            {
                case "SimpleGoal":
                    _goals.Add(new SimpleGoal(
                        data[0],
                        data[1],
                        int.Parse(data[2])
                    )
                    {
                    });

                    SimpleGoal simple = (SimpleGoal)_goals[_goals.Count - 1];
                    if (bool.Parse(data[3]))
                    {
                        simple.RecordEvent();
                    }
                    break;

                case "EternalGoal":
                    _goals.Add(new EternalGoal(
                        data[0],
                        data[1],
                        int.Parse(data[2])
                    ));
                    break;

                case "ChecklistGoal":
                    _goals.Add(new ChecklistGoal(
                        data[0],
                        data[1],
                        int.Parse(data[2]),
                        int.Parse(data[4]),
                        int.Parse(data[5])
                    ));

                    ChecklistGoal checklist = (ChecklistGoal)_goals[_goals.Count - 1];

                    checklist.SetAmountCompleted(int.Parse(data[3]));
                    break;

                default:
                    Console.WriteLine($"Unknown goal type: {goalType}");
                    break;
            }
        }

        Console.WriteLine("Goals loaded successfully.");
    }

    private int CalculatePoints(Goal goal)
    {
        if (goal is not ChecklistGoal checklist)
            return goal.GetPoints();

        int points = goal.GetPoints();

        if (checklist.IsComplete())
            points += GetChecklistBonus(checklist);

        return points;
    }

    private int GetChecklistBonus(ChecklistGoal checklist)
    {
        return checklist.GetBonus();
    }

    private void CheckLevelUp()
    {
        int newLevel = (_score / 100) + 1;

        if (newLevel > _level)
        {
            _level = newLevel;
            Console.WriteLine($"*** Congratulations! You reached Level {_level}! ***");
        }
    }
}