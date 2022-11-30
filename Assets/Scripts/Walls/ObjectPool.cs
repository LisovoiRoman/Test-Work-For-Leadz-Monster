using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private int _capacity;

    private Camera _camera;

    private List<GameObject> _pool = new List<GameObject>();

    protected void Initialize(GameObject prefab)
    {
        _camera = Camera.main;

        for(int i = 0; i < _capacity; i++)
        {
            GameObject spawned = Instantiate(prefab, _container.transform);

            _pool.Add(spawned);
        }
    }

    protected bool TryGetObject(out GameObject rezult)
    {
        rezult = _pool.FirstOrDefault(p => p.activeSelf == false);

        return rezult != null;
    }

    protected void DisableObjectAbroadScreen()
    {
        foreach(var item in _pool)
        {
            if(item.activeSelf == true)
            {
                Vector3 point = _camera.WorldToScreenPoint(item.transform.position);
                if (point.x < -100)
                    item.SetActive(false);
            }
        }
    }

    public void ResetPool()
    {
        foreach (var item in _pool)
            item.SetActive(false);
    }
}
