using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRange : MonoBehaviour {

    public TurretController turret;

    private void Awake()
    {
        turret = gameObject.GetComponentInParent<TurretController>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            turret.Shoot();
        }
    }
}
