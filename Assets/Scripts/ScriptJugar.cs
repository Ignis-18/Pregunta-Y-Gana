using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptJugar : MonoBehaviour
{
    public void Jugar()
    {
        SceneManager.LoadScene("introduccion");
    }
}
