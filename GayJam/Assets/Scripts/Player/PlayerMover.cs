using Player.Configs;
using UnityEngine;

namespace Player
{
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField] private PlayerConfig _playerConfig;
        [SerializeField] private Rigidbody2D _rigidbody2D;
        
        private InputSystem_Actions _inputSystemActions;
        private Vector2 _direction;
        
        public void Awake()
        {
            _inputSystemActions = new InputSystem_Actions();
        }

        private void OnEnable()
        {
            _inputSystemActions.Enable();
        }

        private void OnDisable()
        {
            _inputSystemActions.Disable();
        }

        private void Update()
        {
            _direction = _inputSystemActions.Player.Move.ReadValue<Vector2>();
        }

        private void FixedUpdate()
        {
            _rigidbody2D.MovePosition(_rigidbody2D.position + _direction * _playerConfig.Speed * Time.fixedDeltaTime);
        }
    }
}