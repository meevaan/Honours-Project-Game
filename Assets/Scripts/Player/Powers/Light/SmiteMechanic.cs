using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmiteMechanic : MonoBehaviour
{
    public UnityEngine.Rendering.Universal.Light2D holyLight;
    public GameObject smite;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.childCount >= 2)
        {
            if(holyLight.transform.localScale.x < 1f/8)
            {
                holyLight.transform.localScale += new Vector3(Time.deltaTime/8, 0f, 0f);
            }
            if(holyLight.transform.localScale.x >= 1f/8)
            {
                smite.GetComponent<Rigidbody2D>().AddForce(transform.up * -2f, ForceMode2D.Impulse);
            }
        }

        if(this.transform.childCount < 2)
        {
            holyLight.transform.localScale -= new Vector3(Time.deltaTime/8, 0f, 0f);

            if(holyLight.transform.localScale.x <= 0f)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
