using UnityEngine;
using System.Collections;

public interface IUIScreen
{
	UIState StateId {get;}
	void Activate();
	void Deactivate(System.Action onDone);
}
