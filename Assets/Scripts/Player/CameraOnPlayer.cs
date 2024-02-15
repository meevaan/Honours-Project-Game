using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOnPlayer : MonoBehaviour
{
    public GameObject ply;

    // Start is called before the first frame update
    void Start()
    {
        ply = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(ply.transform.position.x, ply.transform.position.y + 3.03f, -10f);
    }
}
