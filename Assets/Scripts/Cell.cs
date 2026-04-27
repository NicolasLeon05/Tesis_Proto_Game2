using UnityEngine;

public class Cell : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private bool _isWalkable = true;
    [SerializeField] private bool _isHeightConnector;
    [SerializeField] private int _height;

    [Header("Visual")]
    [SerializeField] private Transform _visual;
    [SerializeField] private float _heightStep = 1f;

    [SerializeField] private Vector2Int _coordinates;

    public int gCost;
    public int hCost;
    public int fCost;
    public Cell cameFromCell;

    public bool IsWalkable => _isWalkable;
    public bool IsHeightConnector => _isHeightConnector;
    public int Height => _height;
    public float WorldHeight => _height * _heightStep;
    public Vector2Int Coordinates => _coordinates;

    public void SetCoordinates(Vector2Int coordinates)
    {
        _coordinates = coordinates;
    }

    public int CalculateFCost()
    {
        fCost = gCost + hCost;
        return fCost;
    }

    private void OnValidate()
    {
        ApplyHeight();
    }

    private void Start()
    {
        ApplyHeight();
    }

    private void ApplyHeight()
    {
        if (_visual != null)
        {
            _visual.localPosition = new Vector3(0, WorldHeight, 0);
        }
    }
}