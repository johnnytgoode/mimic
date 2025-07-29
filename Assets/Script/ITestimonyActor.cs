using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITestimonyActor
{


	//public int PartNo {get;set;}

	public TestimonyManager.TestimonyType Type { get; }

	[SerializeField]
	public TestimonyManager.TestimonyActorID ActorId { get; }

}
