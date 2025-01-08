using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivatePlatform : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    Animator anim;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if(gameObject.CompareTag("Breakable")) anim = GetComponent<Animator>();
    }

    private void Update()
    {
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(Camera.main);
        if (transform.position.y > -4f)
        {
            if (!GeometryUtility.TestPlanesAABB(planes, spriteRenderer.bounds))
            {
                gameObject.SetActive(false);
            }
        }
    }

    public void DeactivateBreakable()
    {
        Invoke("Deactivate", 1f);
    }

    void Deactivate()
    {
        SoundManage.instance.IceBreakSound();
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject.CompareTag("Breakable"))
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                anim.SetTrigger("Break");
            }
        }
    }
}
