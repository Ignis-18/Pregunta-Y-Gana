using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptJugar : MonoBehaviour
{
    public SceneLoaderScript SceneLoader;
    
    public void Jugar()
    {
        SceneLoader.activarEscena = true;
    }
}
