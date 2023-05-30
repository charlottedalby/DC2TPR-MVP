using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Reflection;
using System.Runtime.Serialization;
    
[ExecuteInEditMode]
public class MapGeneration : MonoBehaviour
{

    public Text playerHealthText;
    // Changeable properties

    // prefab the user can swap out
    public GameObject nodePrefab;

    // Start pos. Move this this change where the map begins generating. 
    public Transform genStartPos;

    // Parent transform the nodes are placed under on build
    public Transform nodesParent;

    // Parent transform the lines are placed under on build
    public Transform linesParent;

    // The minimum amount of columns the map will generate
    // Columns are vertical
    // Set the min and max to the same to always generate the same amount of columns
    // The amount of columns determines the amount of nodes in rows
    public int minColumns = 5;

    //The maximum amount of columns the map will generate
    public int maxColumns = 7;

    // The minimum amount of rows the map will generate
    // Rows are horizontal
    // Set min and max the same to always generate a fixed amount of rows
    public int minRows = 5;
    // The maximum amount of rows the map will generate
    public int maxRows = 10;

    // The distance between each row
    public float rowDist = 2f;

    // The distance between each column
    public float colDist = 2f;

    // Minimum and maximum amount each node will deviate from its generated position
    public float minXDeviation = -0.5f;
    public float maxXDeviation = 0.5f;
    public float minYDeviation = -0.5f;
    public float maxYDeviation = 0.5f;

    // The default chance any node will be culled
    public float cullNodesChance = 25f;
    // The chance the first row will be culled
    public float bottomNodesCullChance = 0f;
    // The chance the last row will be culled
    public float topNodesCullChance = 0f;

    // Z position of the lines.
    public float lineZPosition = 5f;

    // Manually set a fixed amount of nodes on a row. Check docs for more details
    public List<RowInput> userEnteredRowAmount = new List<RowInput>();

    // Manually set the amount of nodes on the top/last row. Ignore rowNum, has no effect
    public RowInput topRowNodes;

    // Chance for a node to connect to any of the nodes on the above row
    public float nodeConnectionChanceDefault = 25f;

    // Manaully set the connection chance based on the column distance to the above nodes
    // Check docs for use
    public List<NthAway> nThColumnAwayConnectionChance = new List<NthAway>();

    // Set the chance to connect to above nodes nth distance or more away 
    public NthAway nThPlus;

    // Set true to ensure nodes always connect upwards on their own columns if possible
    public bool alwaysConnectUpwards = true;    

    // Set true to ensure all nodes connect to a forward node
    public bool nodesAlwaysHaveAtLeastOneForwardConnection = true;

    // If the user manually sets a row that has more nodes in it than columns,
    // squash the nodes to fix them in the bounds of the column
    // so that they don't span outwards
    public bool squashRowsInIfLargerThanColumns = true;

    // Center the top nodes instead of generating on the left
    public bool centerTopNodes = true;
    public bool noCrossover = false;
    

    // Above this line are the properties users can change

    // Below this line are properties which users should not change, unless they want to edit code

    private int rows;
    private int columns = 0;
    private int topRow;

    public List<Node> nodes;
    private MapState mapState;
    private string saveData;

    // Builds a new map on start
    void Start(){
        BuildNew();
    }

    public void BuildNew()
    {
        if (GameController.gameMapState!= null){
            LoadSavedMap();
        }
        else{
            Load(GenerateMap());
        }
        
    }

    // Use this for saving
    public void SaveMap(){
        GameController.gameMapState = Serialize();
    }

    // Use this for loading
    public void LoadSavedMap(){
        Deserialize(GameController.gameMapState);
    }
    
    // Saving
    public string Serialize()
    {
        return mapState.Serialize();  
    }

    // Loading
 
    public void Deserialize(string serializedData)
    {
        Load(MapState.Deserialize(serializedData));
    }
   
