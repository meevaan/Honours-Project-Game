using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmiteSpearMechanics : MonoBehaviour
{
    public float deathTimer;
    public float damage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        deathTimer += Time.deltaTime;

        if(deathTimer >= 3f)
        {
            Destroy(this.gameObject);
        }

        this.transform.position = new Vector3(this.transform.parent.transform.position.x, this.transform.position.y, 0f);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyHealth>().enemyHealth -= damage;
        }
    }
}
