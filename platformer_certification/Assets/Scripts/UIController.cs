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
    

    //This is to test showing up the game over screen wheh we hit the t key
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            ShowGameOverScreen();
        }
    }



    public void ShowGameOverScreen()
    {
        gameOverScreen.SetActive(true);

        float roundedDistance = Mathf.Ceil(player.distanceTravelled);
        distanceTravelled.text = roundedDistance.ToString();
        
        coinsCollected.text = player.collectedCoins.ToString();
         
    }


    public void GameRestart()
    {
        SceneManager.LoadScene("EndlessRunner_Scene1");
    }
}
