using System;
using Enemy;
using TMPro;
using UnityEngine;

namespace UI
{
        public class ScoreController : MonoBehaviour
        {
                [SerializeField] private TextMeshProUGUI scoreTextBox;

                private void Reset()
                {
                       // scoreTextBox ??= transform.Find("Value").GetComponent<TextMeshProUGUI>();
                        // scoreTextBox.text = (startingGoldbyLevel.lvl1).ToString();
                }

                private void Start()
                {
                        scoreTextBox.text = Convert.ToString((int) startingGoldbyLevel.lvl1);
                }

                private void OnEnable()
                {
                        EnemyController.OnDeath += UpdateScore;
                }

                private void OnDisable()
                {
                        EnemyController.OnDeath -= UpdateScore;
                }

                private void UpdateScore(int value)
                {
                        scoreTextBox.text = (int.Parse(scoreTextBox.text) + value).ToString();
                }
        }
}