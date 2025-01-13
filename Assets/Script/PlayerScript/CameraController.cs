using UnityEngine;

namespace Script
{
    public class CameraController : MonoBehaviour
    {
        //Room camera
        [SerializeField] private float speed;
         private float _currentPosX;
        // private Vector2 _velocity = Vector2.zero;

        //Follow player
        [SerializeField] private Transform player;
        [SerializeField] private float headDistance;
        [SerializeField] private float cameraSpeed;
        private float _lookHead;


        // Update is called once per frame
        void Update()
        {
            //Room camera
            // transform.position = Vector2.SmoothDamp(transform.position,
            //     new Vector2(_currentPosX, transform.position.y), ref _velocity, speed * Time.deltaTime);
            transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
            _lookHead = Mathf.Lerp(_lookHead, (headDistance * player.localScale.x), cameraSpeed * Time.deltaTime);
        }

        public void MoveToNewRoom(Transform newRoom)
        {
            _currentPosX = newRoom.position.x;
        }
    }
}