using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptRespuestas : MonoBehaviour
{
   public bool esCorrecta = false;
   public Pruebas pruebas;
   
   public void Respuesta()
   {
        if(pruebas.contadorPreguntas>1 && (pruebas.contadorPreguntas-1)%3==0)
        {
            pruebas.bonus = true;
        }

        else
        {
            pruebas.bonus = false;
        }
        
        if(esCorrecta)
        {
            Debug.Log("Correcta");
            if(pruebas.bonus)
            {
                pruebas.usosComodin++;
                print("sume bonus");
            } 
            pruebas.correcto();
            print("respondi correcto");
                       
        }
        else
        {
            Debug.Log("Incorrecta");
            pruebas.incorrecto();
        }
   }
}
