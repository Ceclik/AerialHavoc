using UnityEngine.UI;
using Photon.Pun;
using UnityEngine;

public class ValueBarsManager : MonoBehaviour
{
    private Player _player;
    private PhotonView _view;
    private Image _energyBar;
    private Image _mentalHealthBar;

    private float _maxValue = 100f;
    private float _currentValue;

    private void Start()
    {
        _player = GetComponent<Player>();
        _view = GetComponent<PhotonView>();
        _mentalHealthBar = GameObject.Find("MentalHealthBar")?.GetComponent<Image>();
        _energyBar = GameObject.Find("EnergyBar")?.GetComponent<Image>();
    }

    private void UpdateEnergyBar()
    {
        float valuePercentage = _player.Energy / _maxValue;
        _energyBar.fillAmount = valuePercentage;
    }

    private void UpdateMentalHealthBar()
    {
        float valuePercentage = _player.MentalHealth / _maxValue;
        _mentalHealthBar.fillAmount = valuePercentage;
    }

    private void Update()
    {
        if (_view.IsMine)
        {
            UpdateEnergyBar();
            UpdateMentalHealthBar();
        }
    }
}
