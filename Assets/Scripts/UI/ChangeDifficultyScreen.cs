using UnityEngine;

public class ChangeDifficultyScreen : MonoBehaviour
{
    [SerializeField] private PlayerMover _playerMover;
    private float _speed = 3;

    public float Speed => _speed;

    private void Start()
    {
        transform.gameObject.SetActive(false);
    }

    public void ClickButtonOpenScreen()
    {
        transform.gameObject.SetActive(true);
    }

    public void ClickButtonEasy()
    {
        _speed = 3;
        _playerMover.SetSpeed(_speed);
        transform.gameObject.SetActive(false);
    }

    public void ClickButtonMedium()
    {
        _speed = 6;
        _playerMover.SetSpeed(_speed);
        transform.gameObject.SetActive(false);
    }

    public void ClickButtonHard()
    {
        _speed = 10;
        _playerMover.SetSpeed(_speed);
        transform.gameObject.SetActive(false);
    }
}
