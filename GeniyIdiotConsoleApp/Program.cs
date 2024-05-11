Console.WriteLine("Введите ваше имя:");
var userFirstName = Console.ReadLine();

Console.WriteLine("Введите вашу фамилию:");
var userLastName = Console.ReadLine();

bool isOpenApp = true;

while (isOpenApp)
{
    var questions = GetQuestions();
    var answers = GetAnswers();
    var diagnoses = GetDiagnoses();

    var countRightAnswers = 0;
    var questionsCount = questions.Count;
    var random = new Random();    

    for (int i = 0; i < questionsCount; i++)
    {
        var randomQuestinIndex = random.Next(0, questions.Count);

        Console.WriteLine($"\nВопрос №{i + 1}:\n{questions[randomQuestinIndex]}");
        var userAnswer = Convert.ToInt32(Console.ReadLine());

        var rightAnwers = answers[randomQuestinIndex];
        if (userAnswer == rightAnwers)
        {
            countRightAnswers++;
            questions.RemoveAt(randomQuestinIndex);
            answers.RemoveAt(randomQuestinIndex);
        }
    }

    Console.WriteLine($"Количество правильных ответов: {countRightAnswers}\n");
    Console.WriteLine($"{userFirstName} {userLastName} Ваш диагноз: " + diagnoses[countRightAnswers]);

    Console.WriteLine("Хотите продолжить? Введите 'да' или 'нет'");
    isOpenApp = IsYes(Console.ReadLine());
    Console.Clear();
}

List<string> GetQuestions()
{
    var questions = new List<string>()
    {
        "Сколько будет два плюс два умноженное на два?",
        "Бревно нужно распилить на 10 частей, сколько надо сделать распилов?",
        "На двух руках 10 пальцев. Сколько пальцев на 5 руках?",
        "Укол делают каждые пол часа, сколько нужно минут для трех уколов?",
        "Пять свечей горело, две потухли. Сколько свечей осталось??"
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

bool IsYes(string userAnswer)
{
    if (userAnswer.ToLower() == "да")
    {
        return true;    
    }
    return false;
}