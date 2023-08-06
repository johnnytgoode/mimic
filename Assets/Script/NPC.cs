using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class NPC : MonoBehaviour
{
    public PlayableDirector _PlayableD;


    public bool _TimelinePause = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void checkTimelineCondition()
    {
        if( _TimelinePause )
        {
            _PlayableD.Pause();
        }
    }

    public void enableTimeline()
    {
        _PlayableD.Resume();
    }
}
