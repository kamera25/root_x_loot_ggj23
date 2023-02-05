using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    [SerializeField]
    float firstTimer = 180;
    float timer;
    public float Timer => timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = firstTimer;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
    }
}
