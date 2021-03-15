using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolantBehaviour : SteerableBehaviour, IShooter, IDamageable
{
   float angle = 0;

   public GameObject tiro;

   GameManager gm;

   private void Start()
    {
       gm = GameManager.GetInstance();
    }

   private void FixedUpdate()
   {
       angle += 0.1f;
       if (angle > 2.0f * Mathf.PI) angle = 0.0f;
       Thrust(0, Mathf.Cos(angle));

       if (gm.gameState != GameManager.GameState.GAME) return;
   }
   public void Shoot()
    {
       Instantiate(tiro, transform.position, Quaternion.identity);
    //    print("atira");
    }

    public void TakeDamage()
    {
        Die();
        gm.pontos+=100;
        // print(gm.pontos);
        gm.acerto_nave= 1;
        gm.EnemyName = gameObject.name;
        
    }

    public void Die()
    {
        Destroy(gameObject);
    }

}
