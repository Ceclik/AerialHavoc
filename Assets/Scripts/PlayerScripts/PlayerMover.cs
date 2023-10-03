using Photon.Pun;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    private PhotonView _view;
    private Camera _camera;

    private void Awake()
    {
        _view = GetComponent<PhotonView>();
        _camera = FindObjectOfType<Camera>();
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0) && _view.IsMine)
        {
            Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            transform.position = new Vector3(transform.position.x, _camera.ScreenToWorldPoint(mousePosition).y, 0.0f);
        }
    }
}
