using System;
using UnityEngine;

namespace CommonTools.Components
{
    /// <summary>
    /// Компонент настраиваемой 2D сетки
    /// </summary>
    public class WorldGrid : MonoBehaviour
    {
        [Header("Grid properties")]
        
        [Min(1)]
        [SerializeField] private Vector2Int _gridSize;
        [Min(0.05f)]
        [SerializeField] private Vector2 _cellSize;
        
        [Header("Snapping properties")]
        [Min(0)]
        [SerializeField] private float _depthThreshold = 0.5f;
        
        public Vector2 PhysicalSize => _gridSize * _cellSize;
        
        public Vector2 CellSize => _cellSize;
        public Vector2Int GridSize => _gridSize;

        public void SetSizeX(int x)
        {
            if (x <= 0)
            {
                throw new ArgumentException();
            }

            _gridSize.x = x;
        }
        
        public void SetSizeY(int y)
        {
            if (y <= 0)
            {
                throw new ArgumentException();
            }

            _gridSize.y = y;
        }

        public bool IsOnGrid(Vector3 point)
        {
            var localPoint = transform.InverseTransformPoint(point);
            
            Vector3 lb = -(_gridSize * _cellSize) / 2;
            Vector3 rt = _gridSize * _cellSize / 2;

            if (localPoint.x < lb.x || localPoint.y < lb.y)
            {
                return false;
            }

            if (localPoint.x > rt.x || localPoint.y > rt.y)
            {
                return false;
            }

            return !(Mathf.Abs(localPoint.z) > _depthThreshold);
        }

        public Vector3 Snap(Vector3 point)
        {
            var localPoint = transform.InverseTransformPoint(point);
            Vector3 origin = -(_gridSize * _cellSize) / 2;

            var diff = localPoint - origin;
            var div = diff / _cellSize;

            var x = Mathf.FloorToInt(div.x);
            var y = Mathf.FloorToInt(div.y);

            var gridPoint = GetPointLocal(x, y);

            gridPoint = transform.TransformPoint(gridPoint);
            
            Debug.DrawLine(gridPoint, gridPoint + Vector3.up);

            return diff;
        }

        public Vector3 GetPointLocal(int x, int y)
        {
            var halfCell = _cellSize / 2;
            var origin = -(_gridSize * halfCell);

            var xPos = origin.x + _cellSize.x * x + halfCell.x;
            var yPos = origin.y + _cellSize.y * y + + halfCell.y;
            
            return new Vector3(xPos, yPos);
        }

        public Vector3 GetPointWorld(int x, int y)
        {
            return transform.TransformPoint(GetPointLocal(x, y));
        }

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            var matrix = Gizmos.matrix;
            Gizmos.matrix = transform.localToWorldMatrix;

            var origin = -(_gridSize * _cellSize) / 2;

            for (var x = 0; x <= _gridSize.x; x++)
            {
                var color = x / (float) _gridSize.x;
                Gizmos.color = new Color(color, color, color);
                
                var offset = origin + new Vector2(x * _cellSize.x, 0);
                Gizmos.DrawLine(offset, offset + new Vector2(0, _gridSize.y*_cellSize.y));
            }
            
            for (var y = 0; y <= _gridSize.y; y++)
            {
                var color = y / (float) _gridSize.y;
                Gizmos.color = new Color(color, color, color);
                
                var offset = origin + new Vector2(0, y * _cellSize.y);
                Gizmos.DrawLine(offset, offset + new Vector2(_gridSize.x *_cellSize.x, 0));
            }

            Gizmos.matrix = matrix;
        }
#endif
    }
}