   // Generates the map. Doesn't build
    private MapState GenerateMap()
    {

        mapState = new MapState();

        FunctionsAtEachGeneration();

        nodes = new List<Node>();

        // Generate columns and row length
        columns = Random.Range(minColumns, maxColumns+1);
        rows = Random.Range(minRows, maxRows+1);


        topRow = rows-1;

        GenerateMaxNodes();
        CullNodes();
        ReassignTopNodeColumns();

        if(squashRowsInIfLargerThanColumns)
            CenterNodesAfterGeneration();
        if(centerTopNodes)
            CenterTopNodes();

        GenerateConnections();

        if(noCrossover)
            RemoveCrossoverConnections();       
        if(alwaysConnectUpwards)
            ConnectAllNodesUpwards();
        if(nodesAlwaysHaveAtLeastOneForwardConnection)
            EnsureAllNodesHaveAtLeastOneForwardConnection();
        EnsureTopNodesAlwaysHaveAConnection();
        SaveMap();
        //GameController.gameMapState = mapState;
        return mapState;
    }

    // Load a mapstate   
    public void Load(MapState loadState)
    {
        FunctionsAtEachGeneration();
        mapState = loadState;
        Build(mapState);

    }

    // Given a mapstate (a list of nodes), build the map
   
    private void Build(MapState mapState)
    {
        nodes = new List<Node>();
        nodes = mapState.nodes;

        // Iterate through each node and build it        
        foreach (var node in nodes)
        {
            var nodeObject = Instantiate(nodePrefab, node.position, nodePrefab.transform.rotation, nodesParent);
            nodeObject.name = "Node: " + node.id + " Row: " + node.row + " Column: " + node.column;

            nodeObject.GetComponent<NodeOBJ>().node = node;

            var nodesAboveIDs = node.forwardConnections;

            // Iterate through each connection and draw a line
            foreach (var nodeAboveID in nodesAboveIDs)
            {
                Node nodeAbove = GetNodeGivenID(nodeAboveID);
                DrawLine(node, nodeAbove);
            }
        }
       
        // establish connections between nodes here based on Node.connections
    }

    // Function that draws a line between two nodes to represent a connection.
    // I'd suggest writing your own function as this is ugly and a placeholder.
    void DrawLine(Node nodeBelow, Node nodeAbove){

        Vector3 start = nodeBelow.position;
        Vector3 end = nodeAbove.position;

        start.z = lineZPosition;
        end.z = lineZPosition;
        GameObject myLine = new GameObject();
        myLine.transform.parent = linesParent;
        myLine.tag = "Line";
        myLine.transform.position = start;
        myLine.name = "Connecting: " + nodeBelow.id + " to: " + nodeAbove.id;

        myLine.AddComponent<LineRenderer>();
        LineRenderer lr = myLine.GetComponent<LineRenderer>();
        lr.sortingOrder = -3;
        lr.material = new Material(Shader.Find("Sprites/Default"));
        lr.startColor = Color.gray;
        lr.endColor = Color.clear;
        lr.startWidth = 0.05f;
        lr.endWidth = 0.2f;
        lr.SetPosition(0, start);
        lr.SetPosition(1, end);
}

    // Functions to call at each build. Clears the log if need be
    void FunctionsAtEachGeneration(){
        ClearNodesAndLines();
        // ClearLog();
        // Debug.ClearDeveloperConsole();
    }

    public void ClearLog(){
        
        #if UNITY_EDITOR

        var assembly = Assembly.GetAssembly(typeof(UnityEditor.Editor));
        var type = assembly.GetType("UnityEditor.LogEntries");
        var method = type.GetMethod("Clear");
        method.Invoke(new object(), null);

        #endif
    }

    // Clears built nodes and lines from the scene
    public void ClearNodesAndLines(){

        var nodesToDelete = GameObject.FindGameObjectsWithTag("Node");

        foreach (var node in nodesToDelete)
        {
            DestroyImmediate(node);
        }

        var lines = GameObject.FindGameObjectsWithTag("Line");

        foreach (var line in lines)
        {
            DestroyImmediate(line);
        }
    }

