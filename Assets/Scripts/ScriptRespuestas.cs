using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptRespuestas : MonoBehaviour
{
   public bool esCorrecta = false;
   public Pruebas pruebas;
   public AudioSource correcta, incorrecta, comodin;
   
   
   public void Respuesta()
   {        
        if(esCorrecta)
        {
            comodin.Stop();
            correcta.Stop();
            incorrecta.Stop();
            Debug.Log("Correcta");            
            correcta.Play();
            if(pruebas.bonus)
            {
                correcta.Stop();
                comodin.Play();
                pruebas.usosComodin++;
                print("sume bonus");
            }
            pruebas.correcto();
            print("respondi correcto");
                       
        }
        else
        {
            comodin.Stop();
            correcta.Stop();
            incorrecta.Stop();
            Debug.Log("Incorrecta");
            pruebas.incorrecto();
            incorrecta.Play();
        }
   }
}
