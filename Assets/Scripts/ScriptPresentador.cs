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

            if (pruebas.cantidadCorrectas >= 0 && pruebas.cantidadCorrectas <= 2)
            {
                animator.SetInteger("Normal", 1); // 1 representa "Normal"
            }
            else if (pruebas.cantidadCorrectas >= 3 && pruebas.cantidadCorrectas <= 5)
            {
                animator.SetInteger("Nervioso", 2); // 2 representa "Nervioso"
            }
            else if (pruebas.cantidadCorrectas >= 6 && pruebas.cantidadCorrectas <= 8)
            {
                animator.SetInteger("Asustado", 3); // 3 representa"Asustado"
            }
            else if (pruebas.cantidadCorrectas >= 9)
            {
                animator.SetInteger("Derrotado", 4); // 4 representa "Derrotado"
            }
        }

        if (pruebas.oportunidades != minVida)
        {
            minVida = pruebas.oportunidades;

            if (pruebas.oportunidades == 2)
            {
                animator.SetTrigger("TF1"); // Usa un Trigger para animaciones específicas
            }
            else if (pruebas.oportunidades == 1)
            {
                animator.SetTrigger("TF2"); // Otro Trigger para esta animación
            }
        }
    }

}