    // Generate all possible nodes given columns and rows
    void GenerateMaxNodes(){

        int id = 0;

        // Iterate through each row
        for (int rowCount = 0; rowCount < rows; rowCount++)
        {
                

            int nodesOnThisRow = columns;
            bool nodesAreCullable = true;

            // If are the top row
            if(rowCount == rows-1){

                if(topRowNodes.nodeNum != 0){
                    nodesOnThisRow = 1;
                    nodesAreCullable = topRowNodes.cullable;
                }

            }

            // Check if user has manually entered row input 
            foreach (var entry in userEnteredRowAmount)
            {
                if(entry.rowNum == rowCount){
                    int amountOfNodesRequired = entry.nodeNum;
                    nodesOnThisRow = amountOfNodesRequired;
                    nodesAreCullable = entry.cullable;
                }
            }

            // Iterate through each column and generate the nodes. Building is done later
            for (int colCount = 0; colCount < nodesOnThisRow; colCount++)
            {
                Node newNode = new Node();
                
                Vector3 pos = genStartPos.position;
                pos.x+= rowCount * rowDist + Random.Range(minYDeviation, maxYDeviation);
                
                pos.y += colCount * colDist + Random.Range(minXDeviation, maxXDeviation);
                newNode.position = pos;
                newNode.row = rowCount;
                newNode.column = colCount;
                newNode.id = id;
                newNode.cullable = nodesAreCullable;
                mapState.nodes.Add(newNode);
                id++;
            }
        }
    }

    // Cull nodes based on chance input

    void CullNodes(){

        // Iterate through all nodes
        for (int i = mapState.nodes.Count-1; i >= 0 ; i--)
        {

            // Default cull chance
            var cullChance = cullNodesChance;

            Node node = mapState.nodes[i];

            if(!node.cullable)
                continue;

            // Takes into account bottom nodes chance
            if(node.row == 0)
                cullChance = bottomNodesCullChance;

            // Takes into account top nodes chance
            if(node.row == topRow)
                cullChance = topNodesCullChance;
            
            // This is where the actual roll occurs
            float cullChanceRoll = Random.Range(0, 100f);

            if(cullChanceRoll < cullChance){
                // print("Removing node at: " + i);
                mapState.nodes.RemoveAt(i);
            }
        }
    }

    // This function ensures top node columns are evenly spread out instead of increasing linearaly.
    // This stops connections with top nodes skewing rightwards

    void ReassignTopNodeColumns(){

        var topNodes = GetTopNodes();

        float div = topNodes.Count;

        float interval = columns/(div);
        float count = 0;

        // print("cols (" + columns+")" + " / " + div + " = " + interval);
        
        foreach (var topNode in topNodes)
        {
            // topNode.position.x = count;
            int countRounded = Mathf.RoundToInt(count);
            topNode.column = countRounded;
            count += interval;
        }

    }

    // Generate connections based on input in 'NthColumnAwayConnectionChance' and
    // 'NodeConnectionChanceDefault'

    void GenerateConnections(){
        foreach (var node in mapState.nodes)
        {
            // If we have reached the row
            if(node.row == topRow)
                return;

            List<Node> nodesAbove = GetNodesInRow(node.row + 1);

            if(node.row == topRow-1){
                Node closest = GetClosestAboveNodeByX(node);
                ConnectNodes(node, closest);
                continue;
            }

            // Iterate through each node above
            foreach (var nodeAbove in nodesAbove)
            {
                
                // Default connection chance
                float connectionChance = nodeConnectionChanceDefault;

                int columnsAway = Mathf.Abs(node.column - nodeAbove.column);

                if(columnsAway >= nThPlus.columnNumberAway)
                    connectionChance = nThPlus.chanceToConnect;

                if(columnsAway > 1 && noCrossover){
                    continue;
                }

                // Check each node above with all user entries in nth column away and change connection chance
                // if there is entry
                foreach (var entry in nThColumnAwayConnectionChance)
                {
                    if(entry.columnNumberAway == columnsAway){
                        connectionChance = entry.chanceToConnect;
                        break;
                    }
                }

                // Roll the chance to connect

                var roll = Random.Range(0, 100f);

                if(roll < connectionChance){
                    ConnectNodes(node, nodeAbove);
                }
            }

        }
    }

