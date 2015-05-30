using UnityEngine;
using System.Collections;

public class IngameScreen : MonoBehaviour, IUIScreen 
{

	public UIState StateId { get { return UIState.IngameScreen; } }

	public void Activate () {
		this.gameObject.SetActive( true );
	}

	public void Deactivate (System.Action onDone) {
		this.gameObject.SetActive( false );
		onDone();
	}
}
