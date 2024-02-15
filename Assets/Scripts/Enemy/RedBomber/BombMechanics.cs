using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombMechanics : MonoBehaviour
{
    Rigidbody2D thisRB;
    public GameObject bombExplosion;

    // Start is called before the first frame update
    void Start()
    {
        thisRB = this.GetComponent<Rigidbody2D>();

        if(this.transform.position.x <= GameObject.Find("Player").transform.position.x)
        {
            thisRB.AddForce(transform.right * 5f, ForceMode2D.Impulse); 
            thisRB.AddForce(transform.up * 7f, ForceMode2D.Impulse); 
        }
        if(this.transform.position.x > GameObject.Find("Player").transform.position.x)
        {
            thisRB.AddForce(transform.right * -5f, ForceMode2D.Impulse); 
            thisRB.AddForce(transform.up * 7f, ForceMode2D.Impulse); 
        }
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.eulerAngles -= new Vector3(0f, 0f, 1f);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(bombExplosion, this.transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
