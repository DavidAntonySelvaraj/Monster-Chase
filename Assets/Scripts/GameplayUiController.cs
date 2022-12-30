using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayUiController : MonoBehaviour
{
    



    public void RestartGame()
    {
        //SceneManager.LoadScene("Gameplay");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }



    public void Home()
    {
        SceneManager.LoadScene("Mainmenu");
    }

   
}//class






















