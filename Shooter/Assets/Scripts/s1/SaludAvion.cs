using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaludAvion : MonoBehaviour
{

    /// <summary>
    /// Puntos de vida del avion
    /// </summary>
    public int vidaMax = 500;

    /// <summary>
    /// Cantidad de vida actual
    /// </summary>
    private int vidaActual;

    /// <summary>
    /// Si el avion esta derribado o no
    /// </summary>
    public bool sinVida = false;

    // Use this for initialization
    void Start()
    {

        vidaActual = vidaMax;

    }

    // Update is called once per frame
    void Update()
    {

        if (vidaActual <= 0)
            sinVida = true;


    }

    /// <summary>
    /// Establece la vida normal
    /// </summary>
    public void reiniciarVida()
    {

        vidaActual = vidaMax;
        if (sinVida)
        {
            GameManager.puntuacion++;
            sinVida = false;
        }

    }

    /// <summary>
    /// Quita x vida al avion
    /// </summary>
    /// <param name="a">Cantida de vida a succionar</param>
    public void quitarSalud(int a)
    {

        vidaActual -= a;

    }

    /// <summary>
    /// Devuelve los puntos de vida actuales
    /// </summary>
    /// <returns></returns>
    public int getSalud()
    {

        return vidaActual;

    }
}
