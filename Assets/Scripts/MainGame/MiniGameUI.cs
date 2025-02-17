using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MainGame
{
    public class MiniGameUI : MonoBehaviour
    {
        public Button test1;
        public Button test2;


        private void Start()
        {
            test1.onClick.AddListener(testMiniGame1);
            test2.onClick.AddListener(testMiniGame2);
        }

        private void testMiniGame1()
        {
            SceneManager.LoadScene("Mini_FlapPlane");
        }

        private void testMiniGame2()
        {
            SceneManager.LoadScene("Mini_Stack");
        }
    }
}
