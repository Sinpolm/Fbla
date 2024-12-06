using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
 public void PlayGame()
 {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);

 } 

 public void QuitGame()
 {
    Debug.Log("Quit Game!!!");
    Application.Quit();
 }

}
