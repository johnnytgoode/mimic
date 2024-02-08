using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GUIPartNo : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI _PartNoGUIObj = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// 表示内容セット
    /// </summary>
    /// <param name="partNo"></param>
    public void setPartNo(int partNo)
    {
        _PartNoGUIObj.text = partNo.ToString();
    }
}
