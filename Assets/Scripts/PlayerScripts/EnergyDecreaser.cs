using System.Collections;
using Photon.Pun;
using UnityEngine;

[RequireComponent(typeof(Player))]
public  class EnergyDecreaser : MonoBehaviour
{
    [SerializeField] private float deltaDecreasingTime;
    [SerializeField] private int periodicDecreaseValue;
    private PhotonView _view; 
    
    private GameObject _energyBar;
    private Player _player;

    private void Awake()
    {
        _view = GetComponent<PhotonView>();
        _energyBar = GameObject.Find("EnergyBar");
        _player = GetComponent<Player>();
        StartCoroutine(PeriodicEnergyDecreaser());
    }

    public void DecreaseValue(int subtrahend)
    {
        _player.Energy -= subtrahend;
        if (_player.Energy >= 0)
        {
            _energyBar.GetComponent<Transform>().position = new Vector3
            (
                _energyBar.GetComponent<Transform>().position.x - (float)subtrahend * 0.027f,
                _energyBar.GetComponent<Transform>().position.y,
                _energyBar.GetComponent<Transform>().position.z
            );
            _energyBar.GetComponent<Transform>().localScale = new Vector3
            (
                _energyBar.GetComponent<Transform>().localScale.x - subtrahend * 0.055f,
                _energyBar.GetComponent<Transform>().localScale.y,
                _energyBar.GetComponent<Transform>().localScale.z
            );
        }
        else _energyBar.SetActive(false);
    }

    private IEnumerator PeriodicEnergyDecreaser()
    {
        while (true)
        {
            if (_view.IsMine)
            {
                yield return new WaitForSeconds(deltaDecreasingTime);
                DecreaseValue(periodicDecreaseValue);
            }
        }
    }
}
