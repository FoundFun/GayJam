using System.Collections;
using TMPro;
using UnityEditor;
using UnityEngine;

public class RunningGameManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _points;
    [SerializeField] private GameObject _runningMiniGame;
    [SerializeField] private RunningConfig _config;

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
        _points.text = $"������: {_currentPoints}";
    }

    public void EndMiniGame()
    {
        Debug.Log($"������: {_currentPoints}");

        StartCoroutine(EndMiniGameCoroutine());
    }

    private IEnumerator EndMiniGameCoroutine()
    {
        WaitForSeconds pause = new WaitForSeconds(_config.PauseAfterFinishing);
        
        yield return pause;

        _runningMiniGame.SetActive( false );
    }

}
