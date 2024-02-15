using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float playerHealth;
    public float playerMaxHealth;

    public Waves W;
    public int playerDayCounter;

    Animator thisAnim;
    Rigidbody2D rb;

    public bool deathMoveDown;

    // Start is called before the first frame update
    void Start()
    {
        playerMaxHealth = playerHealth;

        thisAnim = this.GetComponent<Animator>();
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerHealth <= 0f)
        {
            //play death anim or something
            thisAnim.Play("PlayerDeath");
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            this.GetComponent<PlayerMove>().enabled = false;
            this.GetComponent<AnimController>().enabled = false;
            this.GetComponent<Collider2D>().enabled = false;

            this.GetComponent<Fire>().enabled = false;
            this.GetComponent<Water>().enabled = false;
            this.GetComponent<Earth>().enabled = false;
            if(deathMoveDown == false)
            {
                this.transform.position -= new Vector3(0f, 0.23f, 0f);
                deathMoveDown = true;
            }
        }

        if(W.day > playerDayCounter)
        {
            playerHealth = playerMaxHealth;
            playerDayCounter += 1;
        }

        if(playerHealth > playerMaxHealth)
        {
            playerHealth = playerMaxHealth;
        }
    }
}
