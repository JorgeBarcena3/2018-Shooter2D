using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    /// <summary>
    /// Componente RigidBody2D de la bala
    /// </summary>
    private Rigidbody2D rb;

    /// <summary>
    /// Velocidad de la bala
    /// </summary>
    public float velocidadBala = 300;

    /// <summary>
    /// Posicion de la bala
    /// </summary>
    private Vector3 pos;

    // Use this for initialization
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();

        establecerDireccionDeLaBala();


    }



    /// <summary>
    /// Establece la rotacion y direccion que debe cojer la bala
    /// </summary>
    private void establecerDireccionDeLaBala()
    {


        float camDis = Camera.main.transform.position.y - transform.position.y;

        pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, camDis));

        var heading = pos - transform.position;
        var distance = heading.magnitude;
        var direction = heading / distance;

        rb.velocity = direction * velocidadBala * Time.deltaTime;

        float AngleRad = Mathf.Atan2(pos.y - transform.position.y, pos.x - transform.position.x);
        float angle = (180 / Mathf.PI) * AngleRad;
        rb.rotation = angle;



    }

    /// <summary>
    /// Destruye el objeto si se sale de los limites de la pantalla
    /// </summary>
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    /// <summary>
    /// Cuando colisiono con un avion, me destruyo
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Avion")
        {
            Destroy(this.gameObject);

        }

    }
}
