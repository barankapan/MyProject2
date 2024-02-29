using MyProject2.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyProject2.Uis
{
    public class GameOverPanel : MonoBehaviour
    {
        public void YesButton()
        {
            GameManager.Instance.LoadScene("MyProject2");
        }
        public void NoButton()
        {
            GameManager.Instance.LoadScene("Menu");
        }
    }
}


