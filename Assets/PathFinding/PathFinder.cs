using System;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] Vector2Int startCoordinates;
    [SerializeField] Vector2Int destinationCoordinates;

    Node startNode;
    Node destinationNode;
    [SerializeField] Node currentSearchNode;

    Queue<Node> frontier = new Queue<Node>();
    Dictionary<Vector2Int, Node> reached = new Dictionary<Vector2Int, Node>();

    Vector2Int[] directions = { Vector2Int.left, Vector2Int.right, Vector2Int.up, Vector2Int.down };
    GridManager gridManager;
    Dictionary<Vector2Int, Node> grid = new Dictionary<Vector2Int, Node>();

    private void Awake()
    {
        gridManager = FindFirstObjectByType<GridManager>();
        if (gridManager != null)
        {
            grid = gridManager.Grid;
        }


    }

    void Start()
    {
        startNode = gridManager.Grid[startCoordinates];
        destinationNode = gridManager.Grid[destinationCoordinates];
        BreadthFirstSearch();
        BuildPath();
    }

    private void ExploreNeighbours()
    {
        List<Node> neighbours = new List<Node>();

        foreach (Vector2Int direction in directions)
        {
            Vector2Int neighbourCoords = currentSearchNode.coordinates + direction;
            if (grid.ContainsKey(neighbourCoords))
            {
                neighbours.Add(grid[neighbourCoords]);

            }
        }
        foreach (Node neighbour in neighbours)
        {
            if (!reached.ContainsKey(neighbour.coordinates) && neighbour.isWalkable)
            {
                neighbour.connectedTo = currentSearchNode;
                reached.Add(neighbour.coordinates, neighbour);
                frontier.Enqueue(neighbour);
            }
        }
    }

    void BreadthFirstSearch()
    {
        bool isRunning = true;

        frontier.Enqueue(startNode);
        reached.Add(startCoordinates, startNode);

        while (frontier.Count > 0 && isRunning)
        {
            currentSearchNode = frontier.Dequeue();
            currentSearchNode.isExplored = true;
            ExploreNeighbours();
            if (currentSearchNode.coordinates == destinationCoordinates)
            {
                isRunning = false;
            }
        }
    }

    List<Node> BuildPath()
    {
        List<Node> path = new List<Node>();
        Node currentNode = destinationNode;

        path.Add(currentNode);
        currentNode.isPath = true;

        while (currentNode.connectedTo != null)
        {
            currentNode = currentNode.connectedTo;
            path.Add(currentNode);
            currentNode.isPath = true;
        }
        path.Reverse();

        return path;
    }
}
