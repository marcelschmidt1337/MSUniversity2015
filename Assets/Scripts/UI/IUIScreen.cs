using UnityEngine;
using System.Collections;

public interface IUIScreen
{
	UIState StateId {get;}
	void Activate(UIState OldState);
	void Deactivate(System.Action onDone);
}
