using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class EntityGold : MonoBehaviour
{
    [SerializeField] public int _gold;
    [SerializeField] TextMeshProUGUI _goldText;
    
    private void Update()
    {
        if (_goldText != null)
        {
            _goldText.text = "Gold : " + $"{_gold}";
        }
    }
}