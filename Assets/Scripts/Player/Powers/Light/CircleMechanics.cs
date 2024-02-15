using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleMechanics : MonoBehaviour
{
    public float previousEnemySpeed;
    public bool hitSlowField;

    public float deathTimer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.GetChild(0).transform.localScale.x < 0.125f)
        {
            this.transform.GetChild(0).transform.localScale += new Vector3(Time.deltaTime, 0f, 0f);
        }

        if(this.transform.GetChild(0).transform.localScale.y < 1.14f)
        {
            this.transform.GetChild(0).transform.localScale += new Vector3(0f, Time.deltaTime, 0f);
        }

        deathTimer += Time.deltaTime;

        if(deathTimer >= 15f)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            collision.GetComponent<EnemyHealth>().enemySpeed = 4;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            collision.GetComponent<EnemyHealth>().enemySpeed = collision.GetComponent<EnemyHealth>().startingSpeed;
        }
    }
}
