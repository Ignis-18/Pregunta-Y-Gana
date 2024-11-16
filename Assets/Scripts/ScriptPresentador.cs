using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptPresentador : MonoBehaviour
{
    public Pruebas pruebas;

    private Animator animator;

    public int maxCorrecto;
    public int minVida;

    void Start()
    {
        animator = GetComponent<Animator>(); 
        maxCorrecto = 0;
        minVida = 3;
    }

    void Update()
    {
        if (pruebas.cantidadCorrectas != maxCorrecto)
        {
            maxCorrecto = pruebas.cantidadCorrectas;

            if (pruebas.cantidadCorrectas >= 0 && pruebas.cantidadCorrectas <= 5)
            {
                animator.ResetTrigger("TF1");
                animator.SetInteger("StatusWin", 1); // 1 representa "Normal"
            }
            else if (pruebas.cantidadCorrectas > 5 && pruebas.cantidadCorrectas <= 8)
            {
                animator.ResetTrigger("TF1");
                animator.SetInteger("StatusWin", 2); // 2 representa "Feliz"
            }
            else if (pruebas.cantidadCorrectas > 8)
            {
                animator.ResetTrigger("TF1");
                animator.SetInteger("StatusWin", 3); // 3 representa "Entusiasmado"
            }
        }

        if (pruebas.oportunidades != minVida)
        {
            minVida = pruebas.oportunidades;

            if (pruebas.oportunidades == 2)
            {
                animator.SetTrigger("TF1"); // Representa "Nervioso"
            }

        }
    }

}
