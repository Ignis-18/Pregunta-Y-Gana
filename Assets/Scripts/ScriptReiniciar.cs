using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptReiniciar : MonoBehaviour
{
    public SceneLoaderScript sceneLoader;
    
    public void Reiniciar()
    {
        sceneLoader.activarEscena = true;
    }
}
