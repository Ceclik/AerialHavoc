using System.Collections;
using Photon.Pun;
using UnityEngine;

[RequireComponent(typeof(Player))]
public  class EnergyDecreaser : MonoBehaviour
{
    [SerializeField] private float deltaDecreasingTime;
    [SerializeField] private int periodicDecreaseValue;
    [SerializeField] private bool isDecreaseEnabled;
    private PhotonView _view; 
    
    private GameObject _energyBar;
    private Player _player;
    private StartGameCondtions _game;

    private void Awake()
    {
        _game = GameObject.Find("StartGameConditions").GetComponent<StartGameCondtions>();
        _view = GetComponent<PhotonView>();
        _energyBar = GameObject.Find("EnergyBar");
        _player = GetComponent<Player>();
        if(isDecreaseEnabled && _view.IsMine && _game.IsStarted)
            StartCoroutine(PeriodicEnergyDecreaser());
    }

    public void DecreaseValue(int subtrahend)
    {
        _player.Energy -= subtrahend;
        if (_player.Energy >= 0)
        {
            _energyBar.transform.position = new Vector3
            (
                _energyBar.transform.position.x - (float)subtrahend * 0.027f,
                _energyBar.transform.position.y,
                _energyBar.transform.position.z
            );
            _energyBar.transform.localScale = new Vector3
            (
                _energyBar.transform.localScale.x - subtrahend * 0.055f,
                _energyBar.transform.localScale.y,
                _energyBar.transform.localScale.z
            );
        }
        else _energyBar.SetActive(false);
    }

    private IEnumerator PeriodicEnergyDecreaser()
    {
        while (true)
        {
            yield return new WaitForSeconds(deltaDecreasingTime);
            DecreaseValue(periodicDecreaseValue);
        }
    }
}
