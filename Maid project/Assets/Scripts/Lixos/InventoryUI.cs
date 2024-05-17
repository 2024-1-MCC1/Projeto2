using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    public TextMeshProUGUI ContadorText;

    void Start()
    {
        ContadorText = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateContadorText(PlayerInventory playerInventory)
    {
        ContadorText.text = playerInventory.NumberOfContador.ToString();
    }
}