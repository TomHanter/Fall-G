using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class TriggerTrail : MonoBehaviour
{
    [SerializeField] private string playerTag = "Player";
    [SerializeField] private MovingTrail trail;

    private void OnTriggerEnter(Collider other)
    {
        trail.Move();
    }


}


