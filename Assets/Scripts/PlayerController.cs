using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private float cameraSpeed = 10f;
    [SerializeField] private GameObject particleSystemPrefab;

    private PlayerMouvement playerMouvement;
    private GameObject spawnPoint;

    private bool isDead;

    private void Start()
    {
        cam = Camera.main;
        playerMouvement = GetComponent<PlayerMouvement>();
        GetComponent<ParticleSystem>().Stop();
    }

    private void FixedUpdate()
    {
        SmoothCamera();

        if(isDead)
        {
            backToSpawnPoint();
        }
    }

    private void SmoothCamera()
    {
        float interpolation = playerMouvement.moveSpeed - 4 * Time.deltaTime;
        
        Vector3 position = cam.transform.position;
        position.y = Mathf.Lerp(cam.transform.position.y, this.transform.position.y, interpolation);
        position.x = Mathf.Lerp(cam.transform.position.x, this.transform.position.x, interpolation);
        
        cam.transform.position = position;
    }

    public void StartGame(GameObject _spawnPoint)
    {
        spawnPoint = _spawnPoint;
        this.transform.position = spawnPoint.transform.position;
        GetComponent<PlayerMouvement>().enabled = true;
    }

    public void Die()
    {
        GetComponent<PlayerMouvement>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
        playerMouvement.resetVelocity();
        isDead = true;
        GameObject particleObj = Instantiate(particleSystemPrefab, this.transform.position, Quaternion.identity);
        ParticleSystem particleSystem = particleObj.GetComponent<ParticleSystem>();
        particleSystem.Emit(30);

        Destroy(particleObj, 3f);
    }

    private void backToSpawnPoint()
    {
        if(Vector3.Distance(spawnPoint.transform.position, this.transform.position) < 5f)
        {
            isDead = false;
            GetComponent<PlayerMouvement>().enabled = true;
            GetComponent<BoxCollider2D>().enabled = true;
            return;
        }

        float interpolation = 8 * Time.deltaTime;
        
        Vector3 position = this.transform.position;
        position.y = Mathf.Lerp(this.transform.position.y, spawnPoint.transform.position.y, interpolation);
        position.x = Mathf.Lerp(this.transform.position.x, spawnPoint.transform.position.x, interpolation);
        
        this.transform.position = position;

        Debug.Log(Vector3.Distance(spawnPoint.transform.position, this.transform.position) );
    }
}
