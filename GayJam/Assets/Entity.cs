using TMPro;
using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField] private TextMeshPro _textMeshPro;
    [HideInInspector] public bool CanSort;
    private static int _number;

    private Transform[] _path;
    
    private int _index = 0;
   

    public void Init(Transform[] path)
    {
        _path = path;
        transform.position = _path[_index].position;

        _number++;
        _textMeshPro.text = _number.ToString();
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
        transform.position = target;
    }
}
