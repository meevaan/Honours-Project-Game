using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earth : MonoBehaviour
{
    public Animator Anim;
    Rigidbody2D rb;
    public bool attacking;

    public GameObject mouse;

    ///// Q ability ///////
    public float SpawnYPos;
    public GameObject QRock;
    public float rockTimer;
    ///////////////////////

    ///// E ability ///////
    public GameObject smallMeteor;
    public GameObject mediumMeteor;
    public GameObject bigMeteor;
    public float cooldown;
    public float powerUp;
    ///////////////////////

    ///// Right Click /////
    public float clickCooldown;
    public GameObject stoneWall;
    ///////////////////////

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
        mouse.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        /////////////////////////////////////////////////////////////// This section is Q ability //////////////////////////////////////////////////////
        rockTimer += Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.Q) && attacking == false && rockTimer >= 1f)
        {
            StartCoroutine(SpawnRock());
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /////////////////////////////////////////////////////////////// This section is E ability //////////////////////////////////////////////////////
        cooldown += Time.deltaTime;

        if(attacking == false && cooldown >= 4f)
        {
            if(Input.GetKey(KeyCode.E))
            {
                powerUp += Time.deltaTime;
                rb.constraints = RigidbodyConstraints2D.FreezePositionX;
                Anim.Play("ChargeMeteor");
            }

            if(Input.GetKeyUp(KeyCode.E) && powerUp < 2f)
            {
                StartCoroutine(LaunchSmallMeteor());
                powerUp = 0f;
            }
            if(Input.GetKeyUp(KeyCode.E) && powerUp > 2f && powerUp < 4f)
            {
                StartCoroutine(LaunchMedMeteor());
                powerUp = 0f;
            }
            if(Input.GetKeyUp(KeyCode.E) && powerUp > 4f)
            {
                StartCoroutine(LaunchBigMeteor());
                powerUp = 0f;
            }
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /////////////////////////////////////////////////////////////// This section is Right Click ability ////////////////////////////////////////////
        clickCooldown += Time.deltaTime;

        if(Input.GetMouseButtonDown(1) && attacking == false && clickCooldown >= 15f)
        {
            StartCoroutine(SpawnWalls());
        }
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

    /////////////////////////////////////////////////////////////// This section is Q ability //////////////////////////////////////////////////////
    IEnumerator SpawnRock()
    {
        attacking = true;
        rockTimer = 0f;
        Anim.Play("SmallRockSummon");
        yield return new WaitForSeconds(0.333f);
        Instantiate(QRock, new Vector3(mouse.transform.position.x, SpawnYPos + 0.3f, 0f), Quaternion.identity);
        Anim.Play("IdleAnim");
        attacking = false;
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    
    /////////////////////////////////////////////////////////////// This section is E ability //////////////////////////////////////////////////////
    IEnumerator LaunchSmallMeteor()
    {
        attacking = true;
        Anim.Play("ThrowMeteor");
        yield return new WaitForSeconds(0.333f);
        Instantiate(smallMeteor, new Vector3(mouse.transform.position.x-3f, Random.Range(14f, 18f), 0f), Quaternion.identity);
        Instantiate(smallMeteor, new Vector3(mouse.transform.position.x-5f, Random.Range(14f, 18f), 0f), Quaternion.identity);
        Instantiate(smallMeteor, new Vector3(mouse.transform.position.x-7f, Random.Range(14f, 18f), 0f), Quaternion.identity);
        attacking = false;
        cooldown = 0f;
        rb.constraints = RigidbodyConstraints2D.None;
        Anim.Play("IdleAnim");
    }
    IEnumerator LaunchMedMeteor()
    {
        attacking = true;
        Anim.Play("ThrowMeteor");
        yield return new WaitForSeconds(0.333f);
        Instantiate(mediumMeteor, new Vector3(mouse.transform.position.x-3f, Random.Range(14f, 18f), 0f), Quaternion.identity);
        Instantiate(mediumMeteor, new Vector3(mouse.transform.position.x-7f, Random.Range(14f, 18f), 0f), Quaternion.identity);
        attacking = false;
        cooldown = 0f;
        rb.constraints = RigidbodyConstraints2D.None;
        Anim.Play("IdleAnim");
    }
    IEnumerator LaunchBigMeteor()
    {
        attacking = true;
        Anim.Play("ThrowMeteor");
        yield return new WaitForSeconds(0.333f);
        Instantiate(bigMeteor, new Vector3(mouse.transform.position.x-3f, 15f, 0f), Quaternion.identity);
        attacking = false;
        cooldown = 0f;
        rb.constraints = RigidbodyConstraints2D.None;
        Anim.Play("IdleAnim");
    }
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    /////////////////////////////////////////////////////////////// This section is Q ability //////////////////////////////////////////////////////
    IEnumerator SpawnWalls()
    {
        attacking = true;
        clickCooldown = 0f;
        //Anim.Play("SmallRockSummon");
        yield return new WaitForSeconds(0.333f);
        Instantiate(stoneWall, new Vector3(mouse.transform.position.x + 4f, SpawnYPos + 1.9f, 0f), Quaternion.identity);
        Instantiate(stoneWall, new Vector3(mouse.transform.position.x - 4f, SpawnYPos + 1.9f, 0f), Quaternion.identity);
        Anim.Play("IdleAnim");
        attacking = false;
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
}
