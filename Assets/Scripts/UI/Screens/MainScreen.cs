using UnityEngine;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MainScreen : MonoBehaviour, IUIScreen
{
	public UIState StateId {get {return UIState.MainScreen; } }

	public void Activate () {
		this.gameObject.SetActive( true );
	}

	public void Deactivate (System.Action onDone) {
		this.gameObject.SetActive( false );
		onDone();
	}

	public void Quit () {
#if UNITY_EDITOR
		EditorApplication.isPlaying = false;
#endif
		Application.Quit();
	}

	public void Highscore () {
		UIScreenHandler.Instance.ChangeState( UIState.HighscoreScreen );
	}

	public void StartGame () {
		throw new System.NotImplementedException();
	}
}
