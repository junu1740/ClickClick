using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OverBtn : MonoBehaviour
{

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    public void exit()
    {
        Application.Quit();
    }


    private void OnCollisionExit(Collision collision)
    {
        
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
