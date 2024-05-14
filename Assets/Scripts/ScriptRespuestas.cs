using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptRespuestas : MonoBehaviour
{
   public bool esCorrecta = false;
   public Pruebas pruebas;
   public AudioSource correcta, incorrecta;
   
   
   public void Respuesta()
   {        
        if(esCorrecta)
        {
            correcta.Stop();
            incorrecta.Stop();
            Debug.Log("Correcta");
            if(pruebas.bonus)
            {
                pruebas.usosComodin++;
                print("sume bonus");
            }
            correcta.Play();
            pruebas.correcto();
            print("respondi correcto");
                       
        }
        else
        {
            correcta.Stop();
            incorrecta.Stop();
            Debug.Log("Incorrecta");
            pruebas.incorrecto();
            incorrecta.Play();
        }
   }
}
