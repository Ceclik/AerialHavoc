using System.Collections;
using Photon.Pun;
using UnityEngine;

public class InjuriesPicker : MonoBehaviour
{
    [SerializeField] private int decreaseValueFromBullet;
    [SerializeField] private int decreaseValueFromEnemy;
    [SerializeField] private int decreaseValueFromKukin;
    [SerializeField] private float bloodEffectDuration;
    [SerializeField] private AudioSource hurtSound;
    private PhotonView _view;
    private GameObject _bloodEffect;
    private Player _player;

    private void Awake()
    {
        _view = GetComponent<PhotonView>();
        _player = GetComponent<Player>();
        _bloodEffect = GameObject.Find("BloodEffect");
        if(GetComponent<PhotonView>().IsMine)
            _bloodEffect.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (_view.IsMine)
        {
            if (other.TryGetComponent<EnemyBullet>(out EnemyBullet bullet))
            {
                hurtSound.Play();
                _player.MentalHealth -= decreaseValueFromBullet;
            }

            if (other.TryGetComponent<EnemyMover>(out EnemyMover mover))
            {
                hurtSound.Play();
                _player.MentalHealth -= decreaseValueFromEnemy;
                StartCoroutine(BloodEffectRunner());
            }

            if (other.TryGetComponent<KukinBullet>(out KukinBullet kb))
            {
                hurtSound.Play();
                _player.MentalHealth -= decreaseValueFromKukin;
                _player.Energy -= decreaseValueFromKukin;
            }
        }
    }

    private IEnumerator BloodEffectRunner()
    {
        _bloodEffect.SetActive(true); 
        yield return new WaitForSeconds(bloodEffectDuration);
        _bloodEffect.SetActive(false); 
    }
}
