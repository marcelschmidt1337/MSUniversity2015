using UnityEngine;
using System.Collections;

public class PauseScreen : MonoBehaviour, IUIScreen 
{
	public UIState StateId { get { return UIState.PauseScreen; } }

	public void Activate () {
		throw new System.NotImplementedException();
	}

	public void Deactivate (System.Action onDone) {
		onDone();
	}
}
