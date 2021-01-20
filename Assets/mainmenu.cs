using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenu : MonoBehaviour
{
    public void PlayGame(){
        SceneManager.LoadScene("Jetro the goblin");
    }

    public void QuitGame(){
        Application.Quit();
        print("The game has closed");
    }
}