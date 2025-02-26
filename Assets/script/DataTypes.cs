using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataTypes : MonoBehaviour
{
    public Transform squarTrans;
    public Transform triangleTrans;
    public Transform circleTrans;
    public Rigidbody2D rbSquare;
    public SpriteRenderer spriteTriangle;
    public GameObject circuleObg;
    public float force = 5;


    private void Awake()
    {
        
    }
    private void OnEnable()
    {
    }
    private void OnDisable()
    {
    }
    private void OnDestroy()
    {
    }
    private void Start()
    {
    }
    private void Update()
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        force = Random.Range(2, 6);
        float z = Random.Range(-45, 45);
        squarTrans.rotation = Quaternion.Euler(0, 0, z);
        float r = Random.value;
        float g = Random.value;
        float b = Random.value;
        spriteTriangle.color = new Color(r, g, b);
        squarTrans.localScale = new Vector3(7, 7, 0);

    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        rbSquare.AddForce(Vector3.up * force,ForceMode2D.Impulse);
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        float x = Random.Range(7, 14);
        float y = Random.Range(7, 14);
        squarTrans.localScale = new Vector3(x, y, 0);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        rbSquare.drag = 10f;
        rbSquare.angularDrag = 10f;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        spriteTriangle.color = Color.red;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        spriteTriangle.color = Color.green;
    }

    private void OnMouseEnter()
    {
        Debug.Log("mouse enter");
    }

    private void OnMouseExit()
    {
        Debug.Log("mouse exit");
    }

    private void OnMouseDown()
    {
        Debug.Log("mouse down");
    }

    private void OnMouseUp()
    {
        Debug.Log("mouse up");
    }














    private void JumpRing()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 moveup = Vector3.ProjectOnPlane(squarTrans.up, Vector3.forward);
            rbSquare.velocity += new Vector2(0, moveup.y * force);
        }
    }

    private void RigbodyTest()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            rbSquare.AddForce(Vector2.up * force, ForceMode2D.Impulse);
            rbSquare.AddTorque(force, ForceMode2D.Impulse);
        }
    }

    private void TransformTest()
    {
        squarTrans.position = new Vector2(3, 5);
        triangleTrans.rotation = Quaternion.Euler(0, 0, 45);
        circleTrans.localScale = new Vector2(4, 6);
    }

    

    private void TransformTest2()
    {
        squarTrans.position = new Vector2(0, 0);
        triangleTrans.Rotate(Vector3.forward * Time.deltaTime * 45);
        circleTrans.localScale = new Vector2(10, 10);
    }
}
