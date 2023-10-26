using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiddleGame : MonoBehaviour
{
    public void ChamaContinuar()
    {
        SceneManager.LoadScene("QuizScene");
    }
    public void ChamaLoja()
    {
        SceneManager.LoadScene("ShopV2");
    }
    public void ChamaMenu()
    {
        GameManagerBadges.Instance.SavePoints(0);
        GameManagerBadges.Instance.ResetBadges();
        GameManagerBadges.Instance.ResetQuestions();
        
        SceneManager.LoadScene("Intro_Scene");
    }
}
