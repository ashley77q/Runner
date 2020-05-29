using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemanager : MonoBehaviour

{
    //Total game time
    public TextureScroller Ground;
    public float gameTime = 10;

    float totalTimeElapsed = 0;
    bool isGameOver = false;

    void Update()
    //keeps track of time 
    {
        if (isGameOver)
            return;
        totalTimeElapsed += Time.deltaTime;
        gameTime -= Time.deltaTime;

        if (gameTime <= 0)
            isGameOver = true;
    }

    public void AdjustTime(float amount)
    {

        gameTime += amount;
        if (amount < 0)
            SlowWorldDown();
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
            Rect boxRect = new Rect(Screen.width / 2 - 50, Screen.height - 100, 100, 50);
            GUI.Box(boxRect, "Time Remaining");

            Rect labelRect = new Rect(Screen.width / 2 - 10, Screen.height - 80, 20, 40);
            GUI.Label(labelRect, ((int)gameTime).ToString());

        }
        else
        {
            Rect boxRect = new Rect(Screen.width / 2 - 60, Screen.height / 2 - 100, 120, 50);
            GUI.Box(boxRect, "Game Over");
           
            Rect labelRect = new Rect(Screen.width / 2 - 55, Screen.height / 2 - 80, 90, 40);
            GUI.Label(labelRect, "Total Time: " + (int)totalTimeElapsed);

            Time.timeScale = 0;
            }
        }
    }