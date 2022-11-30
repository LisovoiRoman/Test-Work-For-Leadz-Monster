using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    private PlayerMover _playerMover;

    private int _score;

    private int _raceTime;

    public int RaceTime => _raceTime;

    public int Score => _score;

    public event UnityAction GameOver;

    private void Start()
    {
        _raceTime = 0;
        _score = 0;

        _playerMover = GetComponent<PlayerMover>();

        transform.gameObject.SetActive(false);
    }

    public void IncreaseScore(int value)
    {
        _score += value;
    }

    public void StartTimerAddSpeed()
    {
        _playerMover.StartTimerAddSpeed();
    }

    public void StopTimerAddSpeed()
    {
        _playerMover.StopTimerAddSpeed();
    }

    public void ResetPlayer()
    {
        _playerMover.ResetPlayer();
        _score = 0;
        _raceTime = 0;
    }

    public void Die()
    {
        GameOver?.Invoke();
    }

    public void StartTimer()
    {
        StartCoroutine(RiceTimer());
    }

    public void StopTimer()
    {
        StopAllCoroutines();
    }

    private IEnumerator RiceTimer()
    {
        while(true)
        {
            yield return new WaitForSeconds(1);

            _raceTime += 1;
        }
        
    }
}
