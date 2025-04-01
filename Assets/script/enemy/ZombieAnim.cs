using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAnim : MonoBehaviour
{
    private Animator anim;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    public void AtackAnim(bool isAttack)
    {
        anim.SetBool("IsAttack", isAttack);
    }
    
    public void DeadAnim()
    {
        anim.SetTrigger("DeadZtrigger");

    }

    public void MoveAnim(bool isAttack,float horizontal)
    {
        if (!isAttack)
        anim.SetFloat("MoveZ",Mathf.Abs(horizontal));
    }
}
