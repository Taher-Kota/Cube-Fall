using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroll : MonoBehaviour
{
    MeshRenderer meshRenderer;
    [SerializeField]
    float scrollSpeed;
    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        Scroll();
    }

    void Scroll()
    {
        Vector2 offset = meshRenderer.material.GetTextureOffset("_MainTex");
        offset.y += scrollSpeed * Time.deltaTime;
        meshRenderer.material.SetTextureOffset("_MainTex", offset);
    }
}
