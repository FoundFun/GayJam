using System.Collections;
using System.Collections.Generic;
using System.Linq;
using GlobalComponents;
using Player;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Mini_Games.Press
{
    public class PressMiniGame : MonoBehaviour
    {
        [SerializeField] private PlayerMover _player;
        [SerializeField] private PressConfig _config;
        [SerializeField] private int _startTimerFromSpawn;
        [SerializeField] private TMP_Text _timer;
        [SerializeField] private TMP_Text _points;
        [SerializeField] private int _correctTip;
        [SerializeField] private int _wrongTip;

        [Space(10), SerializeField] private PressEntity[] prefabs;
        [SerializeField] private Transform[] path;

        [Space(10), SerializeField] private SortedEntityContainer left;
        [SerializeField] private SortedEntityContainer right;


        private List<PressEntity> list = new List<PressEntity>();

        private InputSystem_Actions _inputSystemActions;
        private bool _sortKeyPressed;
        private float _remainingTime;
        private bool _isStopGame;
        private int _targetSpawned;

        private void Awake()
        {
            _inputSystemActions = new InputSystem_Actions();
        }

        private void OnEnable()
        {
            Reset();
            
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
            
            _inputSystemActions.Enable();

            _inputSystemActions.Player.PressRight.canceled += MoveRight;
            _inputSystemActions.Player.PressLeft.canceled += MoveLeft;
            _player.gameObject.SetActive(false);
            
            UpdatePoints();
        }

        private void OnDisable()
        {
            _inputSystemActions.Player.PressRight.canceled -= MoveRight;
            _inputSystemActions.Player.PressLeft.canceled -= MoveLeft;
            _inputSystemActions.Disable();
            _player.gameObject.SetActive(true);
        }

        private void Spawn()
        {
            PressEntity entity = Instantiate(prefabs[UnityEngine.Random.Range(0, prefabs.Length)], transform);

            entity.Init(path);
            list.Add(entity);

            foreach (PressEntity en in list)
            {
                en.MoveNext();
            }
        }

        private void Start()
        {
            for (int i = 0; i < path.Length; i++)
            {
                Spawn();
            }
        }

        private void Update()
        {
            if (_targetSpawned >= _startTimerFromSpawn)
                _remainingTime -= Time.deltaTime;

            UpdateRemainingTime();

            if (_remainingTime <= 0 && !_isStopGame)
                StartCoroutine(EndMiniGame());
        }
    
        private void MoveRight(InputAction.CallbackContext obj)
        {
            _sortKeyPressed = false;
            SortDirection currentSortDirection = SortDirection.Right;

            PressEntity entity = list.FirstOrDefault(x => x.CanSort);
            if (entity != null)
            {
                _sortKeyPressed = true;
                entity.Move(right.transform.position);
                list.Remove(entity);

                if (right.currentEntity != null)
                {
                    Destroy(right.currentEntity.gameObject, 1f);
                }
                right.currentEntity = entity;

                if (entity.sortDirection == currentSortDirection)
                {
                    Score.PressScore += _correctTip;
                    UpdatePoints();
                }
                else
                {
                    Score.PressScore -= _correctTip;
                    UpdatePoints();
                }
            }

            Spawn();
            _targetSpawned++;
        }

        private void MoveLeft(InputAction.CallbackContext obj)
        {
            _sortKeyPressed = false;
            SortDirection currentSortDirection = SortDirection.Left;
            
            PressEntity entity = list.FirstOrDefault(x => x.CanSort);
            if (entity != null)
            {
                _sortKeyPressed = true;
                entity.Move(left.transform.position);
                list.Remove(entity);

                if (left.currentEntity != null)
                {
                    Destroy(left.currentEntity.gameObject, 1f);
                }
                left.currentEntity = entity;

                if(entity.sortDirection == currentSortDirection)
                {
                    Score.PressScore += _correctTip;
                    UpdatePoints();
                }
                else
                {
                    Score.PressScore -= _correctTip;
                    UpdatePoints();
                }
            }

            Spawn();
            _targetSpawned++;
        }
    
        private void Reset()
        {
            Score.PressScore = 0;
            PlayerPrefs.Save();
            _remainingTime = 0;
            _isStopGame = false;
        }
        
        private void UpdatePoints()
        {
            _points.text = $"МУСКУЛ: {Score.PressScore}";
        }
        
        private void UpdateRemainingTime()
        {
            if (_remainingTime > 0)
                _timer.text = $"Время:  {Mathf.Round(_remainingTime)}";
        }
        
        private IEnumerator EndMiniGame()
        {
            Stop();
            
            Debug.Log($"ОЧКИ: {Score.PressScore}");
            
            //todo Add ScreenScore

            yield return new WaitForSeconds(1);
            
            gameObject.SetActive(false);
        }
        
        private void Stop()
        {
            _isStopGame = true;
            _inputSystemActions.Player.PressRight.canceled -= MoveRight;
            _inputSystemActions.Player.PressLeft.canceled -= MoveLeft;
            _inputSystemActions.Disable();
        }
    }
}
