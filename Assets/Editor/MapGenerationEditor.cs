using UnityEngine;
using UnityEditor;



namespace WorldMapGenerator
{
    

[CustomEditor(typeof(MapGeneration))]
[CanEditMultipleObjects]
public class MapGenerationEditor : Editor 
{
    SerializedProperty nodePrefab;
    SerializedProperty genStartPos;
    SerializedProperty nodesParent;
    SerializedProperty linesParent;
    SerializedProperty minColumns;
    SerializedProperty maxColumns;
    SerializedProperty minRows;
    SerializedProperty maxRows;
    SerializedProperty rowDist;
    SerializedProperty colDist;
    SerializedProperty minXDeviation;
    SerializedProperty maxXDeviation;
    SerializedProperty minYDeviation;
    SerializedProperty maxYDeviation;
    SerializedProperty cullNodesChance;
    SerializedProperty bottomNodesCullChance;
    SerializedProperty topNodesCullChance;
    SerializedProperty nodeConnectionChanceDefault;
    SerializedProperty lineZPosition;
    SerializedProperty userEnteredRowAmount;
    SerializedProperty topRowNodes;
    SerializedProperty nThColumnAwayConnectionChance;
    SerializedProperty nThPlus;
    SerializedProperty alwaysConnectUpwards;
    SerializedProperty nodesAlwaysHaveAtLeastOneForwardConnection;
    SerializedProperty squashRowsInIfLargerThanColumns;
    SerializedProperty centerTopNodes;
    SerializedProperty noCrossover;

    
    void OnEnable()
    {
        nodePrefab = serializedObject.FindProperty("nodePrefab");
        genStartPos = serializedObject.FindProperty("genStartPos");
        nodesParent = serializedObject.FindProperty("nodesParent");
        linesParent = serializedObject.FindProperty("linesParent");

        minColumns = serializedObject.FindProperty("minColumns");
        maxColumns = serializedObject.FindProperty("maxColumns");
        minRows = serializedObject.FindProperty("minRows");
        maxRows = serializedObject.FindProperty("maxRows");

        rowDist = serializedObject.FindProperty("rowDist");
        colDist = serializedObject.FindProperty("colDist");

        minXDeviation = serializedObject.FindProperty("minXDeviation");
        maxXDeviation = serializedObject.FindProperty("maxXDeviation");

        minYDeviation = serializedObject.FindProperty("minYDeviation");
        maxYDeviation = serializedObject.FindProperty("maxYDeviation");

        cullNodesChance = serializedObject.FindProperty("cullNodesChance");
        bottomNodesCullChance = serializedObject.FindProperty("bottomNodesCullChance");
        topNodesCullChance = serializedObject.FindProperty("topNodesCullChance");

        nodeConnectionChanceDefault = serializedObject.FindProperty("nodeConnectionChanceDefault");
        lineZPosition = serializedObject.FindProperty("lineZPosition");

        userEnteredRowAmount = serializedObject.FindProperty("userEnteredRowAmount");
        topRowNodes = serializedObject.FindProperty("topRowNodes");

        

        nThColumnAwayConnectionChance = serializedObject.FindProperty("nThColumnAwayConnectionChance");
        
        nThPlus = serializedObject.FindProperty("nThPlus");
        alwaysConnectUpwards = serializedObject.FindProperty("alwaysConnectUpwards");
        nodesAlwaysHaveAtLeastOneForwardConnection = serializedObject.FindProperty("nodesAlwaysHaveAtLeastOneForwardConnection");
        squashRowsInIfLargerThanColumns = serializedObject.FindProperty("squashRowsInIfLargerThanColumns");

        centerTopNodes = serializedObject.FindProperty("centerTopNodes");
        noCrossover = serializedObject.FindProperty("noCrossover");
        
    }
    public override void OnInspectorGUI()
    {
        MapGeneration mapGeneration = (MapGeneration)target;

        serializedObject.Update();


        // GUILayout.FlexibleSpace();
        EditorGUILayout.LabelField("Transforms");
        EditorGUILayout.PropertyField(nodePrefab);
        EditorGUILayout.PropertyField(genStartPos); 
        EditorGUILayout.PropertyField(nodesParent);
        EditorGUILayout.PropertyField(linesParent);

        EditorGUILayout.LabelField("");
        EditorGUILayout.LabelField("Map size, distances and positions");

        EditorGUILayout.PropertyField(centerTopNodes);
        EditorGUILayout.PropertyField(squashRowsInIfLargerThanColumns);    

        EditorGUILayout.PropertyField(minColumns);
        EditorGUILayout.PropertyField(maxColumns);
        EditorGUILayout.PropertyField(minRows);
        EditorGUILayout.PropertyField(maxRows);

        EditorGUILayout.PropertyField(rowDist);
        EditorGUILayout.PropertyField(colDist);

        EditorGUILayout.PropertyField(minXDeviation);
        EditorGUILayout.PropertyField(maxXDeviation);

        EditorGUILayout.PropertyField(minYDeviation);
        EditorGUILayout.PropertyField(maxYDeviation);

        EditorGUILayout.PropertyField(lineZPosition);

        EditorGUILayout.LabelField("");
        EditorGUILayout.LabelField("Node Culling");

        EditorGUILayout.PropertyField(cullNodesChance);
        EditorGUILayout.PropertyField(bottomNodesCullChance);
        EditorGUILayout.PropertyField(topNodesCullChance);

        EditorGUILayout.LabelField("");
        EditorGUILayout.LabelField("Node connections");

        EditorGUILayout.PropertyField(noCrossover);
        EditorGUILayout.PropertyField(alwaysConnectUpwards);
        EditorGUILayout.PropertyField(nodesAlwaysHaveAtLeastOneForwardConnection);
        EditorGUILayout.PropertyField(nodeConnectionChanceDefault);
        EditorGUILayout.PropertyField(nThColumnAwayConnectionChance, true);
        EditorGUILayout.PropertyField(nThPlus);

        EditorGUILayout.LabelField("");
        EditorGUILayout.LabelField("Row sizes");

        EditorGUILayout.PropertyField(topRowNodes);
        EditorGUILayout.PropertyField(userEnteredRowAmount, true);





        serializedObject.ApplyModifiedProperties();

        if(GUILayout.Button("Generate")) {
            mapGeneration.BuildNew();
        }
    }
}
}