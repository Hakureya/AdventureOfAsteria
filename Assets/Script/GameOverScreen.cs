using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class kalah : MonoBehaviour
{
        public void RestartButton(){
        SceneManager.LoadScene("Game");
    }

        public void ExitButton(){
       SceneManager.LoadScene("Main Menu");
    }
}
