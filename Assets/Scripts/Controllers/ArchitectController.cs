using UnityEngine;
using UnityEngine.InputSystem;

public class ArchitectController : MonoBehaviour
{
    private GameInputActions.ArchitectActions architectActions;

    private void Start()
    {
        architectActions = InputManager.Instance.GetGameInputActions().Architect;

        architectActions.PlaceTile.performed += OnPlaceTile;
        architectActions.SelectTile.performed += OnSelectTile;
        architectActions.TriggerTrap.performed += OnTriggerTrap;
    }

    private void OnPlaceTile(InputAction.CallbackContext context)
    {
        Debug.Log("Architect placed a tile.");
    }

    private void OnSelectTile(InputAction.CallbackContext context)
    {
        Debug.Log("Architect selected a tile.");
    }

    private void OnTriggerTrap(InputAction.CallbackContext context)
    {
        Debug.Log("Architect triggered a trap.");
    }

    private void Update()
    {
        Vector2 cursorMove = architectActions.CursorMove.ReadValue<Vector2>();
        // Logic to move the architect's cursor based on cursorMove
    }
}
