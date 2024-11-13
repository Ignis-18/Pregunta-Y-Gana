using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum Dificultad{FACIL, INTERMEDIO, DIFICIL}
public class Pruebas : MonoBehaviour
{
    public GameObject info;
    public DoNotDestroyOnLoad detecta;    
    public List<Preguntas> preguntasFaciles;
    public List<Preguntas> preguntasMedias;
    public List<Preguntas> preguntasDificiles;
    public GameObject[] opciones;
    public GameObject botonComodin;
    public GameObject panelPregunta;
    public GameObject indicadorBonus;
    public SceneLoaderScript Loader;
    
    public Dificultad _dificultad;
    public int preguntaActual;
    
    public Text preguntaTxt;
    public int contadorDificultad;
    public int contadorPreguntas;
    public int cantidadCorrectas;
    public int oportunidades;
    public int usosComodin;
    public bool bonus = false;

    public bool esCorrecta = false;

    public Text puntuacion;
    public Text vidas;

    private void Start() //Iniciar primera pregunta
    {
        info = GameObject.FindWithTag("Manager");
        detecta = info.GetComponent<DoNotDestroyOnLoad>();
        
        contadorDificultad = 1;
        oportunidades = 3;
        cantidadCorrectas = 0;
        contadorPreguntas = 1;
        usosComodin = 0;

        detecta.win = false;
        detecta.lose = false;

        opciones[0].SetActive(true);
        opciones[1].SetActive(true);
        opciones[2].SetActive(true);
        opciones[3].SetActive(true);
        
        generarPreguntas();

        puntuacion.text = "Puntos: \n"+cantidadCorrectas;
        vidas.text = "Vidas: \n"+oportunidades;
    }

    private void Update()
    {
        if(contadorPreguntas>1 && (contadorPreguntas-1)%3==0 && detecta.infinite == false)
        {
            bonus = true;
        }

        else
        {
            bonus = false;
        }

        if(bonus)
        {
            indicadorBonus.SetActive(true);
        }
        else
        {
            indicadorBonus.SetActive(false);
        }

        if (detecta.infinite == false)
        {
            if(cantidadCorrectas >= 10 || oportunidades <= 0)
            {
                Loader.activarEscena = true;
            }
        }

        else
        {
            if(preguntasDificiles.Count <= 0 || oportunidades <= 0)
            {
                Loader.activarEscena = true;
            }
        }
    }

    public void correcto() //Siguiente preguntas en caso de respuesta correcta
    {
        Debug.Log(contadorPreguntas);
        
        opciones[0].SetActive(true);
        opciones[1].SetActive(true);
        opciones[2].SetActive(true);
        opciones[3].SetActive(true);
        
        if (_dificultad == Dificultad.FACIL)
        {
            preguntasFaciles.RemoveAt(preguntaActual);
        }

        else if (_dificultad == Dificultad.INTERMEDIO)
        {
            preguntasMedias.RemoveAt(preguntaActual);
        }

        else if (_dificultad == Dificultad.DIFICIL)
        {
            preguntasDificiles.RemoveAt(preguntaActual);
        }        

        generarPreguntas();

        if(bonus == false)
        {
            contadorDificultad++;
            cantidadCorrectas++;  
        }
        contadorPreguntas++;

        puntuacion.text = "Puntos: \n"+cantidadCorrectas;

        if(cantidadCorrectas>=10 && detecta.infinite == false)
        {
            Debug.Log("Ganaste");
            //Win();
        }

        if(preguntasDificiles.Count <= 0 && detecta.infinite == true)
        {
            Debug.Log("Ganaste");
        }
    }

    public void incorrecto() //Siguiente pregunta en caso de respuesta incorrecta
    {
        Debug.Log(contadorPreguntas);

        /*
        Responder();
        Evaluar();
        si es buena
        Chequear si hay bonus()
        evaluar dificultad()
        Avanzar a la siguiente()
        si es mala
        evaluar dificultad()
        Quitar vida()*/
        
        opciones[0].SetActive(true);
        opciones[1].SetActive(true);
        opciones[2].SetActive(true);
        opciones[3].SetActive(true);
        
        if (_dificultad == Dificultad.FACIL)
        {
            preguntasFaciles.RemoveAt(preguntaActual);
        }

        else if (_dificultad == Dificultad.INTERMEDIO)
        {
            preguntasMedias.RemoveAt(preguntaActual);
        }

        else if (_dificultad == Dificultad.DIFICIL)
        {
            preguntasDificiles.RemoveAt(preguntaActual);
        }

        generarPreguntas();

        if(bonus == false)
        {
            contadorDificultad--;
            oportunidades--;  
        }
        contadorPreguntas++;

        vidas.text = "Vidas: \n"+oportunidades;

        if (oportunidades<=0)
        {
           Debug.Log("Fin del juego");
           //GameOver();
        }

        
    }

    void generarPreguntas() //Generar pregunta dependiendo de dificultad
    {

        AsignarDificultad();

        switch (_dificultad)
        {
            case Dificultad.FACIL:
                preguntaActual = Random.Range(0, preguntasFaciles.Count);
                preguntaTxt.text = preguntasFaciles[preguntaActual].Pregunta;
                marcarRespuestas();
            break;

            case Dificultad.INTERMEDIO:
                preguntaActual = Random.Range(0, preguntasMedias.Count);
                preguntaTxt.text = preguntasMedias[preguntaActual].Pregunta;
                marcarRespuestas(); 
            break;

            case Dificultad.DIFICIL:
                preguntaActual = Random.Range(0, preguntasDificiles.Count);
                preguntaTxt.text = preguntasDificiles[preguntaActual].Pregunta;
                marcarRespuestas();
            break;
        }

        /*
        if (contadorDificultad >=0 && contadorDificultad<=3)
        {
            preguntaActual = Random.Range(0, preguntasFaciles.Count);

            preguntaTxt.text = preguntasFaciles[preguntaActual].Pregunta;

            marcarRespuestas();
        }

        else if (contadorDificultad >=4 && contadorDificultad<=6)
        {
            preguntaActual = Random.Range(0, preguntasMedias.Count);

            preguntaTxt.text = preguntasMedias[preguntaActual].Pregunta;

            marcarRespuestas(); 
        }

        else if (contadorDificultad >=7)
        {
            preguntaActual = Random.Range(0, preguntasDificiles.Count);

            preguntaTxt.text = preguntasDificiles[preguntaActual].Pregunta;

            marcarRespuestas();
        }*/
    }

