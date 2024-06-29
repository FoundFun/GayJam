using UnityEngine;
using TMPro;

public class BadStuffPointRender : MonoBehaviour
{
    [SerializeField] private RunningConfig _config;
    [SerializeField] private TMP_Text _points;

    private void Start()
    {
        _points.text = $"-{_config.GoodStuffPoints.ToString()}";
    }
}
