using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public Animator Anim;
    Rigidbody2D rb;
    public bool attacking;

    //// Q Stuff ////////////////
    public float powerupAttack;

    public GameObject smallFire;
    public GameObject medFire;
    public GameObject bigFire;

    public GameObject smallFireLight;
    public GameObject medFireLight;
    public GameObject bigFireLight;
    ///////////////////////////////

    //// E Stuff ////////////////
    public GameObject flamePillar;
    public GameObject mouse;
    public Vector2 mousePos;
    public float SpawnXPos;
    public float SpawnYPos;

    public GameObject footLight;
    ////////////////////////////

    /// Right Click Stuff /////
    public GameObject fireExplosion;
    public float RCCooldown;
    public GameObject fireExplosionLight;
    public bool lightExplosion;
    public Vector3 spawnExplosion;
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
        if(Input.GetKey(KeyCode.Q) && attacking == false)
        {
            powerupAttack += Time.deltaTime;
            rb.constraints = RigidbodyConstraints2D.FreezePositionX;
            Anim.Play("ChargeFireball");

            if(powerupAttack <= 1f && GameObject.Find("FireLight(Clone)") == null)
            {
                Instantiate(smallFireLight, this.transform);

                smallFireLight.GetComponent<UnityEngine.Rendering.Universal.Light2D>().intensity = 1f;
                smallFireLight.GetComponent<UnityEngine.Rendering.Universal.Light2D>().pointLightOuterRadius = 2f;
            } 
            if(powerupAttack > 1f && powerupAttack <= 4f && GameObject.Find("FireLight2(Clone)") == null)
            {
                Instantiate(medFireLight, this.transform);

                GameObject.Find("FireLight(Clone)").GetComponent<UnityEngine.Rendering.Universal.Light2D>().intensity = 3f;
                GameObject.Find("FireLight(Clone)").GetComponent<UnityEngine.Rendering.Universal.Light2D>().pointLightOuterRadius = 4f;

                GameObject.Find("FireLight2(Clone)").GetComponent<UnityEngine.Rendering.Universal.Light2D>().intensity = 2f;
                GameObject.Find("FireLight2(Clone)").GetComponent<UnityEngine.Rendering.Universal.Light2D>().pointLightOuterRadius = 1f;
            }
            if(powerupAttack > 4f && GameObject.Find("FireLight3(Clone)") == null)
            {
                Instantiate(bigFireLight, this.transform);

                GameObject.Find("FireLight(Clone)").GetComponent<UnityEngine.Rendering.Universal.Light2D>().intensity = 5f;
                GameObject.Find("FireLight(Clone)").GetComponent<UnityEngine.Rendering.Universal.Light2D>().pointLightOuterRadius = 6f;

                GameObject.Find("FireLight2(Clone)").GetComponent<UnityEngine.Rendering.Universal.Light2D>().intensity = 2f;
                GameObject.Find("FireLight2(Clone)").GetComponent<UnityEngine.Rendering.Universal.Light2D>().pointLightOuterRadius = 2f;
            }
        }

        if(Input.GetKeyUp(KeyCode.Q) && attacking == false)
        {
            if(powerupAttack <= 1f)
            {
                StartCoroutine(LaunchFire());
                Destroy(GameObject.Find("FireLight(Clone)"));
            } 
            if(powerupAttack > 1f && powerupAttack <= 4f)
            {
                StartCoroutine(LaunchMedFire());
                Destroy(GameObject.Find("FireLight(Clone)"));
                Destroy(GameObject.Find("FireLight2(Clone)"));
            }
            if(powerupAttack > 4f)
            {
                StartCoroutine(LaunchBigFire());
                Destroy(GameObject.Find("FireLight(Clone)"));
                Destroy(GameObject.Find("FireLight2(Clone)"));
                Destroy(GameObject.Find("FireLight3(Clone)"));
            }

            powerupAttack = 0f;
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /////////////////////////////////////////////////////////////// This section is E ability //////////////////////////////////////////////////////
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if(mousePos.x < this.transform.position.x + 10f && mousePos.x > this.transform.position.x - 10f)
        {
            SpawnXPos = mousePos.x;
        }
        if(mousePos.x > this.transform.position.x + 10f)
        {
            SpawnXPos = this.transform.position.x + 10f;
        }
        if(mousePos.x < this.transform.position.x - 10f)
        {
            SpawnXPos = this.transform.position.x - 10f;
        }

        if(Input.GetKeyDown(KeyCode.E) && attacking == false && GameObject.Find("FirePillar(Clone)") == null)
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionX;
            StartCoroutine(SpawnFirePillar());
        }
        
        mouse.transform.position = new Vector3(mousePos.x, mousePos.y, 0f);
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /////////////////////////////////////////////////////////////// This section is Right Click ability ////////////////////////////////////////////
        RCCooldown += Time.deltaTime;

        if(Input.GetMouseButtonDown(1) && attacking == false && RCCooldown >= 10f)
        {
            spawnExplosion = new Vector3(mousePos.x, mousePos.y, 0f);
            //rb.constraints = RigidbodyConstraints2D.FreezePositionX;
            StartCoroutine(SpawnFireExplosion());
            Instantiate(fireExplosionLight, spawnExplosion, Quaternion.identity);
        }

        if(lightExplosion == true && GameObject.Find("LeadupExplosionLight(Clone)") != null)
        {
            GameObject.Find("LeadupExplosionLight(Clone)").GetComponent<UnityEngine.Rendering.Universal.Light2D>().intensity += 0.05f;
            GameObject.Find("LeadupExplosionLight(Clone)").GetComponent<UnityEngine.Rendering.Universal.Light2D>().pointLightOuterRadius += 0.05f;
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    }

    void FixedUpdate()
    {
        ////////////////////////// E ability stuff //////////////////////////////////////////////////////////////////////
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


/////////////////////////////////////////////////////////////// This section is Q ability //////////////////////////////////////////////////////////////
    IEnumerator LaunchFire()
    {
        attacking = true;
        Anim.Play("LaunchFireball");
        yield return new WaitForSeconds(0.4f);
        Instantiate(smallFire, new Vector3(this.transform.position.x, this.transform.position.y, 0f), Quaternion.identity);
        attacking = false;
        rb.constraints = RigidbodyConstraints2D.None;
        Anim.Play("IdleAnim");
    }
    IEnumerator LaunchMedFire()
    {
        attacking = true;
        Anim.Play("LaunchFireball");
        yield return new WaitForSeconds(0.4f);
        Instantiate(medFire, new Vector3(this.transform.position.x, this.transform.position.y, 0f), Quaternion.identity);
        attacking = false;
        rb.constraints = RigidbodyConstraints2D.None;
        Anim.Play("IdleAnim");
    }
    IEnumerator LaunchBigFire()
    {
        attacking = true;
        Anim.Play("LaunchFireball");
        yield return new WaitForSeconds(0.4f);
        Instantiate(bigFire, new Vector3(this.transform.position.x, this.transform.position.y, 0f), Quaternion.identity);
        attacking = false;
        rb.constraints = RigidbodyConstraints2D.None;
        Anim.Play("IdleAnim");
    }
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

/////////////////////////////////////////////////////////////// This section is E ability ////////////////////////////////////////////////////////////////
    IEnumerator SpawnFirePillar()
    {
        attacking = true;
        Anim.Play("SpawnFirePillar");
        yield return new WaitForSeconds(0.45f);
        Instantiate(footLight, new Vector3(this.transform.position.x, this.transform.position.y - 1.1f, 0f), Quaternion.identity);
        yield return new WaitForSeconds(0.3f);
        Instantiate(flamePillar, new Vector3(SpawnXPos, SpawnYPos + 3.25328f, 0f), Quaternion.identity);
        attacking = false;
        rb.constraints = RigidbodyConstraints2D.None;
        Destroy(GameObject.Find("FootLight(Clone)"));
        Anim.Play("IdleAnim");
    }
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

/////////////////////////////////////////////////////////////// This section is Right Click ability //////////////////////////////////////////////////////
    IEnumerator SpawnFireExplosion()
    {
        attacking = true;
        lightExplosion = true;
        yield return new WaitForSeconds(0.5f);
        Instantiate(fireExplosion, spawnExplosion, Quaternion.identity);
        Destroy(GameObject.Find("LeadupExplosionLight(Clone)"));
        lightExplosion = false;
        fireExplosionLight.GetComponent<UnityEngine.Rendering.Universal.Light2D>().intensity = 1f;
        fireExplosionLight.GetComponent<UnityEngine.Rendering.Universal.Light2D>().pointLightOuterRadius = 0f;
        RCCooldown = 0f;
        attacking = false;
        //rb.constraints = RigidbodyConstraints2D.None;
    }
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
}
