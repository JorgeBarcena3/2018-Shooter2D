using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour
{

    /// <summary>
    /// Vector que apunta al raton
    /// </summary>
    private Vector3 pos;

    /// <summary>
    /// RigidBody2D del objeto
    /// </summary>
    private Rigidbody2D rb;

    /// <summary>
    /// Prefab de la bala
    /// </summary>
    public GameObject bullet;

    /// <summary>
    /// Tiempo de recarga de coolDown
    /// </summary>
    public float coolDownDeDisparo = 1;

    /// <summary>
    /// Cronometro que controla el coolDown
    /// </summary>
    private float cronometro;


    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cronometro = 0;
        // Debug.Log(pos);
    }

    // Update is called once per frame
    void Update()
    {

        cronometro -= Time.deltaTime;
        calcularDisparo();

        if (Input.GetButtonDown("Fire1") && cronometro <= 0)
        {
            calcularDisparo();
            ejecutarDisparo();
            cronometro = coolDownDeDisparo;

        }

        // Debug.DrawLine(transform.position, pos, Color.red);

    }

    /// <summary>
    /// Instancia la bala
    /// </summary>
    private void ejecutarDisparo()
    {

        Instantiate(bullet, transform.position, transform.rotation);

    }

    /// <summary>
    /// Determina la direccion de la flecha segun la posicion del raton
    /// </summary>
    private void calcularDisparo()
    {

        float camDis = Camera.main.transform.position.y - transform.position.y;

        pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, camDis));

        float tangenteEnRadianes = Mathf.Atan2(pos.y - transform.position.y, pos.x - transform.position.x);
        float anguloDeGiro = (180 / Mathf.PI) * tangenteEnRadianes;
      

        rb.rotation = anguloDeGiro;


    }


}
