using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene:MonoBehaviour
{
    /// <summary>
    /// MEthod for the init of the introduction
    /// </summary>
    public void StartIntroduction()
    {
        SceneManager.LoadScene(1);
    }

    /// <summary>
    /// MEthod for the init of the game
    /// </summary>
    public void StartGame()
    {
        SceneManager.LoadScene(2);
    }
}
