using UnityEngine;
using UnityEngine.UI;

public class AnswerButton : MonoBehaviour
{
    public int buttonIndex;
    private QuizManager gameController;

    void Start()
    {
        gameController = FindObjectOfType<QuizManager>();
        GetComponent<Button>().onClick.AddListener(OnButtonClick);
    }

    public void OnButtonClick()
    {
        gameController.AnswerButtonClicked(buttonIndex);
    }
}