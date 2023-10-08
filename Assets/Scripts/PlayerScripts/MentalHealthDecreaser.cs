using Photon.Pun;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class MentalHealthDecreaser : MonoBehaviour
{
    private GameObject _mentalHealthBar;
    private Player _player;
    private float _startXPos;
    private float _startXScale;
    private PhotonView _view;

    private void Awake()
    {
        _view = GetComponent<PhotonView>();
        _mentalHealthBar = GameObject.Find("MentalHealthBar");
        _startXPos = _mentalHealthBar.transform.position.x;
        _startXScale = _mentalHealthBar.transform.localScale.x;
        _player = GetComponent<Player>();
    }

    public void DecreaseValue(int subtrahend)
    {
        _player.MentalHealth -= subtrahend;
        if (_player.MentalHealth <= 0)
            _mentalHealthBar.SetActive(false);
        
    }
    
    private void Update()
    {
        if (_view.IsMine)
        {
            float deltaEnergy = 100 - _player.Energy;
            float newXPos = _startXPos - deltaEnergy * 0.027f;
            float newXScale = _startXScale - deltaEnergy * 0.055f;

            _mentalHealthBar.transform.position = new Vector3
            (
                newXPos,
                _mentalHealthBar.transform.position.y,
                _mentalHealthBar.transform.position.z
            );
            _mentalHealthBar.transform.localScale = new Vector3
            (
                newXScale,
                _mentalHealthBar.transform.localScale.y,
                _mentalHealthBar.transform.localScale.z
            );
        }
    }
}