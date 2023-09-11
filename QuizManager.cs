using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    public Text questionText;
    public Button[] optionButtons;
    public Text scoreText;
    public Text timerText;

    private string[] questions = {
        "Question 1: What is the capital of France?",
        "Question 2: What is the largest planet in our solar system?",
        "Question 3: Who painted the Mona Lisa?",
        // Add more questions here
    };

    private string[] correctAnswers = {
        "Paris",
        "Jupiter",
        "Leonardo da Vinci",
        // Add more correct answers here
    };

    private int currentQuestionIndex = 0;
    private int score = 0;
    private float timeRemaining = 10f; // in seconds
    private bool quizEnded = false;

    private const string ScoreKey = "QuizScore";

    void Start()
    {
        score = PlayerPrefs.GetInt(ScoreKey, 0);
        SetQuestion(currentQuestionIndex);
    }

    void Update()
    {
        if (quizEnded)
        {
            return;
        }

        timeRemaining -= Time.deltaTime;
        timerText.text = "Time: " + Mathf.RoundToInt(timeRemaining).ToString();

        if (timeRemaining <= 0f)
        {
            EndQuiz();
        }
    }

    public void AnswerButtonClicked(int buttonIndex)
    {
        if (quizEnded)
        {
            return;
        }

        if (questions[currentQuestionIndex] == correctAnswers[currentQuestionIndex])
        {
            score++;
            scoreText.text = "Score: " + score.ToString();
        }

        currentQuestionIndex++;

        if (currentQuestionIndex >= questions.Length)
        {
            EndQuiz();
        }
        else
        {
            SetQuestion(currentQuestionIndex);
        }
    }

    private void SetQuestion(int questionIndex)
    {
        questionText.text = questions[questionIndex];

        for (int i = 0; i < optionButtons.Length; i++)
        {
            optionButtons[i].GetComponentInChildren<Text>().text = "Option " + (i + 1).ToString();
        }
    }

    private void EndQuiz()
    {
        quizEnded = true;
        questionText.text = "Quiz Ended";
        for (int i = 0; i < optionButtons.Length; i++)
        {
            optionButtons[i].gameObject.SetActive(false);
        }

        // Save the score
        PlayerPrefs.SetInt(ScoreKey, score);
        PlayerPrefs.Save();
    }
}
