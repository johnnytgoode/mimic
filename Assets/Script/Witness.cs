using Arbor;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Witness : Humanoid
{
    [SerializeField] private WitnessManager.WitnessId _WitnessId;
    public WitnessManager.WitnessId WitnessId
    { get { return _WitnessId; } }


    /// <summary>
    /// BT制御用のパラメータコンテナ
    /// </summary>
    private ParameterContainer _PC;

    /// <summary>
    /// 吹き出しのテキスト
    /// </summary>
    [SerializeField] private TextMeshProUGUI _BaroonText;

    /// <summary>
    /// 思考FSM
    /// </summary>
    public Arbor.ArborFSM _ThinkFSM = null;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();        
        // パラメタコンテナ取得
        _PC = GetComponent<ParameterContainer>();
        // FSM取得
        _ThinkFSM = GetComponent<Arbor.ArborFSM>();

        // 証人リストに自分を追加
        WitnessManager.Instance.addWitness(this);

        // 吹き出しテキスト
        _BaroonText = GetComponentInChildren<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// そのパートのアクションが完了しているかどうか
    /// </summary>
    /// <returns></returns>
    public bool isPartActionSuccess()
    {
        if(_PC == null)
        {
            Debug.Log("パラメータコンテナがnull");
            return false;
        }

        return _PC.GetBool("IsPartActionSuccess");
    }

    /// <summary>
    /// パート完了フラグのセット
    /// </summary>
    /// <param name="success"></param>
    public void setPartActionSuccess(bool success)
    {
        if (_PC == null)
        {
            Debug.Log("パラメータコンテナがnull");
        }

        _PC.SetBool("IsPartActionSuccess",success);

    }

    /// <summary>
    /// 思考FSMの再開（ループリセット、次パートへの遷移用）
    /// </summary>
    public void restartThinkFSM()
    {
        if(_ThinkFSM != null)
        {
            var state = _ThinkFSM.FindState("ActionStart");
            _ThinkFSM.Transition(state);
        }
    }

    /// <summary>
    /// パートごとの開始位置に戻す（ループリセット用）
    /// </summary>
    /// <param name="part"></param>
    public override void resetPartTransform(int part)
    {
        // とりあえず開始時の座標を入れる
        // TODO各パート開始位置を保存しておいて指定する？
        var agent = GetComponent<NavMeshAgent>(); // ナビ用エージェントがついてると座標指定移動ができないことがあるので切って設定
        agent.enabled = false;
        transform.SetLocalPositionAndRotation(_PartStartPosList[part], transform.rotation);
        agent.enabled = true;
    }

    /// <summary>
    /// パートを指定して吹き出しテキストセット
    /// </summary>
    /// <param name="partNo"></param>
    public void setPartBaroonText(int partNo)
    {
        var testimonyData = WitnessManager.Instance.getTestimonyData(partNo, WitnessId);
        var text = "";
        if (testimonyData != null)
        {
            text = testimonyData.getTextimony();
        }
        setBaroonText(text);
    }


    /// <summary>
    /// 吹き出しの文章セット
    /// </summary>
    /// <param name="text"></param>
    private void setBaroonText(string text)
    {
        _BaroonText.text = text;
    }

}