using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class MyTest : MonoBehaviour
{
    [SerializeField] private Entity prefab;
    [SerializeField] private Transform[] path;

    [Space(10), SerializeField] private SortedEntityContainer left;
    [SerializeField] private SortedEntityContainer right;

    private List<Entity> list = new List<Entity>();

    bool sortKeyPressed;

    private void Spawn()
    {
        Entity entity = Instantiate(prefab, transform);

        entity.Init(path);
        list.Add(entity);

        foreach (Entity en in list)
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

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Entity entity = list.FirstOrDefault(x => x.CanSort);
            if (entity != null)
            {
                sortKeyPressed = true;
                entity.Move(left.transform.position);
                list.Remove(entity);

                if (left.currentEntity != null)
                {
                    Destroy(left.currentEntity.gameObject);
                }

                left.currentEntity = entity;
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Entity entity = list.FirstOrDefault(x => x.CanSort);
            if (entity != null)
            {
                sortKeyPressed = true;
                entity.Move(right.transform.position);
                list.Remove(entity);

                if (right.currentEntity != null)
                {
                    Destroy(right.currentEntity.gameObject);
                }

                right.currentEntity = entity;
            }
        }

        if (sortKeyPressed)
        {
            Spawn();
        }
    }
}
