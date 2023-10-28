using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Iniciar : MonoBehaviour
{
    public void chamaExp(){
        SceneManager.LoadScene("Explicacao");
    }
}