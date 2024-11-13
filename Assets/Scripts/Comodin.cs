using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Comodin : MonoBehaviour
{
    public Pruebas pruebas;
    public Sprite ByN;
    public Sprite color;
    DoNotDestroyOnLoad datos;
    GameObject detector;


    void Start()
    {
        //detector = GameObject.FindWithTag("Manager");
        if (!GameObject.FindWithTag("Manager"))
        {
            detector = pruebas.refInfo;

        }
        else
        {
            detector = GameObject.FindWithTag("Manager");
        }
        datos = detector.GetComponent<DoNotDestroyOnLoad>();
    }
    
    void Update()
    {
        if (pruebas.usosComodin>0 && datos.infinite == true)
        {
            
            GetComponent<Image>().sprite = color;
        }

        else
        {
            GetComponent<Image>().sprite = ByN;
        }
    }

    public void comodin()
    {
        pruebas.comodin();
    }
}
