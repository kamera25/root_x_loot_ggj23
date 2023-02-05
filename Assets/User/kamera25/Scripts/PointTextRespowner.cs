using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointTextRespowner : MonoBehaviour
{
    List<PointTextBehavior> pointTextPrefabList = new List<PointTextBehavior>();

    // Update is called once per frame
    void Update()
    {
        if( pointTextPrefabList.Count == 0 )
        {
            return;
        }

        ActivatePointText();
    }

    void ActivatePointText()
    {
        if( pointTextPrefabList[0] != null )
        {
            pointTextPrefabList[0].ActivatePointText();
        }
        else
        {
            pointTextPrefabList.RemoveAt(0);
        }
    }

    public void AddPointTextList( PointTextBehavior comp)
    {
        pointTextPrefabList.Add(comp);
    }
}
