using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(EnemyStateMachine))]
public class EnemyEditor : Editor
{
    private void OnSceneGUI()
    {
        EnemyStateMachine enemy = (EnemyStateMachine)target;

        Handles.color = Color.red;

        Handles.DrawWireArc(enemy.transform.position, Vector3.up, Vector3.forward, 360, enemy.runHearRadius);
        Handles.DrawWireArc(enemy.transform.position, Vector3.up, Vector3.forward, 360, enemy.walkHearRadius);
        Handles.DrawWireArc(enemy.transform.position, Vector3.up, Vector3.forward, 360, enemy.crouchHearRadius);
        Handles.DrawWireArc(enemy.transform.position, Vector3.up, Vector3.forward, 360, enemy.killRadius);
    }
}
