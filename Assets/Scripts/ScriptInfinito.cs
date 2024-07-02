using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptInfinito : MonoBehaviour
{
    
    public SceneLoaderScript SceneLoader;
    GameObject detector;
    DoNotDestroyOnLoad valorACambiar;
    // Start is called before the first frame update
    public void cambiar()
    {
        detector = GameObject.FindWithTag("Manager");
        valorACambiar = detector.GetComponent<DoNotDestroyOnLoad>();
        valorACambiar.infinite = true;
        SceneLoader.activarEscena = true;
    }
}
