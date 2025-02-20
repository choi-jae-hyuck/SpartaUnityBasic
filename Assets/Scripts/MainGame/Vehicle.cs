using System;
using UnityEngine;

namespace MainGame
{
    public class Vehicle : MonoBehaviour
    {
        private bool IsRide = false;
        private bool IsTriggerIn = false;
        [SerializeField]private GameObject gridCar;
        [SerializeField] private GameObject player;
        private PlayerController playerController;
        private AnimationHandler animationHandler;

        private void Awake()
        {
            playerController = player.GetComponent<PlayerController>();
            animationHandler = player.GetComponent<AnimationHandler>();
        }

        private void RideCar()
        {
            IsRide = true;
            gridCar.gameObject.SetActive(false);
            playerController.ChangeSpeed(10);
            animationHandler.Car();
        }

        private void OnTriggerStay2D(Collider2D other)
        {
           
            if (other.gameObject.CompareTag("Player"))
            {
                IsTriggerIn = true;
            }
            if(other.gameObject.CompareTag("BackGround"))
                return;
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
                IsTriggerIn = false;
        }
        

        private void Update()
        {
            if (!IsRide && Input.GetKeyDown(KeyCode.F) && IsTriggerIn)
            {
                RideCar();
            }
            
            if (IsRide && Input.GetKeyDown(KeyCode.V))
            {
                IsRide = false;
                gridCar.gameObject.SetActive(true);
                playerController.ChangeSpeed(5);
                gameObject.transform.position = player.transform.position;
                animationHandler.Car();
            }
        }
    }
}
