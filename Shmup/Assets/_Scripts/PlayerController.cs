using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : SteerableBehaviour, IShooter, IDamageable
{
  
    Animator animator;
    public GameObject bullet;
    public Transform arma01;
    private int _lifes;
    public float shootDelay = 0.5f;
    private float _lastShootTimestamp = 0.0f;

    Vector3 startPos;

    public AudioClip shootSFX;

    GameManager gm;
    
    
    private void Start()
    {
       animator = GetComponent<Animator>();
    
      gm = GameManager.GetInstance();

      startPos = this.transform.position;
       
    }

    public void Shoot()
    {
        if (Time.time - _lastShootTimestamp < shootDelay) return;
        AudioManager.PlaySFX(shootSFX);
        _lastShootTimestamp = Time.time;
        Instantiate(bullet, arma01.position, Quaternion.identity);
    }

    public void TakeDamage()
    {
       gm.lifes--;
       if (gm.lifes <= 0) Die();
      //  print(gm.lifes);
       
    }

    public void Die()
    {
        // Destroy(gameObject);
        if(gm.gameState == GameManager.GameState.GAME)
       {
          gm.ChangeState(GameManager.GameState.ENDGAME);
       }
    }

    void FixedUpdate()
    {
        float yInput = Input.GetAxis("Vertical");
        float xInput = Input.GetAxis("Horizontal");
        Thrust(xInput, yInput);
        if (yInput != 0 || xInput != 0)
        { 
           animator.SetFloat("velocity", 1.0f);
        }
        else
        {
           animator.SetFloat("velocity", 0.0f);
        }

        if(Input.GetAxisRaw("Jump") != 0)
        {
           Shoot();
        }
        if(Input.GetKeyDown(KeyCode.Escape) && gm.gameState == GameManager.GameState.GAME) {
           gm.ChangeState(GameManager.GameState.PAUSE);
        }
        if(gm.gameState == GameManager.GameState.MENU) {

           this.transform.position = startPos; 
            
        }

        if (gm.gameState != GameManager.GameState.GAME) return;
          
    }    
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Inimigos"))
        {
            // gm.acerto_nave = 100;
            Destroy(collision.gameObject);
            TakeDamage();
            
        }
    }

   public void restart(){

      this.transform.position = startPos; 
      print("restartttttt");
   }  
}
