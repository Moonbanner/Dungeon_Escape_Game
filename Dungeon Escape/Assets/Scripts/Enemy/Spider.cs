using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy, IDamageable
{
    public GameObject acidEffectPrefab;
    public int Health { get; set; }

    // use for initialization
    public override void Init()
    {
        base.Init();
        Health = base.health;
    }
    public override void Update()
    {
       
    }
    public void Damage()
    {
        Health--;
        if (Health < 1) 
        {
            isDeath = true;
            anim.SetTrigger("Death");
        }
    }
    public override void Movement()
    {
       // sit still 
    }

    public void Attack()
    {
        Instantiate(acidEffectPrefab, transform.position, Quaternion.identity);
    }

}
