using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;



public class Menus : MonoBehaviour
{

    public void StartGame(){

       UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex +1);
    }

    public void HowToPlay(){
        UnityEngine.SceneManagement.SceneManager.LoadScene("HowToPlayScene");
    }

    public void Back(){
        UnityEngine.SceneManagement.SceneManager.LoadScene("StartScreen");

    }

    public void Quit(){
       Application.Quit();
    }
  
}
