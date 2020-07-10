using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{


    public void RestartGameButton()
    {


        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);


    }


}