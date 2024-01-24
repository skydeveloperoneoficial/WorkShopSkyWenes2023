using UnityEngine;
public class Scene2End : MonoBehaviour
{
    [SerializeField] private string sceneName;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.gameObject.CompareTag("Player"))
        {
            ControllerScene.SetScene(sceneName);
        }
    }


}
