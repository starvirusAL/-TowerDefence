using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{

    public float xzLengs = 10f;
    public float GetGridXZLengs() { return xzLengs; }

    public bool isExplored = false;

    public Waypoint isExploredFrom;

    public bool isPlaceble = true;




    private void Start()
    {
        // Physics.queriesHitTriggers = false; //отключить работу тригеров и мышки
        TextMesh text = GetComponentInChildren<TextMesh>();
        gameObject.name = (GetGridPos().x + "," + GetGridPos().y);
    }


    public Vector2Int GetGridPos()
    {
        int x = (int)(Mathf.RoundToInt(transform.position.x / xzLengs));
        int z = (int)(Mathf.RoundToInt(transform.position.z / xzLengs));
        return new Vector2Int(x, z);

    }

    public void SetTopColor(Color color)
    {
        var MeshTop = transform.Find("top").GetComponent<MeshRenderer>();
        MeshTop.material.color = color;
    }


    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && isPlaceble)
        {
            var tower = FindObjectOfType<SetTower>();
            tower.InstantiateTower(this);
        }
    }
}

