using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartWall : MonoBehaviour
{
    public bool summonWall;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            summonWall = true;
            //this.GetComponent<Collider2D>().enabled = false;
        }
    }
}
