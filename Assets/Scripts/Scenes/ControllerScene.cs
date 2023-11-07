using UnityEngine;
using UnityEngine.SceneManagement;
public class ControllerScene:MonoBehaviour

{
    public static bool ActiveEndWindows;
    private void Start()
    {
        ActiveEndWindows = this;
    }
    public static void SetScene(string nameScene)
    {
        SceneManager.LoadScene(nameScene);
    }
    public static void SetSceneAsync(string nameScene)
    {
        SceneManager.LoadSceneAsync(nameScene);
    }
    public static void EndWindows()
    {
        if(ActiveEndWindows)
        Application.Quit();
    }
}
