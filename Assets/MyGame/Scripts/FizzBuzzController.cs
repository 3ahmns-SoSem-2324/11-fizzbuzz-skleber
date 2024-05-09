using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.UI;

public class FizzBuzzController : MonoBehaviour
{
    private string Fizz = "Fizz";
    private string Buzz = "Buzz";
    private string FizzBuzz = "FizzBuzz";
    private string NormalNumber = "Normale Zahl";

    [SerializeField] private Image background;
    [SerializeField] private Text zahlText, feedbackText, scoreText;
    [SerializeField] private AudioSource audioCorrect, audioWrong;
    [SerializeField] private ScoreManager scoreManager;

    private int targetNumber;
    private bool hasAnswered = false;

    private void Start()
    {
        GenerateRandomNumber();
        ResetFeedbackText();
        scoreManager.ResetScoreAndLives();
    }

    private void Update()
    {
        HandleInput();
        scoreText.text = "Punkte: " + scoreManager.score.ToString();
    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            CheckFizzBuzz(Fizz, "LeftArrow");

        else if (Input.GetKeyDown(KeyCode.RightArrow))
            CheckFizzBuzz(Buzz, "RightArrow");

        else if (Input.GetKeyDown(KeyCode.UpArrow))
            CheckFizzBuzz(FizzBuzz, "UpArrow");

        else if (Input.GetKeyDown(KeyCode.DownArrow))
            CheckFizzBuzz(NormalNumber, "DownArrow");

        else if (Input.GetKeyDown(KeyCode.Space))
            GenerateAndReset();
    }

    private void CheckFizzBuzz(string input, string arrowPressed)
    {
        string expectedResult = GetFizzBuzzResult(targetNumber);

        if (hasAnswered)
            return; 

        if (input == expectedResult)
            HandleCorrectGuess(arrowPressed);
        else
            HandleWrongGuess(expectedResult);

        hasAnswered = true;
    }

    private void HandleCorrectGuess(string arrowPressed)
    {
        Debug.Log("Correct!");
        background.color = Color.green;
        audioCorrect.Play();
        ResetFeedbackText();
        Debug.Log($"{arrowPressed} is pressed ({arrowPressed})");
        scoreManager.AddPoints(10);
    }

    private void HandleWrongGuess(string expectedResult)
    {
        Debug.Log("Wrong!");
        background.color = Color.red;
        audioWrong.Play();
        ShowFeedback(expectedResult);
        scoreManager.SubtractPoints(5);
        scoreManager.LoseLife();
    }

    private void ShowFeedback(string expectedResult)
    {
        if (expectedResult == FizzBuzz)
            feedbackText.text = "Diese Zahl ist durch 5 und 3 teilbar! " +
                                "Eine Zahl ist durch 3 teilbar, wenn die Quersumme durch 3 teilbar ist. Eine Zahl ist durch 5 teilbar, wenn die letzte Ziffer eine durch 5 teilbare Zahl darstellt.";

        else if (expectedResult == Buzz)
            feedbackText.text = "Diese Zahl ist durch 5 teilbar! " +
                                "Eine Zahl ist durch 5 teilbar, wenn die letzte Ziffer eine durch 5 teilbare Zahl darstellt.";

        else if (expectedResult == Fizz)
            feedbackText.text = "Diese Zahl ist durch 3 teilbar! " +
                                "Eine Zahl ist durch 3 teilbar, wenn die Quersumme durch 3 teilbar ist.";

        else
            feedbackText.text = "Diese Zahl ist weder durch 3 noch durch 5 teilbar!" +
                                "Eine Zahl ist durch 3 teilbar, wenn die Quersumme durch 3 teilbar ist. Eine Zahl ist durch 5 teilbar, wenn die letzte Ziffer eine durch 5 teilbare Zahl darstellt.";
    }

    private string GetFizzBuzzResult(int randomTragetNumber)
    {
        if (randomTragetNumber % 3 == 0 && randomTragetNumber % 5 == 0)
            return FizzBuzz;
        if (randomTragetNumber % 3 == 0)
            return Fizz;
        if (randomTragetNumber % 5 == 0)
            return Buzz;
        return NormalNumber;
    }

    private void GenerateAndReset()
    {
        GenerateRandomNumber();
        ResetFeedbackText();
        hasAnswered = false;
        Debug.Log("Space is pressed");
    }

    private void GenerateRandomNumber()
    {
        targetNumber = Random.Range(0, 1001);
        zahlText.text = targetNumber.ToString();
        background.color = Color.white;
    }

    private void ResetFeedbackText()
    {
        feedbackText.text = "";
    }
}
