using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ RequireComponent(typeof(Rigidbody2D))]
public class MoveObject : MonoBehaviour
{
    private Rigidbody2D RbCapsule;
    public Transform TrCapsule;
    private float deltaX;
    private float deltaY;
    public float speed = 3;
    public float sancitivity = 45;

    // Start is called before the first frame update
    private void Awake()
    {
        RbCapsule = GetComponent<Rigidbody2D>();
        //TrCapsule = GetComponent <Transform>();
    }

    

    // Update is called once per frame
    private void Update()
    {
        MouseDelta();
        Moving();
    }
    
    private void MouseDelta()
    {
        deltaX += sancitivity * Time.deltaTime * Input.GetAxis("Mouse X");
        deltaY -= sancitivity * Time.deltaTime * Input.GetAxis("Mouse Y");
        Quaternion rotate = Quaternion.Euler(deltaY, deltaX, 0);
        TrCapsule.rotation = Quaternion.Slerp(TrCapsule.rotation, rotate, Time.deltaTime * 5);
    }

    private void Moving()
    {
        float x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float y = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        TrCapsule.position += new Vector3(x, y , 0);
        //RbCapsule.velocity = new Vector2(x,y);
    }
}
