using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform bullTR;
    public float damageBullet = 10;
    public float speed = 20;
    public float time = 3;
    private void Awake()
    {
        bullTR = GetComponent<Transform>();
    }
    private void Update()
    {
        bullTR.position += bullTR.right * speed * Time.deltaTime;
        time -= Time.deltaTime;
        if (time <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            ZombieHP zombieHP = collision.gameObject.GetComponent<ZombieHP>();
            zombieHP.TakeDamage(damageBullet);
        }
    }
}
