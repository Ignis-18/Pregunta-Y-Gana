using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InitialLoadScript : MonoBehaviour
{

    public Slider barra;
    //public Object escenaACargar;

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
        AsyncOperation op = SceneManager.LoadSceneAsync("Menu");

       
        while (!op.isDone)
        {
            //Debug.Log(escenaACargar.name + op.progress);
            float prg = Mathf.Clamp01(op.progress / .9f);
            barra.value = prg;
            yield return null;
        }
    }
}