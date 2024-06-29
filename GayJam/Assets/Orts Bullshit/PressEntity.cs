using DG.Tweening;
using TMPro;
using UnityEngine;

public class PressEntity : MonoBehaviour
{
    [HideInInspector] public bool CanSort;

    public SortDirection sortDirection;

    private Transform[] _path;
    private int _index = 0;
    private Vector3 sourceScale;

    private void Awake()
    {
        sourceScale = transform.localScale;
    }

    public void Init(Transform[] path)
    {
        _path = path;
        transform.position = _path[_index].position;
    }

    public void MoveNext()
    {
        if (_index < _path.Length)
        {
            Move(_path[_index].position);
            _index++;
        }
        
        if(_index >= _path.Length)
        {
            CanSort = true;
        }
    }

    public void Move(Vector3 target)
    {
        var newScale = sourceScale * 1.2f;

        Sequence sequence = DOTween.Sequence();
        sequence.Join(transform.DOMove(target, 0.2f).SetEase(Ease.OutQuad));
        sequence.Join(transform.DOScale(newScale, 0.2f).SetEase(Ease.OutSine));
        sequence.Append(transform.DOScale(sourceScale, 0.2f).SetEase(Ease.InSine));
        sequence.Play();
    }
}

public enum SortDirection
{
    Left,
    Right
}
