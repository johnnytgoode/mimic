using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "�،��f�[�^")]
public class TestimonyData : ScriptableObject 
{
    /// <summary>
    /// �،���ID
    /// </summary>
    public WitnessManager.WitnessId WitnessId;

	/// <summary>
	/// �،����e���s�ҁi�ؐl���g�����̐l�A���邢�͎Օ����Ȃǃ��m�����邱�Ƃ�����H�j
	/// </summary>
	private ITestimonyActor _Actor;

	public ITestimonyActor Actor => _Actor;


	/// <summary>
	/// �،�ID
	/// </summary>.
	public TestimonyManager.TestimonyID TestimonyId;

    public int Stage = -1;
    public int PartNo = -1;

	public string ActorName;
    public string BaseTestimony;
    public EvidenceManager.EvidenceId EvidenceId;
    public string UpdateTestimony;

	/// <summary>
	/// �T���l�C��
	/// </summary>
	[SerializeField] private Sprite _Tmb;
	public Sprite Tmb { get => _Tmb; }

	public string getBaseTextimonyText()
    {
        // �����B�����Ă���X�V��̏،���Ԃ�����

        return BaseTestimony;
    }
}
