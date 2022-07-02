using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Waypoint))]
public class SnapToGrid : MonoBehaviour
{



    Vector3 gridPos;
    Waypoint waipoint;
    private void Awake()
    {

        waipoint = GetComponent<Waypoint>();
    }
    void Update()
    {
        SnapToGridPos();

        UpdateLabel();

    }

    private void UpdateLabel()
    {
        TextMesh text;
        text = GetComponentInChildren<TextMesh>();
        text.text = ((waipoint.GetGridPos().x).ToString() + "," + (waipoint.GetGridPos().y).ToString());
        gameObject.name = text.text;

    }

    private void SnapToGridPos()
    {

        gridPos.z = waipoint.GetGridPos().y * waipoint.xzLengs;
        gridPos.x = waipoint.GetGridPos().x * waipoint.xzLengs;
        transform.position = gridPos;
    }
}
