using Photon.Pun;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Transform _playersParent;
    public int MentalHealth { get; set; }
    public int Energy {get; set; }
    public int Score { get; set; }
    public bool IsAlive { get; private set; }

    [SerializeField] private bool debugDeathAllow;

    private void Awake()
    {
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
    }
}
