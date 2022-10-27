using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    //handle to animator
    private Animator _anim;
    private Animator _swordAnimation;

    // Start is called before the first frame update
    void Start()
    {
        //assign handle to animator
        _anim = GetComponentInChildren < Animator>();
        _swordAnimation = transform.GetChild(1).GetComponent<Animator>();
    }

    // Update is called once per frame
    public void Move(float move)
    {
        _anim.SetFloat("Move", Mathf.Abs(move));
    }

    public void Jump(bool jumping)
    {
        _anim.SetBool("midAir", jumping);
    }
    

    public void Swing()
    {
        _anim.SetTrigger("Attack");   
    }
    public void SwordArc()
    {
        _swordAnimation.SetTrigger("SwordAnimation");
    }
    public void Death()
    {
        _anim.SetTrigger("Death");
    }

    public void Hit()
    {
        _anim.SetTrigger("Hit");
    }
}
