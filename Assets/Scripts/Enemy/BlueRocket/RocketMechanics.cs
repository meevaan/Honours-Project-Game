using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMechanics : MonoBehaviour
{
    Rigidbody2D thisRB;
    public float launchTimer;

    public bool foundTarget;
    public GameObject playerFound;

    public GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        thisRB = this.GetComponent<Rigidbody2D>();
        thisRB.AddForce(transform.up * 5f, ForceMode2D.Impulse);
        this.transform.localEulerAngles += new Vector3(0f, 0f, 90f);
    }

    // Update is called once per frame
    void Update()
    {
        launchTimer += Time.deltaTime;

        if(launchTimer >= 0.5f)
        {
            //thisRB.velocity = new Vector3(10f, 0f, 0f);
            if(foundTarget == false)
            {
                this.transform.localEulerAngles -= new Vector3(0f, 0f, 2f);
            }
        }

        if(playerFound != null)
        {
            Vector3 Look = this.transform.InverseTransformPoint(playerFound.transform.position);
            float Angle = Mathf.Atan2(Look.y, Look.x) * Mathf.Rad2Deg;        

            if(foundTarget == true)
            {
                thisRB.AddForce(transform.right, ForceMode2D.Impulse);
                this.transform.Rotate(0f, 0f, Angle);
            }
        }

        if(launchTimer >= 10f)
        {
            Destroy(this.gameObject);
        }
    }

    void FixedUpdate()
    {
        RaycastHit2D rocketLine = Physics2D.Raycast(transform.position, transform.right, 150f, LayerMask.GetMask("PlayerLayer"));
        Debug.DrawRay(transform.position, transform.right * 50, Color.red);

        if(rocketLine.collider != null)
        {
            if(rocketLine.transform.tag == "Player")
            {
                playerFound = rocketLine.transform.gameObject;
                foundTarget = true;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag != "Player")
        {
            Instantiate(explosion, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
        if(collision.gameObject.tag == "Player")
        {
            Instantiate(explosion, collision.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
