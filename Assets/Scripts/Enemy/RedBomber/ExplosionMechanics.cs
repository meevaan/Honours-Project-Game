using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionMechanics : MonoBehaviour
{
    public float timeTilDeath;
    // Start is called before the first frame update
    void Start()
    {
        timeTilDeath = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        timeTilDeath -= Time.deltaTime;

        if(timeTilDeath <= 1f)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(this.transform.position.x < collision.gameObject.transform.position.x)
            {
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * 600f, ForceMode2D.Impulse);
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.right * 750f, ForceMode2D.Impulse);
            }
            if(this.transform.position.x >= collision.gameObject.transform.position.x)
            {
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * 600f, ForceMode2D.Impulse);
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.right * -750f, ForceMode2D.Impulse);
            }
        }
    }
}
