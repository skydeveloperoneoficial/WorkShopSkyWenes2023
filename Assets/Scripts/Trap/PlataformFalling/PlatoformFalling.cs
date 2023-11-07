using UnityEngine;

public class PlatoformFalling : MonoBehaviour
{
     [SerializeField] private BoxCollider2D boxCollider;
     [SerializeField] private TargetJoint2D  joint;
     [SerializeField]private  float fallingTime;


    public float FallingTime { get => fallingTime; set => fallingTime = value; }

    private  void Falling()
    {
        boxCollider.enabled= false;
        joint.enabled = false;
        Destroy(gameObject,fallingTime);
    }
   private void OnCollisionEnter2D(Collision2D other) 
   {
         if(other.transform.CompareTag("Player"))
         {
            Invoke("Falling",fallingTime);
         }
   }
}
