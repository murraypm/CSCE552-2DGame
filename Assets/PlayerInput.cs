using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float movementSpeed = 1.0f;
    public float jumpSpeed = 1.0f;
    public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 position = transform.position;
        position.x += movementSpeed * horizontal * Time.deltaTime;
        position.y += jumpSpeed * vertical * Time.deltaTime;
        transform.position = position;

        if (Input.GetButtonDown("Fire1"))
        {
            position.x += 2;
            Instantiate(bullet, position, transform.rotation).SetActive(true);
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
