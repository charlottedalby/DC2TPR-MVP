using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    
/*
    Class: Classes 
    Visibility: Public 
    Output: N/A
    Attributes: 

    a. N/A

    Classes: 

    a. Node
    b. RowInput
    c. NthAway
    d. MapState

*/

class Classes{
}

/*
    Class: Node
    Visibility: Public 
    Output: N/A
    Attributes: 

    a. id: Identification of node
    b. row: Row of node
    c. column: Column of node
    d. battleStrength: Strength of node
    e. forwardConnections: Forward connections of each node, contains a list of nodes
    f. backwardsConnections: Backwards connections of each node, contains a list of nodes
    g. position: Position of node
    h. cullable: Identifies if node is cullable  

    Methods: 

    a. IsConnected()
    b. IsConnectedBWK()
    c. ColumnDistance()
    d. returnNodeID()

*/

[System.Serializable]
public class Node
{
    public int id;
    public int row;
    public int column;
    public int battleStrength;
    public List<int> forwardConnections = new List<int>();
    public List<int> backwardConnections = new List<int>(); 
    public Vector3 position;
    public bool cullable = true;

    /*
	    Method: IsConnected()
        Visibility: Public 
        Output: Boolean 
        Purpose: 

        a. Iterates through forwardConnection arrays 
        b. if connection == node id 
        c. then return true 
        d. else return false
    */

    public bool IsConnected(Node node)
    {

        foreach (var connection in forwardConnections)
        {
            if(connection == node.id)
                return true;
        }

        return false;
    }

    /*
	    Method: IsConnectedBWK()
        Visibility: Public 
        Output: Boolean 
        Purpose: 

        a. Iterates through backwardConnections arrays 
        b. if connection == node id 
        c. then return true 
        d. else return false
    */

    public bool IsConnectedBKW(Node node)
    {
        foreach (var connection in backwardConnections)
        {
            if(connection == node.id)
                return true;
        }
        return false;
    }

    /*
	    Method: ColumnDistance()
        Visibility: Public 
        Output: Int 
        Purpose: 

        a. Set dist
        b. return dist 
    */

    public int ColumnDistance(Node nodeToCompare)
    {
        int dist = Mathf.Abs(column - nodeToCompare.column);
        return dist;
    }

    /*
	    Method: returnNodeID()
        Visibility: Public 
        Output: Int 
        Purpose: 

        a. Return Node id
    */

    public int returnNodeID(Node node)
    {
        return node.id;
    }
}

/*
    Class: RowInput 
    Visibility: Public 
    Output: N/A
    Attributes: 

    a. rowNum: number of rows in Map
    b. nodeNum: number of nodes in Map
    c. cullable: if Map is cullable 

*/

[System.Serializable]
public class RowInput
{
    public int rowNum;
    public int nodeNum;
    public bool cullable = true;
}

/*
    Class: NthAway 
    Visibility: Public 
    Output: N/A
    Attributes: 

    a. columnNumberAway: column numbers
    b. chanceToConnect: chance of connection between nodes

*/

[System.Serializable]
public class NthAway
{
    public int columnNumberAway;
    public float chanceToConnect;
}

/*
    Class: MapState 
    Visibility: Public 
    Output: N/A
    Attributes: 

    a. nodes: list of nodes in Map

    Methods: 

    a. Serialize()
    b. Deserialize()

*/

[System.Serializable]
public class MapState
{
    public List<Node> nodes = new List<Node>();
    
    /*
	    Method: Serialize()
        Visibility: Public 
        Output: String
        Purpose: 

        a. Returns String of Map State 
    */

    public string Serialize()
    {
        return JsonUtility.ToJson(this);
    }
    
    /*
	    Method: Deserialize()
        Visibility: Public 
        Output: MapState
        Purpose: 

        a. Returns MapState that has been serialized 
    */

    public static MapState Deserialize(string serializedData)
    {
        return JsonUtility.FromJson<MapState>(serializedData);
    }
}