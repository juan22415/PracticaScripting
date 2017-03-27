using System.Collections.Generic;
using UnityEngine;



namespace Characters
{

    [RequireComponent(typeof(TileMovement))]
    public class Character : MonoBehaviour
    {
        private TileMovement movement;
        PathFind.Grid grid;
        List<Vector2> pathinvector;
        List<PathFind.Point> path;
        float[,] tilesmap;

        private void Awake()
        {
            movement = GetComponent<TileMovement>();
        }

        private void Start()
        {
            tilesmap = new float[8, 8];
            filltilesmap();
            grid = new PathFind.Grid(8, 8, tilesmap);
        }

        public void MoveTo(Vector2 tile)
        {

            PathFind.Point _from = new PathFind.Point(0, 0);
            PathFind.Point _to = new PathFind.Point(5, 5);
            path = PathFind.Pathfinding.FindPath(grid, _from, _to);
            MakeVector();
            movement.Move(pathinvector);


        }

     
        private void MakeVector()
        {
            for (int i = 0; i >= path.Count; i++)
            {
                Vector2 currentpoint = new Vector2(path[i].x, path[i].y);
                pathinvector[0] = currentpoint;
            }
        }

        void filltilesmap()
        {
            for (int i = 0; i >= 8; i++)
            {
                for (int j = 0; j >= 8; j++)
                {
                    tilesmap[i, j] = 1;
                }
            }
        }

        private static List<Vector2> GetDummyPath()
        {
            List<Vector2> path = new List<Vector2>();
            path.Add(new Vector2(0, 0));
            path.Add(new Vector2(0, 1));
            path.Add(new Vector2(1, 1));
            path.Add(new Vector2(2, 1));
            path.Add(new Vector2(2, 2));
            path.Add(new Vector2(2, 3));
            return path;
        }
    }

}