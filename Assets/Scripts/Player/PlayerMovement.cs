using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float horizontalPadding = 0.5f;

    private Vector2 moveInput;
    private InputSystem_Actions controls;

    private float minX;
    private float maxX;

    private void Awake()
    {
        controls = new InputSystem_Actions();

        controls.Player.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        controls.Player.Move.canceled += ctx => moveInput = Vector2.zero;
    }

    private void OnEnable()
    {
        controls.Player.Enable();

        // Calculate screen edge bounds when enabled
        float cameraZ = transform.position.z - Camera.main.transform.position.z;
        Vector3 left = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, cameraZ));
        Vector3 right = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, cameraZ));

        minX = left.x + horizontalPadding;
        maxX = right.x - horizontalPadding;
    }

    private void OnDisable()
    {
        controls.Player.Disable();
    }

    void Update()
    {
        Vector3 movement = new Vector3(moveInput.x, 0f, 0f);
        Vector3 newPosition = transform.position + movement * moveSpeed * Time.deltaTime;

        // Clamp the X position to screen bounds
        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);

        transform.position = newPosition;
    }
}
