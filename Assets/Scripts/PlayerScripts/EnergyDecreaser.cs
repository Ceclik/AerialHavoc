using System.Collections;
using Photon.Pun;
using UnityEngine;

[RequireComponent(typeof(Player))]
public  class EnergyDecreaser : MonoBehaviour
{
    [SerializeField] private float decreasePeriod;
    [SerializeField] private int decreaseValue;
    [SerializeField] private bool isDecreaseEnabled;
    private PhotonView _view; 
    
    private Player _player;
    private StartGameCondtions _game;
    
    private void Awake()
    {
        _game = GameObject.Find("StartGameConditions").GetComponent<StartGameCondtions>();
        _view = GetComponent<PhotonView>();
        _player = GetComponent<Player>();
        if(isDecreaseEnabled && _view.IsMine)
            StartCoroutine(PeriodicEnergyDecreaser());
    }
    
    private IEnumerator PeriodicEnergyDecreaser()
    {
        while (true)
        {
            yield return new WaitForSeconds(decreasePeriod);
            if (_game.IsStarted)
                _player.Energy -= decreaseValue;
        }
    }
}
