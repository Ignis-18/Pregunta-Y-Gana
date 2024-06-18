using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptReiniciar : MonoBehaviour
{
    public void Reiniciar()
    {
        SceneManager.LoadScene("Trivia");
    }
}
