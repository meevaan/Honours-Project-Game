using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parrallax : MonoBehaviour
{
    public float moveSpeed;
    public float offset;

    public float startPosX;
    public float newPosX;

    public float randMove;
    public float moveTime;

    // Start is called before the first frame update
    void Start()
    {
        startPosX = this.transform.position.x;

        randMove = Random.Range(2f, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale == 1f)
        {
            newPosX = Mathf.Repeat(Time.time * -moveSpeed, offset);

            this.transform.position = new Vector2(startPosX, this.transform.position.y) + Vector2.right * newPosX;

            moveTime += Time.deltaTime;

            if(moveTime < randMove)
            {
                this.transform.position += new Vector3(0f, 0.001f, 0f);
            }
            if(moveTime > randMove && moveTime < randMove*2f)
            {
                this.transform.position -= new Vector3(0f, 0.001f, 0f);
            }
            if(moveTime > randMove*2f)
            {
                moveTime = 0f;
            }
        }
    }
}
