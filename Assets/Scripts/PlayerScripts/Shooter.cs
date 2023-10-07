using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject playerBullet;
    [SerializeField] private float reloadTime;
    private ScoreCounter _scoreCounter;
    private Button[] _buttons;
    private Button _shootButton;
    private PhotonView _view;
    private float _deltaTime;

    private void Start()
    {
        _scoreCounter = GetComponent<ScoreCounter>();
        _deltaTime = 0;
        _view = GetComponent<PhotonView>();
        _buttons = FindObjectsOfType<Button>();
        foreach (Button b in _buttons)
            if(b.tag == "ShootButton")
                _shootButton = b;
        _shootButton.onClick.AddListener(Shoot);
    }

    private void Update()
    {
        _deltaTime += Time.deltaTime;
    }

    public void Shoot()
    {
        if (_deltaTime > reloadTime && _view.IsMine)
        {
            _deltaTime = 0;
            Vector3 spawnPosition = new Vector3(transform.position.x + 0.8f, transform.position.y, 0.0f);
            RaycastHit2D hit = Physics2D.Raycast(spawnPosition, transform.up, 10f);
            if (hit)
            {
                GameObject hittedObject = hit.collider.gameObject;
                if (hittedObject.TryGetComponent<EnemyMover>(out EnemyMover mover))
                    _scoreCounter.AddScore(20);
            }
            _view.RPC("SpawnBullet", RpcTarget.MasterClient, spawnPosition, transform.rotation);
        }
    }

    [PunRPC]
    public void SpawnBullet(Vector3 spawnPosition, Quaternion spawnRotation)
    {
        PhotonNetwork.Instantiate(playerBullet.name, spawnPosition, spawnRotation);
    }
}