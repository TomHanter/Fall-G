using DG.Tweening;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    internal class FallTrail : MovingTrail
    {
        [SerializeField] private float distance = 10f;
        [SerializeField] private float duraction = 1f;
        [SerializeField] private float delay = 0.5f;

        public override void Move()
        {
            transform.DOMove(transform.position + Vector3.down * distance, duraction)
            .OnComplete(OnComplete)
                .SetDelay(delay);
            transform.GetComponent<Renderer>().material.color = Color.blue;
        }

        private void OnComplete()
        {
            Destroy(gameObject);
        }
    }
}
