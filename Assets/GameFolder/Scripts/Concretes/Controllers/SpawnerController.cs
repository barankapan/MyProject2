using MyProject2.Enums;
using MyProject2.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MyProject2.Controllers
{
    public class SpawnerController : MonoBehaviour
    {
        
        
        [Range(0.1f, 5f)][SerializeField] float _min = 0.1f;
        [Range(0.1f, 15f)][SerializeField] float _max = 15f;


        float _maxSpawnLife;

        float _currentSpawnLife = 0f ;
        int _index = 0;
        float _maxAddEnemyTime;
        public bool CanIncrease => _index < EnemyManager.Instance.Count;
        private void OnEnable()
        {
            GetRandomMaxTime();
        }
        private void Update()
        {
            _currentSpawnLife += Time.deltaTime;
            if (_currentSpawnLife > _maxSpawnLife)
            {
                Spawn();
            }
            if (!CanIncrease) return;
            if (_maxAddEnemyTime < Time.time)
            {
                _maxAddEnemyTime = Time.time + EnemyManager.Instance.AddDelayTime;
                IncreaseIndex();
            }

        }
        void Spawn()
        {
           
            EnemyController newEnemy = EnemyManager.Instance.GetPool((EnemyEnum)Random.Range(0,_index));
            newEnemy.transform.parent = transform;
            newEnemy.transform.position = this.transform.position;
            newEnemy.gameObject.SetActive(true);
            _currentSpawnLife = 0f;
            GetRandomMaxTime();
        }
        private void GetRandomMaxTime()
        {
            _maxSpawnLife = Random.Range(_min, _max);
        }

        private void IncreaseIndex()
        {
            if (CanIncrease)
            {
                _index++;
            }
        }

    }
}

