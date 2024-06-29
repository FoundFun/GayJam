using DG.Tweening;
using GlobalComponents;
using UnityEngine;
using UnityEngine.InputSystem;
using Action = System.Action;

namespace Mini_Games.BenchPress
{
    public class BenchPressBar : MonoBehaviour
    {
        [SerializeField] private GameObject _point;
        [SerializeField] private GameObject _startPoint;
        [SerializeField] private GameObject _endPoint;
        [SerializeField] private float _time = 1;
        [SerializeField] private LayerMask _batTypeMask;

        private InputSystem_Actions _inputSystemActions;
        private Tweener _tweener;

        public event Action NextBar;

        private void Awake()
        {
            _inputSystemActions = new InputSystem_Actions();
        }

        private void OnEnable()
        {
            _inputSystemActions.Enable();
            _inputSystemActions.Player.BenchPress.canceled += OnBenchPress;
            
            StartPingPong(_startPoint.transform.localPosition.x, _endPoint.transform.localPosition.x + 0.1f);
        }

        private void OnDisable()
        {
            _tweener.Kill();
            
            _inputSystemActions.Player.BenchPress.canceled -= OnBenchPress;
            _inputSystemActions.Disable();
        }

        private void StartPingPong(float from, float to)
        {
            _tweener = _point.transform.DOLocalMoveX(to, _time).OnComplete(() => StartPingPong(to, from));
        }

        private void OnBenchPress(InputAction.CallbackContext obj)
        {
            Collider2D overlapBox = Physics2D.OverlapCircle(_point.transform.position, 0.5f, _batTypeMask);
            
            if (overlapBox != null)
            {
                if (overlapBox.TryGetComponent(out BarType barType))
                {
                    Score.BenchPressScore += barType.Score;
                    OnDisable();
                    NextBar?.Invoke();
                    Debug.Log(barType.Score);
                }
            }
        }
    }
}