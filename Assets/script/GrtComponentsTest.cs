using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class GrtComponentsTest : MonoBehaviour
{
    public Rigidbody2D playerRb;
    private SpriteRenderer spriteChill;
    private SpriteRenderer spriteParent;
    private TargetComponent target;
    private Camera cam;

    private void Awake()
    {
     //   spriteChill = GetComponentInChildren<SpriteRenderer>();
        spriteChill = transform.GetChild(0).GetComponent<SpriteRenderer>();
     //   spriteParent = GetComponentInParent <SpriteRenderer>();
        playerRb = GetComponent<Rigidbody2D>();
        target = FindObjectOfType<TargetComponent>();
        cam = target.GetComponent<Camera>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRb.AddForce(Vector2.up * 3, ForceMode2D.Impulse);
            spriteChill.color = Color.red;
           
            cam.backgroundColor = Color.white;
           

        }
        else if (Input.GetMouseButtonDown(0))
        {
            playerRb.AddForce(Vector2.up * 3, ForceMode2D.Impulse);
            spriteChill.color = Color.blue;
            cam.backgroundColor = Color.grey;
        }
    }
}
