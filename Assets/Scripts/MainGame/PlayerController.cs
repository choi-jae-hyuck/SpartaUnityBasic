using FlapPlane;
using UnityEngine;

namespace MainGame
{
    public class PlayerController : BaseController
    {
        private Camera _camera;

        protected override void Start()
        {
            base.Start();
            _camera = Camera.main;
        }
        protected override void HandleAction()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            movementDirection = new Vector2(horizontal, vertical).normalized;
            
            Vector2 mousePosition = Input.mousePosition;
            Vector2 wolrdPos = _camera.ScreenToWorldPoint(mousePosition);
            lookDirection = wolrdPos - (Vector2)transform.position;

            if (lookDirection.magnitude < 0.9f)
            {
                lookDirection = Vector2.zero;
            }
            else
            {
                lookDirection = lookDirection.normalized;
            }
        }
    }
}
