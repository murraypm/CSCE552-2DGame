using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInput : MonoBehaviour
{
    public float movementSpeed = 1.0f;
    public float jumpSpeed = 1.0f;
    public int health = 3;
    public GameObject bullet;

    public AudioSource WalkingOnGrass;

    // Start is called before the first frame update
    void Start()
    {
        WalkingOnGrass = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    Vector2 position;
    Vector2 bulletPosition;
    void Update()
    {
        if (health <= 0)
        {
            SceneManager.LoadScene("DeathScene");
            // print("Dead");
        }
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        gameObject.GetComponent<SpriteRenderer>().flipX = horizontal < 0;

        position = transform.position;
        position.x += movementSpeed * horizontal * Time.deltaTime;
        position.y += jumpSpeed * vertical * Time.deltaTime;
        transform.position = position;

        if (Input.GetButtonDown("Fire1"))
        {
            bulletPosition = transform.position;
            bulletPosition.x += 2 * horizontal;
            Instantiate(bullet, bulletPosition, transform.rotation).SetActive(true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Terrain"))
        {
            
            WalkingOnGrass.Play();
        }
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            health -= 1;
        }
    }

    /*    public void OnMove(InputValue value)
        {
            *//*ConstantForce2D test;
            test = gameObject.AddComponent<ConstantForce2D>();
            test.force.Set(0, 100);*//*
            // print(value.Get<Vector2>());
            if (value.Get<Vector2>().y == 1)
            {
                // print("test");
                // gameObject.GetComponent<ConstantForce2D>;
                this.gameObject.transform.Translate(Vector3.up);
            } if (value.Get<Vector2>().x == -1)
            {
                this.gameObject.transform.Translate(Vector3.left);
            } if (value.Get<Vector2>().x == 1)
            {
                this.gameObject.transform.Translate(Vector3.right);
            }

        }*/
}
