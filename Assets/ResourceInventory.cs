using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class ResourceInventory : MonoBehaviour
{

    public int wood = 0;
    public TMPro.TMP_Text woodText;

    public void IncrementWood()
    {
        wood++;
        woodText.SetText(wood + " wood");
    }
}
