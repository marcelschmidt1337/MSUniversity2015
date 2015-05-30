using UnityEngine;
using System.Collections;

public class HighscoreScreen : MonoBehaviour , IUIScreen
{
	public UIState StateId { get { return UIState.HighscoreScreen; } }

	public void Activate () {
		this.gameObject.SetActive( true );
	}

	public void Deactivate (System.Action onDone) {
		this.gameObject.SetActive( false );
		onDone();
	}

	public void GoBack () {
		UIScreenHandler.Instance.ChangeState( UIState.MainScreen );
	}
}
