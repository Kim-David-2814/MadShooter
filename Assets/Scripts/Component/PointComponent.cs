using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.Component
{
    public class PointComponent : MonoBehaviour
    {
        [SerializeField] private Text _scoreText;
        private int _score = 0;

        private void Start()
        {
            UpdateScoreText();
        }

        public void AddScore(int amount)
        {
            _score += amount;
            UpdateScoreText();
        }

        private void UpdateScoreText()
        {
            if (_scoreText != null)
            {
                _scoreText.text = _score.ToString();
            }
        }
    }
}