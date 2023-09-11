using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerButtons : MonoBehaviour
{
    public int answerIndex;
    private QuizManagement quizManager;

    private void Start()
    {
        quizManager = FindObjectOfType<QuizManagement>();
    }

    public void OnClick()
    {
        quizManager.AnswerQuestion(answerIndex);
    }
}
