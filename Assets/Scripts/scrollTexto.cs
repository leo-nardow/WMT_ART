using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scrollTexto : MonoBehaviour
{
    public float scrollSpeed = 80;
    float t;
    void Start(){
        t = 0;
    }
    void Update(){

        Vector3 pos = transform.position;

        Vector3 localVectorUp = transform.TransformDirection(0,1,0);
        t+= Time.deltaTime;
        pos += localVectorUp * scrollSpeed * Time.deltaTime;
        transform.position = pos;

        if(t > 15){
            SceneManager.LoadScene("Intro_scene");
        }
    }
}