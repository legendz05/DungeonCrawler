using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/TileDataBase")]
public class TileDataBase : ScriptableObject
{
    public List<GameObject> tiles = new List<GameObject>();
}
