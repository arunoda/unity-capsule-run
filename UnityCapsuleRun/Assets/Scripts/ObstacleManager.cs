using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    private Transform player;
    private GameManager gameManager;

    void Start()
    {
        player = FindObjectOfType<PlayerMovements>().gameObject.transform;
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        var zDiff =  player.position.z - transform.position.z;
        if (zDiff > 5)
        {
            gameManager.SpawnObstacle();
            Destroy(gameObject);
        }
    }
}
