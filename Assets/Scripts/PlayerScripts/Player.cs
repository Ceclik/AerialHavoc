using Photon.Pun;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PhotonView View { get; private set; }
    public int MentalHealth { get; set; }
    public int Energy {get; set; }
    public int Score { get; set; }

    private void Awake()
    {
        View = GetComponent<PhotonView>();
        MentalHealth = 100;
        Energy = 100;
        Score = 0;
    }
}
