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

    private Vector3 startPos;

    void Start()
    {
        txtGameOver.SetActive(false);
        startPos = player.position;  
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
}
