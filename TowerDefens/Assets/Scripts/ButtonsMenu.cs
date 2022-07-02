using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsMenu : MonoBehaviour
{
    [SerializeField] int Level;

  public void OnButtonClickLevelChange()
    {
        SceneManager.LoadScene(Level);
    }
   

  
}

