using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private Vector3 _startPosition;

    [SerializeField] private float _speed;

    [SerializeField] private float _forceTap;

    [SerializeField] private ChangeDifficultyScreen _changeDifficultyScreen;

    private Rigidbody2D _rigidbody2D;

    public float Speed => _speed;

    private void Start()
    {
        transform.localPosition = _startPosition;

        _rigidbody2D = GetComponent<Rigidbody2D>();

        ResetPlayer();
    }

    private void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    { 
        if (Time.timeScale != 0 && (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)))
        {
            _rigidbody2D.velocity = new Vector2(_speed, 0);
            _rigidbody2D.AddForce(Vector2.up * _forceTap, ForceMode2D.Force);
        }
    }

    public void ResetPlayer()
    {
        transform.position = _startPosition;
        _rigidbody2D.velocity = Vector2.zero;
        _speed = _changeDifficultyScreen.Speed;
    }

    public void SetSpeed(float value)
    {
        _speed = value;
    }

    public void StartTimerAddSpeed()
    {
        StartCoroutine(AddSpeed());
    }

    public void StopTimerAddSpeed()
    {
        StopAllCoroutines();
    }

    private IEnumerator AddSpeed()
    {
        while(true)
        {
            yield return new WaitForSeconds(2);
            _speed += 0.15f;
        }
    }
}
