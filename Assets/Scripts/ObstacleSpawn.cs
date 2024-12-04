using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawn : MonoBehaviour
{

    public float cooldown = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {        
        // Get GameManager
        var gameManager = GameManager.Instance;

        // Ignore if game is over
        if(gameManager.IsGameOver()) {
            return;
        }
        // Update cooldown
        cooldown -= Time.deltaTime;
        if(cooldown <= 0f) {
            cooldown = gameManager.obstacleInterval;

            // Spawn obstacle
            int prefabIndex = Random.Range(0, gameManager.obstaclePrefabs.Count);
            // Prefab
            GameObject prefab = gameManager.obstaclePrefabs[prefabIndex];
            // Rotation
            Quaternion rotation = prefab.transform.rotation;
            // Position
            float x = gameManager.obstacleOffsetX;
            float y = Random.Range(gameManager.obstacleOffsetY.x, gameManager.obstacleOffsetY.y);
            float z = 8;
            Vector3 position = new Vector3(x, y, z);
            Instantiate(prefab, position, rotation);
        }   
    }
}
