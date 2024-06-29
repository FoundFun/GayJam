using TMPro;
using UnityEngine;

public class PullUpGameManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _points;
    [SerializeField] private TMP_Text _timer;
    [SerializeField] private PullUpConfig _config;

    private int _currentPoints = 0;
    private float _remainingTime;

    void Start()
    {
        _remainingTime = _config.TimerDuration;

        UpdatePoints();
        UpdateRemainingTime();
    }

    void Update()
    {
        _remainingTime -= Time.deltaTime;

        UpdateRemainingTime();

        if (_remainingTime <= 0)
            EndMiniGame();

        if (Input.GetKeyDown(KeyCode.Space)) //TODO ïåðåáèòü íà input systemÛ
            OnPullUpButtonClicked();
    }

    public void OnPullUpButtonClicked()
    {
        _currentPoints++;
        UpdatePoints();
    }

    public void UpdatePoints()
    {
        _points.text = $"ÌÓÑÊÓË: {_currentPoints}";
    }

    public void UpdateRemainingTime()
    {
        if (_remainingTime > 0)
            _timer.text = $"Âðåìÿ:  {Mathf.Round(_remainingTime)}";
    }

    void EndMiniGame()
    {
        Debug.Log($"Î×ÊÈ: {_currentPoints}");
        //TODO Çàêðûòü ýêðàí
    }
}
