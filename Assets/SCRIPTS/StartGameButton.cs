using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameButton : MonoBehaviour
{
    public void StartGame()
    {
        // Load the game scene when the "Start Game" button is clicked.
        SceneManager.LoadScene("Game");
    }
}