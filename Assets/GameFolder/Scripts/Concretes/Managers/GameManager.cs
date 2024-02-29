using MyProject2.Abstracts.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using MyProject2.ScriptableObjects;

namespace MyProject2.Managers
{
    public class GameManager : SingletonObject<GameManager>

    {
        [SerializeField] LevelDifficulty[] _levelDifficulty;
        public event System.Action OnGameStop;
        public LevelDifficulty LevelDifficulty => _levelDifficulty[DifficultyIndex];
        int _difficultyIndex;

        public int DifficultyIndex { get => _difficultyIndex;
            set
            {
                if (_difficultyIndex<0 || _difficultyIndex>_levelDifficulty.Length)
                {
                    LoadSceneAsync("Menu");
                }
                else
                {
                    _difficultyIndex = value;
                }
            } }
       
        void Awake()
        {
            SingletonThisObject(entity :this);
        }
        public void StopGame()
        {
            Time.timeScale = 0;
            OnGameStop?.Invoke();

        }
        public void LoadScene(string sceneName)
        {
            
            StartCoroutine(LoadSceneAsync(sceneName));
        }
        private IEnumerator LoadSceneAsync(string sceneName)
        { 
            Time.timeScale = 1f;
            yield return SceneManager.LoadSceneAsync(sceneName);
        }
        public void ExitGame ()
        {
            Debug.Log("exit clicked");
            Application.Quit();
        }
    }
}

