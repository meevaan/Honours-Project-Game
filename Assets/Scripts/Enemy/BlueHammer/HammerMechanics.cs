using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerMechanics : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rb;
    public BoxCollider2D col;

    public GameObject hitGround;
    public GameObject leftShockWave;
    public GameObject rightShockWave;
    public bool nothingSpawned;
    public bool attackComplete;

    public HammerWeapon HW;

    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(anim.GetBool("Attack") == true && attackComplete == false)
        {
            HW.hammerAttackMode = true;
            HW.hammerDefenseMode = false;
            StartCoroutine(SwingHammer());
        }
    }

    IEnumerator SwingHammer()
    {
        attackComplete = true;
        this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        yield return new WaitForSeconds(1.75f); //add more delay for suspense?
        anim.Play("BlueHammerAttack");
        yield return new WaitForSeconds(0.333f);
        if(nothingSpawned == false)
        {
            Instantiate(hitGround, this.transform);
            Instantiate(leftShockWave, this.transform);
            Instantiate(rightShockWave, this.transform);
            nothingSpawned = true;
        }
        yield return new WaitForSeconds(2f);
        nothingSpawned = false;
        this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        anim.Play("BlueHammerWalk");
        attackComplete = false;
    }
}
