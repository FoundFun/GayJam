using Mini_Games;
using Player.Configs;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerSelect : MonoBehaviour
    {
        [SerializeField] private PlayerConfig _playerConfig;
        [SerializeField] private LayerMask _layerMiniGame;

        private InputSystem_Actions _inputSystemActions;

        private void Awake()
        {
            _inputSystemActions = new InputSystem_Actions();
        }

        private void OnEnable()
        {
            _inputSystemActions.Enable();
            _inputSystemActions.Player.SelectMiniGame.canceled += OnSelected;
        }

        private void OnDisable()
        {
            _inputSystemActions.Player.SelectMiniGame.canceled -= OnSelected;
            _inputSystemActions.Disable();
        }
        
        private void OnSelected(InputAction.CallbackContext obj)
        {
            Collider2D overlapCircle = Physics2D.OverlapCircle(transform.position, _playerConfig.RadiusSelect, _layerMiniGame);
            if (overlapCircle != null)
            {
                if (overlapCircle.gameObject.TryGetComponent(out MiniGame miniGame))
                {
                    miniGame.StartMiniGame();
                }
            }
        }
    }
}