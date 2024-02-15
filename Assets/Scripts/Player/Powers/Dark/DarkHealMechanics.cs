using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkHealMechanics : MonoBehaviour
{
    public GameObject player;
    public Rigidbody2D thisRB;
    public Vector3 targ;
    public Vector3 thisPos;
    public float angle;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        thisRB = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //thisRB.AddForce(transform.up * 0.025f, ForceMode2D.Impulse);

        targ = player.transform.position;
        thisPos = this.transform.position;

        targ.x = targ.x - thisPos.x;
        targ.y = targ.y - thisPos.y;

        angle = Mathf.Atan2(targ.y, targ.x) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle-90f));

        if(player.transform.position.x < this.transform.position.x)
        {
            this.transform.position -= new Vector3(0.04f, 0f, 0f);
        }
        if(player.transform.position.x > this.transform.position.x)
        {
            this.transform.position += new Vector3(0.04f, 0f, 0f);
        }

        if(player.transform.position.y < this.transform.position.y)
        {
            this.transform.position -= new Vector3(0f, 0.025f, 0f);
        }
        if(player.transform.position.y > this.transform.position.y)
        {
            this.transform.position += new Vector3(0f, 0.025f, 0f);
        }

        thisRB.AddForce(transform.right * Random.Range(-0.1f, 0.1f), ForceMode2D.Impulse);
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.GetComponent<PlayerHealth>().playerHealth += 10f;
            Destroy(this.gameObject);
        }
    }
}
