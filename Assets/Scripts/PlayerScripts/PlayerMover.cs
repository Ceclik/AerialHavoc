using Photon.Pun;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float maxYPosition;
    [SerializeField] private float minYPosition;
    
    private PhotonView _view;
    private Camera _camera;
    private bool _isMobile;

    private Vector3 _startPlayerPosition;
    private Vector2 _startTouchPosition;
    private Vector2 _currentTouchPosition;
    private float _deltaYTouchPosition;

    private void Awake()
    {
        _isMobile = Application.isMobilePlatform;
        _view = GetComponent<PhotonView>();
        _camera = FindObjectOfType<Camera>();
    }

    private void Update()
    {
        if (_isMobile)
            MoveUsingTouch();
        else
            MoveUsingMouse();
    }

    private void MoveUsingMouse()
    {
        if (Input.GetMouseButtonDown(0) && _view.IsMine)
            BeganPhase();
        else if (Input.GetMouseButton(0) && _view.IsMine)
            MovePhase();
        if (Input.GetMouseButtonUp(0) && _view.IsMine)
            EndPhase();
    }

    private void MoveUsingTouch()
    {
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began && _view.IsMine)
                BeganPhase();
            else if(Input.GetTouch(0).phase == TouchPhase.Moved && _view.IsMine)
                MovePhase();
            if(Input.GetTouch(0).phase == TouchPhase.Ended && _view.IsMine)
                EndPhase();
        }
    }

    private void BeganPhase()
    {
        _currentTouchPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        _startTouchPosition = _currentTouchPosition;
        _startPlayerPosition = transform.position;
    }

    private void MovePhase()
    {
        _currentTouchPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        if (_camera.ScreenToWorldPoint(_currentTouchPosition).x < 6)
        {
            _deltaYTouchPosition = _camera.ScreenToWorldPoint(_currentTouchPosition).y -
                                   _camera.ScreenToWorldPoint(_startTouchPosition).y;
            float newYPosition = _startPlayerPosition.y + _deltaYTouchPosition;
            if(newYPosition <= maxYPosition && newYPosition >= minYPosition)
                transform.position =
                    new Vector3(transform.position.x, newYPosition, 0.0f);
        }
    }

    private void EndPhase()
    {
        _startPlayerPosition = Vector3.zero;
        _currentTouchPosition = Vector2.zero;
        _startTouchPosition = Vector2.zero;
        _deltaYTouchPosition = 0;
    }
}
