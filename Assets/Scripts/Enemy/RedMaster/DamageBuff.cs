using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBuff : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        /*if(this.GetComponent<EnemyDamage>() != null)
        {
            this.GetComponent<EnemyDamage>().enemyDamage = this.GetComponent<EnemyDamage>().ogDamage * 1.5f;
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        /*for(int i = 0; i < this.transform.childCount; i++)
        {
            if(this.transform.GetChild(i).GetComponent<EnemyDamage>() == null && 
            (this.transform.GetChild(i).gameObject.tag == "EnemyProjectile" || this.transform.GetChild(i).gameObject.tag == "EnemyWeapon"))
            {
                this.transform.GetChild(i).gameObject.AddComponent<EnemyDamage>();
            }
        }*/
    }
}
