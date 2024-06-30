using System.Collections;
using Player;
using TMPro;
using Unity.Cinemachine;
using UnityEngine;

namespace Mini_Games.Running
{
    public class RunningGameManager : MonoBehaviour
    {
        [SerializeField] private TMP_Text _points;
        [SerializeField] private GameObject _runningMiniGame;
        [SerializeField] private RunningConfig _config;
        [SerializeField] private PlayerMover _playerMover;
        [SerializeField] private GameObject _cameraFollow;
        [SerializeField] private CinemachineCamera _camera;
        [SerializeField] private CinemachinePositionComposer _cinemachinePosition;
        [SerializeField] private GameObject _walls;

        private int _currentPoints = 0;

        private void Update()
        {
            UpdatePoints();
        }

        public void AddPoints(int value) =>
            _currentPoints += value;

        public void DecreasePoints(int value) =>
            _currentPoints -= value;

        public void UpdatePoints()
        {
            _points.text = $"Мускул: {_currentPoints}";
        }

        public void EndMiniGame()
        {
            Debug.Log($"Мускул: {_currentPoints}");

            StartCoroutine(EndMiniGameCoroutine());
        }

        private IEnumerator EndMiniGameCoroutine()
        {
            WaitForSeconds pause = new WaitForSeconds(_config.PauseAfterFinishing);
        
            yield return pause;

            _runningMiniGame.SetActive(false);
            _playerMover.gameObject.SetActive(true);
            _walls.gameObject.SetActive(true);
            _camera.Follow = _cameraFollow.transform;
            _cinemachinePosition.TargetOffset = Vector3.zero;
        }
    }
}
