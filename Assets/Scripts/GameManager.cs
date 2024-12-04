using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }
        [FormerlySerializedAs("prefabs")]
        public List<GameObject> obstaclePrefabs;
        public float obstacleInterval = 1;
        public float obstacleSpeed = 10;
        public float obstacleOffsetX = 0;
        public Vector2 obstacleOffsetY = new Vector2(0, 0);

         private bool isGameOver = false;

        [HideInInspector]
        public int score = 0;

        void Awake() {
            // Singleton
            if(Instance != null && Instance != this) {
                Destroy(this);
            } else {
                Instance = this;
            }
        }

        public bool IsGameActive() {
            return !isGameOver;
        }

        public bool IsGameOver() {
            return isGameOver;
        }

        public void EndGame() {
            //Set flag
            isGameOver = true;
            // Print message
            Debug.Log("Game over... Your score was " + score);
            // Reload scene
            StartCoroutine(ReloadScene(2));
        }

        private IEnumerator ReloadScene(float delay) {
            // Esperar 2 segundos (delay)
            yield return new WaitForSeconds(delay);
        // Recarregar a cena
            string sceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(sceneName);
            Debug.Log("Reload scene please!!!!");
        }  
    }