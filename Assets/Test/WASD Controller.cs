using UnityEngine;
using UnityEngine.InputSystem;

public class WASDController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    private Vector2 movementInput;

    private void Update()
    {
        transform.position += speed * Time.deltaTime * (Vector3)movementInput;
    }

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }
}
