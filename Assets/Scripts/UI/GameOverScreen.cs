using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class GameOverScreen : Screen
{
    [SerializeField] private TextMeshProUGUI _timeRace;
    [SerializeField] private TextMeshProUGUI _score;
    [SerializeField] private TextMeshProUGUI _numberAttempts;
    [SerializeField] private Player _palyer;

    public event UnityAction RestartButtonClick;

    public override void Close()
    {
        CanvasGroup.alpha = 0;
        Button.interactable = false;
    }

    public override void Open()
    {    
        CanvasGroup.alpha = 1;
        Button.interactable = true;
        _timeRace.text = "Время : " + _palyer.RaceTime + " сек.";
        _score.text = "Счет : " + _palyer.Score;
        _numberAttempts.text = "Попытка № " + PlayerPrefs.GetInt("Attempt").ToString();
    }

    protected override void OnButtonClick()
    {
        RestartButtonClick?.Invoke();
    }
}
