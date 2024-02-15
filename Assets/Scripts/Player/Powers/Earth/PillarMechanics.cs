using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarMechanics : MonoBehaviour
{
    public float deathTimer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        deathTimer += Time.deltaTime;

        if(deathTimer > 5f)
        {
            Destroy(this.gameObject);
        }
    }
}
