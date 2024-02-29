using MyProject2.Abstracts.Utilities;
using MyProject2.Controllers;
using MyProject2.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Random = UnityEngine.Random;

namespace MyProject2.Managers
{
    public class EnemyManager : SingletonObject<EnemyManager>
    {
        [SerializeField] float _addDelayTime = 50f;
        [SerializeField] EnemyController[] _enemyPrefabs;
        
       Dictionary<EnemyEnum, Queue<EnemyController>>  _enemyControllers = new Dictionary<EnemyEnum, Queue<EnemyController>>();

        public float AddDelayTime => _addDelayTime;

        public int Count => _enemyPrefabs.Length;

        float _moveSpeed;

        void Awake()
        {
            SingletonThisObject(this);
        }
       void Start()
        {
            InitializePool();
        }
      
       void InitializePool()
        {

            for (int i = 0; i < _enemyPrefabs.Length; i++)
            {
                Queue<EnemyController> enemyControllers = new Queue<EnemyController>();
                for (int j = 0; j < 10; j++)
                {

                    EnemyController newEnemy = Instantiate(_enemyPrefabs[i]);
                    newEnemy.gameObject.SetActive(false);
                    newEnemy.transform.parent = this.transform;
                    enemyControllers.Enqueue(newEnemy);
                   



                }
                _enemyControllers.Add((EnemyEnum)i, enemyControllers);
            }
           
        }
        public void SetPool(EnemyController enemyController)
        {   enemyController.gameObject.SetActive(false);
            enemyController.transform.parent = this.transform;

            Queue<EnemyController> enemyControllers = _enemyControllers[enemyController.EnemyType];
            enemyControllers.Enqueue(enemyController);
            //havuza eklemek
        }
        public EnemyController GetPool(EnemyEnum enemyType) {
            Queue<EnemyController> enemyControllers = _enemyControllers[enemyType];

            if (enemyControllers.Count==0)
            {
                for (int i = 0; i < 2; i++)
                {
                    EnemyController newEnemy = Instantiate(_enemyPrefabs[(int)enemyType]);
                    newEnemy.gameObject.SetActive(false);
                    enemyControllers.Enqueue(newEnemy);

                }
        

            }
            EnemyController enemyController= enemyControllers.Dequeue();
            enemyController.SetMoveSpeed(_moveSpeed);
            return enemyController ;
        }

        public  void SetMoveSpeed(float moveSpeed)
        {
          _moveSpeed= moveSpeed;
        }
        // havuzdan çýkarmak
        public void SetAddDelayTime(float addDelayTime)
        {
            _addDelayTime = addDelayTime;
        }
    }
}

