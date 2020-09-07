using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneContoller : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    private GameObject _enemy;

    void Update()
    {
        if (_enemy == null)
        {
            _enemy = Instantiate(enemyPrefab) as GameObject;
            _enemy.transform.position = new Vector3(2, 3, 0);
            float _angle = Random.Range(0, 360);
            _enemy.transform.Rotate(0, _angle, 0);
        }
    }
}
