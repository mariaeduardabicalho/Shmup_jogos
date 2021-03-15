using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_pontosganhos : MonoBehaviour
{

    Text textComp;
    GameManager gm;
    int pontos_ganhos;

    public Text message;
    
    private float timeToAppear = 0.2f;
    private float timeWhenDisappear;
    // Vector3 PosInimigo;

    // public void Enable

    // Start is called before the first frame update
    void Start()
    {
        textComp = GetComponent<Text>();
        
        gm = GameManager.GetInstance();
        // Vector3 PosInimigo = GameObject.Find(gm.EnemyName).transform.position;
        // Instantiate(gameObject, PosInimigo, Quaternion.identity);
        message.text = "+  100";

        message.enabled = false;

        
        
    }

    // Update is called once per frame
    void Update()
    {
        
            
        
            if(gm.acerto_nave > 0){

                // Vector3 PosInimigo = GameObject.Find(gm.EnemyName).transform.position;
                

                message.enabled = true;
                
               
                timeWhenDisappear = Time.time + timeToAppear;

                // message.transform.position = PosInimigo;

                gm.acerto_nave= 0;

            }
                
            if(Time.time >= timeWhenDisappear){
                    message.enabled = false;

            }
                
            
        
    }
}
