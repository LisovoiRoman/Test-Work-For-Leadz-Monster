using UnityEngine;

public class PlayerTracker : MonoBehaviour
{
    [SerializeField] private Player _player;

    [SerializeField] private float _xOffset;

    private void Update()
    {
        if(Time.timeScale != 0)
        transform.position = new Vector3(_player.transform.position.x - _xOffset, transform.position.y, transform.position.z);
    }
}
