using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPoolScript : MonoBehaviour
{
    public GameObject enemyPrefab;

    //Determine the size of enemies army: columns * rows
    private int numberOfColumns = 8;
    [Tooltip("How many rows of enemies will appear")]
    public int numberOfRows;
    [Tooltip("How many rows of shooting enemies will appear. Setting to '1' means there will be 8 shooting enemies")]
    public int rowsOfArchers;   //Determine at how many rows from the top will shooting enemies be spawned
    private int archersLeftToSpawn = 0;

    private Vector2 spawnStartPosition = new Vector2(-3, 5.5f);
    private Vector2 spawnPosition = Vector2.zero;

    void Start()
    {
        GameController.Instance.totalEnemies = numberOfColumns * numberOfRows;  //Total amount of enemies to create
        
        
        spawnPosition = spawnStartPosition;
        archersLeftToSpawn = rowsOfArchers * numberOfColumns;

        //for loop for creating enemies 
        for (int i = 0; i < numberOfRows; i++)
        {
			for (int j = 0; j < numberOfColumns; j++)
			{
                CreateAnEnemy();
			}
            spawnPosition = new Vector2(spawnStartPosition.x, spawnPosition.y - 0.75f);
        }
    }

    //Creating an enemy object and determining its tag.
    private void CreateAnEnemy()
    {
        GameObject go = (GameObject)Instantiate(enemyPrefab, spawnPosition, Quaternion.identity, transform);
        SpriteRenderer sr = go.GetComponent<SpriteRenderer>();
        if (archersLeftToSpawn > 0){
            sr.color = Color.yellow;
            go.transform.tag = "ShootingEnemy";
            archersLeftToSpawn--;
        }else{
            go.transform.tag = "RammingEnemy";
            sr.color = Color.cyan;
        }
        spawnPosition.x += 0.75f;
    }
}
