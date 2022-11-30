using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private WallGenerator _wallGenerator;
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private GameOverScreen _gameOverScreen;
    [SerializeField] private GameObject[] _lvl;

    private int _attemptCount;

    private void OnEnable()
    {
        _startScreen.PlayButtonClick += OnPlayButtonClick;
        _gameOverScreen.RestartButtonClick += OnRestartButtonClick;

        _player.GameOver += OnGameOver;
    }

    private void OnDisable()
    {
        _startScreen.PlayButtonClick -= OnPlayButtonClick;
        _gameOverScreen.RestartButtonClick -= OnRestartButtonClick;
        _player.GameOver -= OnGameOver;
    }

    private void Start()
    {
        if (PlayerPrefs.GetInt("Attempt") != 0)
            _attemptCount = PlayerPrefs.GetInt("Attempt");
        else
            _attemptCount = 0;

        Time.timeScale = 0;
        _startScreen.Open();

        foreach(var item in _lvl)
            item.SetActive(false);
    }

    private void OnPlayButtonClick()
    {
        _startScreen.Close();
        StartGame();
    }

    private void OnRestartButtonClick()
    {
        _gameOverScreen.Close();
        _wallGenerator.ResetPool();
        StartGame();
    }

    private void StartGame()
    {
        _player.transform.gameObject.SetActive(true);

        Time.timeScale = 1;
        _player.ResetPlayer();
        _player.StartTimerAddSpeed();
        _player.StartTimer();

        foreach (var item in _lvl)
            item.SetActive(true);
    }

    public void OnGameOver()
    {
        Time.timeScale = 0;
        _gameOverScreen.Open();
        _player.StopTimerAddSpeed();
        _player.StopTimer();

        PlayerPrefs.SetInt("Attempt", _attemptCount += 1);

        _player.transform.gameObject.SetActive(false);

        foreach (var item in _lvl)
            item.SetActive(false);
    }
}
