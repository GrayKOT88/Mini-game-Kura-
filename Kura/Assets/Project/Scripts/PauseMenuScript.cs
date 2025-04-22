using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

public class PauseMenuScript : MonoBehaviour
{
    public bool PauseGame;
    public GameObject pauseGameMenu;
    public GameObject rateGameButton;

   
    public void RateGameButton()
    {
        YandexGame.ReviewShow(true);
    }
    public void Resume()
    {
        pauseGameMenu.SetActive(false);
        Time.timeScale = 1;
        PauseGame = false;
    }
    public void Pause()
    {
        pauseGameMenu.SetActive(true);
        Time.timeScale = 0;
        PauseGame = true;
    }
    public void LosdMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    public void Restart() 
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
        Progress.PlayerData.eatenChick = 0;
        Progress.PlayerData.saveChick = 0;
        Progress.SaveData();
    }
}
