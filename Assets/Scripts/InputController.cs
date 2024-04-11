using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    public static InputController Instance;


    public static CharacterInputActions InputActions;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        InputActions = new CharacterInputActions();
        InputActions.Enable();
    }

    private void OnEnable()
    {
        InputActions.Character.MoveDirection.started += MoveDirectionButton;
    }

    private void OnDisable()
    {
        InputActions.Character.MoveDirection.started -= MoveDirectionButton;
    }

    public event Action<Vector2> OnMoveDirectionButtonPerformedEvent;
    private void MoveDirectionButton(InputAction.CallbackContext context)
    {
        Vector2 direction = context.ReadValue<Vector2>();
        OnMoveDirectionButtonPerformedEvent?.Invoke(direction);
    }

}
