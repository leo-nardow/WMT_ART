using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using System.Linq;
using UnityEngine.SceneManagement;

public class QuizLogic : MonoBehaviour
{
    private TextMeshProUGUI question;
    private TextMeshProUGUI answer0;
    private TextMeshProUGUI answer1;
    private TextMeshProUGUI answer2;
    private TextMeshProUGUI answer3;
    private TextMeshProUGUI scoreText;
    private GameObject resolutionCanvas;

    public List<QuestionObject> questions;

    private int currentQuestionIndex = 0;
    private float correct = 0;
    private float total = 0;

    private List<QuestionObject> _questions;

    public void SaveAnsweredQuestion(int index)
    {
        GetQuestions();
        this._questions[index].QuestionAnswered = true;
        SaveQuestions();
    }

    public List<QuestionObject> GetSixRandomQuestions()
    {
        GetQuestions();
        System.Random random = new System.Random();
        List<QuestionObject> orderedQuestions = _questions.Where(x => !x.QuestionAnswered).OrderBy(q => random.Next()).ToList();
        List<QuestionObject> sixRandomQuestions = orderedQuestions.Take(6).ToList();
        return sixRandomQuestions;
    }

    private void GetQuestions() => this._questions = GameManagerBadges.Instance.GetQuestions();
    private void SaveQuestions() => GameManagerBadges.Instance.SaveQuestions(this._questions);

    private void Awake()
    {
        // Registrar o método para ser chamado quando a cena for carregada
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name != "QuizScene") return;
        question = GameObject.Find("Question").GetComponent<TextMeshProUGUI>();
        answer0 = GameObject.Find("Answer0Text").GetComponent<TextMeshProUGUI>();
        answer1 = GameObject.Find("Answer1Text").GetComponent<TextMeshProUGUI>();
        answer2 = GameObject.Find("Answer2Text").GetComponent<TextMeshProUGUI>();
        answer3 = GameObject.Find("Answer3Text").GetComponent<TextMeshProUGUI>();
        scoreText = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();

        // GameObject.Find("Answer0").GetComponent<Button>().onClick.AddListener(Answer(0));
        // GameObject.Find("Answer1").GetComponent<Button>().onClick.AddListener(Answer(1));
        // GameObject.Find("Answer2").GetComponent<Button>().onClick.AddListener(Answer(2));
        // GameObject.Find("Answer3").GetComponent<Button>().onClick.AddListener(Answer(3));

        // resolutionCanvas = GameObject.Find("ResolutionCanvas").GetComponent<GameObject>();
        correct = 0;
        total = 0;
        currentQuestionIndex = 0;

        questions = GetSixRandomQuestions();
        total = questions.Count;

        Debug.Log(questions[currentQuestionIndex].Question);
        question.text = questions[currentQuestionIndex].Question;
        answer0.text = questions[currentQuestionIndex].Answers[0];
        answer1.text = questions[currentQuestionIndex].Answers[1];
        answer2.text = questions[currentQuestionIndex].Answers[2];
        answer3.text = questions[currentQuestionIndex].Answers[3];
        scoreText.text = "Pontuação: " + GameManagerBadges.Instance.GetPoints();
    }

    // public static void Answer(int answerIndex) {
    //     Debug.Log("Answered" + aaa);
    //     SceneManager.LoadScene("Middle");
    // }

    public void Answer(int answerIndex)
    {
        Debug.Log("Answered");
        if (answerIndex == questions[currentQuestionIndex].CorrectAnswersIndex)
        {
            GameManagerBadges.Instance.SavePoints(GameManagerBadges.Instance.GetPoints() + 10);
            correct++;
            // Debug.Log("Correct" + currentQuestionIndex);
            SaveAnsweredQuestion(currentQuestionIndex);
        }
        else
        {
            // Debug.Log("Wrong" + currentQuestionIndex);
        }
        NextQuestion();
    }

    void NextQuestion()
    {
        currentQuestionIndex++;
        if (currentQuestionIndex < questions.Count)
        {
            question.text = questions[currentQuestionIndex].Question;
            answer0.text = questions[currentQuestionIndex].Answers[0];
            answer1.text = questions[currentQuestionIndex].Answers[1];
            answer2.text = questions[currentQuestionIndex].Answers[2];
            answer3.text = questions[currentQuestionIndex].Answers[3];
            scoreText.text = "Pontuação: " + GameManagerBadges.Instance.GetPoints();
        }
        else
        {
            SceneManager.LoadScene("Middle");
        }
    }

    void ShowAnswerResult(int scorePoints)
    {
        //change TextMeshProUGUI named  Score_Text from inside resolutionCanvas
        resolutionCanvas.SetActive(true);

        GameObject.Find("Score_Text").GetComponent<TextMeshProUGUI>().text = (scorePoints > 0 ? "+" : "") + GameManagerBadges.Instance.GetPoints();
        // StartCoroutine(FadeGameObjectToZeroAlpha(1f, resolutionCanvas));
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
