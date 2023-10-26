using UnityEngine;

public class Kukin : MonoBehaviour
{
    public int Health { get; private set; }
    [SerializeField] private int decreaseHealthFromBullet;
    [SerializeField] private AudioSource kukinHurtSound;

    private void Start()
    {
        Health = 100;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<PlayerBullet>(out PlayerBullet bullet))
        {
            kukinHurtSound.Play();
            Health -= decreaseHealthFromBullet;
        }
    }
}
