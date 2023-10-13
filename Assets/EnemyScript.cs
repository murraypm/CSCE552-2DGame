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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentPath >= pathDistanceMaximum)
        {

        }
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Bullet"))
        {
            health -= 1;
        }
    }
}
