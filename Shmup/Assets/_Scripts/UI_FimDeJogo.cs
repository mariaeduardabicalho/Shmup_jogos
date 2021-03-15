using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UI_FimDeJogo : MonoBehaviour
{
   public Text message;

    GameManager gm;
    PlayerController pc;
    EnemyController ec;

   private void OnEnable()
   {
       gm = GameManager.GetInstance();

       if(gm.lifes > 0)
       {
           message.text = "Você Ganhou!!!";
       }
       else
       {
           message.text = "Você Perdeu!!";
       }
   }
   public void Voltar()
   {
        // pc.restart();
        // ec.restart();
        gm.ChangeState(GameManager.GameState.GAME);
        

   }
}
