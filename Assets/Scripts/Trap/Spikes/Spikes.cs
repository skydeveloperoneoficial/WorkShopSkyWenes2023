using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
 
    public GameController gc;
    
   

     private void OnTriggerEnter2D(Collider2D other) {
         if( other.transform.gameObject.CompareTag("Player"))
         {
            gc.SwitchState(stateMachine.DEAD);
            
            other.GetComponent<CharacterMoviment>();
            //Debug.Log("Player Dead");//
         }
     }
}
