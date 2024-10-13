using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindZone : MonoBehaviour
{
    [SerializeField] private float windForce = 1f;
    [SerializeField] private float delayDiraction = 2f;
    [SerializeField] private float afterTime = 2f;

    private void Start()
    {
        InvokeRepeating(nameof(RotateZone), afterTime, delayDiraction);
    }

    private void RotateZone()
    {
        transform.eulerAngles = new Vector3(0, Random.Range(-360f, 361f), 0);
    }

    private void OnTriggerStay(Collider other)
    {
        var hitObject = other.gameObject;

        if (hitObject != null)
        {
            var rigidbody = hitObject.GetComponent<Rigidbody>();
            var direction = transform.right;
            rigidbody.AddForce(direction * windForce);
        }
    }
}
