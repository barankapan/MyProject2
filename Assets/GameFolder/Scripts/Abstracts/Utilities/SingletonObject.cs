using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using Component = System.ComponentModel.Component;

namespace MyProject2.Abstracts.Utilities
{
    public abstract class SingletonObject<T> : MonoBehaviour 
    {
        public static T Instance { get; private set; }

        protected void SingletonThisObject(T entity) {
            if (Instance==null)
            {
                Instance = entity;
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
    }
}

