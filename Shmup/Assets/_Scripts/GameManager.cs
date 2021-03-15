using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
   private static GameManager _instance;
   public enum GameState { MENU, GAME, PAUSE, ENDGAME };

   public GameState gameState { get; private set; }
   public int lifes;
   public int pontos;
   public int acerto_nave;

   public delegate void ChangeStateDelegate();
   public static ChangeStateDelegate changeStateDelegate;

   public string EnemyName;

   PlayerController pc;
   EnemyController ec;

   public static GameManager GetInstance()
   {
       if(_instance == null)
       {
           _instance = new GameManager();
       }

       return _instance;
   }
   private GameManager()
   {
       lifes = 10;
       pontos = 0;
       acerto_nave=0;
       EnemyName=" ";
       gameState = GameState.MENU;

   }
   public void ChangeState(GameState nextState)
{
   if (nextState == GameState.GAME) Reset();
   gameState = nextState;
   changeStateDelegate();
}

private void Reset()
{
   lifes = 10;
   pontos = 0;
//    if(gameState == )
//    pc.restart();
//    ec.restart();

}   

}
