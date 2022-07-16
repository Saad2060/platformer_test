using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [SerializeField] Text distanceTravelled;
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] Player player;
    [SerializeField] Text coinsCollected;
    [SerializeField] GameObject gameMusic;
    [SerializeField] GameObject sky;
    


    public void ShowGameOverScreen()
    {
        gameOverScreen.SetActive(true);
        gameMusic.SetActive(false);
        sky.SetActive(false);
        float roundedDistance = Mathf.Ceil(player.distanceTravelled);
        distanceTravelled.text = roundedDistance.ToString();
        
        coinsCollected.text = player.collectedCoins.ToString();
         
    }


    public void GameRestart()
    {
        SceneManager.LoadScene("EndlessRunner_Scene1");
    }
}
