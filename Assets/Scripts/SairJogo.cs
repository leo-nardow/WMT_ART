using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SairJogo : MonoBehaviour
{
   public void Quit()
    {
        Application.Quit();
        Debug.Log("Saindo do jogo");
    }
}