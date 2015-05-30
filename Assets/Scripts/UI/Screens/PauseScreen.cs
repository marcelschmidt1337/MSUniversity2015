using UnityEngine;
using System.Collections;

public class PauseScreen : MonoBehaviour, IUIScreen 
{
	public UIState StateId { get { return UIState.PauseScreen; } }

	public void Activate () {
		this.gameObject.SetActive( true );
	}

	public void Deactivate (System.Action onDone) {
		this.gameObject.SetActive( false );
		onDone();
	}

	public void GotoMainMenu () {
		UIScreenHandler.Instance.ChangeState( UIState.MainScreen );
	}

	public void Continue () {
		UIScreenHandler.Instance.ChangeState( UIState.IngameScreen );
	}
}
