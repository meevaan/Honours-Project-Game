using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManMechanics : MonoBehaviour
{
    public float health;

    public float punchTimer;
    public GameObject punch;

    public bool attack;

    Animator thisAnim;
    Rigidbody2D thisRB;

    public bool inAir;

    public float deathTimer;

    // Start is called before the first frame update
    void Start()
    {
        punch = this.transform.GetChild(0).gameObject;

        thisAnim = this.GetComponent<Animator>();
        thisRB = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        deathTimer += Time.deltaTime;

        if(attack == true)
        {
            thisAnim.Play("LightManPunch");
            punchTimer += Time.deltaTime;

            if(punchTimer >= 0.570f)
            {
                punch.GetComponent<Collider2D>().enabled = true;
            }
            if(punchTimer >= 0.583f)
            {
                punchTimer = 0f;
            }
            if(punchTimer < 0.570f)
            {
                punch.GetComponent<Collider2D>().enabled = false;
            }
        }
        else
        {
            thisAnim.Play("LightManWalk");
            punch.GetComponent<Collider2D>().enabled = false;
            punchTimer = 0f;
        }

        if(health <= 0f || deathTimer >= 30f)
        {
            Destroy(this.gameObject);
        }

        if(inAir == true)
        {
            thisRB.AddForce(-transform.up * 50f, ForceMode2D.Impulse);
        }
    }

    void FixedUpdate()
    {
        RaycastHit2D forwardHit = Physics2D.Raycast(new Vector2(this.transform.position.x, this.transform.position.y - 0.75f), Vector2.right, 200f, LayerMask.GetMask("Enemy"));
        RaycastHit2D backwardsHit = Physics2D.Raycast(new Vector2(this.transform.position.x, this.transform.position.y - 0.75f), -Vector2.right, 200f, LayerMask.GetMask("Enemy"));

        if(forwardHit.collider != null)
        {
            if(forwardHit.transform.tag == "Enemy" && attack == false)
            {
                thisRB.AddForce(transform.right * (75f * 10f), ForceMode2D.Force);
                this.transform.eulerAngles = new Vector3(0f, 0f, 0f);
            }
        }   

        if(backwardsHit.collider != null)
        {
            if(backwardsHit.transform.tag == "Enemy" && attack == false)
            {
                thisRB.AddForce(transform.right * (75f * 10f), ForceMode2D.Force); 
                this.transform.eulerAngles = new Vector3(0f, 180f, 0f);
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            inAir = true;
        }

        if(collision.gameObject.tag == "Enemy")
        {
            attack = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            inAir = false;
        }
        if(collision.gameObject.tag == "Enemy")
        {
            attack = true;
        }
        if(collision.gameObject.GetComponent<EnemyDamage>() != null)
        {
            if(collision.gameObject.tag == "EnemyWeapon" || collision.gameObject.tag == "EnemyProjectile")
            {
                health -= collision.gameObject.GetComponent<EnemyDamage>().enemyDamage;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<EnemyDamage>() != null)
        {
            if(collision.gameObject.tag == "EnemyWeapon" || collision.gameObject.tag == "EnemyProjectile")
            {
                health -= collision.gameObject.GetComponent<EnemyDamage>().enemyDamage;
            }
        }
    }
}
