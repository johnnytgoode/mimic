using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIManager : SingletonMonoBehaviour<GUIManager>
{
    public enum GUIID
    {
        None,

        Pause,
        ThrustMenu,
        TestimonySelect,
        DialogueWindow,
    }

    [SerializeField]
    private List<GameObject> _GUIPrefabList = new List<GameObject>();

    private List<GUIBase> _GUICmpList = new List<GUIBase>();

    // Start is called before the first frame update
    void Start()
    {
        foreach(var prefab in  _GUIPrefabList)
        {
            var cmp = prefab.GetComponent<GUIBase>();
            if(cmp != null )
            {
                _GUICmpList.Add(cmp);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void openGUI(GUIID id)
    {
        // idを探してオープン（activate）
        var gui = _GUICmpList.Find(x => x.GUIId == id);
        if( gui != null )
        {
            gui.gameObject.SetActive(true);
        }
    }

    public void closeGUI(GUIID id)
    {
        // idを探してクローズ
        // idを探してオープン（activate）
        var gui = _GUICmpList.Find(x => x.GUIId == id);
        if (gui != null)
        {
            gui.gameObject.SetActive(false);
        }

    }
}
