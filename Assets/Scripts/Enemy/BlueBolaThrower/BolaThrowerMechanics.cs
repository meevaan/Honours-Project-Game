using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaThrowerMechanics : MonoBehaviour
{
    Animator thisAnim;
    public GameObject bola;

    public bool playerFrozen;

    // Start is called before the first frame update
    void Start()
    {
        thisAnim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && playerFrozen == false)
        {
            StartCoroutine(ThrowBola());
        }
    }

    IEnumerator ThrowBola()
    {
        this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        thisAnim.Play("BlueBolaAttack");
        yield return new WaitForSeconds(1f);
        Instantiate(bola, this.transform.position, Quaternion.identity, this.transform);
        yield return new WaitForSeconds(7f);
        this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        thisAnim.Play("BlueBolaWalk");
    }
}
