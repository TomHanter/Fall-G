using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] float maxHp = 100f;
    [SerializeField] UnityEvent die;
    [SerializeField] UnityEvent<float> hpChangedPercent;

    private float currentHp;
    public float HP
    {
        get => currentHp;
        set
        {
            currentHp = value;
            hpChangedPercent?.Invoke(currentHp / maxHp);

            if (currentHp <= 0)
                die?.Invoke();
        }
    }

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        HP = maxHp;
    }

    public void GetDamage(float damage)
    {
        HP -= damage;
    }

}
