using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttack : MonoBehaviour
{
    public float damage = 10;
    public float minDistAtack = 3;
    public bool isAttack = false;
    private ZombieAnim anim;
    private ZombieMove move;


    void Awake()
    {
        move = GetComponent<ZombieMove>();
        anim = GetComponent<ZombieAnim>();
    }




    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            CharacterHP hp = collision.gameObject.GetComponent<CharacterHP>();
            StartCoroutine(AttackCoroutine(hp));
            anim.AtackAnim(true);
            isAttack = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            CharacterHP hp = collision.gameObject.GetComponent<CharacterHP>();
            StopCoroutine(AttackCoroutine(hp));
            anim.AtackAnim(false);
            isAttack = false;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isAttack = true;
        }
        else
        {
            isAttack =false;
        }
    }

    private IEnumerator AttackCoroutine(CharacterHP hp)
    {
        while (isAttack)
        {
            yield return new WaitForSeconds(0.5f);
            hp.TakeDamage(damage);
        }
    }

}
