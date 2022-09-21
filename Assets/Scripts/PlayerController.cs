using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private float cameraSpeed = 10f;

    private PlayerMouvement playerMouvement;

    private void Start()
    {
        cam = Camera.main;
        playerMouvement = GetComponent<PlayerMouvement>();
    }

    private void FixedUpdate()
    {
        SmoothCamera();
    }

    private void SmoothCamera()
    {
        float interpolation = playerMouvement.moveSpeed - 4 * Time.deltaTime;
        
        Vector3 position = cam.transform.position;
        position.y = Mathf.Lerp(cam.transform.position.y, this.transform.position.y, interpolation);
        position.x = Mathf.Lerp(cam.transform.position.x, this.transform.position.x, interpolation);
        
        cam.transform.position = position;
    }

    public void StartGame()
    {
        GetComponent<PlayerMouvement>().enabled = true;
    }
}
