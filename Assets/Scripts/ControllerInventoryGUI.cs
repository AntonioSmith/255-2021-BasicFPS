using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerInventoryGUI : MonoBehaviour
{
    public Transform imgKey;

    void Start()
    {
        
    }

    void Update()
    {
        imgKey.gameObject.SetActive(Inventory.main.hasKey);
    }
}
