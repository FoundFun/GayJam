using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PressMiniGame : MonoBehaviour
{
    [SerializeField] private int _correctTip;
    [SerializeField] private int _wrongTip;

    [Space(10), SerializeField] private PressEntity[] prefabs;
    [SerializeField] private Transform[] path;

    [Space(10), SerializeField] private SortedEntityContainer left;
    [SerializeField] private SortedEntityContainer right;

    public event Action<int> ScoreChanged;

    private List<PressEntity> list = new List<PressEntity>();

    private bool sortKeyPressed;

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
        sortKeyPressed = false;
        SortDirection currentSortDirection;

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            currentSortDirection = SortDirection.Left;
            
            PressEntity entity = list.FirstOrDefault(x => x.CanSort);
            if (entity != null)
            {
                sortKeyPressed = true;
                entity.Move(left.transform.position);
                list.Remove(entity);

                if (left.currentEntity != null)
                {
                    Destroy(left.currentEntity.gameObject, 1f);
                }
                left.currentEntity = entity;

                if(entity.sortDirection == currentSortDirection)
                {
                    ScoreChanged?.Invoke(_correctTip);
                }
                else
                {
                    ScoreChanged?.Invoke(_wrongTip);
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            currentSortDirection = SortDirection.Right;

            PressEntity entity = list.FirstOrDefault(x => x.CanSort);
            if (entity != null)
            {
                sortKeyPressed = true;
                entity.Move(right.transform.position);
                list.Remove(entity);

                if (right.currentEntity != null)
                {
                    Destroy(right.currentEntity.gameObject, 1f);
                }
                right.currentEntity = entity;

                if (entity.sortDirection == currentSortDirection)
                {
                    ScoreChanged?.Invoke(_correctTip);
                }
                else
                {
                    ScoreChanged?.Invoke(_wrongTip);
                }
            }
        }

        if (sortKeyPressed)
        {
            Spawn();
        }
    }
}
