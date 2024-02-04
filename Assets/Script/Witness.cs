using Arbor;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Witness : Humanoid
{
    /// <summary>
    /// BT制御用のパラメータコンテナ
    /// </summary>
    private ParameterContainer _PC;

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

        var trans = GetComponent<Transform>();
        _PartStartPos = trans.position;
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
    public void resetPartTransform(int part)
    {
        // とりあえず開始時の座標を入れる
        // TODO各パート開始位置を保存しておいて指定する？
        transform.SetPositionAndRotation(_PartStartPos, transform.rotation);

    }

}
