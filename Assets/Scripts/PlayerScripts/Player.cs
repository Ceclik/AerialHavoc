using Photon.Pun;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Transform _playersParent;
    private StartGameCondtions _game;
    public int MentalHealth { get; set; }
    public int Energy {get; set; }
    public int Score { get; set; }
    public bool IsAlive { get; private set; }

    [SerializeField] private bool debugDeathAllow;

    [SerializeField] private int thirdPlaceRatingDecreaseValue;
    [SerializeField] private int firstPlaceRatingIncreaseValue;

    private void Awake()
    {
        _game = GameObject.Find("StartGameConditions").GetComponent<StartGameCondtions>();
        _playersParent = GameObject.Find("Players").transform;
        transform.SetParent(_playersParent);
        IsAlive = true;
        MentalHealth = 100;
        Energy = 100;
        Score = 0;
    }
    
    private void Update()
    {
        if ((Energy <= 0 || MentalHealth <= 0) && debugDeathAllow)
            IsAlive = false;
        if (_playersParent.childCount == 1 && IsAlive && debugDeathAllow && _game.IsStarted)
        {
            PlayerPrefs.SetInt("Rate", 1);
            PlayerPrefs.SetInt("Rating", PlayerPrefs.GetInt("Rating", 100) + firstPlaceRatingIncreaseValue);
            PhotonNetwork.LeaveRoom();
            PhotonNetwork.Destroy(gameObject);
            PhotonNetwork.LoadLevel("LoseScreen");
        }
    }

    private void OnDestroy()
    {
        if (!IsAlive)
        {
            switch (_playersParent.childCount)
            {
                case 3:
                    PlayerPrefs.SetInt("Rate", 3);
                    PlayerPrefs.SetInt("Rating", PlayerPrefs.GetInt("Rating", 100) - thirdPlaceRatingDecreaseValue);
                    break;
                case 2:
                    PlayerPrefs.SetInt("Rate", 2);
                    break;
            }
        }
    }
}
