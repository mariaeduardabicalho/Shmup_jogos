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

    private int lifes;


    public AudioClip shootSFX;

    
    

    private void Start()
    {
       animator = GetComponent<Animator>();
       lifes=10;
       
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
       lifes--;
       if (lifes <= 0) Die();
       print(lifes);
    }

    public void Die()
    {
        Destroy(gameObject);
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
    }    
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Inimigos"))
        {
            Destroy(collision.gameObject);
            print("colidiu");
            TakeDamage();
        }
    }


    
}
