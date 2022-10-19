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

    private bool levelFinished = true;

    private GameObject player;

    private bool started = false;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    private void Update()
    {
        if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name != "SampleScene") {
            checkForLevel();
        }
        startLevel();

    }

    private void showSpashScreen() 
    {
        if(!text) 
        {
            text = GameObject.FindGameObjectWithTag("SplashText").GetComponent<TextMeshProUGUI>();
        }

        if(!started) 
        {
            text.text = "Press Space to Start";
        }
    }

    private void checkForLevel() 
    {
        switch(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name) {
            case "LevelMenu":
                if(levelFinished) {
                    loadNextScene("Level01");
                }
                break;
            case "Level01":
                if(levelFinished) {
                    loadNextScene("LevelMenu");
                }
                break;
            default: 
                loadNextScene("LevelMenu");
                break;
        }

    }

    private void loadNextScene(string sceneName)
    {
        if(levelFinished && Input.GetButtonDown("Jump")) {
            levelFinished = false;
            started = false;
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
            showSpashScreen();
        }
    }

    private void startLevel() 
    {
        if (Input.GetButtonDown("Jump") && !started && UnityEngine.SceneManagement.SceneManager.GetActiveScene().name != "LevelMenu")
        {
            spawnPoint = GameObject.FindGameObjectWithTag("Respawn");

            started = true;
            player = Instantiate(playerPrefab, spawnPoint.transform.position, Quaternion.identity);
            player.GetComponent<PlayerController>().StartGame(spawnPoint);

            if(text) {
                text.text = "P";
                text = null;
            }
        }
    }
}
