using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBeamMechanics : MonoBehaviour
{
    public GameObject beamHolder;

    public float damage;

    GameObject player;

    public float dmgTimer;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        beamHolder.transform.position = player.transform.position;
        var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(beamHolder.transform.position);
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        beamHolder.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            dmgTimer += Time.deltaTime;

            if(dmgTimer > 0.25f)
            {
                collision.gameObject.GetComponent<EnemyHealth>().enemyHealth -= damage;
                dmgTimer = 0f;
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            dmgTimer = 0f;
        }
    }
}
