using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeployUFO : MonoBehaviour
{
    public GameObject UFO;
    public GameObject[] SpawnerUFO;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(UFOWave());   
    }

    private void spawnUFO()
    {
        Vector2 position = SpawnerUFO[Random.Range(0, SpawnerUFO.Length)].transform.position;
        GameObject UFOCl = Instantiate(UFO, new Vector2(position.x, position.y), transform.rotation);
        UFOCl.SetActive(true);
    }

    IEnumerator UFOWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(2);
            Debug.Log("AFAS");
            spawnUFO();
        }
    }
}
