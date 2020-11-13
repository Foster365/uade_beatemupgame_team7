using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{

    private Image pjHealthUI;

    private void Awake()
    {
        pjHealthUI = GameObject.FindWithTag(UtilitiesTags.HEALTH_UI_TAG).GetComponent<Image>();
    }

    public void DisplayHealth(float value)
    {
        value /= 100f;
        if(value<0f)
            value=0f;

        pjHealthUI.fillAmount = value;
    }
}
