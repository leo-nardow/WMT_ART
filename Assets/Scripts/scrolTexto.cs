using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scrolTexto : MonoBehaviour
{
    public float scrollSpeed = 100;
    float t;
    void Start(){
        t = 0;
    }
    void Update(){

        Vector3 pos = transform.position;

        Vector3 localVectorUp = transform.TransformDirection(0,5,0);
        t+= Time.deltaTime;
        pos += localVectorUp * scrollSpeed * Time.deltaTime;
        transform.position = pos;

        if(t > 11){
            SceneManager.LoadScene("Intro_scene");
        }
    }
}
