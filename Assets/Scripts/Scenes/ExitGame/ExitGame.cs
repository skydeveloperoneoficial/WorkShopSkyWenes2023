using UnityEngine;

public class ExitGame : MonoBehaviour
{
 public void ExitGameScene()
 {
    ControllerScene.ActiveEndWindows= true;
    ControllerScene.EndWindows();
 }
}
