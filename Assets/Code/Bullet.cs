using UnityEngine;
using System.Collections.Generic;

public class Bullet : MonoBehaviour
{
    private GameObject _prefab = null;
    private List<GameObject> _bullet = null;
    void Start()
    {
        _prefab = Resources.Load<GameObject>("Bullet");
    }

    void Update()
    {
        
    }

    public void CreateBullet(Vector3 position, Quaternion rotation)
    {
        _bullet.Add(GameObject.Instantiate<GameObject>(_prefab, position, rotation));
    }
}
