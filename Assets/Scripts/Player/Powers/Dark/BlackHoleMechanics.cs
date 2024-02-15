using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHoleMechanics : MonoBehaviour
{
    public GameObject childObj;

    public CircleCollider2D col;

    public float deathTimer;

    // Start is called before the first frame update
    void Start()
    {
        childObj = this.transform.GetChild(0).gameObject;
        col = this.GetComponent<CircleCollider2D>();
        col.radius = 0;

        this.transform.localScale = new Vector3(0f, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.localEulerAngles += new Vector3(0f, 0f, 1f);
        childObj.transform.localEulerAngles += new Vector3(0f, 0f, this.transform.localEulerAngles.z * -1f);

        col.radius += 0.01f;

        if(this.transform.localScale.x < 8f)
        {
            this.transform.localScale += new Vector3(0.1f, 0.1f, 0f);
        }

        deathTimer += Time.deltaTime;

        if(deathTimer >= 4f)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "EnemyProjectile")
        {
            if(collision.transform.position.x < this.transform.position.x)
            {
                collision.transform.position += new Vector3(0.15f, 0f, 0f);
            }
            if(collision.transform.position.x > this.transform.position.x)
            {
                collision.transform.position -= new Vector3(0.15f, 0f, 0f);
            }

            if(collision.transform.position.y < this.transform.position.y)
            {
                collision.transform.position += new Vector3(0f, 0.15f, 0f);
            }
            if(collision.transform.position.y > this.transform.position.y)
            {
                collision.transform.position -= new Vector3(0f, 0.15f, 0f);
            }

            collision.GetComponent<Rigidbody2D>().velocity = new Vector3(0f, 0f, 0f);
        }
    }
}
