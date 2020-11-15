using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{

    private Image pjHealthUI;
    private Image bossHealthUI;

    private void Awake()
    {
        pjHealthUI = GameObject.FindWithTag(UtilitiesTags.HEALTH_UI_TAG).GetComponent<Image>();
        bossHealthUI = GameObject.FindWithTag(UtilitiesTags.BOSS_HEALTH_UI_TAG).GetComponent<Image>();
    }

    public void DisplayPlayerHealth(float value)
    {
        value /= 100f;
        if(value<0f)
            value=0f;

        pjHealthUI.fillAmount = value;
    }

    public void DisplayBossHealth(float value)
    {
        value /= 300f;
        if (value < 0f)
            value = 0f;

        bossHealthUI.fillAmount = value;
    }
}
