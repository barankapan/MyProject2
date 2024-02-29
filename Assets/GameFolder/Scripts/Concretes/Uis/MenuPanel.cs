using MyProject2.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyProject2.Uis
{
    public class MenuPanel : MonoBehaviour
    {
        public void SelectAndStartButton(int index)
        {
               GameManager.Instance.DifficultyIndex = index;
               GameManager.Instance.LoadScene("MyProject2");
        }
        public void ExitButton () 
        {
            GameManager.Instance.ExitGame();
        }

    }

}
