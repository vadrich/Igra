using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MoveChare : MonoBehaviour
{

    public event Action<float> onMovePerson;
    public event Action<bool> onJumpingPerson;
    public event Action<bool> onSliderPerson;

    private Rigidbody2D rigidbodyPerson;
    private Transform transformPerson;

    public float speed = 5f;
    public float slideSpeed = 10f;
    public float jumpForce = 6f;
    private float horizontal = 0f;
    private float timer = 0.5f;

    public bool isSlider = false;
    public bool isTerra = false;

    void Start()
    {
        rigidbodyPerson = GetComponent<Rigidbody2D>();
        transformPerson = GetComponent<Transform>();
    }

    void Update()
    {
        Slider();
        Moving();
        if (isTerra)
        {
            Jumping();
            SliderToggle();
            
        }
        ScaleDirection();
    }
    private void SliderToggle()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            timer = 0.5f;
            isSlider = true;
        }
    }
    private void Slider()
    {
        timer -= Time.deltaTime;
        isSlider = timer <= 0 ? false : true;
        onSliderPerson.Invoke(isSlider);
        if (isSlider)
        {
            float slideDirection = Mathf.Sign(transformPerson.localScale.x); // Get direction based on facing side
            Vector3 target = transformPerson.position + new Vector3(2 * slideDirection, 0, 0);
            transformPerson.position = Vector3.MoveTowards(transformPerson.position, target, slideSpeed * Time.deltaTime);
        }
    }
    private void Jumping()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidbodyPerson.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            onJumpingPerson?.Invoke(true);
        }
        else
        {
            onJumpingPerson?.Invoke(false);
        }
    }
    private void Moving()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        rigidbodyPerson.velocity = new Vector2(horizontal * speed, rigidbodyPerson.velocity.y);
        onMovePerson?.Invoke(horizontal);
    }
    private void ScaleDirection()
    {
        if (horizontal < 0f)
        {
            transform.localScale = new Vector3(-1, 1, 0);
        }
        else if (horizontal > 0f)
        {
            transform.localScale = new Vector3(1, 1, 0);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isTerra = true;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        isTerra = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        isTerra = false;
    }
}
