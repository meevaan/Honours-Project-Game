using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public float enemyDamage;
    public float ogDamage;

    public GameObject parentObj;

    // Start is called before the first frame update
    void Start()
    {
        ogDamage = enemyDamage;
        if(this.transform.parent != null)
        {
            parentObj = this.transform.parent.gameObject;
        }
    }

    void Update()
    {
        if(parentObj != null)
        {
            if(this.GetComponent<EnemyDamage>() != null && parentObj.GetComponent<DamageBuff>() != null)
            {
                enemyDamage = Mathf.Ceil(ogDamage * 1.5f);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player" && collision.gameObject.GetComponent<PlayerHealth>() != null)
        {
            collision.gameObject.GetComponent<PlayerHealth>().playerHealth -= enemyDamage;
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && collision.gameObject.GetComponent<PlayerHealth>() != null)
        {
            collision.gameObject.GetComponent<PlayerHealth>().playerHealth -= enemyDamage;
        }
    }
}
