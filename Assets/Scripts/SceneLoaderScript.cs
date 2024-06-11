using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoaderScript : MonoBehaviour
{
    
    public Slider barra;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CargarEscena());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator CargarEscena()
    {
        bool allDone = false;
        
        AsyncOperation op1 = SceneManager.LoadSceneAsync("Menu");
        AsyncOperation op2 = SceneManager.LoadSceneAsync("introduccion");
        AsyncOperation op3 = SceneManager.LoadSceneAsync("Trivia");
        AsyncOperation op4 = SceneManager.LoadSceneAsync("Win");
        AsyncOperation op5 = SceneManager.LoadSceneAsync("GameOver");

        while (!allDone)
        {
            float prg = Mathf.Clamp01((op1.progress + op2.progress + op3.progress + op4.progress + op5.progress) / .9f);
            barra.value = prg;
            yield return null;

            if(op1.isDone && op2.isDone && op3.isDone && op4.isDone && op5.isDone)
            {
                allDone = true;
            }
        }
    }
}
