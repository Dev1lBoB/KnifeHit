using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    [SerializeField]
    private PlayerDataControl   playerDataControl;
    [SerializeField]
    private LevelManager        levelManager;

    public void BackToMenu()
    {
        // Reloads scene to come back to the main menu
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void Restart()
    {
        // Resets everything to the original values and restart game from the first lvl
        levelManager.RestartGame();
        playerDataControl.Restart();
    }
}
