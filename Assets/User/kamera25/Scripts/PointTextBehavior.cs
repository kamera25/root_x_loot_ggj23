using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointTextBehavior : MonoBehaviour
{
    Transform thisTrans;
    [SerializeField]
    TextMeshProUGUI textMesh;
    float dump = 0.02F;

    float thistextDeleteTime = 0.5F;

    bool doUp = false;

    // Start is called before the first frame update
    void Awake()
    {
        textMesh.enabled = false;
        
        GameObject.FindWithTag("GameController").GetComponent<PointTextRespowner>().AddPointTextList( this );
    }

    // Update is called once per frame
    void Update()
    {
        if( !doUp )
        {
            return;
        }

        thisTrans.Translate( Vector3.up * dump);
    }

    public void ActivatePointText()
    {
        if( doUp )
        {
            return;
        }

        thisTrans = this.transform;
        thisTrans.position = GameObject.FindWithTag("Player").transform.position + Vector3.up * 1.5F;

        textMesh.enabled = true;

        Destroy( this.gameObject, thistextDeleteTime );
        doUp = true;
    }

    public void UpdatePointText( int pointText)
    {
        textMesh.text = pointText > 0 ? ("+" + pointText.ToString()) :  pointText.ToString() ;
    }

    public void UpdatePointText( string pointText)
    {
        textMesh.text = pointText.ToString() ;
    }


}
