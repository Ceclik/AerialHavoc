using UnityEngine;

public class InjuriesPicker : MonoBehaviour
{
    [SerializeField] private int bulletHealthDecreaseValue;
    [SerializeField] private int enemyHealthDecreaseValue;
    private Player _player;

    private void Awake()
    {
        _player = GetComponent<Player>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<EnemyBullet>(out EnemyBullet bullet))
            _player.MentalHealth -= bulletHealthDecreaseValue;
        if(other.TryGetComponent<EnemyMover>(out EnemyMover mover))
            _player.MentalHealth -= enemyHealthDecreaseValue;
    }
}