using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgMove : MonoBehaviour
{
    Renderer render;
    public Transform charTR;
    private Transform bgTR;
    public float speed = 0.1f;
    void Start()
    {
        render = GetComponent<Renderer>();
        bgTR = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        Vector3 direction = new Vector3(x, 0, 0);
        bgTR.position = Vector2.Lerp(bgTR.position, charTR.position,Time.deltaTime);
        bgTR.position = new Vector3(bgTR.position.x, bgTR.position.y, 0);
        if (direction.sqrMagnitude > 0.2f)
        {
            render.material.mainTextureOffset += new Vector2(direction.x * speed * Time.deltaTime, 0);
        }
    }
}
