using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewObjectList", menuName = "Data Object/Lists/ObjectList")]
public class ObjectListSO : ScriptableObject
{
    public List<GameObject> list = new List<GameObject>();
}
