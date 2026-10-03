using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/TileDataBase")]
public class TileDataBase : ScriptableObject
{
    [SerializeField]
    public Dictionary<ConnectionTypes, List<GameObject>> tilePrefabs = new()
    {
        { ConnectionTypes.Wall, null },
        { ConnectionTypes.Doorway, null }
    };
}
