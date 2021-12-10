using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    Material mt;
    public float parallax;
    Vector2 offset;
    Transform cam;

    private void Start()
    {
        mt = GetComponent<SpriteRenderer>().material;
        cam = Camera.main.transform;
        offset = mt.mainTextureOffset;
    }

    private void Update()
    {

        offset.x = cam.position.x * parallax * 0.005f;
        offset.y = cam.position.y * parallax * 0.001f;

        //mt.mainTextureOffset = offset;
        mt.SetTextureOffset("_MainTex", offset);
    }

}
