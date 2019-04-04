using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    /// <summary>
    /// Maxima y minima "Y" de spawneo.
    /// </summary>
    public float setYMax, setYMin;

    /// <summary>
    /// Prefab de los aviones
    /// </summary>
    public GameObject prefabAvion;

    /// <summary>
    /// Cantidad maxima de aviones
    /// </summary>
    public int cantidadMaximaDeAviones = 4;

    /// <summary>
    /// Frecuencia de Spawneo en segundos
    /// </summary>
    public float velocidadDeSpawneo;

    /// <summary>
    /// Cantidad de aviones en vuelo
    /// </summary>
    private static int avionesEnVuelo = 0;

    /// <summary>
    /// Cuanta atras que calcula el tiempo de spawneo;
    /// </summary>
    private float cuentaAtras;

    /// <summary>
    /// Texto que muestra la cantidad de aviones derribados
    /// </summary>
    public Text puntuacionText;

    /// <summary>
    /// Cantidad de aviones derribados
    /// </summary>
    public static int puntuacion = 0;

    // Use this for initialization
    void Start()
    {

        cuentaAtras = velocidadDeSpawneo;


    }

    /// <summary>
    /// Muestra los aviones a traves del texto de pantalla
    /// </summary>
    private void mostrarAvionesPorPantalla()
    {

        puntuacionText.text = "AVIONES DERRIBADOS: " + puntuacion;

    }

    // Update is called once per frame
    void Update()
    {

        cuentaAtras += Time.deltaTime;

        mostrarAvionesPorPantalla();

        if (avionesEnVuelo < cantidadMaximaDeAviones && cuentaAtras > velocidadDeSpawneo)
            iniciarAvion();

    }

    /// <summary>
    /// Crea el objeto Avion
    /// </summary>
    private void iniciarAvion()
    {

        GameObject aux = Instantiate(prefabAvion);
        Aviones avion = aux.GetComponent<Aviones>();
        avion.setPosY(Random.Range(setYMin, setYMax));
        cuentaAtras = 0;
        avionesEnVuelo++;

    }
}


