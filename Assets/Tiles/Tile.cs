using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] Tower towerPrefab;

    [SerializeField] bool isPlaceable;
    // property
    public bool IsPlaceable{get{return isPlaceable;}}

    GridManager gridManager;
    PathFinder pathFinder;
    Vector2Int coordinates = new Vector2Int();

    private void Awake() 
    {
        gridManager = FindFirstObjectByType<GridManager>();
        pathFinder = FindFirstObjectByType<PathFinder>();
    }

    private void Start() 
    {
        if(gridManager != null)
        {
            coordinates = gridManager.GetCoordintatesFromPosition(transform.position);
            if(!isPlaceable)
            {
                gridManager.blockNode(coordinates);
            }
        }
    }

    private void OnMouseDown()
    {
        if (gridManager.GetNode(coordinates).isWalkable && !pathFinder.WillBlockPath(coordinates))
        {
            bool isSuccessful = towerPrefab.CreateTower(towerPrefab, transform.position);
            if(isSuccessful)
            {
                gridManager.blockNode(coordinates);
                pathFinder.NotifyReceivers();
            }
        }
    }
}
