using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMechanics : MonoBehaviour
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

        if(deathTimer >= 60f)
        {
            Destroy(this.gameObject);
        }
    }
}
