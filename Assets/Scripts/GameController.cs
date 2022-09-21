using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private TextMeshProUGUI text;

    private bool started = false;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        player = GameObject.Find("Player");

        text.text = "Press Space to Start";
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetButtonDown("Jump") && !started)
        {
            started = true;
            player.GetComponent<PlayerController>().StartGame();
            text.enabled = false;
        }
    }
}
