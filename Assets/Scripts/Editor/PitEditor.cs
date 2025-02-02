using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Pit))]
public class PitEditor : Editor
{
    private void OnSceneGUI()
    {
        var targetPit = target as Pit;
        
        var orientation = Quaternion.LookRotation(targetPit.transform.forward, Camera.current.transform.up);
        
        var matrix = Matrix4x4.TRS(targetPit.transform.position, orientation, Vector3.one);
        using (new Handles.DrawingScope(Color.green, matrix))
        {
            Handles.DrawWireDisc(Vector3.zero, Vector3.forward, targetPit.Radius);
        }
    }
}
