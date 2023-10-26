using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class QuizzManager : MonoBehaviour
{
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

    private void GetQuestions() => this._questions = GameManager.Instance.GetQuestions();
    private void SaveQuestions() => GameManager.Instance.SaveQuestions(this._questions);
}
