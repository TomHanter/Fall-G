using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jump = 10f;
    Rigidbody rb;
    Vector3 moveVector;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        moveVector.x = Input.GetAxis("Horizontal");
        moveVector.z = Input.GetAxis("Vertical");
        rb.MovePosition(rb.position + moveVector * moveSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jump, ForceMode.Impulse);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "StartingLine")
        {
            Camera.main.GetComponent<Stopwatch>().StartStopwatch(other);

        }

        if (other.tag == "Respawn")
            Camera.main.GetComponent<UIPanel>().Lose();

        if (other.tag == "Finish")
        {
            Camera.main.GetComponent<UIPanel>().Win();
            Camera.main.GetComponent<Stopwatch>().StopStopwatch(other);
        }

    }

}
