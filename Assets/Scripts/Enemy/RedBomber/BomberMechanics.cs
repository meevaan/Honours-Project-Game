using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BomberMechanics : MonoBehaviour
{
    Animator enemyAnimator;
    Rigidbody2D thisRB;
    BasicEnemyMove BEM;
    Collider2D thisCol;

    public float copiedSpeed;
    public float copiedRot;
    public float newYpos;

    public bool thrownBomb;
    public bool runAway;

    public GameObject bomb;

    public float deathTimer;

    // Start is called before the first frame update
    void Start()
    {
        enemyAnimator = this.GetComponent<Animator>();
        thisRB = this.GetComponent<Rigidbody2D>();
        BEM = this.GetComponent<BasicEnemyMove>();
        thisCol = this.GetComponent<Collider2D>();

        newYpos = this.transform.position.y - 0.624f;
    }

    // Update is called once per frame
    void Update()
    {
        /*if(enemyAnimator.GetBool("Attack") == true)
        {
            thrownBomb = true;
            copiedRot = this.transform.eulerAngles.y - 180f;
        }

        if(thrownBomb == true)
        {
            StartCoroutine(ThrowAndRun());
            Instantiate(bomb, new Vector3(this.transform.position.x, this.transform.position.y + 1.634f, this.transform.position.z), Quaternion.identity);
        }*/

        if(runAway == true)
        {
            this.transform.eulerAngles = new Vector3(0f, copiedRot, 0f);

            deathTimer += Time.deltaTime;

            if(copiedRot < 180f)
            {
                thisRB.AddForce(transform.right * 750f, ForceMode2D.Force);
            }
            if(copiedRot >= 180f)
            {
                thisRB.AddForce(transform.right * -750f, ForceMode2D.Force);
            }

            if(deathTimer >= 4f)
            {
                Destroy(this.gameObject);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && runAway == false)
        {
            StartCoroutine(ThrowAndRun());
            copiedRot = this.transform.eulerAngles.y - 180f;
            Instantiate(bomb, new Vector3(this.transform.position.x, this.transform.position.y + 1.634f, this.transform.position.z), Quaternion.identity);
        }
    }

    IEnumerator ThrowAndRun()
    {
        thrownBomb = false;
        BEM.enabled = false;
        enemyAnimator.SetBool("Attack", false);
        enemyAnimator.Play("BomberThrow");
        thisCol.offset = new Vector2(0f, 0f);
        this.transform.position = new Vector3(this.transform.position.x, newYpos, this.transform.position.z);
        thisRB.constraints = RigidbodyConstraints2D.FreezePosition;
        yield return new WaitForSeconds(0.333f);
        enemyAnimator.Play("BomberNoBombRunn");
        thisRB.constraints = RigidbodyConstraints2D.None;
        thisRB.constraints = RigidbodyConstraints2D.FreezeRotation;
        runAway = true;
    }
}
