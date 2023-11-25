using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{

    [SerializeField] int steerSpeed = 300;
    [SerializeField] int moveSpeed = 18;
    [SerializeField] int slowSpeed = 10;
    [SerializeField] int boostSpeed = 30;
    void Start()
    {
     
    }


    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "SpeedUp") {
           moveSpeed = boostSpeed;
        }

        if (other.tag == "SlowDown") {
            moveSpeed = slowSpeed;
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        moveSpeed = 18;
    }

    void OnCollisionEnter2D(Collision2D other) {
        moveSpeed = slowSpeed;
    }
}
