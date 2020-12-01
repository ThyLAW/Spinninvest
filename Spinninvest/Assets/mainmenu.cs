using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class mainmenu : MonoBehaviour
{
    public int startBuildIndex = 1;
    public int gameOverBuildIndex = -1;
    public int GameOverBuldIndexMenu = -2;
    public int GameOverBuldIndexMenuBankruptcy = -3;

    //loads next scene (main game)
    public void PlayGame()
   {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + startBuildIndex);
   }
    //exits game
   public void QuitGame()
   {
       Debug.Log("Quit");
       Application.Quit();
   }
    //reloads game scene
   public void RestartGame()
   {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + gameOverBuildIndex);

   }
    //goes back to menu from game over scene
   public void GoBackToMenu()
   {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + GameOverBuldIndexMenu);

    }
    //goes back to menu from bnakruptcy scene
   public void GoBackToMenuBankruptcy()
   {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + GameOverBuldIndexMenuBankruptcy);
        
    }
}
