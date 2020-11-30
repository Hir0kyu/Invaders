using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFO : MonoBehaviour
{
    public int score = 25;
    public GameObject HealPrefab;
    public Transform UFOPrefab;
    public GameObject explosion;


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            
            Destroy(this.gameObject);
        }

        if (other.CompareTag("Bullet"))
        {
            SpawnHeal();
            FindObjectOfType<AudioManager>().Play("BOOM");
            ScoreManager.score += score;
            GameObject e = Instantiate(explosion) as GameObject;
            e.transform.position = transform.position;
            Destroy(other.gameObject);
            Destroy(this.gameObject);
            Destroy(e, 5f);
        }
    }

    void SpawnHeal()
    {
        GameObject Heal = Instantiate(HealPrefab, UFOPrefab.position, UFOPrefab.rotation);
        Destroy(Heal,2f);


    }
}
