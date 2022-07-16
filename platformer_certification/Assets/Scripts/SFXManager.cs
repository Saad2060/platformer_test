using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip coinSFX;
    [SerializeField] AudioClip jumpSFX;
    [SerializeField] AudioClip landSFX;
    [SerializeField] AudioClip doubleJumpSFX;
    [SerializeField] AudioClip gameOverSFX;
    [SerializeField] AudioClip doubleJumpPowerUp;
    [SerializeField] AudioClip shieldPowerUp;
    [SerializeField] AudioClip shieldBreak;

    public void PlaySFX(string clipToPlay)
    {
        switch (clipToPlay)
        {
            case "Coin":
                audioSource.clip = coinSFX;
                break;
            case "Jump":
                audioSource.clip = jumpSFX;
                break;
            case "Land":
                audioSource.clip = landSFX;
                break;
            case "DoubleJump":
                audioSource.clip = doubleJumpSFX;
                break;
            case "GameOverHit":
                audioSource.clip = gameOverSFX;
                break;
            case "PowerupDoubleJump":
                audioSource.clip = doubleJumpPowerUp;
                break;
            case "PowerupShield":
                audioSource.clip = shieldPowerUp;
                break;
            case "ShieldBreak":
                audioSource.clip = shieldBreak;
                break;
        }
        
        //if (clipToPlay == "Coin")
        //{
        //    audioSource.clip = coinSFX;
        //}
        //if (clipToPlay == "Jump"){
        //    audioSource.clip = jumpSFX;
        //}
        //if (clipToPlay == "Land")
        //{
        //    audioSource.clip = landSFX;
        //}
        //if (clipToPlay == "DoubleJump")
        //{
        //    audioSource.clip = doubleJumpSFX;
        //}
        //if (clipToPlay == "GameOverHit")
        //{
        //    audioSource.clip = gameOverSFX;
        //}
        //if (clipToPlay == "PowerupDoubleJump")
        //{
        //    audioSource.clip = doubleJumpPowerUp;
        //}
        //if (clipToPlay == "PowerupShield")
        //{
        //    audioSource.clip = shieldPowerUp;
        //}
        //if (clipToPlay == "ShieldBreak")
        //{
        //    audioSource.clip = shieldBreak;
        //}



        audioSource.Play();
    }
}
