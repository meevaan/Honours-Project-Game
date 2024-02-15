using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSpearMechanics : MonoBehaviour
{
    Rigidbody2D thisRB;

    public int colCounter;

    public float damage;

    public float deathTimer;

    // Start is called before the first frame update
    void Start()
    {
        thisRB = this.GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {
        var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(this.transform.position);
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward); //Random.Range(angle - 5f, angle + 5f)

        thisRB.AddForce(transform.right * 20f, ForceMode2D.Force);

        if(colCounter > 3)
        {
            Destroy(this.gameObject);
        }

        deathTimer += Time.deltaTime;

        if(deathTimer >= 10f)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            Destroy(this.gameObject);
        }

        if(collision.gameObject.tag == "Enemy")
        {
            colCounter += 1;
            collision.gameObject.GetComponent<EnemyHealth>().enemyHealth -= damage;
        }
    }
}
