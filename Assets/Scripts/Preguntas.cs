using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Preguntas
{
    public string Pregunta;
    public string[] Respuestas;
    public int RespuestaCorrecta;
    public bool tieneMedia;
    public AudioClip Media;
}
