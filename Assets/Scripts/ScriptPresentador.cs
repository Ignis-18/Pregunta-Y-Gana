using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptPresentador : MonoBehaviour
{
    
    public Pruebas pruebas;

    public Sprite normal;
    public Sprite nervioso;
    public Sprite asustado;
    public Sprite derrotado;
    public Sprite tf1;
    public Sprite tf2;
    
    public int maxCorrecto;
    public int minVida;



    void Start()
    {
        maxCorrecto = 0;
        minVida = 3;
    }
    

    void Update()
    {
        if(pruebas.cantidadCorrectas != maxCorrecto)
        {
            maxCorrecto = pruebas.cantidadCorrectas;

            if(pruebas.cantidadCorrectas >= 0 && pruebas.cantidadCorrectas <= 2)
            {
                GetComponent<Image>().sprite = normal;
            }

            else if(pruebas.cantidadCorrectas >= 3 && pruebas.cantidadCorrectas <= 5)
            {
                GetComponent<Image>().sprite = nervioso;
            }

            else if(pruebas.cantidadCorrectas >= 6 && pruebas.cantidadCorrectas <= 8)
            {
                GetComponent<Image>().sprite = asustado;
            }

            else if(pruebas.cantidadCorrectas >= 9)
            {
                GetComponent<Image>().sprite = derrotado;
            }
        }

        if(pruebas.oportunidades != minVida)
        {
            minVida = pruebas.oportunidades;

            if(pruebas.oportunidades == 2)
            {
                GetComponent<Image>().sprite = tf1;
            }

            else if (pruebas.oportunidades == 1)
            {
                GetComponent<Image>().sprite = tf2;
            } 
        }
    }
}
