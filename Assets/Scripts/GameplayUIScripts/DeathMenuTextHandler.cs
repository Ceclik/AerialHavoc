using System;
using UnityEngine;
using UnityEngine.UI;

public class DeathMenuTextHandler : MonoBehaviour
{
    [SerializeField] [Multiline] private String firstPlaceDeathMessage;
    [SerializeField] [Multiline] private String secondPlaceDeathMessage;
    [SerializeField] [Multiline] private String thirdPlaceDeathMessage;
    [SerializeField] private Text deathMessageText;

    private void Awake()
    {
        switch (PlayerPrefs.GetInt("Rate"))
        {
            case 1:
                deathMessageText.text = firstPlaceDeathMessage;
                break;
            case 2:
                deathMessageText.text = secondPlaceDeathMessage;
                break;
            case 3:
                deathMessageText.text = thirdPlaceDeathMessage;
                break;
        }
    }
}
