using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    //Valor que nos dara cada manzana
    [SerializeField] private float ValorManzana;
    [SerializeField] private Score score;   //Referencia al script Score

    private void Update()
    {
        //Rotación del objeto
        //transform.Rotate(new Vector3(0f, 70f, 0f) * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            score.SumarPuntos(ValorManzana);
            Destroy(gameObject);
        }
    }
}