    public void AsignarDificultad() //Asignar valores de dificultad
    {
        if (detecta.infinite == false)
        {
            if(contadorDificultad <= 3) _dificultad = Dificultad.FACIL;
            else if(contadorDificultad <= 6) _dificultad = Dificultad.INTERMEDIO;
            else _dificultad = Dificultad.DIFICIL;
        }

        else
        {
            if(preguntasFaciles.Count > 0) _dificultad = Dificultad.FACIL;
            else if(preguntasFaciles.Count <= 0 && preguntasMedias.Count > 0) _dificultad = Dificultad.INTERMEDIO;
            else _dificultad = Dificultad.DIFICIL;
        }
    }

    void marcarRespuestas() //Determinar respuesta correcta
    {
        if (_dificultad == Dificultad.FACIL)
        {
            for (int i = 0; i<opciones.Length; i++)
            {
                opciones[i].GetComponent<ScriptRespuestas>().esCorrecta = false;
                opciones[i].transform.GetChild(0).GetComponent<Text>().text = preguntasFaciles[preguntaActual].Respuestas[i];

                if(preguntasFaciles[preguntaActual].RespuestaCorrecta == i+1)
                {
                    opciones[i].GetComponent<ScriptRespuestas>().esCorrecta = true;
                }
            }
        }

        else if (_dificultad == Dificultad.INTERMEDIO)
        {
            for (int i = 0; i<opciones.Length; i++)
            {
                opciones[i].GetComponent<ScriptRespuestas>().esCorrecta = false;
                opciones[i].transform.GetChild(0).GetComponent<Text>().text = preguntasMedias[preguntaActual].Respuestas[i];

                if(preguntasMedias[preguntaActual].RespuestaCorrecta == i+1)
                {
                    opciones[i].GetComponent<ScriptRespuestas>().esCorrecta = true;
                }
            }
        }

        else if (_dificultad == Dificultad.DIFICIL)
        {
            for (int i = 0; i<opciones.Length; i++)
            {
                opciones[i].GetComponent<ScriptRespuestas>().esCorrecta = false;
                opciones[i].transform.GetChild(0).GetComponent<Text>().text = preguntasDificiles[preguntaActual].Respuestas[i];

                if(preguntasDificiles[preguntaActual].RespuestaCorrecta == i+1)
                {
                    opciones[i].GetComponent<ScriptRespuestas>().esCorrecta = true;
                }
            }
        }
    }

    public void comodin() //Funciones del comodin
    {
        if (_dificultad == Dificultad.FACIL && usosComodin>0 && detecta.infinite == false)
        {
            for (int i = 0; i<opciones.Length; i++)
            {
                if(preguntasFaciles[preguntaActual].RespuestaCorrecta == 1 || preguntasFaciles[preguntaActual].RespuestaCorrecta == 4)
                {
                    opciones[1].SetActive(false);
                    opciones[2].SetActive(false);
                }

                if(preguntasFaciles[preguntaActual].RespuestaCorrecta == 2 || preguntasFaciles[preguntaActual].RespuestaCorrecta == 3)
                {
                    opciones[0].SetActive(false);
                    opciones[3].SetActive(false);
                }
            }
            usosComodin--;
        }

        else if (_dificultad == Dificultad.INTERMEDIO && usosComodin>0 && detecta.infinite == false)
        {
            for (int i = 0; i<opciones.Length; i++)
            {
                if(preguntasMedias[preguntaActual].RespuestaCorrecta == 1 || preguntasMedias[preguntaActual].RespuestaCorrecta == 4)
                {
                    opciones[1].SetActive(false);
                    opciones[2].SetActive(false);
                }

                if(preguntasMedias[preguntaActual].RespuestaCorrecta == 2 || preguntasMedias[preguntaActual].RespuestaCorrecta == 3)
                {
                    opciones[0].SetActive(false);
                    opciones[3].SetActive(false);
                }
            }
            usosComodin--;
        }

        else if (_dificultad == Dificultad.DIFICIL && usosComodin>0 && detecta.infinite == false)
        {
            for (int i = 0; i<opciones.Length; i++)
            {
                if(preguntasDificiles[preguntaActual].RespuestaCorrecta == 1 || preguntasDificiles[preguntaActual].RespuestaCorrecta == 4)
                {
                    opciones[1].SetActive(false);
                    opciones[2].SetActive(false);
                }

                if(preguntasDificiles[preguntaActual].RespuestaCorrecta == 2 || preguntasDificiles[preguntaActual].RespuestaCorrecta == 3)
                {
                    opciones[0].SetActive(false);
                    opciones[3].SetActive(false);
                }
            }
            usosComodin--;
        }
    }

    public void GameOver()
    {
        /*
        DesactivarBotones();
        DesactivarPregunta();
        ActivarPantallaGameOver();
        ActivarBotonesSalirRestart();
        */

        SceneManager.LoadScene("GameOver");
    }

    public void Win()
    {
        SceneManager.LoadScene("Win");
    }
}
