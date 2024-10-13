using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jump = 10f;
    private Rigidbody rb;
    private Stopwatch stopWatch;
    private UIPanel uIPanel;
    private Vector3 moveVector;

    private void Awake()
    {
        stopWatch = Camera.main.GetComponent<Stopwatch>();
        uIPanel = Camera.main.GetComponent<UIPanel>();
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
        switch (other.tag)
        {
            case "StartingLine":
                stopWatch.StartStopwatch(other);
                break;
            case "Respawn":
                uIPanel.Lose();
                break;
            case "Finish":
                uIPanel.Win();
                stopWatch.StopStopwatch(other);
                break;
        }
    }
}
