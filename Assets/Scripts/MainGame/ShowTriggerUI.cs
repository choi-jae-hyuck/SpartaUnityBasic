using System;
using UnityEngine;

namespace MainGame
{
    public class ShowTriggerUI : MonoBehaviour
    {
        public GameObject UI;

        private void Awake()
        {
            UI.SetActive(false);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            UI.SetActive(true);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            UI.SetActive(false);
        }
    }
}
