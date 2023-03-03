using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;


public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject asteroid;// префаб астероида 
    GameObject ufo;//префаб инопланетной тарелки
    GameObject[] pointsToSpawn; // все возможные точки для спауна
    GameObject[] pointsToMove; // все возможные точки к которым может двигаться астероид
    private void Start() 
    {
        pointsToSpawn = GameObject.FindGameObjectsWithTag("PointToSpawn");    
        pointsToMove = GameObject.FindGameObjectsWithTag("PointToMove");
    }
    private void FixedUpdate() 
    {
        int chance = new System.Random().Next(1,50);
        if (chance == 1)
        {
            SpawnAsteoid();
        }    
    }
    public void SpawnAsteoid()
    {
        GameObject newAsteroid = Instantiate(asteroid,FindRandomPointToSpawn(),Quaternion.identity); // создаем астероид
        newAsteroid.GetComponent<BigAsteroid>().vectorToMove = FindRandomPointToFly() - newAsteroid.transform.position; // объясяем астероиду куда лететь
    }
    Vector3 FindRandomPointToSpawn() // точка в которой заспаунится астероид 
    {
        System.Random random = new System.Random();
        int numbOfPointToSpawn = random.Next(0,pointsToSpawn.Length); 
        return pointsToSpawn[numbOfPointToSpawn].transform.position;
    }
    Vector3 FindRandomPointToFly() // точка в которую полетит астероид 
    {
        System.Random random = new System.Random();
        int numbOfPointToSpawn = random.Next(0,pointsToSpawn.Length); 
        return pointsToSpawn[numbOfPointToSpawn].transform.position;
    }
}
