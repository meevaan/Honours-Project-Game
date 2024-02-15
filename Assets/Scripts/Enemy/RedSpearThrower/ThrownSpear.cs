using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrownSpear : MonoBehaviour
{
    Rigidbody2D thisRB;
    GameObject parentObj;

    // Start is called before the first frame update
    void Start()
    {
        parentObj = this.transform.parent.gameObject;
        this.transform.localEulerAngles += new Vector3(0f, parentObj.transform.eulerAngles.y, 0f);
        thisRB = this.GetComponent<Rigidbody2D>();
        thisRB.AddForce(transform.right * (Random.Range(15f, 40f)), ForceMode2D.Impulse);  //* (this.transform.localEulerAngles.y/180f)
        thisRB.AddForce(transform.up * Random.Range(-1f, 2f), ForceMode2D.Impulse);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(RemoveThis());
    }

    IEnumerator RemoveThis()
    {
        yield return new WaitForSeconds(0.05f);
        Destroy(this.gameObject);
    }
}
