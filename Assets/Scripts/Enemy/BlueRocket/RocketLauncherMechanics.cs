using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncherMechanics : MonoBehaviour
{
    public GameObject rocket;
    public float launchTimer;
    public bool launchOrNot;
    Animator thisAnim;

    // Start is called before the first frame update
    void Start()
    {
        thisAnim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(launchOrNot == false)
        {
            launchTimer += Time.deltaTime;

            if(launchTimer >= 4f)
            {
                StartCoroutine(LaunchRocket());
                launchOrNot = true;
                launchTimer = 0f;
            }
        }
    }

    IEnumerator LaunchRocket()
    {
        this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        thisAnim.Play("BlueRocketLaunch");
        Instantiate(rocket, new Vector3(this.transform.position.x - 0.3f, this.transform.position.y + 3.8f, this.transform.position.z), Quaternion.identity);
        yield return new WaitForSeconds(3f);
        this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        thisAnim.Play("BlueRocketWalk");
        launchOrNot = false;
    }
}
