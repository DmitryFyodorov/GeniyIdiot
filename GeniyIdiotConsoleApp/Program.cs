Console.WriteLine("Добро пожаловать в игру \"Гений - Идиот\"!\n");

Console.WriteLine("Введите ваше имя:");
var userFirstName = Console.ReadLine();
Console.WriteLine();

Console.WriteLine("Введите вашу фамилию:");
var userLastName = Console.ReadLine();
Clear();

bool isOpenApp = true;

while (isOpenApp)
{
    var questions = GetQuestions();
    var answers = GetAnswers();
    var diagnoses = GetDiagnoses();

    var rightAnswersCount = 0;
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
            rightAnswersCount++;
            questions.RemoveAt(randomQuestinIndex);
            answers.RemoveAt(randomQuestinIndex);
        }
        Clear();
    }
    Console.WriteLine($"Количество правильных ответов: {rightAnswersCount}");
    Console.WriteLine($"{userFirstName} {userLastName}, ваш диагноз: {diagnoses[rightAnswersCount]}\n");

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

bool IsYes(string question)
{

    while (true)
    {
        Console.WriteLine($"\n{question} Введите да или нет:");
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
    Console.WriteLine("Вы ввели некорректные данные.\n");
}

void Clear()
{
    Console.Clear();
}