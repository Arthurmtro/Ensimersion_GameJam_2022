using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject spawnPoint;

    private GameObject player;

    private bool started = false;

    private void Awake()
    {
        DontDestroyOnLoad(this);

<<<<<<< HEAD
        text.text = "Press Space to Start";
=======
        if(text) {
            text.text = "Press Space to Start";
        }
>>>>>>> c3d387d3877e78c4fd0536eb35b5c9b5b05e2cd7

        spawnPoint = GameObject.FindGameObjectWithTag("Respawn");
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetButtonDown("Jump") && !started)
        {
            started = true;
            player = Instantiate(playerPrefab, spawnPoint.transform.position, Quaternion.identity);
            player.GetComponent<PlayerController>().StartGame(spawnPoint);
<<<<<<< HEAD
=======


        if(text) {
        }
>>>>>>> c3d387d3877e78c4fd0536eb35b5c9b5b05e2cd7
            text.enabled = false;
        }
    }
}
