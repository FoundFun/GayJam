using Unity.Cinemachine;
using UnityEngine;

namespace Mini_Games.Running
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private RunningConfig _config;
        [SerializeField] private RunningGameManager _manager;
        [SerializeField] private LayerMask _ground;
        [SerializeField] private CinemachineCamera _camera;

        private float _speed;
        private float _speedIncreaseRate;
        private float _jumpForce;

        private Rigidbody2D _rigidbody;
        private Collider2D _collider;

        private bool _isGrounded;
        private bool _isFinished;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _collider = GetComponent<Collider2D>();

            _isFinished = false;
            _speed = _config.Speed;
            _speedIncreaseRate = _config.SpeedIncreaseRate;
            _jumpForce = _config.JumpForce;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Finish"))
            {
                _camera.Follow = null;            
            }

            if (other.CompareTag("StopPoint"))
            {
                _isFinished = true;
                _manager.EndMiniGame();
            }

            if (other.CompareTag("GoodStuff"))
            {
                _manager.AddPoints(_config.GoodStuffPoints);
                Destroy(other.gameObject);
            }

            if (other.CompareTag("BadStuff"))
            {
                _manager.DecreasePoints(_config.BadStuffPoints);
                Destroy(other.gameObject);
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) & _isGrounded)
                Jump();
        }

        private void FixedUpdate()
        {
            if (_isFinished)
            {
                _rigidbody.velocity = Vector2.zero;
            }
            else
            {
                _speed += _speedIncreaseRate;
                _rigidbody.velocity = new Vector2(_speed, _rigidbody.velocity.y);

                IsTouchingGround();           
            }
        }

        private bool IsTouchingGround() =>
            _isGrounded = Physics2D.IsTouchingLayers(_collider, _ground);

        private void Jump() =>
            _rigidbody.velocity = new Vector2(_rigidbody.velocityX, _jumpForce);
    }
}
