using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyController : SteerableBehaviour, IShooter, IDamageable
{

    GameManager gm;
    Vector3 startPos;

    private void Start()
    {
       gm = GameManager.GetInstance();
       startPos = this.transform.position;
    }

    public void Shoot()
    {
        throw new System.NotImplementedException();
    }

    public void TakeDamage()
    {
        gm.pontos+=50;
        gm.acerto_nave= 1;
        gm.EnemyName = gameObject.name;
        // print(gm.pontos);
        Die();
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    // float angle = 0;

    // private void FixedUpdate()
    // {
    //     angle += 0.1f;
    //     Mathf.Clamp(angle, 0.0f, 2.0f * Mathf.PI);
    //     float x = Mathf.Sin(angle);
    //     float y = Mathf.Cos(angle);

    //     Thrust(x, y);
    //     if (gm.gameState != GameManager.GameState.GAME) return;
       
    // }


    public void restart(){
        Instantiate(gameObject, startPos, Quaternion.identity, transform);
        
    }
}
