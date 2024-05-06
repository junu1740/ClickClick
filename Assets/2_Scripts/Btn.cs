using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class OverBtn : MonoBehaviour
{
    public AudioSource audioSource;

    public void nose()
    {
        audioSource.Play();
    }


    public void Menu()
    {
        SceneManager.LoadScene(0);
    }



    public void Restart()
    {
       
        SceneManager.LoadScene(1);
        BestScore.Score = 0;
    }
    public void start()
    {
        SceneManager.LoadScene(1);
    }

    public void exit()
    {
        Application.Quit();
    }


    private void OnCollisionExit(Collision collision)
    {
        
    }

   

    
}
