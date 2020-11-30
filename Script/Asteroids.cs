using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroids : MonoBehaviour
{
    private Rigidbody2D rb;
    private float rotationSpeed;
    private Vector2 screenBounds;
    private Vector2 direction;
    public float speed = 10.0f;
    public int scoreValue = 10;
    public GameObject explosion;
    public PlayerController ship;
    private float shift;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        ship = GameObject.FindObjectOfType<PlayerController>();
        direction = ship.transform.position - transform.position;
        shift = Random.Range(-5, 5);
        rb.AddForce(new Vector2(direction.x + shift,direction.y + shift) * speed);
        rotationSpeed = Random.Range(25, -25);
        
        


    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, rotationSpeed)*Time.deltaTime);
       if(transform.position.x > 23||transform.position.x <-23){
            Destroy(this.gameObject);
        }
       if(transform.position.y >15||transform.position.y < -15)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            FindObjectOfType<AudioManager>().Play("BOOM");
            ScoreManager.score += scoreValue;
            GameObject e = Instantiate(explosion) as GameObject;
            e.transform.position = transform.position;
            Destroy(this.gameObject);
            Destroy(e, 5f);
            if (other.CompareTag("Bullet")){
                Destroy(other.gameObject);
            }
        }
            
    }
 }

