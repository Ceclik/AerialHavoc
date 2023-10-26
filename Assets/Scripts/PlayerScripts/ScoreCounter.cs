using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Player))]
public class ScoreCounter : MonoBehaviour
{
     private Text _score;
     private Player _player;
     private PhotonView _view;
     private void Awake()
     {
          _score = FindObjectOfType<Text>();
          _player = GetComponent<Player>();
          _view = GetComponent<PhotonView>();
          if(_view.IsMine)
               _score.text = $"Очки: {_player.Score}";
     }

     public void AddScore(int addValue)
     {
          _player.Score += addValue;
          if(_view.IsMine)
               _score.text = $"Очки: {_player.Score}";
     }
}
