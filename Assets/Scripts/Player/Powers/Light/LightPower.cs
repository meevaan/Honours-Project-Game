using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPower : MonoBehaviour
{
    public Animator Anim;
    Rigidbody2D rb;
    public bool attacking;

    //////// Q ability ////////
    public GameObject mouse;
    public Vector2 mousePos;
    public GameObject lightSpear;
    public float spawnTime;
    public GameObject spinObj;
    public bool spawnedSpinner;
    ///////////////////////////

    //////// E ability ////////
    public GameObject slowingCircle;
    public float SpawnYPos;
    public float circleCooldown;
    ///////////////////////////

    //////// Right Click //////
    public GameObject lightMan;
    public float manCooldown;
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

        mouse.transform.position = new Vector3(mousePos.x, mousePos.y, 0f);

        if(Input.GetKey(KeyCode.Q))
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionX;
            Anim.Play("SpearSummon");
            spawnTime += Time.deltaTime;
            attacking = true;

            if(spawnTime >= 0.25f)
            {
                Instantiate(lightSpear, new Vector3(this.transform.position.x, this.transform.position.y + 2f, 0f), Quaternion.identity);
                spawnTime = 0f;
            }
            if(spawnedSpinner == false)
            {
                Instantiate(spinObj, new Vector3(this.transform.position.x, this.transform.position.y + 2f, 0f), Quaternion.identity);
                spawnedSpinner = true;
            }
        }
        if(Input.GetKeyUp(KeyCode.Q))
        {
            attacking = false;
            rb.constraints = RigidbodyConstraints2D.None;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            spawnedSpinner = false;
            spawnTime = 0.25f;
            Anim.Play("IdleAnim");
            Destroy(GameObject.Find("LightSpin(Clone)"));
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        /////////////////////////////////////////////////////////////// This section is E ability //////////////////////////////////////////////////////
        if(Input.GetKeyDown(KeyCode.E) && attacking == false && circleCooldown >= 10f)
        {
            StartCoroutine(SlowingCircleSummon());
        }

        circleCooldown += Time.deltaTime;
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        /////////////////////////////////////////////////////////////// This section is Right CLick ability //////////////////////////////////////////////////////
        manCooldown += Time.deltaTime;

        if(Input.GetMouseButtonDown(1) && manCooldown >= 5f)
        {
            Instantiate(lightMan, new Vector3(this.transform.position.x + 0.08f, this.transform.position.y + 1.15f, 0f), Quaternion.identity);
            manCooldown = 0f;
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

    IEnumerator SlowingCircleSummon()
    {
        attacking = true;
        circleCooldown = 0f;
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        Anim.Play("SummonCircleWiden");
        yield return new WaitForSeconds(0.75f); //anim time here
        Instantiate(slowingCircle, new Vector3(mouse.transform.position.x, SpawnYPos, 0f), Quaternion.identity);
        rb.constraints = RigidbodyConstraints2D.None;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        Anim.Play("IdleAnim");
        attacking = false;
    }
}
