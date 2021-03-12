﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotBehaviour : SteerableBehaviour
{
    
    

    // Update is called once per frame
    void Update()
    {
        Thrust(1, 0);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.CompareTag("Player")) return;

       IDamageable damageable = collision.gameObject.GetComponent(typeof(IDamageable)) as IDamageable;
       if (!(damageable is null))
       {
           damageable.TakeDamage();
       }
       print(gameObject);
       Destroy(gameObject);
       
    }

    
}


