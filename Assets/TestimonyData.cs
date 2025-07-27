using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "証言データ")]
public class TestimonyData : ScriptableObject 
{
    /// <summary>
    /// 証言者ID
    /// </summary>
    public WitnessManager.WitnessId WitnessId;

	/// <summary>
	/// 証言内容実行者（証人自身か他の人、あるいは遮蔽物などモノが入ることもある？）
	/// </summary>
	private ITestimonyActor _Actor;

	public ITestimonyActor Actor => _Actor;


	/// <summary>
	/// 証言ID
	/// </summary>.
	public TestimonyManager.TestimonyID TestimonyId;

    public int Stage = -1;
    public int PartNo = -1;

	public string ActorName;
    public string BaseTestimony;
    public EvidenceManager.EvidenceId EvidenceId;
    public string UpdateTestimony;

	/// <summary>
	/// サムネイル
	/// </summary>
	[SerializeField] private Sprite _Tmb;
	public Sprite Tmb { get => _Tmb; }

	public string getBaseTextimonyText()
    {
        // 条件達成してたら更新後の証言を返す判定

        return BaseTestimony;
    }
}
