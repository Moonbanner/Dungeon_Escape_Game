using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy, IDamageable
{
    public int Health { get; set; }

    //use for initialization
    public override void Init()
    {
        base.Init();
        Health = base.health; 
    }
    public void Damage()
    {
        Debug.Log("Hit!");
        Health--;
        if (Health < 1)
        {
            Destroy(this.gameObject);
        }

    }

}
