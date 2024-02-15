using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummoningCircle : MonoBehaviour
{
    Animator thisAnim;
    public float animTimer;

    public Vector3 thisPos;

    public GameObject iceWall;
    public bool iceWallNotSpawned;

    // Start is called before the first frame update
    void Start()
    {
        thisAnim = this.GetComponent<Animator>();
        thisPos = this.transform.position;

        this.transform.GetChild(0).transform.localScale = new Vector3(0.125f, 0f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        animTimer += Time.deltaTime;

        if(animTimer >= 0.667f)
        {
            thisAnim.SetBool("Loop", true);
        }

        if(this.transform.GetChild(0) != null && this.transform.GetChild(0).transform.localScale.y <= 0.4f)
        {
            this.transform.GetChild(0).transform.localScale += new Vector3(0f, 0.005f, 0f);
        }


        this.transform.position = thisPos;

        if(animTimer >= 7f && iceWallNotSpawned == false)
        {
            Instantiate(iceWall, new Vector3(this.transform.position.x, this.transform.position.y + 5.15f, this.transform.position.z), Quaternion.identity);
            iceWallNotSpawned = true;
        }
        if(animTimer >= 10f)
        {
            Destroy(this.gameObject);
            //this.GetComponent<SpriteRenderer>().enabled = false;
            //this.transform.GetChild(0).gameObject.enabled = false;
        }
    }
}
