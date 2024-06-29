using System.Collections;
using System.Collections.Generic;
using GlobalComponents;
using Mini_Games.PullUp;
using Player;
using TMPro;
using UnityEngine;

namespace Mini_Games.BenchPress
{
    public class BenchPress : MonoBehaviour
    {
        [SerializeField] private TMP_Text _pointText;
        [SerializeField] private TMP_Text _approach;
        [SerializeField] private PullUpConfig _config;
        [SerializeField] private PlayerMover _playerMover;
        [SerializeField] private List<BenchPressBar> _bars;

        private int _count;

        private void OnEnable()
        {
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
                //todo result
                StartCoroutine(EndMiniGame());
            }
            
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