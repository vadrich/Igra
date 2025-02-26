using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CharAnim : MonoBehaviour
{
    private Animator _animator;
    private MoveChare personController;
    private void Awake()
    {
        _animator =GetComponent<Animator>();
        personController = GetComponent<MoveChare>();
    }
    private void OnEnable()
    {
        personController.onMovePerson += MoveAnim;
        personController.onJumpingPerson += JumpAnim;
        personController.onSliderPerson += SliderAnim;
    }
    private void OnDisable()
    {
        personController.onMovePerson -= MoveAnim;
        personController.onJumpingPerson -= JumpAnim;
        personController.onSliderPerson -= SliderAnim;
    }
    private void MoveAnim(float horizontal)
    {
        _animator.SetFloat("speedmove", Mathf.Abs(horizontal));
    }
    private void JumpAnim(bool isJumping)
    {
        _animator.SetBool("isJump", isJumping);
    }
    private void SliderAnim(bool isSlide)
    {
        _animator.SetBool("isSlide", isSlide);
    }
}
//параметры,аргументы и возврощаемые типы данных