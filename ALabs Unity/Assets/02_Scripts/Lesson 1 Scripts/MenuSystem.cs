using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuSystem : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Menu Panel")]
    [SerializeField] private Button exitMenu;
    [SerializeField] private Button MainMenu;
    [SerializeField] private Button Continue;
    [SerializeField] private GameObject menu;

    [Header("Level Finished Panel")]
    [SerializeField] private Button endbutton;
    [SerializeField] private GameObject LevelFinished;
    [SerializeField] private Button PlayAgain;
    


    private bool isGamePaused = false;

    #region Menu Panel Functions
    public void OpenMenu()
    {
        isGamePaused = true;
        menu.SetActive(true);
        PauseGame();
    }
    public void ExitMenu()
    {
        isGamePaused = false;
        menu.SetActive(false);
        UnpauseGame();
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("Dashboard");
    }

    public void ContinueFunc()
    {
        isGamePaused = false;
        menu.SetActive(false);
        UnpauseGame();
    }
    #endregion

    #region Level Finished Panel Functions
    public void OpenLevelFinished()
    {
        isGamePaused = true;
        LevelFinished.SetActive(true);
        PauseGameWithAudio();
    }

    public void PlayAgainFunc()
    {
        // Add logic here to reset the game to its original state
        ResetGame();

        // Close the LevelFinished panel
        LevelFinished.SetActive(false);

        // Unpause the game
        UnpauseGame();
    }

    private void ResetGame()
    {
        // Add logic here to reset the game to its original state
        // This could include resetting player positions, scores, etc.

        // For example, you might reload the current scene:
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    #endregion

    private void TogglePauseGame()
    {
        isGamePaused = !isGamePaused;

        // Pause or unpause the game based on the current state
        if (isGamePaused)
        {
            PauseGame();
        }
        else
        {
            UnpauseGame();
        }
    }

    private void PauseGame()
    {
        // Pause the game by setting time scale to 0
        Time.timeScale = 0f;
        AudioListener.pause = true;

        // Add any additional pause-related functionality here (e.g., show menu)
    }
    private void PauseGameWithAudio()
    {
        // Pause the game by setting time scale to 0
        Time.timeScale = 0f;

        // Add any additional pause-related functionality here (e.g., show menu)
    }

    private void UnpauseGame()
    {
        // Unpause the game by setting time scale back to 1
        Time.timeScale = 1f;
        AudioListener.pause = false;

        // Add any additional unpause-related functionality here (e.g., hide menu)
    }
}
