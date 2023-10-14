using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public int health = 3;
    public float movementSpeed = 1.0f;
    public float pathDistanceMaximum = 5.0f;
    public float currentPath = 0.0f;
    private bool direction = true; // true = right, false = left

    public AudioSource DuckQuacking;
    public AudioSource DuckDeathNoise;
    public AudioSource DuckDamageNoise;
    private float timeBetweenQuacks = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        DuckQuacking = gameObject.GetComponents<AudioSource>()[0];
        // DuckDeathNoise = gameObject.GetComponents<AudioSource>()[1];
        DuckDamageNoise = gameObject.GetComponents<AudioSource>()[2];
    }

    // Update is called once per frame
    void Update()
    {
        if (timeBetweenQuacks > 3)
        {
            timeBetweenQuacks = 0;
            DuckQuacking.Play();
        } else
        {
            timeBetweenQuacks += Time.deltaTime;
        }
        if (currentPath > pathDistanceMaximum || currentPath < 0)
        {
            direction = !direction;
        }
        if (direction)
        {
            currentPath += movementSpeed * Time.deltaTime;
            transform.Translate(transform.right * movementSpeed * Time.deltaTime);
        } else
        {
            currentPath -= movementSpeed * Time.deltaTime;
            transform.Translate(-1 * transform.right * movementSpeed * Time.deltaTime);
        }
        if (health <= 0)
        {
            // DuckDeathNoise.Play();
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Bullet"))
        {
            health -= 1;
            DuckDamageNoise.Play();
        }
    }
}
