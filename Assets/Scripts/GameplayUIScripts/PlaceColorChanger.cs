using UnityEngine;
using UnityEngine.UI;

public class PlaceColorChanger : MonoBehaviour
{
   [SerializeField] private Color thirdPlaceColor;
   [SerializeField] private Color secondPlaceColor;
   [SerializeField] private Color firstPlaceColor;
   [SerializeField] private Image deathScreenBackplate;

   private void Start() {
      int place = PlayerPrefs.GetInt("Rate");
      switch (place)
      {
         case 1: 
            deathScreenBackplate.color = firstPlaceColor;
            break;
         case 2:
            deathScreenBackplate.color = secondPlaceColor;
            break;
         case 3:
            deathScreenBackplate.color = thirdPlaceColor;
            break;
      }
   }
}
