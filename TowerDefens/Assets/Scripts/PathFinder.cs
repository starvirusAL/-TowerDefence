using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{

    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();

    [SerializeField] Waypoint waipointStart, waipointEnd;

    Queue<Waypoint> queue = new Queue<Waypoint>();

    bool isRunning = true;

    Waypoint serchPoint;



    public List<Waypoint> path = new List<Waypoint>();

    public List<Waypoint> GetPath()
    {
        if (path.Count == 0)
        {
            LoadBloks();
            PathFind();
            CreatePath();
        }
        return path;
    }

    public void CreatePath()
    {
        path.Add(waipointEnd);
        waipointEnd.isPlaceble = false;
        Waypoint exploredFrom = waipointEnd.isExploredFrom;
        while (exploredFrom != waipointStart)
        {
            path.Add(exploredFrom);
            exploredFrom.isPlaceble = false;
            exploredFrom = exploredFrom.isExploredFrom;
        }
        path.Add(waipointStart);
        path.Reverse();
    }


    Vector2Int[] direction =
        {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
        };

    void PathFind()
    {
        queue.Enqueue(waipointStart);
        while (queue.Count > 0 && isRunning == true)
        {
            serchPoint = queue.Dequeue();
            serchPoint.isExplored = true;
            CheckForEndPoint();
            ExploreNearWaipoints();
        }
    }

    private void CheckForEndPoint()
    {
        if (serchPoint == waipointEnd)
        {
            isRunning = false;
        }
    }

    private void LoadBloks()
    {
        var waipoints = FindObjectsOfType<Waypoint>();
        foreach (var waipoint in waipoints)
        {
            Vector2Int getGridPos = waipoint.GetGridPos();
            if (grid.ContainsKey(getGridPos))
            {
              
            }
            else
                grid.Add(getGridPos, waipoint);
        }
    }

    private void SetColorFinishStart(Color col1, Color col2)
    {
        waipointStart.SetTopColor(col1);
        waipointEnd.SetTopColor(col2);
    }
    void ExploreNearWaipoints()
    {

        if (!isRunning) { return; }

        foreach (var point in direction)
        {
            Vector2Int nearCord = serchPoint.GetGridPos() + point;
            if(grid.ContainsKey(nearCord))
            {
                Waypoint nearPoint = grid[nearCord];
                AddToQueue(nearPoint);
            }
        }
    }

    private void AddToQueue(Waypoint nearPoint)
    {
        if (nearPoint.isExplored || queue.Contains(nearPoint))
        {
            return;
        }
        else
        {
            queue.Enqueue(nearPoint);
            nearPoint.isExploredFrom = serchPoint;
        }

    }

    
}
