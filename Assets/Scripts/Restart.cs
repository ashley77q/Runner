using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{


    public void RestartTheGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("SampleScene");



    }

}