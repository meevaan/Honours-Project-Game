using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleMechanics : MonoBehaviour
{
    public SpriteRenderer middleSprite;
    public SpriteRenderer innerSprite;

    GameObject player;

    public int hitCounter;
    
    // Start is called before the first frame update
    void Start()
    {
        middleSprite = this.transform.GetChild(0).GetComponent<SpriteRenderer>();
        innerSprite = this.transform.GetChild(1).GetComponent<SpriteRenderer>();

        middleSprite.color = new Color(255f, 255f, 255f, 0.5f);
        innerSprite.color = new Color(255f, 255f, 255f, 0.25f);

        player= GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = player.transform.position;
        if(player.GetComponent<Water>().enabled == false || hitCounter >= 3)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "EnemyProjectile")
        {
            Destroy(collision.gameObject);
            hitCounter += 1;
        }
    }
}
