using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    Material material;
    Vector2 offset;
    public int xVelocity, yvelocity;
    public float speed = 0.5f;

    private void Start()
    {
        material = GetComponent<Renderer>().material;
        GetComponent<MeshRenderer>().material.color = new Color(.5f, .5f, .5f, 0.1f);
    }

    void Update()
    {
        offset = new Vector2(xVelocity, yvelocity);
        material.mainTextureOffset += offset * Time.deltaTime;
    }
}
