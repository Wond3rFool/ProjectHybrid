using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsVisible : MonoBehaviour
{
    // Position, rotation, scale, color
    public List<ChangeableValues> changeableValues = new List<ChangeableValues>();
    public List<Renderer> rends { get; private set; } = new List<Renderer>();


    private GameObject activePremesh = null;
    private float currentTime = 0;
    public float maxTime;
    public bool loopable;

    private int currentState = 1;
    private bool activated = false;

    private void Start()
    {
        CreateRenderList();
    }

    private void Update()
    {
        int visCount = 0;

        for (int i = 0; i < rends.Count; i++)
        {
            if (rends[i].isVisible)
            {
                visCount++;
                Debug.Log("Object is visible");
                if (currentState < changeableValues.Count && activePremesh == null)
                {
                    activated = false;
                }
            }
        }

        if (visCount == 0)
        {
            Debug.Log("Object is no longer visible");
            if (currentTime >= maxTime && changeableValues[currentState].skipTimer >= changeableValues[currentState].maxSkipTime && !activated)
            {
                CreatePreMesh();
                activated = true;
            }
        }
    }

    private void FixedUpdate()
    {
        currentTime += Time.fixedDeltaTime;

        if (currentTime >= maxTime)
        {
            for (int i = 0; i < changeableValues.Count; i++)
            {
                if (i == currentState)
                {
                    changeableValues[i].skipTimer += Time.fixedDeltaTime;
                }
            }
        }
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

    private void CreatePreMesh()
    {
        if (changeableValues[currentState].position != transform.position)
        {
            activePremesh = Instantiate(gameObject, changeableValues[currentState].position, Quaternion.identity);

            Destroy(activePremesh.GetComponent<IsVisible>());
            Destroy(activePremesh.GetComponent<Collider>());
            activePremesh.AddComponent<Replacable>();
            activePremesh.GetComponent<Replacable>().refItem = this;

            if (activePremesh.GetComponent<MeshRenderer>() != null)
            {
                activePremesh.GetComponent<MeshRenderer>().renderingLayerMask = 0;
            }

            for (int i = 0; i < transform.childCount; i++)
            {
                if (activePremesh.transform.GetChild(i).GetComponent<MeshRenderer>() != null)
                {
                    activePremesh.transform.GetChild(i).GetComponent<MeshRenderer>().renderingLayerMask = 0;
                }
            }

            activePremesh.transform.eulerAngles = changeableValues[currentState].rotation;
            activePremesh.transform.localScale = changeableValues[currentState].scale;
        }
    }

    public void MoveItem()
    {
        transform.position = changeableValues[currentState].position;
        transform.eulerAngles = changeableValues[currentState].rotation;
        transform.localScale = changeableValues[currentState].scale;

        activePremesh = null;
        changeableValues[currentState].skipTimer = 0;

        if (currentState < changeableValues.Count - 1)
        {
            currentState++;
        }
        else if (loopable)
        {
            currentState = 0;
        }
    }
}

