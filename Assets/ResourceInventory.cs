using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class ResourceInventory : MonoBehaviour
{

    private int wood = 0;
    public TMPro.TMP_Text woodText;

    public void IncrementWood()
    {
        wood++;
        UpdateWoodUI();
    }

    public void ClearWood()
    {
        wood = 0;
        UpdateWoodUI();
    }

    private void UpdateWoodUI()
    {
        woodText.SetText(wood + " wood");
    }

    public int GetWood()
    {
        return wood;
    }
}
