using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace WorldMapGenerator
{
    

class Classes{
}



[System.Serializable]
public class Node
{
    public int id; // each Node is given a unique id
    public int row;
    public int column;
    public List<int> forwardConnections = new List<int>(); // array of ids representing connections between nodes
    public List<int> backwardConnections = new List<int>(); // array of ids representing connections between nodes
    public Vector3 position;
    public bool cullable = true;

    public bool IsConnected(Node node){

        foreach (var connection in forwardConnections)
        {
            if(connection == node.id)
                return true;
        }

        foreach (var connection in backwardConnections)
        {
            if(connection == node.id)
                return true;
        }

        return false;
    }

    public int ColumnDistance(Node nodeToCompare){

        int dist = Mathf.Abs(column - nodeToCompare.column);
        return dist;
    }

}

[System.Serializable]
public class RowInput
{
    public int rowNum;
    public int nodeNum;
    public bool cullable = true;
}

[System.Serializable]
public class NthAway
{
    public int columnNumberAway;
    public float chanceToConnect;
}

[System.Serializable]
public class MapState
{
    public List<Node> nodes = new List<Node>();
   
    public string Serialize()
    {
        return JsonUtility.ToJson(this);
    }
   
    public static MapState Deserialize(string serializedData)
    {
        return JsonUtility.FromJson<MapState>(serializedData);
    }
}
}