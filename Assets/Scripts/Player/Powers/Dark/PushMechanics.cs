using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushMechanics : MonoBehaviour
{
    public UnityEngine.Rendering.Universal.Light2D buffLight;
    public float timeTilDeath;

    //public DamageBuff DB;

    // Start is called before the first frame update
    void Start()
    {
        this.transform.localScale = new Vector3(0f, 0f, 0f);
        buffLight = this.GetComponent<UnityEngine.Rendering.Universal.Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
        buffLight.pointLightInnerRadius += 0.1f;
        buffLight.pointLightOuterRadius += 0.1f;

        this.transform.localScale = new Vector3((buffLight.pointLightOuterRadius*2)/8, (buffLight.pointLightOuterRadius*2)/8, 0f);

        buffLight.color = new Color(this.GetComponent<SpriteRenderer>().color.r, this.GetComponent<SpriteRenderer>().color.g, 
        this.GetComponent<SpriteRenderer>().color.b, this.GetComponent<SpriteRenderer>().color.a);

        timeTilDeath += Time.deltaTime;

        if(timeTilDeath > 1.5f)
        {
            buffLight.pointLightInnerAngle -= 5f;

            if(timeTilDeath > 1.625f)
            {
                buffLight.pointLightOuterAngle -= 5f;

                if(buffLight.pointLightOuterAngle <= 0f)
                {
                    Destroy(this.gameObject);
                }
            }
        }
    }
}
