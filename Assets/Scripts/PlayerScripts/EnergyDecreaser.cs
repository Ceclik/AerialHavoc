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
    private float _startXPos;
    private float _startXScale;

    private void Awake()
    {
        _game = GameObject.Find("StartGameConditions").GetComponent<StartGameCondtions>();
        _view = GetComponent<PhotonView>();
        _energyBar = GameObject.Find("EnergyBar");
        _player = GetComponent<Player>();
        _startXScale = _energyBar.transform.localScale.x;
        _startXPos = _energyBar.transform.position.x;
        if(isDecreaseEnabled && _view.IsMine)
            StartCoroutine(PeriodicEnergyDecreaser());
    }

    public void DecreaseValue(int subtrahend)
    {
        _player.Energy -= subtrahend;
        if(_player.Energy <= 0)
            _energyBar.SetActive(false);
    }

    private void Update()
    {
        if (_view.IsMine)
        {
            float deltaEnergy = 100 - _player.Energy;
            float newXPos = _startXPos - deltaEnergy * 0.027f;
            float newXScale = _startXScale - deltaEnergy * 0.055f;

            _energyBar.transform.position = new Vector3
            (
                newXPos,
                _energyBar.transform.position.y,
                _energyBar.transform.position.z
            );
            _energyBar.transform.localScale = new Vector3
            (
                newXScale,
                _energyBar.transform.localScale.y,
                _energyBar.transform.localScale.z
            );
        }
    }

    private IEnumerator PeriodicEnergyDecreaser()
    {
        while (true)
        {
            yield return new WaitForSeconds(deltaDecreasingTime);
            if(_game.IsStarted)
                DecreaseValue(periodicDecreaseValue);
        }
    }
}
