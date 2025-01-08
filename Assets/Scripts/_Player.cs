using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Player : MonoBehaviour
{
    Rigidbody2D myBody;
    float moveSpeed = 2f;
    bool CanMovePlatform,LeftMove;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        Time.timeScale = 1f;
    }

    void Update()
    {
        platformMove();
        Move();
    }

    void Move()
    {
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            myBody.velocity = new Vector2(moveSpeed,myBody.velocity.y);
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            myBody.velocity = new Vector2(-moveSpeed,myBody.velocity.y);
        }
    }

    void platformMove()
    {
        if(!CanMovePlatform) return;

        if (LeftMove)
        {
            myBody.velocity = new Vector2(-1.5f, myBody.velocity.y);
        }
        else
        {
            myBody.velocity = new Vector2(1.5f, myBody.velocity.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Standard"))
        {
            SoundManage.instance.LandSound();
        }
        if (collision.transform.CompareTag("Spiked"))
        {
            Time.timeScale = 0f;
        }
        if (collision.transform.CompareTag("Speed_Left"))
        {
            platformMove();
            LeftMove = true;
            CanMovePlatform = true;
        }
        if (collision.transform.CompareTag("Speed_Right"))
        {
            platformMove();
            LeftMove = false;
            CanMovePlatform = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Speed_Left"))
        {
            CanMovePlatform = false;
        }
        if (collision.transform.CompareTag("Speed_Right"))
        {
            CanMovePlatform = false;
        }
    }
}
