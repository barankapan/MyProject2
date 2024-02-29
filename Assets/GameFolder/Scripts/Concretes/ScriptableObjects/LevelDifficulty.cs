using MyProject2.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MyProject2.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Level Difficulty", menuName = "Create Difficulty/Create New ", order = 1)]
    public class LevelDifficulty : ScriptableObject
    {
        [SerializeField] FloorController _floorPrefab;
        [SerializeField] GameObject _spawnersPrefab;
        [SerializeField] Material _skyboxMaterial;
        [SerializeField] float _moveSpeed;
        [SerializeField] float _addDelayTime = 50f;
        public FloorController FloorPrefab => _floorPrefab;
        public GameObject SpawnersPrefab => _spawnersPrefab;
        public Material SkyboxMaterial => _skyboxMaterial; 

        public float AddDelayTime => _addDelayTime;

        public float MoveSpeed => _moveSpeed;   
    }
}

