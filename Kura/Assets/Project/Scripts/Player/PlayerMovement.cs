using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Animator playerAnim;

    private float oldMousePositionX;
    private float eulerY;
    private bool isGameOver = false;

    public void SetGameOver(bool value) => isGameOver = value;

    private void Update()
    {
        if (isGameOver) return;
        HandleMovement();
    }

    private void HandleMovement()
    {
        if (Input.GetMouseButtonDown(0))
        {
            oldMousePositionX = Input.mousePosition.x;
        }

        if (Input.GetMouseButton(0))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            float deltaX = Input.mousePosition.x - oldMousePositionX;
            oldMousePositionX = Input.mousePosition.x;
            eulerY += deltaX;
            transform.eulerAngles = new Vector3(0, eulerY, 0);
            playerAnim.SetFloat("Speed_f", 1);
        }

        if (Input.GetMouseButtonUp(0))
        {
            playerAnim.SetFloat("Speed_f", 0);
        }
    }
}