    // Center the top nodes
    void CenterTopNodes(){
        List<Node> topRowNodes = GetNodesInRow(rows-1);

        float length = (columns-1) * colDist;

        float interval = length / (topRowNodes.Count+1);

        for (int i = 0; i < topRowNodes.Count; i++){
            topRowNodes[i].position.y = interval * (i+1) + genStartPos.position.y;
        }

        if(topRowNodes.Count > 1){
            topRowNodes[0].position.x -= colDist;
            topRowNodes[topRowNodes.Count-1].position.x += colDist;
        }


    }

    // Center any nodes that are in a row that has more nodes in it than possible to generate.
    // This happens when a user enters a rowinput value that is greater than the bounds of the map
    void CenterNodesAfterGeneration(){
        for (int i = 0; i < rows; i++)
        {
            List<Node> nodesInRow = GetNodesInRow(i);

            if(nodesInRow.Count > columns){

            float length = columns * colDist;

            float interval = length / nodesInRow.Count;

                for (int ii = 0; ii < nodesInRow.Count; ii++)
                {
                    nodesInRow[ii].position.x = interval * ii + genStartPos.position.x;
                }
            }
            
        }
    }

    void EnsureAllNodesHaveAtLeastOneForwardConnection(){

        foreach (var node in mapState.nodes)
        {
            if(node.forwardConnections.Count == 0)
                EnsureAtLeastOneForwardConnection(node);
        }
    }

    void EnsureAtLeastOneForwardConnection(Node node){

        int rowsLeft = rows - node.row;

        for (int i = 0; i < rowsLeft; i++)
        {
            List<Node> nodesInRow = GetNodesInRow(i + node.row + 1);

            if(nodesInRow.Count > 0){

                // Gets the closest nodes (by column distance) in the row above in a list and chooses one randomly
                List<Node> closestNodes = new List<Node>();

                int closestDist = 9999;

                foreach (var nodeInRow in nodesInRow)
                {
                    int dist = node.ColumnDistance(nodeInRow);

                    if(dist < closestDist){
                        closestNodes = new List<Node>();
                        closestNodes.Add(nodeInRow);
                        closestDist = dist;
                    }
                    else if(dist == closestDist){
                        closestNodes.Add(nodeInRow);
                    }

                }

                if(closestNodes != null){

                    Node nodeToConnect = closestNodes[Random.Range(0, closestNodes.Count)];

                    ConnectNodes(node, nodeToConnect);
                    // print("Made forward connection for: "+ node.id + " and: " + nodeToConnect.id);
                    return;
                }
            }
        }
        
    }

    void EnsureTopNodesAlwaysHaveAConnection(){

        foreach (var topNode in GetNodesInRow(rows-1))
        {

            if(topNode.backwardConnections.Count > 0)
                continue;

            Node closestNode = null;
            float closestDist = 9999;

            var belowNodes = GetNodesInRow(rows - 2);

            foreach (var belowNode in belowNodes)
            {
                var dist = Mathf.Abs(topNode.position.x - belowNode.position.x);
                if(dist < closestDist){
                    closestDist = dist;
                    closestNode = belowNode;
                }
            }

            ConnectNodes(closestNode, topNode);
        }
    }

    void RemoveCrossoverConnections(){

        var shuffledNodes = new List<Node>(mapState.nodes);
        shuffledNodes.Shuffle();

        foreach (var node in shuffledNodes)
        {

            CheckCrossover(node);

            // foreach (var nodeInRow in GetNodesInRow(node.row))
            // {
            //     RemoveCrossoverTwoNodes(node, nodeInRow);
            // }            
        }

    }

