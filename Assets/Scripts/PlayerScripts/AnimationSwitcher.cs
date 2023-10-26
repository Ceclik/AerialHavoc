using Photon.Pun;
using UnityEngine;

public class AnimationSwitcher : MonoBehaviour
{
    private Animator _player;
    private Transform _playersParent;
    private PhotonView _view;

    private void Start()
    {
        _view = GetComponent<PhotonView>();
        _playersParent = GameObject.Find("Players").transform;
        _player = GetComponent<Animator>();
        
        if(_view.IsMine)
            _player.SetTrigger("Yurii");
        else
        {
            if(_playersParent.childCount == 2)
                _player.SetTrigger("Tatiana");
            else if(_playersParent.childCount == 3)
                _player.SetTrigger("Emily");
        }
    }
}
