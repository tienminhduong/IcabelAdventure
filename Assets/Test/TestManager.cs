using UnityEngine;
using UnityEngine.InputSystem;

public class TestManager : MonoBehaviour
{
    [SerializeField] private InputActionReference jump;

    [SerializeField] private GameObject rhinoPrefab;
    [SerializeField] private GameObject slimePrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnEnable()
    {
        jump.action.started += OnJumpAction;
    }

    private void OnJumpAction(InputAction.CallbackContext context)
    {
        Debug.Log("Jump action triggered!");
        ObjectPoolManager.SpawnObject(rhinoPrefab, Vector3.zero, Quaternion.identity);
        ObjectPoolManager.SpawnObject(slimePrefab, Vector3.left, Quaternion.identity);
    }
}
