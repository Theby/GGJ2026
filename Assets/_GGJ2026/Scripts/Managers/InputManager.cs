using GGJ.Input;
using UnityEngine;

namespace GGJ2026.Managers
{
    public class InputManager : MonoBehaviour
    {
        public InputSystem_Actions Actions { get; private set; }

        void Awake()
        {
            Actions = new InputSystem_Actions();
        }

        void OnEnable()
        {
            EnablePlayerInput();
        }

        void OnDisable()
        {
            DisableAllInput();
        }

        void OnDestroy()
        {
            Actions?.Dispose();
        }

        public void EnablePlayerInput()
        {
            Actions.UI.Disable();
            Actions.Player.Enable();
        }

        public void EnableUIInput()
        {
            Actions.Player.Disable();
            Actions.UI.Enable();
        }

        public void DisableAllInput()
        {
            Actions.Player.Disable();
            Actions.UI.Disable();
        }
    }
}