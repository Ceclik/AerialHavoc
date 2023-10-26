using Photon.Pun;
using UnityEngine;

public class BonusPicker : MonoBehaviour
{
    [SerializeField] private int increaseHealthValueFromPillow;
    [SerializeField] private int increaseHealthBonusFromPancake;
    [SerializeField] private int increaseEnergyValueFromCoffee;
    [SerializeField] private int increaseEnergyValueFromSpotify;
    [SerializeField] private AudioSource bonusPickSound;
    
    private Player _player;
    private PhotonView _view;

    private void Start()
    {
        _view = GetComponent<PhotonView>();
        _player = GetComponent<Player>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (_view.IsMine)
        {
            if (other.name == "Pillow(Clone)")
            {
                SetMentalHealth(increaseHealthValueFromPillow);
                other.GetComponent<BonusDestroyer>().DestroyWhenHit();
                bonusPickSound.Play();
            }

            else if (other.name == "Spotify(Clone)")
            {
                SetEnergy(increaseEnergyValueFromSpotify);
                other.GetComponent<BonusDestroyer>().DestroyWhenHit();
                bonusPickSound.Play();
            }

            else if (other.name == "CoffeeCup(Clone)")
            {
                SetEnergy(increaseEnergyValueFromCoffee);
                other.GetComponent<BonusDestroyer>().DestroyWhenHit();
                bonusPickSound.Play();
            }
            else if (other.name == "Pancake(Clone)")
            {
                SetEnergy(increaseHealthBonusFromPancake);
                other.GetComponent<BonusDestroyer>().DestroyWhenHit();
                bonusPickSound.Play();
            }
        }
    }

    private void SetEnergy(int value)
    {
        if (_player.Energy + value > 100)
            _player.Energy = 100;
        else
            _player.Energy += value;
    }

    private void SetMentalHealth(int value)
    {
        if (_player.MentalHealth + value > 100)
            _player.MentalHealth = 100;
        else
            _player.MentalHealth += value;
    }
}
