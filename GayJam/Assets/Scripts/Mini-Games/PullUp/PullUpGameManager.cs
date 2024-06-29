using System.Collections;
using GlobalComponents;
using Player;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Mini_Games.PullUp
{
    public class PullUpGameManager : MonoBehaviour
    {
        [SerializeField] private TMP_Text _points;
        [SerializeField] private TMP_Text _timer;
        [SerializeField] private PullUpConfig _config;
        [SerializeField] private PlayerMover _playerMover;

        private InputSystem_Actions _inputSystemActions;
        private float _remainingTime;
        private bool _isStopGame;

        private void Awake()
        {
            _inputSystemActions = new InputSystem_Actions();
        }

        private void OnEnable()
        {
            Reset();
            
            _playerMover.gameObject.SetActive(false);
            
            switch ((Complication)Score.CurrentDay)
            {
                case Complication.Day1:
                    _remainingTime = _config.TimerDurationDay1;
                    break;
                case Complication.Day2:
                    _remainingTime = _config.TimerDurationDay2;
                    break;
                case Complication.Day3:
                    _remainingTime = _config.TimerDurationDay3;
                    break;
                case Complication.Day4:
                    _remainingTime = _config.TimerDurationDay4;
                    break;
                case Complication.Day5:
                    _remainingTime = _config.TimerDurationDay5;
                    break;
                case Complication.Day6:
                    _remainingTime = _config.TimerDurationDay6;
                    break;
                case Complication.Day7:
                    _remainingTime = _config.TimerDurationDay7;
                    break;
            }

            UpdatePoints();
            UpdateRemainingTime();
            
            _inputSystemActions.Enable();
            _inputSystemActions.Player.PullUp.canceled += OnPullUp;
        }

        private void OnDisable()
        {
            _playerMover.gameObject.SetActive(true);
            
            _inputSystemActions.Player.PullUp.canceled -= OnPullUp;
            _inputSystemActions.Disable();
        }

        private void OnPullUp(InputAction.CallbackContext obj)
        {
            Score.PullUpsScore++;
            PlayerPrefs.Save();
            UpdatePoints();
        }

        private void Update()
        {
            _remainingTime -= Time.deltaTime;

            UpdateRemainingTime();

            if (_remainingTime <= 0 && !_isStopGame)
                StartCoroutine(EndMiniGame());
        }

        private void Reset()
        {
            Score.PullUpsScore = 0;
            PlayerPrefs.Save();
            _remainingTime = 0;
            _isStopGame = false;
        }

        private void UpdatePoints()
        {
            _points.text = $"МУСКУЛ: {Score.PullUpsScore}";
        }

        private void UpdateRemainingTime()
        {
            if (_remainingTime > 0)
                _timer.text = $"Время:  {Mathf.Round(_remainingTime)}";
        }

        private IEnumerator EndMiniGame()
        {
            Stop();
            
            Debug.Log($"ОЧКИ: {Score.PullUpsScore}");
            
            //todo Add ScreenScore

            yield return new WaitForSeconds(1);
            
            gameObject.SetActive(false);
        }

        private void Stop()
        {
            _isStopGame = true;
            _inputSystemActions.Player.PullUp.canceled -= OnPullUp;
            _inputSystemActions.Disable();
        }
    }
}
