using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizManagement : MonoBehaviour
{
    public Text questionText;
    public Button[] answerButtons;
    public Text scoreText;
    public Text questionCountText;
    public Color correctColor;
    public Color incorrectColor;

    private int currentQuestion = 0;
    private int score = 0;
    private bool hasAnswered = false;
    private List<int> remainingQuestions = new List<int>();

    [SerializeField] private GameObject popupGameObject;

    public List<Question> questions = new List<Question>()
    {
        // Questions and answers here
        //HOUSE QUESTIONS
        new Question("While you are cooking if the stove and LPG are opened, what should you do before leaving it?", new string[] {"Turn Off the stove and LPG", "Leave the stove and LPG open", "Turn off the LPG"}, 0),
        new Question("After using any electrical appliances in your house, what should you do next before leaving?", new string[] { "Turn off the appliances", "Unplug it after turning off", "Just leave it plugged in"}, 1),
        new Question("In the event of a power interruption in your area, where is the proper place to lit the candle?", new string[] { "On the table near the window with a curtain", "On the table near the window without flammable materials", "On the table and anywhere in the room"}, 1),
        new Question("After leaving away from the burned house, the firefighters have managed to extinguish the fire earlier, what is the right thing to do?", new string[] {"Call your loved ones to know your safe", "Go live on social media platforms about the situation", "Go back and check the house if there are any belongings that could be recover"}, 0),
        new Question("After your house has been completely burned down by fire while you are on the street, where should you temporarily go?", new string[] { "Evacuation Center", "Hospital", "Fire Station"}, 0),
        new Question("If you are trapped in your room and the room beside in your house is on fire, what should you do?", new string[] { "Open the door in that room", "Use your window to escape and call for help", "Call BFP"}, 1),
        new Question("If the container of diesel leaked and started a fire in the storage room, what type of fire extinguisher should you use?", new string[] { "Class A Fire Extinguisher", "Class B Fire Extinguisher", "Class C Fire Extinguisher"}, 1),
        new Question("While you are cooking fried chicken, a grease fire occurs because the cooking oil becomes too hot and reaches a high temperature level. What should you do now?", new string[] { "Use a bucket of water", "Use your covering metal pan to kill the fire", "Use fire extinguisher that is not design for that fire"}, 1),
        //

        //SCHOOL QUESTIONS
         new Question("Your class has been dismissed, and now you are leaving the classroom, but the appliances are still plugged in. What should you do?", new string[] {"Turn off the appliances and unplugged it", "Make sure to turn off all the appliances", "Just leave it plugged in"}, 0),
         new Question("Berong is a computer assistant in the computer laboratory. He has already turned off the computer, but it is still plugged in, and he needs to go home now. What should Berong do?", new string[] { "Turn off the Automatic Voltage Regulator AVR and Pull the plugs", "Leave the computer plugged in", "Just unplug it without turning off the AVR"}, 0),
         new Question("You are in the kitchen laboratory and there is a lot of garbage in your area, what should you do before starting cooking?", new string[] {"Continue cooking and clean the area", "Collect the garbage put them into the trashcan and move away from the stove first", "Clean the area and collect the garbage and continue cooking"}, 1),
         new Question("The school has been burned and the firefighters have managed to extinguish the fire earlier, and you are now in the safe gathering area, what should you do next?", new string[] {"Go back in the burned building and check if there are possible survivors", "Call the attention of your classmates and teachers to conduct a headcount first", "Call and inform your parents that you are safe"}, 1),
         new Question("Almost half of the canteen has been burned by fire, and the firefighters have managed to extinguish the fire earlier and some of your belongings are there, what should you do now?", new string[] {"Check if the fire is completely extinguished then look for your belongings that can be possibly recover", "Move away from the establishment", "Go back and check the canteen if there are any belongings that could be recover"}, 1),
         new Question("During the fire in your school, if you are trapped on the first floor in your classroom and you need to escape, what should you do?", new string[] {"Use window to escape", "Open the door to check if you can run outside", "Open the window only and call for help"}, 0),
         new Question("If you see that there is a fire in another classroom, what should you do now?", new string[] {"Move away from the establishment and shout for help", "Sound the alarm to alert others and move away", "Call BFP and move away"}, 1),
         new Question("If your left arm is burning what should you do now?", new string[] {"Do the stop, drop and roll", "Find and use wet towel", "Find the use fire extinguisher"}, 0),
           
          

         //BUSINESS QUESTIONS
          new Question("Berong is closing his business because it's already evening, and the appliances have already been turned off. What should be the last thing he will do now?", new string[] {"Leave the restaurant while the main electrical switch is opened", "Turn off the main electrical switch of the establisment", "Double check if the all the appliances have been already turn off"}, 1),
          new Question("Berong bought a new fire extinguisher. Where should he put it in the right place?", new string[] {"Place into the stockroom", "Place where it can be easily seen", "Place it inside the cabinet to secure it"}, 1),
          new Question("Your order of boxes of products has arrived. Where is the proper place to stock them?", new string[] {"Place near the fire exits", "Place it into the stock room", "Place where it can easily be relocated"}, 1),
          new Question("The coffee shop has been burned, and everyone are outside. While you are leaving, your parents are now calling your phone. What should you do?", new string[] { "Answer their call first and check your companions if they are okay", "Don't answer their call", "Check first your companions if they are okay and answer their call"}, 0),
          new Question("After your business has been burned and the firefighters have managed to put out the fire, and they have already started investigating, what should you do now?", new string[] {"Volunteer and Help to investigate the cause of fire", "Find a temporary safe place", "Re-enter the burned establishment to check if there are belongings that can still be recovered"}, 1),
          new Question("You are trapped in the office that has no windows and there is a big fire beside your office, and the smoke has begun to spread immediately, what should you do now?", new string[] {"Use any clothes to cover the hole below the door and call BFP", "Open the door and use the available tools you think will help you to extinguished the fire", "Use your clothes and cover to your nose while the smoke are coming inside your room"}, 0),
          new Question("If you see that there is a fire in another office room, what should you do now?", new string[] {"Sound the alarm", "Leave the establishment alone", "Call BFP and move away"}, 0),
          new Question("If your computer shop is on fire, what is the right type of fire extinguisher should you use?", new string[] { "Class A Fire Extinguisher", "Class B Fire Extinguisher", "Class C Fire Extinguisher"}, 2),

        new Question("Which among these is the real contact number of the Bureau of Fire Protection in San Jose City, Nueva Ecija?", new string[] { "0925-453-0777", "911", "8888"}, 0),
    };

    private void Start()
    {
        score = PlayerPrefs.GetInt("Score", 0);
        scoreText.text = score.ToString();
        GenerateRemainingQuestions();
        ShowQuestion();

        // Hide the pop-up game object initially
        popupGameObject.SetActive(false);
    }

    private void GenerateRemainingQuestions()
    {
        remainingQuestions.Clear();

        for (int i = 0; i < questions.Count; i++)
        {
            remainingQuestions.Add(i);
        }

        // Shuffle the remaining questions list
        for (int i = 0; i < remainingQuestions.Count; i++)
        {
            int temp = remainingQuestions[i];
            int randomIndex = Random.Range(i, remainingQuestions.Count);
            remainingQuestions[i] = remainingQuestions[randomIndex];
            remainingQuestions[randomIndex] = temp;
        }
    }

    private void UpdateQuestionCount()
    {
        int questionCount = currentQuestion + 1;
        questionCountText.text = "" + questionCount + "/" + questions.Count;
    }

    public void AnswerQuestion(int answer)
    {
        if (hasAnswered)
        {
            return;
        }

        hasAnswered = true;

        if (answer == questions[remainingQuestions[currentQuestion]].correctAnswer)
        {
            score++;
            PlayerPrefs.SetInt("Score", score);
            scoreText.text = score.ToString();
            SetButtonColor(answerButtons[answer], correctColor);
        }
        else
        {
            SetButtonColor(answerButtons[answer], incorrectColor);
            SetButtonColor(answerButtons[questions[remainingQuestions[currentQuestion]].correctAnswer], correctColor);
        }

        currentQuestion++;

        StartCoroutine(NextQuestionWithDelay(1.0f));

        if (currentQuestion >= questions.Count)
        {
            Debug.Log("Quiz complete!");
            // Show the pop-up game object instead of loading the scene
            popupGameObject.SetActive(true);
        }
    }

    private IEnumerator NextQuestionWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        ShowQuestion();
        ResetButtonColors();
    }

    private void ShowQuestion()
    {
        hasAnswered = false;

        if (currentQuestion >= questions.Count)
        {
            return;
        }

        UpdateQuestionCount();

        int questionIndex = remainingQuestions[currentQuestion];
        Question question = questions[questionIndex];

        questionText.text = question.question;

        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].GetComponentInChildren<Text>().text = question.answers[i];
            SetButtonColor(answerButtons[i], Color.white);
        }
    }

    private void ResetButtonColors()
    {
        for (int i = 0; i < answerButtons.Length; i++)
        {
            SetButtonColor(answerButtons[i], Color.white);
        }
    }

    private void SetButtonColor(Button button, Color color)
    {
        var colors = button.colors;
        colors.normalColor = color;
        colors.highlightedColor = color;
        button.colors = colors;
        button.interactable = true;
    }
}

public class Question
{
    public string question;
    public string[] answers;
    public int correctAnswer;

    public Question(string question, string[] answers, int correctAnswer)
    {
        this.question = question;
        this.answers = answers;
        this.correctAnswer = correctAnswer;
    }
}
