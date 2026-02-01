using DamageNumbersPro;
using TMPro;
using UnityEngine;

namespace GGJ2026.UI
{
    public class ScoreUI : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI scoreText;
        [SerializeField] DamageNumber damageNumberGUIPrefab;

        public int CurrentScore { get; private set; } = 0;

        void Awake()
        {
            scoreText.text = CurrentScore.ToString();
        }

        public void AddScore(int score)
        {
            var floatingNumber = Instantiate(damageNumberGUIPrefab, transform);
            floatingNumber.number = score;
            CurrentScore += score;
            scoreText.text = CurrentScore.ToString();
        }
    }
}