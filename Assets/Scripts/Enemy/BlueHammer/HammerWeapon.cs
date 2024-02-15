using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerWeapon : MonoBehaviour
{
    public bool hammerAttackMode;
    public bool hammerDefenseMode;
    public float hitsTaken;
    public bool attackInProgress;

    public UnityEngine.Rendering.Universal.Light2D L2D;

    // Start is called before the first frame update
    void Start()
    {
        hammerDefenseMode = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(hammerDefenseMode == true)
        {
            this.GetComponent<EnemyDamage>().enabled = false;
            this.transform.localPosition = new Vector3(0.165f,0.097f,0);

            if(hitsTaken < 3)
            {
                L2D.enabled = true;
            }
            if(hitsTaken >= 3)
            {
                L2D.enabled = false;
                this.GetComponent<Collider2D>().enabled = false;
            }
        }
        if(hammerAttackMode == true)
        {
            L2D.enabled = false;
            if(attackInProgress == false)
            {
                StartCoroutine(HammerAttack());
                attackInProgress = true;
            }
        }
    }

    IEnumerator HammerAttack()
    {
        this.GetComponent<EnemyDamage>().enabled = true;
        this.GetComponent<Collider2D>().enabled = false;
        this.transform.localPosition = new Vector3(0.165f, 0.587f, 0f);
        attackInProgress = false;
        yield return new WaitForSeconds(2.05f);
        this.GetComponent<Collider2D>().enabled = true;
        this.transform.localPosition = new Vector3(0.165f, 0.097f, 0f);
        yield return new WaitForSeconds(1.85f);
        attackInProgress = false;
        hammerAttackMode = false;
        hammerDefenseMode = true;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "PlayerWeapon")
        {
            hitsTaken += 1;
            Destroy(collision.gameObject);
        }
    }
}
