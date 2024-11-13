using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoaderScript : MonoBehaviour
{
    
    public Slider barra;
    public string nombreEscena;
    public bool activarEscena;
    
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
        AsyncOperation op = SceneManager.LoadSceneAsync(nombreEscena);

        if (!activarEscena)
        {
            op.allowSceneActivation = false;
        }
        while (!op.isDone)
        {
            //Debug.Log(escenaACargar.name + op.progress);
            float prg = Mathf.Clamp01(op.progress / .9f);
            barra.value = prg;
            yield return null;
            if (activarEscena)
            {
                Debug.Log("cambio bool");
                op.allowSceneActivation = true;
            }
        }
    }
}
