using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedMasterMechanics : MonoBehaviour
{
    public StartBuffs SB;
    Animator thisAnim;

    public bool uzumaki;

    public GameObject buffZone;
    public GameObject punch;
    public float punchTimer;

    // Start is called before the first frame update
    void Start()
    {
        thisAnim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(SB.buffYes == true && uzumaki == false)
        {
            StartCoroutine(BuffMove());
            uzumaki = true;
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
    }

    IEnumerator BuffMove()
    {
        this.transform.GetChild(0).gameObject.SetActive(false);
        thisAnim.Play("RedMasterUzumaki");
        this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        yield return new WaitForSeconds(2f);
        Instantiate(buffZone, this.transform);
        this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        thisAnim.Play("RedMasterWalk");
    }
}
