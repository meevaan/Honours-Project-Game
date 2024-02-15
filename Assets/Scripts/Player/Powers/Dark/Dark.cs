using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dark : MonoBehaviour
{
    public Animator Anim;
    Rigidbody2D rb;
    public bool attacking;

    //// Q Stuff ////////////////
    public GameObject darkPool;
    public GameObject darkSpike;
    public GameObject smallSpike;
    public GameObject medSpike;
    public GameObject bigSpike;
    public float chargeTime;
    public GameObject foundPool;
    public float spawnAmount;
    public float spriteWidth;
    public float cooldown;
    public bool holdingDown;
    ///////////////////////////////

    //// E Stuff ////////////////
    public GameObject pushZone;
    public float pushCD;
    ////////////////////////////

    /// Right Click Stuff /////
    public GameObject mouse;
    public Vector2 mousePos;
    public int turnOrNoTurn;
    public GameObject blackHole;
    public float holeCD;
    //////////////////////////

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
        if(Input.GetKey(KeyCode.Q) && attacking == false && cooldown >= 3f)
        {
            chargeTime += Time.deltaTime;
        } 
        if(Input.GetKeyDown(KeyCode.Q) && attacking == false && cooldown >= 3f)
        {
            Anim.Play("SpikesWindUp");
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            Instantiate(darkPool, new Vector3(this.transform.position.x + 0.1f, this.transform.position.y - 1.01f, 0f), Quaternion.identity);
            holdingDown = true;
        }
        if(Input.GetKeyUp(KeyCode.Q) && attacking == false && cooldown >= 3f && holdingDown == true)
        {
            StartCoroutine(SpawnSpikes());
            holdingDown = false;
        }
        cooldown += Time.deltaTime;

        if(chargeTime <= 1f)
        {
            darkSpike = smallSpike;
        }
        if(chargeTime > 0.75f && chargeTime <= 1.5f)
        {
            darkSpike = medSpike;
        }
        if(chargeTime > 2f)
        {
            darkSpike = bigSpike;
        }

        if(this.transform.eulerAngles.y >= 180f)
        {
            turnOrNoTurn = -1;
        }
        if(this.transform.eulerAngles.y <= 0f)
        {
            turnOrNoTurn = 1;
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        /////////////////////////////////////////////////////////////// This section is E ability //////////////////////////////////////////////////////
        if(Input.GetKeyDown(KeyCode.E) && attacking == false && pushCD >= 12.5f)
        {
            StartCoroutine(PushBack());
        }

        pushCD += Time.deltaTime;
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        /////////////////////////////////////////////////////////////// This section is Right Click ////////////////////////////////////////////////////
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouse.transform.position = new Vector3(mousePos.x, mousePos.y, 0f);
        
        holeCD += Time.deltaTime;

        if(Input.GetMouseButtonDown(1) && attacking == false && holeCD >= 8f)
        {
            StartCoroutine(SpawnBlackHole());
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    }

    IEnumerator SpawnSpikes()
    {
        attacking = true;
        foundPool = GameObject.Find("SpikesRange(Clone)");
        foundPool.GetComponent<Animator>().enabled = false;
        spriteWidth = foundPool.GetComponent<SpriteRenderer>().sprite.bounds.size.x * 8;
        spawnAmount = spriteWidth / (darkSpike.GetComponent<SpriteRenderer>().sprite.bounds.size.x * 8);
        Anim.Play("SpikesSummon");
        yield return new WaitForSeconds(0.167f);
        for(int i = 0; i < spawnAmount-1; i++)
        {
            Instantiate(darkSpike, new Vector3(foundPool.transform.position.x + (((spriteWidth/spawnAmount) * turnOrNoTurn) * i) + (1f * turnOrNoTurn), 
            foundPool.transform.position.y, 0f), Quaternion.identity);
        }
        rb.constraints = RigidbodyConstraints2D.None;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        Anim.Play("IdleAnim");
        attacking = false;
        chargeTime = 0f;
        cooldown = 0f;
    }

    IEnumerator PushBack()
    {
        attacking = true;
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        Anim.Play("ZoneChannel");
        yield return new WaitForSeconds(0.417f);
        Instantiate(pushZone, this.transform.position, Quaternion.identity);
        rb.constraints = RigidbodyConstraints2D.None;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        Anim.Play("IdleAnim");
        attacking = false;
        pushCD = 0f;
    }

    IEnumerator SpawnBlackHole()
    {
        yield return new WaitForSeconds(0.1f);
        attacking = true;
        Instantiate(blackHole, mouse.transform.position, Quaternion.identity);
        attacking = false;
        holeCD = 0;
    }
}
