using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerHP : MonoBehaviour
{
    public int Max_Health = 100;
    public int Current_Health;

    public HealthBar healthBar;
    public GameObject explosion;

    void Start()
    {
        Current_Health = Max_Health;
        healthBar.SetMaxHealth(Max_Health);
    }

    void Update()
    {
        if(PlayerController.Overdrive == true)
        {
            TakeDamage(5);
            PlayerController.Overdrive = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Asteroids")
        {
            TakeDamage(10);
        }
        if (other.CompareTag("Heal"))
        {
            TakeDamage(-10);
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Enemies"))
        {
            TakeDamage(25);
        }

        if (Current_Health <= 0)
        {
            FindObjectOfType<AudioManager>().Play("BOOM");
            GameObject e = Instantiate(explosion) as GameObject;
            e.transform.position = transform.position;
            Destroy(this.gameObject);
            Destroy(e, 5f);
            FindObjectOfType<GameManager>().EndGame();
        }
    }

    void TakeDamage(int damage)
    {
        Current_Health -= damage;
        healthBar.SetHealth(Current_Health);
    }
}
