using System.Collections;
using System.Collections.Generic;
using GlobalComponents;
using Player;
using TMPro;
using UnityEngine;

namespace Mini_Games.BenchPress
{
    public class BenchPress : MonoBehaviour
    {
        [SerializeField] private TMP_Text _pointText;
        [SerializeField] private TMP_Text _approach;
        [SerializeField] private BenchPressConfig _config;
        [SerializeField] private PlayerMover _playerMover;
        [SerializeField] private List<BenchPressBar> _bars;

        private int _count;

        private void OnEnable()
        {
            Reset();
            
            _playerMover.gameObject.SetActive(false);
            
            _approach.text = $"Подход: {_count}/5";
            _pointText.text = $"Мускул: {Score.BenchPressScore}";
            
            foreach (BenchPressBar bar in _bars)
            {
                bar.NextBar += OnNextBar;
            }
            
            foreach (BenchPressBar pressBar in _bars)
            {
                pressBar.gameObject.SetActive(false);
            }

            _count = 0;
            _bars[_count].gameObject.SetActive(true);
        }

        private void OnDisable()
        {
            foreach (BenchPressBar bar in _bars)
            {
                bar.NextBar -= OnNextBar;
            }
            
            _playerMover.gameObject.SetActive(true);
        }

        private void OnNextBar()
        {
            StartCoroutine(NextBar());
        }

        private IEnumerator NextBar()
        {
            yield return new WaitForSeconds(1);

            foreach (BenchPressBar pressBar in _bars)
            {
                pressBar.gameObject.SetActive(false);
            }

            if (_count < _bars.Count - 1)
            {
                _count++;
                _bars[_count].gameObject.SetActive(true);
            }
            else
            {
                StartCoroutine(EndMiniGame());
            }

            _approach.text = $"Подход: {_count}/5";
            _pointText.text = $"Мускул: {Score.BenchPressScore}";
        }
        
        private void Reset()
        {
            Score.BenchPressScore = 0;
            PlayerPrefs.Save();
        }
        
        private IEnumerator EndMiniGame()
        {
            Debug.Log($"ОЧКИ: {Score.PullUpsScore}");
            
            //todo Add ScreenScore

            yield return new WaitForSeconds(1);
            
            gameObject.SetActive(false);
        }
    }
}