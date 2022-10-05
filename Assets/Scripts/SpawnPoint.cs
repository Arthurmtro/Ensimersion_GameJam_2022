using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        player = GameObject.Find("Player");    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
