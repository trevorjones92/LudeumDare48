using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    Material material;
    Vector2 offset;

    public int xVelocity, yvelocity;
    public float speed = 0.5f;
    // Start is called before the first frame update

    private void Awake()
    {
        material = GetComponent<Renderer>().material;
        this.GetComponent<MeshRenderer>().material.color = new Color(.5f, .5f, .5f, 0.1f);
    }
    void Start()
    {
        //offset = new Vector2(xVelocity, yvelocity);
    }

    // Update is called once per frame
    void Update()
    {
        offset = new Vector2(xVelocity, yvelocity);
        material.mainTextureOffset += offset * Time.deltaTime;
    }
}
