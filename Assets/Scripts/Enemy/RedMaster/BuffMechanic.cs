using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffMechanic : MonoBehaviour
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

        timeTilDeath += Time.deltaTime;

        if(timeTilDeath > 3f)
        {
            buffLight.pointLightInnerAngle -= 5f;

            if(timeTilDeath > 3.25f)
            {
                buffLight.pointLightOuterAngle -= 5f;

                if(buffLight.pointLightOuterAngle <= 0f)
                {
                    Destroy(this.gameObject);
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")   //|| collision.gameObject.tag == "EnemyProjectile"
        {
            if(collision.gameObject.GetComponent<DamageBuff>() == null)
            {
                collision.gameObject.AddComponent<DamageBuff>();
            }
        }
    }
}
