using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueWizMechanics : MonoBehaviour
{
    public bool startSummonWall;
    StartWall SW;
    Animator thisAnim;

    public GameObject iceDisk;
    public GameObject punch;
    public float punchTimer;

    public GameObject summoningCircle;
    public GameObject player;
    public Vector3 playerPos;
    public Vector3 instantiatePos;

    // Start is called before the first frame update
    void Start()
    {
        thisAnim = this.GetComponent<Animator>();
        SW = this.transform.GetChild(0).GetComponent<StartWall>();

        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(startSummonWall == false && SW.summonWall == true)
        {
            StartCoroutine(summonTheWall());
            startSummonWall = true;
            SW.summonWall = false;
        }

        if(thisAnim.GetBool("Attack") == true)
        {
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
            punch.GetComponent<Collider2D>().enabled = false;
            punchTimer = 0f;
        }


        playerPos = player.transform.position;

        if(playerPos.x >= this.transform.position.x)
        {
            instantiatePos = new Vector3(playerPos.x + 7f, -4.253f, 0f);
        }
        if(playerPos.x < this.transform.position.x)
        {
            instantiatePos = new Vector3(playerPos.x - 7f, -4.253f, 0f);
        }
    }

    IEnumerator summonTheWall()
    {
        this.transform.GetChild(0).gameObject.SetActive(false);
        thisAnim.Play("BlueWizardSummon");
        this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        yield return new WaitForSeconds(0.417f);
        Instantiate(summoningCircle, instantiatePos, Quaternion.identity, this.transform);
        Instantiate(iceDisk, this.transform);
        yield return new WaitForSeconds(6.777f);
        thisAnim.Play("BlueWizardCast");
        yield return new WaitForSeconds(0.333f);
        this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        thisAnim.Play("BlueWizardWalk");
        this.transform.position += new Vector3(0f, 0.03f, 0f);
        startSummonWall = false;
    }
}
