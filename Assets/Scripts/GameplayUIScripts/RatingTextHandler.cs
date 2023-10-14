using UnityEngine;
using UnityEngine.UI;

public class RatingTextHandler : MonoBehaviour
{
    [SerializeField] private Text ratingText;
    private int _rating;

    private void Awake()
    {
        ratingText.text = $"Rating: {PlayerPrefs.GetInt("Rating", 100)}";
    }
}
