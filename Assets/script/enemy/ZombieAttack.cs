using UnityEngine;

public class ZombieAttack : MonoBehaviour
{
    public float damage = 5;
    public float minDistAtack = 3;
    public float waitTime = 0;
    public float intervalTime = 0.5f;
    public bool isAttack;
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
            anim.AtackAnim(true);
            isAttack = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            anim.AtackAnim(false);
            isAttack = false;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            CharacterHP hp = collision.gameObject.GetComponent<CharacterHP>();
            WaitTime(hp);
        }
    }

    private void WaitTime(CharacterHP hp)
    {
        if (waitTime <= Time.time)
        {
            waitTime = Time.time + intervalTime;
            hp.TakeDamage(damage);
            Debug.Log("takeDamage");
        }
    }
}
