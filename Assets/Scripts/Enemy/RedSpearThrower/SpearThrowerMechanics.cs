using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearThrowerMechanics : MonoBehaviour
{
    public bool throwSpear;
    public GameObject throwingSpear;

    Animator enemyAnimator;

    public float spawnTime;

    // Start is called before the first frame update
    void Start()
    {
        enemyAnimator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        spawnTime += Time.deltaTime;

        if(spawnTime >= 0.5f && throwSpear == false)
        {
            Instantiate(throwingSpear, new Vector3(this.transform.position.x, this.transform.position.y + 0.78f, this.transform.position.z), Quaternion.identity, this.transform);
            throwSpear = true;
        }
        if(spawnTime >= 2f)
        {
            spawnTime = 0f;
            throwSpear = false;
        }

        /*for(int i = 1; i < this.transform.childCount; i++)
        {
            Destroy(this.transform.GetChild(i).gameObject);
        }*/

        if(enemyAnimator.GetBool("Walking") == true)
        {
            throwSpear = false;
            spawnTime = 0f;
        }
    }
}
