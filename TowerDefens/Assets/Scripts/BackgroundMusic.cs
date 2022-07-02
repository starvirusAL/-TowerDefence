using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundMusic : MonoBehaviour
{
   
    private void Awake() {
        DontDestroyOnLoad(this.gameObject);
       


    }

    private void Update()
    {
        var i = SceneManager.GetActiveScene().buildIndex;
       
        if (Input.GetKeyDown(KeyCode.Escape) && i != 0 && i != 1)
        {
            SceneManager.LoadScene(1);
        }
    }      
                
}