using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //When it gets to 2, enemies are going down by one unit and touchCounter resets
    private int wallTouchCounter = 0;

    private float startingMoveDelay = 0.75f;
    private float actualMoveDelay = 0.75f;

    //Amount of units by which the enemy moves
    private float moveSpeed = 0.25f;

    //EnemyController Transform component to be able to use his children
    private Transform controller;   
    
    void Start()
    {
        actualMoveDelay = startingMoveDelay;
        controller = GetComponent<Transform>();

        GameController.Instance.enemiesLeft = controller.childCount;

        //Repeating function every startingMoveDelay value
        InvokeRepeating("MoveEnemy",startingMoveDelay, startingMoveDelay);
    }

	private void Update()
	{
        if (controller.childCount < 1)
            GameController.Instance.EndTheGame(true);

	}

	//Moves the enemies
	void MoveEnemy()
    {
        controller.position += Vector3.right * moveSpeed;

        if (wallTouchCounter > 1)   //Moving down
        {
            controller.position += Vector3.up * -0.25f;
            wallTouchCounter = 0;
        }

        foreach (Transform child in controller)
        {
            if (child.position.x < -3 || child.position.x > 3)  //One of enemies came farthest to the side
            {
                wallTouchCounter++;
                moveSpeed *= -1;
                return;
            }

            if (child.position.y < -4.5)  //One of enemies get behind the player. That means game over
            {
                GameController.Instance.EndTheGame(false);
            }

            if(controller.childCount < 4)  //Increasing level of difficulty to maximum
			{
                CancelInvoke();
                InvokeRepeating("MoveEnemy", 0.1f, 0.1f);
			}
        }

        //This is for increasing movement speed of all enemies based on variable gameDifficulty from GameController script
        if (actualMoveDelay > startingMoveDelay * 0.3f && controller.childCount != GameController.Instance.enemiesLeft)
        {
            actualMoveDelay = GameController.Instance.gameDifficulty;
            Debug.Log(actualMoveDelay);
            CancelInvoke();
            InvokeRepeating("MoveEnemy", actualMoveDelay, actualMoveDelay);
        }
        //Assign actual enemies left to enemiesLeft variable at GameController script.
        GameController.Instance.enemiesLeft = controller.childCount;
    }
}
