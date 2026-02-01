using System.Collections.Generic;
using GGJ2026.Data;
using UnityEngine;

namespace GGJ2026.Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

        [SerializeField] InputManager inputManager;
        [SerializeField] MaskManager maskManager;
        [SerializeField] CanvasManager canvasManager;
        [SerializeField] ClientManager clientManager;
        [SerializeField] TransactionManager transactionManager;
        [SerializeField] SpriteRenderer characterSpriteRenderer;
        public InputManager InputManager => inputManager;
        public MaskManager MaskManager => maskManager;
        public CanvasManager CanvasManager => canvasManager;
        public ClientManager ClientManager => clientManager;
        public TransactionManager TransactionManager =>  transactionManager;

        public MaskColor CurrentMaskColor { get; set; } = MaskColor.None;
        public MaskMaterial CurrentMaskMaterial { get; set; } = MaskMaterial.Wood;

        int currentClient = -1;

        void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
        }

        void Start()
        {
            canvasManager.OnSell += OnMaskSell;
            SetNextClient();
        }

        void OnMaskSell(CompleteMask craftedMask)
        {
            transactionManager.CraftedMask = craftedMask;

            int scoreReward = (int)transactionManager.CalculateReward();
            canvasManager.SetScore(scoreReward);

            SetNextClient();
        }

        public List<MaskPart> GetMaskParts(MaskPartType type)
        {
            return maskManager.GetMaskParts(type, CurrentMaskColor, CurrentMaskMaterial);
        }

        void SetNextClient()
        {
            currentClient++;
            if (currentClient >= clientManager.ShopClients.Length)
            {
                canvasManager.ShowGameOver();
                return;
            }

            var character = clientManager.ShopClients[currentClient];
            transactionManager.CurrentClient = character;
            transactionManager.CraftedMask = null;

            canvasManager.SetCharacter(character);
            characterSpriteRenderer.sprite = character.Sprite;
        }
    }
}