using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Comodin : MonoBehaviour
{
    public Pruebas pruebas;
    public Sprite ByN;
    public Sprite color;

    void Update()
    {
        if (pruebas.usosComodin<=0)
        {
            GetComponent<Image>().sprite = ByN;
        }

        else
        {
            GetComponent<Image>().sprite = color;
        }
    }

    public void comodin()
    {
        pruebas.comodin();
    }
}
