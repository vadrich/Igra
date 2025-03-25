using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgMove : MonoBehaviour
{
    Renderer render;
    public Transform charTR;
    private Transform bgTR;
    public float speedRotate = 0.1f;
    public float move = 40;
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
        bgTR.position = Vector2.Lerp(bgTR.position, charTR.position,Time.deltaTime * move);
        bgTR.position = new Vector3(bgTR.position.x, bgTR.position.y, 0);
        if (direction.sqrMagnitude > 0.2f)
        {
            render.material.mainTextureOffset += new Vector2(direction.x * speedRotate * Time.deltaTime, 0);
        }
    }
}
