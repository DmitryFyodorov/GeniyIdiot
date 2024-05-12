Console.WriteLine("Добро пожаловать в игру \"Гений - Идиот\"!\n");

var userFirstName = GetUserData("Введите ваше имя:");
var userLastName = GetUserData("Введите вашу фамилию:");
Clear();

bool isOpenApp = true;

while (isOpenApp)
{
    var questions = GetQuestions();
    var answers = GetAnswers();    

    var correctAnswersCount = 0;
    var questionsCount = questions.Count;
    var random = new Random();    

    for (int i = 0; i < questionsCount; i++)
    {
        var randomQuestinIndex = random.Next(0, questions.Count);

        Console.WriteLine($"Вопрос №{i + 1}:\n{questions[randomQuestinIndex]}");
        var userAnswer = GetDigitalUserAnswer();

        var rightAnwers = answers[randomQuestinIndex];
        if (userAnswer == rightAnwers)
        {
            correctAnswersCount++;            
        }
        questions.RemoveAt(randomQuestinIndex);
        answers.RemoveAt(randomQuestinIndex);
        //Clear();
    }

    var userDiagnosis = GetUserDiagnosis(correctAnswersCount, questionsCount);
    SaveResult(userFirstName, userLastName, correctAnswersCount, userDiagnosis);

    Console.WriteLine($"Количество правильных ответов: {correctAnswersCount}");
    Console.WriteLine($"{userFirstName} {userLastName}, ваш диагноз: {userDiagnosis}\n");

    var userChoice = IsYes("Показать таблицу результатов?");
    if (userChoice)
        ShowAllResults();

    isOpenApp = IsYes("Хотите пройти тест снова?");

    Clear();
}

List<string> GetQuestions()
{
    var questions = new List<string>()
    {
        "Сколько будет два плюс два умноженное на два?",
        "Бревно нужно распилить на 10 частей, сколько надо сделать распилов?",
        "На двух руках 10 пальцев. Сколько пальцев на 5 руках?",
        "Укол делают каждые пол часа, сколько нужно минут для трех уколов?",
        "Пять свечей горело, две потухли. Сколько свечей осталось?"
    };
    return questions;
}

List<int> GetAnswers()
{
    var answers = new List<int>()
    {
        6,
        9,
        25,
        60,    
        2
    };
    return answers;
}

List<string> GetDiagnoses()
{
    var diagnoses = new List<string>()
    {
        "идиот",
        "кретин",
        "дурак",
        "нормальный",
        "талант",
        "гений"
    };
    return diagnoses;
}

string GetUserDiagnosis(int correctAnswersCount, int questionsCount)
{
    var diagnosis = GetDiagnoses();

    var correctAnswersPercent = (double)correctAnswersCount * 100 / questionsCount;
    if (correctAnswersPercent == 100)
    {
        return diagnosis[5];
    }
    if (correctAnswersPercent >= 80)
    {
        return diagnosis[4];
    }
    if (correctAnswersPercent >= 60)
    {
        return diagnosis[3];
    }
    if (correctAnswersPercent >= 40)
    {
        return diagnosis[2];
    }
    if (correctAnswersPercent >= 20)
    {
        return diagnosis[1];
    }
    return diagnosis[0];
}


void SaveResult(string userFirstName, string userLastName, int correctAnswersCount, string userDiagnosis)
{
    var resultsFile = "results.txt";
    File.AppendAllText(resultsFile, $"{userFirstName} {userLastName} {correctAnswersCount} {userDiagnosis}" + Environment.NewLine);
}

string[] GetResults()
{
    var results = "results.txt";
    return File.ReadAllLines(results);
}

void ShowAllResults()
{
    var allResults = GetResults();
    ShowTable(allResults);
}

void ShowTable(string[] allResults)
{
    var tableFormat = "{0, -25} || {1, -18} || {2, -10}";

    Console.WriteLine("Таблица результатов тестирования:");
    Console.WriteLine(tableFormat, "Имя и фамилия", "Правильные ответы", "Диагноз");
    foreach (var result in allResults)
    {
        var tempResult = result.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        var fullName = $"{tempResult[0]} {tempResult[1]}";
        var correctAnswersCount = tempResult[2];
        var diagnosis = tempResult[3];
        Console.WriteLine(tableFormat, fullName, correctAnswersCount, diagnosis);
    }
}

string GetUserData(string requestedData)
{
    while (true)
    {
        Console.WriteLine(requestedData);
        var userData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);        
        if (userData.Length == 1)
        {
            return userData[0];
        }
        ShowMistake();
        Console.WriteLine("Необходимо ввести всего одно слово");
    }
}

bool IsYes(string question)
{

    while (true)
    {
        Console.WriteLine($"{question} Введите да или нет:");
        var userInput = Console.ReadLine().ToLower();
        if (userInput == "да" || userInput == "нет")
            return userInput == "да";
        ShowMistake();
    }
}

int GetDigitalUserAnswer()
{
    while(true)
    {
        try
        {
            return int.Parse(Console.ReadLine());
        }
        catch (OverflowException)
        {
            ShowMistake();
            Console.WriteLine("Слишком большое число! Введите число от -2 000 000 000 до 2 000 000 000!");
        }
        catch (FormatException)
        {
            ShowMistake();
            Console.WriteLine("Пожалуйста, введите число:");
        }
    }
}

void ShowMistake()
{
    Console.WriteLine("\nВы ввели некорректные данные.");
}

void Clear()
{
    Console.Clear();
}