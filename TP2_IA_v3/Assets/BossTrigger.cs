using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTrigger : MonoBehaviour
{
    public GameObject bossHealthUI;
    public AudioSource bossBattleCry;

    private void OnTriggerEnter(Collider other)
    {
       
       
            bossHealthUI.SetActive(true);
        

    }
}
