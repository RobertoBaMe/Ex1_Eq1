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
    //Variable para el panel de Win
    [SerializeField] private GameObject panelWin; 

    private void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        //Siempre que se inicie el juego el panel iniciara apagado 
        panelWin.SetActive(false);
        Time.timeScale = 1;
        
    }
    private void Update()
    {
        //Si los puntos son mayor o igual a 100 se activa el panel de win y se pausa el juego 
        if(puntos >= 100)
        {
            panelWin.SetActive(true);
            Time.timeScale = 0;
        }
        //Cobierte los puntos a String para que pueda salir en pantalla
        textMesh.text = puntos.ToString("0");
    }
    //metodo para sumar los puntos
    public void SumarPuntos(float puntosEntrada)
    {
        puntos += puntosEntrada;
    }
}
