using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float movementSpeed = 10.0f;
    public float timeUntilDespawn = 5.0f;
    private float time = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        transform.Translate(transform.right * movementSpeed * Time.deltaTime);
        if (time > timeUntilDespawn)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // print("test");
        Destroy(gameObject);
    }
}
