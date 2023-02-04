using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Root
{
    public class PlayerController : MonoBehaviour
    {
        private Vector3 move;
        Vector3 forward;
        Vector3 right;
        [SerializeField] Transform model;
        [SerializeField] float moveSpeed;
        [SerializeField] float runSpeed = 2f;
        Transform player;
        [SerializeField] float rootLength = 5;
        [SerializeField] Transform root;

        private void Awake()
        {
            move = new Vector3();
            player = this.transform;
        }

        private void FixedUpdate()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            bool isRun = Input.GetKey(KeyCode.LeftShift);

            move.Set(horizontal, vertical, move.z);
            var speed = Mathf.Sqrt((horizontal * horizontal) + ((vertical * vertical)));

            Vector3 CameraModeDirection = TransformJoystickSpace(Camera.main.transform);
            var goPos = player.position + CameraModeDirection;

            //轉向 只轉模型
            model.forward = Vector3.Slerp(model.forward, CameraModeDirection, 0.3f);


            MoveTo(goPos, isRun, speed);
        }


        //以攝像頭的forward為前方
        Vector3 TransformJoystickSpace(Transform camera)
        {
            forward.Set(camera.forward.x, 0, camera.forward.z);
            right.Set(camera.right.x, 0, camera.right.z);

            forward = Vector3.Normalize(forward);
            right = Vector3.Normalize(right);

            forward *= move.y;
            right *= move.x;

            return forward + right;
        }

        void MoveTo(Vector3 target, bool isRun, float speed)
        {
            if (player.position.Equals(target))
                return;

            float runAddition = isRun ? runSpeed : 1;
            player.position = Vector3.MoveTowards(player.position, target, speed * moveSpeed * runAddition);
            RopeRestriction();

        }

        public void SetRoot(Transform root)
        {
            this.root = root;
        }

        void RopeRestriction()
        {
            Vector3 direction = player.position - root.position;
            float distance = direction.magnitude;

            if (distance > rootLength)
            {
                player.position = root.position + direction.normalized * rootLength;
            }


        }
    }
}