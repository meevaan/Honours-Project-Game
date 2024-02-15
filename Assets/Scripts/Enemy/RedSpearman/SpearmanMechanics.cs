using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearmanMechanics : MonoBehaviour
{
    Animator enemyAnimator;
    Rigidbody2D thisRB;

    public Vector3 chargePos;

    // Start is called before the first frame update
    void Start()
    {
        enemyAnimator = this.GetComponent<Animator>();
        thisRB = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyAnimator.GetBool("Attack") == true)
        {
            StartCoroutine(ChargeAttack());
        }   
    }
    

    IEnumerator ChargeAttack()
    {
        yield return new WaitForSeconds(0.3336f);
        this.transform.GetChild(0).GetComponent<Collider2D>().enabled = true;
        thisRB.AddForce(transform.right * 75f, ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.75f);
        thisRB.velocity = new Vector3(0f, 0f, 0f);
        this.transform.GetChild(0).GetComponent<Collider2D>().enabled = false;
        enemyAnimator.SetBool("Attack", false);
        enemyAnimator.SetBool("Idle", true);
    }
}
