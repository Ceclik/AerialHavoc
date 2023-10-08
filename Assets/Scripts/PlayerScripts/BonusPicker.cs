using Photon.Pun;
using UnityEngine;

public class BonusPicker : MonoBehaviour
{
    [SerializeField] private int energyIncrease;
    [SerializeField] private int mentalHealthIncrease;
    private Player _player;
    private PhotonView _view;

    private void Start()
    {
        _view = GetComponent<PhotonView>();
        _player = GetComponent<Player>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<EnergyBonus>(out EnergyBonus bonus) && _view.IsMine)
        {
            SetEnergy();
            other.GetComponent<BonusDestroyer>().DestroyWhenHit();
        }

        if (other.TryGetComponent<MentalHealthBonus>(out MentalHealthBonus mbonus) && _view.IsMine)
        {
            SetMentalHealth();
            other.GetComponent<BonusDestroyer>().DestroyWhenHit();
        }
    }

    private void SetEnergy()
    {
        if (_player.Energy + energyIncrease > 100)
            _player.Energy = 100;
        else
            _player.Energy += energyIncrease;
    }

    private void SetMentalHealth()
    {
        if (_player.MentalHealth + mentalHealthIncrease > 100)
            _player.MentalHealth = 100;
        else
            _player.MentalHealth += mentalHealthIncrease;
    }
}
