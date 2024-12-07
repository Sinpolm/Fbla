using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    public Text questionText;
    public Button[] answerButtons;
    public Text scoreText;

    private int score = 0;
    private int questionIndex = 0;

    // Question and answers
    private string[] questions = { "What is the capital of France?", "What is 2 + 2?", "What color is the sky?" };
    private string[][] answers = {
        new string[] { "Berlin", "Madrid", "Paris", "Rome" },
        new string[] { "3", "4", "5", "6" },
        new string[] { "Blue", "Green", "Red", "Yellow" }
    };
    private int[] correctAnswers = { 2, 1, 0 }; // Indices of the correct answers

    void Start()
    {
        DisplayQuestion();
    }

    void DisplayQuestion()
    {
        questionText.text = questions[questionIndex];
        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].GetComponentInChildren<Text>().text = answers[questionIndex][i];
            int index = i; // Capture the current index
            answerButtons[i].onClick.RemoveAllListeners(); // Clear previous listeners
            answerButtons[i].onClick.AddListener(() => CheckAnswer(index));
        }
    }

    void CheckAnswer(int selectedAnswer)
    {
        if (selectedAnswer == correctAnswers[questionIndex])
        {
            score++;
        }
        questionIndex++;
        if (questionIndex < questions.Length)
        {
            DisplayQuestion();
        }
        else
        {
            ShowScore();
        }
    }

    void ShowScore()
    {
        questionText.text = "Quiz Finished!";
        scoreText.text = "Score: " + score.ToString();
        foreach (Button button in answerButtons)
        {
            button.gameObject.SetActive(false); // Hide buttons
        }
    }
}