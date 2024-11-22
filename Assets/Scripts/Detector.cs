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
    public Animator animatorMago;
    
    // Start is called before the first frame update
    void Start()
    {
        info = GameObject.FindWithTag("Manager");
        detecta = info.GetComponent<DoNotDestroyOnLoad>();

        if (detecta.win == true)
        {
            GetComponent<Image>().sprite = gana;
            animatorMago.SetBool("Won", true);
        }

        if (detecta.lose == true)
        {
            GetComponent<Image>().sprite = pierde;
            animatorMago.SetBool("Won", false);
        }
    }
}
