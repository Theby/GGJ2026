using UnityEngine;

namespace GGJ2026.Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

        [SerializeField] InputManager inputManager;
        [SerializeField] MaskManager maskManager;
        [SerializeField] CanvasManager canvasManager;

        public InputManager InputManager => inputManager;
        public MaskManager MaskManager => maskManager;
        public CanvasManager CanvasManager => canvasManager;

        void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}