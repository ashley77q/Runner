using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Gamemanager : MonoBehaviour

{
    public Text uitext;
    public GameObject GameOverContainer;
    public Animator animator;
    //assign  in inspector here
    [SerializeField] public ParticleSystem _slowparticleSystem;
   

    //Total game time
    public TextureScroller Ground;
    public float gameTime = 10;
    

    float totalTimeElapsed = 0;
    bool isGameOver = false;

    private void Start()
    {
        Time.timeScale = 1f;
    }

    public void RestartGame()
    {

        Debug.Log("RestartGame");
        if (isGameOver)
        {

            isGameOver = false;
            Time.timeScale = 1f;
            SceneManager.LoadScene("SmapleScene");


        }

    }

    void Update() { 
    //keeps track of time 
    
        if (isGameOver)
            return;
        totalTimeElapsed += Time.deltaTime;
        gameTime -= Time.deltaTime;

        if (gameTime <= 0)
            isGameOver = true;

    }

   

    public void AdjustTime(float amount)

    {
        {

            _slowparticleSystem.Stop();
            gameTime += amount;
            if (amount < 0)
                SlowWorldDown();

            if (amount < 0)
                _slowparticleSystem.Play();
        }
    }

    void SlowWorldDown()
      // SlowWorldDown and SlowWorldUP methods works as a conjunction with one another
    {

        //cancel any invokes to speed the world up
        //then slow the world down for one second

        CancelInvoke();
        Time.timeScale = 0.5f;
        Invoke("SpeedWorldUp", 1);

    }
    void SpeedWorldUp()
    {
        Time.timeScale = 1f;
    }
    //note this is using unity's legacy gui system
    void OnGUI()
    {
        if (!isGameOver)
        {


            //Draws the remaing time to the scene while the game is running and shows the total time the game lasted after it ends.
            uitext.text = "Time Remaining";
            uitext.text = "Total Time: " + (int)totalTimeElapsed;
         

            Rect labelRect = new Rect(Screen.width / 2 - 10, Screen.height - 80, 20, 40);
            GUI.Label(labelRect, ((int)gameTime).ToString());

        }
        else 
        {
            //shows the menu after losing a game
            //GameOverContainer.SetActive(true);

            animator.SetBool("pop",true);
            uitext.text = "Total Time: " + (int)totalTimeElapsed;
            Time.timeScale = 0f;
            }
        }
    }
