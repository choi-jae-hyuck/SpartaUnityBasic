using UnityEngine;

namespace MainGame
{
    public class AnimationHandler : MonoBehaviour
    {
        private static readonly int IsMoving = Animator.StringToHash("IsMove");
        private static readonly int MoveX = Animator.StringToHash("MoveX");
        private static readonly int MoveY = Animator.StringToHash("MoveY");

        protected Animator animator;

        protected virtual void Awake()
        {
            animator = GetComponentInChildren<Animator>();
        }

        public void Move(Vector2 obj)
        {
            animator.SetBool(IsMoving, obj.magnitude > .5f);

            if (Mathf.Abs(obj.x) != 0)
            {
                obj.y = 0;
            }
            else if (Mathf.Abs(obj.y) != 0)
            {
                obj.x = 0;
            }
            
            animator.SetFloat(MoveX, obj.x);
            animator.SetFloat(MoveY, obj.y);
        }
    }
}