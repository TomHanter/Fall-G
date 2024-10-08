using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DamageAble : MonoBehaviour
{
    [SerializeField] private UnityEvent<float> damageGot;

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.TryGetComponent<Attacker>(out var attacker))
        {
           damageGot?.Invoke(attacker._damage);
        }
    }
}
