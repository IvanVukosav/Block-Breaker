using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    GameStatus gameStatus;
 
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
       if (currentSceneIndex + 1 == SceneManager.sceneCountInBuildSettings)
        {
            currentSceneIndex = 0;
            SceneManager.LoadScene(currentSceneIndex);
            gameStatus = FindObjectOfType<GameStatus>();//nadi mi taj objekt, bit ce jedan jednini
            gameStatus.ResetGame();
        }
        else
        {
            SceneManager.LoadScene(currentSceneIndex + 1);
           
        }
    }
  
   /* public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
       
    }*/
public void QuitGame()
    {
        Application.Quit();
    }
    //U instrukcijama je nova metoda povezana preko iste klase
      
       
     
     
}
