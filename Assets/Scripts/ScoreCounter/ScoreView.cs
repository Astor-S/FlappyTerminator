using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private ScoreCounter _scoreCounter;
    [SerializeField] private TextMeshProUGUI _scoreText;

    private void OnEnable()
    {
        _scoreCounter.ScoreChanged += UpdateView;
    }

    private void OnDisable()
    {
        _scoreCounter.ScoreChanged -= UpdateView;
    }

    private void UpdateView(int score)
    {
        _scoreText.text = "—чет: " + score;
    }
}