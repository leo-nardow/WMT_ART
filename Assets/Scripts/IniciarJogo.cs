using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IniciarJogo : MonoBehaviour
{
    public void chamaJogo()
    {
        SceneManager.LoadScene("QuizScene");
    }
}
