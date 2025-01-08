using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPlatform : MonoBehaviour
{
    float movespeed = 1f;
    private void Update()
    {
        Vector2 temp = transform.position;
        temp.y += movespeed * Time.deltaTime;
        transform.position = temp;

        if(transform.position.y > 8f)
        {
            gameObject.SetActive(false);
        }
    }
}
