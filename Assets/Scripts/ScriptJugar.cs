using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptJugar : MonoBehaviour
{
    public SceneLoaderScript SceneLoader;
    GameObject detector;
    DoNotDestroyOnLoad valorACambiar;
    
    public void Jugar()
    {
        detector = GameObject.FindWithTag("Manager");
        valorACambiar = detector.GetComponent<DoNotDestroyOnLoad>();
        
        valorACambiar.infinite = false;
        SceneLoader.activarEscena = true;
    }
}
