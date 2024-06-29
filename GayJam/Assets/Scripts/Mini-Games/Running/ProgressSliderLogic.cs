using UnityEngine;
using UnityEngine.UI;

public class ProgressSliderLogic : MonoBehaviour
{
    [SerializeField] private Transform _start;
    [SerializeField] private Transform _finish;
    [SerializeField] private Transform _player;
    [SerializeField] private Slider _slider;
    
    private float _roadLenght;
    private float _currentPlayerPosition;

    private void Start()
    {
        _roadLenght = Vector3.Distance(_start.position, _finish.position);
    }

    private void Update()
    {
        _currentPlayerPosition = Vector3.Distance(_player.position, _start.position);

        float progress = _currentPlayerPosition / _roadLenght;

        _slider.value = progress;
    }
}
