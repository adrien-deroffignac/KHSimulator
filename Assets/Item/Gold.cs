using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : Item
{
    [SerializeField] EntityGold _entityGold;
    void Start()
    {
        _entityGold = FindObjectOfType<EntityGold>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CapsuleCollider>())
        {
            _entityGold._gold += 10;
            Destroy(gameObject);
            
        }
    }
}
