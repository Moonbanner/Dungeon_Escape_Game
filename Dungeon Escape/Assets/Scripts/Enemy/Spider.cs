﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy, IDamageable
{
    public int Health { get; set; }

    // use for initialization
    public override void Init()
    {
        base.Init();
    }
    public void Damage()
    {
      
    }
    public override void Movement()
    {
       // sit still 
    }

}
