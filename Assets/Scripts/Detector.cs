using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Detector : MonoBehaviour
{
    
    public GameObject info;
    public DoNotDestroyOnLoad detecta;
    public Sprite gana;
    public Sprite pierde;
    
    // Start is called before the first frame update
    void Start()
    {
        info = GameObject.FindWithTag("Manager");
        detecta = info.GetComponent<DoNotDestroyOnLoad>();

        if (detecta.win == true)
        {
            GetComponent<Image>().sprite = gana;
        }

        if (detecta.lose == true)
        {
            GetComponent<Image>().sprite = pierde;
        }
    }
}
