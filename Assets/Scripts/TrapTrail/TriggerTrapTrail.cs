using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTrapTrail : MonoBehaviour
{
    [SerializeField] private TrapTrail trapTrail;

    private void OnTriggerEnter(Collider other)
    {
        if (!trapTrail._reloadingTrap && !trapTrail._activatedTrap)
            trapTrail.ColorChange();
    }
}
