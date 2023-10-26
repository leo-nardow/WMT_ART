using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class QuizLogic : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI question = null;
    [SerializeField] TextMeshProUGUI answer0 = null;
    [SerializeField] TextMeshProUGUI answer1 = null;
    [SerializeField] TextMeshProUGUI answer2 = null;
    [SerializeField] TextMeshProUGUI answer3 = null;
    [SerializeField] TextMeshProUGUI score = null;
    [SerializeField] GameObject resolutionCanvas = null;

    public string[] questions;
    public string[][] answers;
    public int[] correctAnswersIndex; //correct answers index

    private int currentQuestionIndex = 0;
    private float correct = 0;
    private float total = 0;

    void Start()
    {
        questions = new string[] { "Pergunta0", "Pergunta1", "Pergunta2" };
        answers = new string[][] {new string[4] {"Resposta00", "Resposta01", "Resposta02", "Resposta03"},
                                   new string[4] {"Resposta10", "Resposta11", "Resposta12", "Resposta13"},
                                   new string[4] {"Resposta20", "Resposta21", "Resposta22", "Resposta23"}};
        correctAnswersIndex = new int[] { 0, 1, 2 };
        total = questions.Length;

        question.text = questions[currentQuestionIndex];
        answer0.text = answers[currentQuestionIndex][0];
        answer1.text = answers[currentQuestionIndex][1];
        answer2.text = answers[currentQuestionIndex][2];
        answer3.text = answers[currentQuestionIndex][3];
        score.text = "Pontuação: " + correct * 10;
    }

    public void Answer(int answer)
    {
        if (answer == correctAnswersIndex[currentQuestionIndex])
        {
            correct++;
            Debug.Log("Correct" + currentQuestionIndex);
            ShowAnswerResult(10);
        }
        else
        {
            Debug.Log("Wrong" + currentQuestionIndex);
        }
        NextQuestion();
    }

    void NextQuestion()
    {
        currentQuestionIndex++;
        if (currentQuestionIndex < questions.Length)
        {
            question.text = questions[currentQuestionIndex];
            answer0.text = answers[currentQuestionIndex][0];
            answer1.text = answers[currentQuestionIndex][1];
            answer2.text = answers[currentQuestionIndex][2];
            answer3.text = answers[currentQuestionIndex][3];
            score.text = "Pontuação: " + correct * 10;
        }
        else
        {
            Debug.Log("Acabou");
        }
    }

    void ShowAnswerResult(int score)
    {
        //change TextMeshProUGUI named  Score_Text from inside resolutionCanvas
        resolutionCanvas.SetActive(true);

        GameObject.Find("Score_Text").GetComponent<TextMeshProUGUI>().text = (score > 0 ? "+" : "") + score;
        StartCoroutine(FadeGameObjectToZeroAlpha(1f, resolutionCanvas));
    }
    public IEnumerator FadeGameObjectToZeroAlpha(float t, GameObject i)
    {
        while (i.GetComponent<CanvasGroup>().alpha > 0.0f)
        {
            i.GetComponent<CanvasGroup>().alpha -= Time.deltaTime / t;
            yield return null;
        }
        i.SetActive(false);
    }

}
