using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotDestroyOnLoad : MonoBehaviour
{
    GameObject manager;
    Pruebas pruebas;
    public bool win = false;
    public bool lose = false;
    
    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        manager = GameObject.FindWithTag("GameController");
        pruebas = manager.GetComponent<Pruebas>();

        if (pruebas.cantidadCorrectas>=10)
        {
            win = true;
        }

        if (pruebas.oportunidades<=0)
        {
            lose = true;
        }
    }
}
