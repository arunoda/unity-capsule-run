using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public Text txtScore;
    public GameObject txtGameOver;
    public Transform player;
    public Transform plane;
    public GameObject obstacle;

    private Vector3 startPos;
    private Vector3 lastObstaclePos;

    void Start()
    {
        txtGameOver.SetActive(false);
        startPos = player.position;

        for (int lc=0; lc<10; lc++)
        {
            var o = SpawnObstacle(10 * lc + 10 + startPos.z);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Player is out of the plane
        if (plane.position.y > player.position.y)
        {
            txtGameOver.SetActive(true);
            return;
        }

        var distance = player.position.z - startPos.z;
        txtScore.text = distance.ToString("0");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Game");
    }

    private GameObject SpawnObstacle(float zPos)
    {
        var xChangeRange = (plane.localScale.x - obstacle.transform.localScale.x) / 2;
        var xPos = Random.Range(-xChangeRange, xChangeRange);
        var o = Instantiate(obstacle, new Vector3(xPos, 0.5f, zPos), Quaternion.identity);
        lastObstaclePos = o.transform.position;

        return o;
    }

    public void SpawnObstacle()
    {
        SpawnObstacle(lastObstaclePos.z + 10);
    }
}
