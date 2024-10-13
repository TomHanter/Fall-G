using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts
{
    internal class TrapTrail : AbsTrapTrail
    {
        [SerializeField] float trapDamage = 10f;
        private Color orangeColor = new(1.0f, 0.64f, 0.0f);
        private Color startingColor = Color.white;
        private Renderer colorRender;
        public bool _reloadingTrap = false;
        public bool _activatedTrap = false;

        private void Start()
        {
            colorRender = GetComponent<Renderer>();
            colorRender.material.color = startingColor;
        }

        public override void ColorChange()
        {
            StartCoroutine(SwitchColor());
        }

        IEnumerator SwitchColor()
        {
            _activatedTrap = true;

            colorRender.material.color = orangeColor;
            yield return new WaitForSeconds(1);

            colorRender.material.color = Color.red;
            TakeDamageTrap();
            yield return new WaitForSeconds(0.1f);

            colorRender.material.color = startingColor;

            _activatedTrap = false;
            StartCoroutine(ReloadTrap());
        }

        IEnumerator ReloadTrap()
        {
            _reloadingTrap = true;
            yield return new WaitForSeconds(5);
            _reloadingTrap = false;
        }

        public void TakeDamageTrap()
        {
            Collider[] colliders = Physics.OverlapBox(transform.position,
                                                     transform.localScale / 2);
            foreach (var collider in colliders)
            {
                if (collider.TryGetComponent<Health>(out var health))
                {
                    health.GetDamage(trapDamage);
                }
            }
        }
    }
}
