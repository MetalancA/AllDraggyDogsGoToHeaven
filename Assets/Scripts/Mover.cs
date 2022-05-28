using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] float zValue = 0;
    [SerializeField] float moveSpeed = 15f;


    
    // Start is called before the first frame update
    void Start()
    {
        PrintInstructions();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();   
    }

    void PrintInstructions()
    {
        Debug.Log("Welcome to the game!");
        Debug.Log("Use your WASD or arrows to move your dog");
        Debug.Log("Don't hit the walls");
    }


    void MovePlayer()
    {
         Rigidbody rb = GetComponent<Rigidbody>();
         if (Input.GetKey(KeyCode.A))
             rb.AddForce(Vector3.left);
         if (Input.GetKey(KeyCode.D))
             rb.AddForce(Vector3.right);
         if (Input.GetKey(KeyCode.W))
             rb.AddForce(Vector3.forward);
         if (Input.GetKey(KeyCode.S))
             rb.AddForce(Vector3.down);


        // float xValue = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        // float yValue = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        // transform.Translate(xValue, yValue, 0);
    }



}
