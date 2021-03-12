using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolantBehaviour : SteerableBehaviour, IShooter, IDamageable
{
   float angle = 0;

   public GameObject tiro;

   private void FixedUpdate()
   {
       angle += 0.1f;
       if (angle > 2.0f * Mathf.PI) angle = 0.0f;
       Thrust(0, Mathf.Cos(angle));
   }
   public void Shoot()
    {
       Instantiate(tiro, transform.position, Quaternion.identity);
       print("atira");
    }

    public void TakeDamage()
    {
        Die();
    }

    public void Die()
    {
        Destroy(gameObject);
    }

}
