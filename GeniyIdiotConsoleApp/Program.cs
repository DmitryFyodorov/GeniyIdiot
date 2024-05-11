var questions = new List<string>()
{
    "Сколько будет два плюс два умноженное на два?",
    "Бревно нужно распилить на 10 частей, сколько надо сделать распилов?",
    "На двух руках 10 пальцев. Сколько пальцев на 5 руках?",
    "Укол делают каждые пол часа, сколько нужно минут для трех уколов?",
    "Пять свечей горело, две потухли. Сколько свечей осталось??"
};

var answers = new List<int>()
{
    6,
    9,
    25,
    60,
    2
};

var countRightAnswers = 0;

var random = new Random();
var questionsCount = questions.Count;
for (int i = 0; i < questionsCount; i++)
{
    var randomQuestinIndex = random.Next(0, questions.Count);

    Console.WriteLine($"Вопрос №{i + 1}:\n{questions[randomQuestinIndex]}");

    var userAnswer = Convert.ToInt32(Console.ReadLine());

    var rightAnwers = answers[randomQuestinIndex];

    if (userAnswer == rightAnwers)
    {
        countRightAnswers++;
        questions.RemoveAt(randomQuestinIndex);
        answers.RemoveAt(randomQuestinIndex);
    }
}

Console.WriteLine($"Количество правильных ответов: {countRightAnswers}");

var diagnoses = new List<string>()
{
    "идиот",
    "кретин",
    "дурак",
    "нормальный",
    "талант",
    "гений"
};

Console.WriteLine("Ваш диагноз: " + diagnoses[countRightAnswers]);