using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMove : MonoBehaviour
{
    private ZombieAnim anim;
    private ZombieAttack attack;

    public Transform trChar;
    private Transform trZ;
    private Rigidbody2D rbZ;
    public float speed = 5;
    private float moveInput;
    private float distance;
    public float jumpForce = 4;
    public float minDistFollow = 12;
    public float timer = 4;
    private bool isFollow = false;
    private bool isJumping = false;
    private bool isOldPoint = false;

    
    private Vector3 currentPoint;

    void Awake()
    {
        trZ = GetComponent<Transform>();
        rbZ = GetComponent<Rigidbody2D>();
        anim = GetComponent<ZombieAnim>();
        attack = GetComponent<ZombieAttack>();
    }
    private void Start()
    {
        StartCoroutine(JumpingCoroutine());
    }

    void FixedUpdate()
    {
        Turning();
        Chekdistance();
        if (IsMinDistance(minDistFollow))
        {
            Follow();
            isFollow = true;
        }
        else
        {
            isFollow = false;
        }

        RandomMove();
    }

    private void Update()
    {
        if (isJumping && isOldPoint)
        {
            JumpZ();
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isJumping = true;
    }

    IEnumerator JumpingCoroutine()
    {
        while (true)
        {
            currentPoint = trZ.position;
            yield return new WaitForSeconds(0.2f);
            if (currentPoint == trZ.position)
                isOldPoint = true;
            else isOldPoint = false;
        }
    }

    void Turning()
    {
        transform.localScale = new Vector3(Mathf.Sign(moveInput), 1, 1);
    }

    void JumpZ()
    {
        rbZ.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        isJumping = false;
    }



    void Follow()
    {
        Vector2 direction = trChar.position - trZ.position;
        moveInput = direction.x > 0 ? 1 : -1;
        if (isFollow)
            Move();
    }

    void Move()
    {
        float x = moveInput * speed;
        float y = rbZ.velocity.y;
        rbZ.velocity = new Vector2(x, y);
        anim.MoveAnim(attack.isAttack,x);
    }

    void Chekdistance()
    {
        distance = Vector2.Distance(trZ.position,trChar.position);
    }

    void RandomMove()
    {
        timer -= Time.deltaTime;
        if (timer <= 0 && !isFollow)
        {
            moveInput = Mathf.Sign(Random.Range(-1, 1));
            timer = Random.Range(3, 7);
        }
        Move();
    }

    public bool IsMinDistance(float minDistance)
    {
        if (distance <= minDistance) return true;
        else return false;
    }
}
