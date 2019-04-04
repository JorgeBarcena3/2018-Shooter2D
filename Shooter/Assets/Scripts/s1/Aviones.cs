using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Aviones : MonoBehaviour
{


    /// <summary>
    /// Componente RigidBody2D del avion
    /// </summary>
    private Rigidbody2D rb;

    /// <summary>
    /// Salud del avion
    /// </summary>
    private SaludAvion salud;

    /// <summary>
    /// Velocidad del avion
    /// </summary>
    public float VelocidadMax = 200;


    /// <summary>
    /// Velocidad actual del avion
    /// </summary>
    private float VelocidadActual;

    /// <summary>
    /// Limites de Spawn
    /// </summary>
    public float limiteMin, limiteMax;

    /// <summary>
    /// Posicion Y del avion
    /// </summary>
    public float posY;

    /// <summary>
    /// Detecta donde se ha recibido el impacto
    /// </summary>
    public DeteccionDeColisiones eslora, alas;

    /// <summary>
    /// GameObject del cambas que almacena la vida
    /// </summary>
    public GameObject vidaInfo;

    /// <summary>
    /// Imagen de la vida
    /// </summary>
    private Image ImagenVida;

    /// <summary>
    /// Posicion de la imagen de la vida
    /// </summary>
    private RectTransform posVida;

    /// <summary>
    /// Limite Y minimo
    /// </summary>
    public float limiteYMin;


    public void setPosY(float a)
    {

        posY = a;

    }

    // Use this for initialization
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        VelocidadActual = VelocidadMax;
        rb.velocity = Vector3.left * VelocidadActual * Time.deltaTime;

        transform.position = new Vector3(limiteMax, posY, transform.position.z);

        salud = GetComponentInChildren<SaludAvion>();

        ImagenVida = vidaInfo.GetComponent<Image>();
        ImagenVida.fillAmount = salud.getSalud() / salud.vidaMax;

        posVida = vidaInfo.GetComponent<RectTransform>();
        posVida.position = Camera.main.WorldToScreenPoint(transform.position);


    }

    /// <summary>
    /// Actualiza la barra de vida del avion
    /// </summary>
    private void barraDeVida()
    {

        ImagenVida.fillAmount = (float)salud.getSalud() / (float)salud.vidaMax;
        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        posVida.position = new Vector3(pos.x, pos.y + 70, pos.z);

    }

    /// <summary>
    /// Cada vez que un avion vuelve a aparecer por pantalla
    /// </summary>
    public void restaurarAvion()
    {

        salud.reiniciarVida();

        rb.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
        setPosY(Random.Range(4.16f, 0.33f));
        transform.position = new Vector3(transform.position.x, posY, transform.position.z);
        VelocidadActual = VelocidadMax;

        alas.GetComponent<BoxCollider2D>().enabled = enabled;
        eslora.GetComponent<BoxCollider2D>().enabled = enabled;

    }

    // Update is called once per frame
    void Update()
    {

        barraDeVida();



        //Calcula si la posicion es correcta
        if (transform.position.x < limiteMin || transform.position.y < limiteYMin)
        {
            restaurarAvion();
            transform.position = new Vector3(limiteMax, posY, transform.position.z);

        }

        if (eslora.colisionDetectada)
        {
            eslora.colisionDetectada = false;
            //  Debug.Log("Has golpeado al cuerpo. Le has quitado " + eslora.vidaASuccionar + " puntos de vida al avion");
            salud.quitarSalud(eslora.vidaASuccionar);
        }

        if (alas.colisionDetectada)
        {
            alas.colisionDetectada = false;
            // Debug.Log("Has golpeado un ala. Le has quitado " + alas.vidaASuccionar + " puntos de vida al avion");
            salud.quitarSalud(alas.vidaASuccionar);
        }

        if (salud.sinVida)
        {

            //Destroy(this.gameObject);
            alas.GetComponent<BoxCollider2D>().enabled = false;
            eslora.GetComponent<BoxCollider2D>().enabled = false;
            //rb.velocity = Vector3.zero;
            rb.constraints = RigidbodyConstraints2D.None;

            //GameManager.menosAvionesEnVuelo();

        }
        else
            //Establece una velocidad constante
            rb.velocity = Vector3.left * VelocidadActual * Time.deltaTime;


    }


}
