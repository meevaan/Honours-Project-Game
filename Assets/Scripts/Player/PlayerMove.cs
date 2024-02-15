using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D Player;

    public float spriteRotation;
    public float jumpRotation;

    public bool Jumping;
    public bool Falling;

    public float DashCooldown;

    // Start is called before the first frame update
    void Start()
    {
        Player = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale == 1f)
        {
            this.transform.eulerAngles = new Vector3(0f, spriteRotation, 0f);

            if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
            {
                Player.AddForce(transform.right * 1500f, ForceMode2D.Force);
            }

            if(Input.GetKey(KeyCode.D))
            {
                spriteRotation = 0f;
            }
            if(Input.GetKey(KeyCode.A))
            {
                spriteRotation = 180f;
            }

            if(Input.GetKeyDown(KeyCode.Space) && Jumping == false)
            {
                Player.AddForce(transform.up * 1000f, ForceMode2D.Impulse);
            }
            if(Jumping == true)
            {
                Player.AddForce(-transform.up * 50f, ForceMode2D.Impulse);
            }

            if(Jumping == true && Input.GetKeyDown(KeyCode.LeftShift) && DashCooldown <= 0f)
            {
                Player.AddForce(transform.right * 1500f, ForceMode2D.Impulse);
                DashCooldown = 100f;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            Jumping = false;
            DashCooldown = 0f;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            Jumping = true;
        }
    }
}
