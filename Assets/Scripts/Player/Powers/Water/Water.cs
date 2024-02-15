using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    public Animator Anim;
    Rigidbody2D rb;
    public bool attacking;

    //////// Q ability ////////
    public GameObject wave;
    public Vector3 spawnPos;

    public GameObject mouse;
    public Vector2 mousePos;
    public float SpawnXPos;
    public float SpawnYPos;
    //////////////////////////

    //////// E ability ////////
    public GameObject waterBeam;
    ///////////////////////////

    //////// Right Click //////
    public GameObject bubble;
    public float cooldown;
    ///////////////////////////

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        Anim = this.GetComponent<Animator>();

        if(GameObject.Find("MouseRayHolder") == null)
        {
            mouse = new GameObject();
            mouse.name = "MouseRayHolder";
        }
        else
        {
            mouse = GameObject.Find("MouseRayHolder");
        }
    }

    // Update is called once per frame
    void Update()
    {
        /////////////////////////////////////////////////////////////// This section is Q ability //////////////////////////////////////////////////////
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if(Input.GetKeyDown(KeyCode.Q) && attacking == false && GameObject.Find("WaterWave(Clone)") == null)
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionX;
            StartCoroutine(LaunchWave());
        }

        mouse.transform.position = new Vector3(mousePos.x, mousePos.y, 0f);
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /////////////////////////////////////////////////////////////// This section is E ability //////////////////////////////////////////////////////
        if(Input.GetKey(KeyCode.E) && attacking == false)
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionX;
            Instantiate(waterBeam, this.transform.position, Quaternion.identity);
            attacking = true;
            Anim.Play("BeamCharge");
        }
        if(Input.GetKeyUp(KeyCode.E))
        {
            Destroy(GameObject.Find("BeamHolder(Clone)"));
            attacking = false;
            rb.constraints = RigidbodyConstraints2D.None;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            Anim.Play("IdleAnim");
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /////////////////////////////////////////////////////////////// This section is Right Click ability ////////////////////////////////////////////
        if(Input.GetMouseButtonDown(1) && cooldown >= 20f && GameObject.Find("OuterBubble(Clone)") == null)
        {
            Instantiate(bubble, this.transform.position, Quaternion.identity);
            cooldown = 0f;
        }

        cooldown += Time.deltaTime;
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    }

    void FixedUpdate()
    {
        ////////////////////////// Q ability stuff //////////////////////////////////////////////////////////////////////
        RaycastHit2D hit = Physics2D.Raycast(mouse.transform.position, -Vector2.up);

        if(hit.collider != null)
        {
            if(hit.collider.gameObject.tag == "Ground")
            {
                SpawnYPos = hit.point.y;
            }
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    }

    /////////////////////////////////////////////////////////////// This section is Q ability //////////////////////////////////////////////////////////   
    IEnumerator LaunchWave()
    {
        attacking = true;
        Anim.Play("WaveSummon");
        yield return new WaitForSeconds(0.5f);
        Instantiate(wave, new Vector3(this.transform.position.x-3f, SpawnYPos+(4.255643f-1.31f), 0f), Quaternion.identity);
        attacking = false;
        rb.constraints = RigidbodyConstraints2D.None;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        Anim.Play("IdleAnim");
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
}
