// MARIANO CODUTTI ALARCON
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    [System.Serializable]
    public struct Path
    {
        public Transform[] points;
    }

    [Header("Available paths")]
    public Path[] paths;


    public Transform[] GetPath(int _index)
    {
        if (paths == null || paths.Length == 0)
        {
            Debug.LogError("NO PATHS ASSIGNED IN WAYPOINTS");
            return null;
        }

        if (_index < 0 || _index >= paths.Length)
        {
            Debug.LogError("PATH INDEX OUT OF RANGE: " + _index);
            return null;
        }

        return paths[_index].points;
    }
}
