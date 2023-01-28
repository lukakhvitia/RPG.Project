using RPG.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float arrowSpeed = 5f;
    
    Health target = null;
    float damage = 0;
    private void Start()
    {
        transform.LookAt(GetAimLocation());
    }

    void Update()
    {
        if (target == null) return;
        //transform.LookAt(GetAimLocation());
        transform.Translate(Vector3.forward * arrowSpeed * Time.deltaTime);
    }
    
    public void SetTarget(Health target, float damage)
    {
        this.target = target;
        this.damage = damage;
    }

    private Vector3 GetAimLocation()
    {
        CapsuleCollider targetCapsule = target.GetComponent<CapsuleCollider>();
        if (targetCapsule == null)
        {
            return target.transform.position;
        }
        return target.transform.position + Vector3.up * targetCapsule.height / 2;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Health>() != target) return;
        target.TakeDamage(damage);
        Destroy(gameObject);
    }
}

