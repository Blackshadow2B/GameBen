using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }

    private GameInputActions gameInputActions;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            gameInputActions = new GameInputActions();
            gameInputActions.Enable();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public GameInputActions GetGameInputActions()
    {
        return gameInputActions;
    }
}
