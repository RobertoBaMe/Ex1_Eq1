using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Score : MonoBehaviour
{
    //Puntos que tenemos
    private float puntos;
    //controla el componente texto
    private TextMeshProUGUI textMesh;
    private void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }
    private void Update()
    {
        //Cobierte los puntos a String para que pueda salir en pantalla
        textMesh.text = puntos.ToString("0");
    }
    //metodo para sumar los puntos
    public void SumarPuntos(float puntosEntrada)
    {
        puntos += puntosEntrada;
    }
}
