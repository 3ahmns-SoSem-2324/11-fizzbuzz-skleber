using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager: MonoBehaviour
{
    public void ExitFunction()
    {
        Application.Quit();
    }

    public void LoadTutorialScene()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }

    
}