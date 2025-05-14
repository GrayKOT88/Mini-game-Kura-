using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Animator _playerAnim;

    private float _speed = 11;
    private float _oldMousePositionX;
    private float _eulerY;
    private bool _isGameOver = false;
    private float _yRange = 0.03f;

    public void SetGameOver(bool value) => _isGameOver = value;

    private void Update()
    {
        if (_isGameOver) return;
        HandleMovement();
    }

    private void HandleMovement()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _oldMousePositionX = Input.mousePosition.x;
        }

        if (Input.GetMouseButton(0))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * _speed);
            float deltaX = Input.mousePosition.x - _oldMousePositionX;
            _oldMousePositionX = Input.mousePosition.x;
            _eulerY += deltaX;
            transform.eulerAngles = new Vector3(0, _eulerY, 0);
            _playerAnim.SetFloat("Speed_f", 1);

            if(transform.position.y < _yRange)
            {
                transform.position = new Vector3(transform.position.x, _yRange, transform.position.z);
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            _playerAnim.SetFloat("Speed_f", 0);
        }
    }
}
