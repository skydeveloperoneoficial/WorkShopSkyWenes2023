using UnityEngine;

public class Apple : MonoBehaviour
{
 private void OnTriggerEnter2D(Collider2D other)
 {
     if( other.transform.gameObject.CompareTag("Player"))
     {
         Destroy(gameObject);
         other.GetComponent<Character>().IncleaseScore();
     }
 }
}
