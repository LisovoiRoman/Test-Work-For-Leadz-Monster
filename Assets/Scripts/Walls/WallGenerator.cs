using UnityEngine;

public class WallGenerator : ObjectPool
{
    [SerializeField] private GameObject _template;
    [SerializeField] private float _timeBetweenSpawn;
    [SerializeField] private float _maxSpawnPositionY;
    [SerializeField] private float _minSpawnPositionY;
    [SerializeField] private PlayerMover _playerMover;

    private float _elapsedTime = 0;

    private void Start()
    {
        Initialize(_template);
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if(_elapsedTime > _timeBetweenSpawn / _playerMover.Speed)
        {
            if(TryGetObject(out GameObject wall))
            {
                _elapsedTime = 0;

                float spawnPositionY = Random.Range(_minSpawnPositionY, _maxSpawnPositionY);
                Vector3 spawnPoint = new Vector3(transform.position.x, spawnPositionY, transform.position.z);
                wall.SetActive(true);
                wall.transform.position = spawnPoint;

                DisableObjectAbroadScreen();
            }
        }    
    }
}
