using Assets.Scripts;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class TriggerTrailMoving : MonoBehaviour
{
    [SerializeField] private MovingTrail moveTrail;

    private void OnTriggerEnter(Collider other)
    {
        moveTrail.Move();
    }
}


