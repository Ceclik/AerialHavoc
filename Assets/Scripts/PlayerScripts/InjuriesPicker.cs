using UnityEngine;

public class InjuriesPicker : MonoBehaviour
{
    [SerializeField] private int decreaseValueFromBullet;
    [SerializeField] private int decreaseValueFromEnemy;
    private Player _player;

    private void Awake()
    {
        _player = GetComponent<Player>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<EnemyBullet>(out EnemyBullet bullet))
            _player.MentalHealth -= decreaseValueFromBullet;
        if(other.TryGetComponent<EnemyMover>(out EnemyMover mover))
            _player.MentalHealth -= decreaseValueFromEnemy;
    }
}