    void CheckCrossover(Node node){

        bool leftOfNodeInSameRow = false;

        var nodesInSameRow = GetNodesInRow(node.row);
        nodesInSameRow.Remove(node);

        foreach (var nodeInSameRow in nodesInSameRow)
        {

            if(nodeInSameRow.column > node.column)
                leftOfNodeInSameRow = true;

            var tempForwards = new List<int>(node.forwardConnections);

            foreach (var forwardCon in tempForwards)
            {

                Node forwardConNode = GetNodeGivenID(forwardCon);

                foreach (var forwardConOfNodeInSameRow in nodeInSameRow.forwardConnections)
                {
                    Node nodeInSameRowForwardNode = GetNodeGivenID(forwardConOfNodeInSameRow);

                    if(leftOfNodeInSameRow){

                        if(forwardConNode.column > nodeInSameRowForwardNode.column){

                            if(forwardConNode.row != rows-1){
                                RemoveConnection(node, forwardConNode);
                            }
                        }
                    }
                    else{
                        if(forwardConNode.column < nodeInSameRowForwardNode.column){

                            if(forwardConNode.row != rows-1){
                                RemoveConnection(node, forwardConNode);
                            }
                        }
                    }
                }

            }

        }
    }

    void RemoveConnection(Node a, Node forward){
        a.forwardConnections.Remove(forward.id);
        forward.backwardConnections.Remove(a.id);
    }

    void ConnectAllNodesUpwards(){

        // Reassign top node values 

        // var topNodes = GetNodesInRow(rows-1);

        // int col = 0;

        // foreach (var topNode in topNodes)
        // {
        //     topNode.column = col;
        //     col++;
        // }

        foreach (var node in mapState.nodes)
        {
            
            if(node.row == rows-1)
                return;
            ConnectUpwards(node);
        }
    }

    void ConnectUpwards(Node node){

        Node nodeAbove = GetNextNodeAboveSameColumn(node);

        if(nodeAbove != null){
            if(nodeAbove.row == rows-1)
                return;
            ConnectNodes(node, nodeAbove);

            // print("Connecting upwards: " + node.id + " with node: " + nodeAbove.id);
        }
        else{
            // print("nodeAbove is null");
        }
    }
    Node GetNextNodeAboveSameColumn(Node node){

        foreach (var nodeToCompare in mapState.nodes)
        {
            if(nodeToCompare.column == node.column && nodeToCompare != node &&
            node.row < nodeToCompare.row){
                return nodeToCompare;
            }
        }

        return null;

    }

    public void ConnectNodes(Node nodeBelow, Node nodeAbove){

        if(nodeBelow == null || nodeAbove == null)
            return;

        // If not already connected, connect
        if(!nodeBelow.IsConnected(nodeAbove)){
            nodeBelow.forwardConnections.Add(nodeAbove.id);
            nodeAbove.backwardConnections.Add(nodeBelow.id);
        }
        // print("Connected node: " + nodeBelow.id + " with node: " + nodeAbove.id);
    }

    List<Node> GetTopNodes(){
        return GetNodesInRow(topRow);
    }

    Node GetClosestAboveNodeByX(Node node){

        var nodesAbove = GetNodesInRow(node.row+1);

        List<Node> closestNodes = new List<Node>();

        float closestDist = 9999;

        Node closest = null;


        foreach (var nodeAbove in nodesAbove)
        {
            float dist = Mathf.Abs(node.position.x - nodeAbove.position.x);
            if(dist < closestDist){
                closest = nodeAbove;
                closestDist = dist;
            }
        }

        return closest;
    }

    public List<Node> GetNodesInRow(int row){
        List<Node> nodesInRow = new List<Node>();

        foreach (var node in mapState.nodes)
        {
            if(node.row == row)
                nodesInRow.Add(node);
        }

        return nodesInRow;
        
    }

    public Node GetNodeGivenID(int id){

        foreach (var node in mapState.nodes)
        {
            if(node.id == id)
                return node;
        }

        return null;
    }
}