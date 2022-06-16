using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moss_Giant : Enemy, IDamageable
{
    public int Health { get; set; }
  
    // use for initialization
    public override void Init()
    {
        base.Init();
        Health = base.health;
    }
    public override void Movement()
    {
        base.Movement();              
    }
    public void Damage()
    {
        if (Health < 1) return;
        //Debug.Log("MossGiant::Damage()");
        Health--;
        anim.SetTrigger("Hit");
        isHit = true;
        anim.SetBool("InCombat", true);

        if (Health < 1)
        {
            isDeath = true;
            anim.SetTrigger("Death");
        }
    }

    public void Spike()
    {
        throw new System.NotImplementedException();
    }
}
