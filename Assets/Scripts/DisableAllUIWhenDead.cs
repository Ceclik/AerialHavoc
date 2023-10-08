using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisableAllUIWhenDead : MonoBehaviour
{
    [SerializeField] private GameObject deathMenu;
    [SerializeField] private List<Button> buttons;
    [SerializeField] private List<GameObject> valueBars;
    [SerializeField] private List<Image> icons;
    [SerializeField] private List<Text> texts;

    private void Update()
    {
        if (deathMenu.activeSelf)
        {
            foreach (var button in buttons)
                button.enabled = false;
            foreach (var bar in valueBars)
                bar.SetActive(false);
            foreach (var icon in icons)
                icon.enabled = false;
            foreach (var text in texts)
                text.enabled = false;
        }
    }
}
