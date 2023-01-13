using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Replacable : MonoBehaviour
{
    public IsVisible refItem;

    private List<Renderer> rends = new List<Renderer>();

    private void Start()
    {
        CreateRenderList();
    }

    private void CreateRenderList()
    {
        if (GetComponent<Renderer>() != null)
        {
            rends.Add(GetComponent<Renderer>());
        }

        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).GetComponent<Renderer>() != null)
            {
                rends.Add(transform.GetChild(i).GetComponent<Renderer>());
            }
        }
    }

    private void Update()
    {
        int visCount = 0;

        for (int i = 0; i < rends.Count; i++)
        {
            if (rends[i].isVisible || refItem.rends[i].isVisible)
            {
                visCount++;
            }
        }

        if (visCount == 0)
        {
            refItem.MoveItem();
            Destroy(gameObject);
        }
    }
}

