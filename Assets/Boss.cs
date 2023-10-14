using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    public float health = 10.0f;
    public AudioSource DuckDamageNoise;

    // Start is called before the first frame update
    void Start()
    {
        DuckDamageNoise = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            SceneManager.LoadScene("VictoryScene");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Bullet"))
        {
            print("test");
            health -= 1;
            DuckDamageNoise.Play();
        }
    }
}
