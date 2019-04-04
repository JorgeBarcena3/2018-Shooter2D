using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeteccionDeColisiones : MonoBehaviour
{

    /// <summary>
    /// Determina si hay o no algun tipo de colision
    /// </summary>
    public bool colisionDetectada = false;

    /// <summary>
    /// Cantidad de vida que se va a supcionar
    /// </summary>
    public int vidaASuccionar = 100;

    /// <summary>
    /// Persiodo de cooldown
    /// </summary>
    public float coolDownMax = 2;

    /// <summary>
    /// Contador del coolDown
    /// </summary>
    private float coolDownTimer;


    private void Start()
    {
        coolDownTimer = 0;
    }

    private void Update()
    {
        coolDownTimer -= Time.deltaTime;
        //Debug.Log(coolDownTimer);
    }

    /// <summary>
    /// Cuando colisiona con la bala, se informa al avion
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Bala" && coolDownTimer <= 0)
        {

            colisionDetectada = true;
            coolDownTimer = coolDownMax;

        }

    }


}
