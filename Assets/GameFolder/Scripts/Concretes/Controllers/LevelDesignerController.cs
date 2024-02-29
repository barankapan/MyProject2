using MyProject2.Managers;
using MyProject2.ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyProject2.Controllers
{
    public class LevelDesignerController : MonoBehaviour
    {
        LevelDifficulty _levelDifficulty;
        private void Awake()
        {
            _levelDifficulty = GameManager.Instance.LevelDifficulty;
        }
        private void Start()
        {
            RenderSettings.skybox = _levelDifficulty.SkyboxMaterial;
            Instantiate(_levelDifficulty.FloorPrefab);
            Instantiate(_levelDifficulty.SpawnersPrefab);
            EnemyManager.Instance.SetMoveSpeed(_levelDifficulty.MoveSpeed);
            EnemyManager.Instance.SetAddDelayTime(_levelDifficulty.AddDelayTime);


        }
    }

}
