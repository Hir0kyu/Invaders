using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deployAsteroids : MonoBehaviour
{
    public GameObject asteroidPrefab;

    public GameObject[] SpawnerP;

    

    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(asteroidWave());
    }

    private void spawnEnemy()
    {
        Vector2 position = SpawnerP[Random.Range(0, SpawnerP.Length)].transform.position;
        GameObject Asteroids = Instantiate(asteroidPrefab, new Vector2(position.x, position.y),transform.rotation);
        Asteroids.SetActive(true);

    }
   IEnumerator asteroidWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(3);
            spawnEnemy();

        }
        
    }
}
