using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptVolverMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void VolverMenu()
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("Menu"));
    }
}
