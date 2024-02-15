using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float enemyHealth;
    public float enemySpeed;

    public float turnRay;

    public GameObject healthBar;
    public float healthBarScale;
    public float startingHealth;

    public float startingSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        startingHealth = enemyHealth;
        healthBarScale = healthBar.transform.localScale.x;

        startingSpeed = enemySpeed;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.transform.localScale = new Vector3((healthBarScale / startingHealth) * enemyHealth, healthBar.transform.localScale.y, healthBar.transform.localScale.z);

        if(enemyHealth <= 0f)
        {
            Destroy(this.gameObject);
        }

        /*if(this.transform.childCount > enemyHealth)
        {
            Destroy(this.transform.GetChild(0).gameObject);
        }*/
    }
}
