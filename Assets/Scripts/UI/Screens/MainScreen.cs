using UnityEngine;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.EventSystems;
#endif

public class MainScreen : MonoBehaviour, IUIScreen
{
	public GameObject UI_Background;
	public UIState StateId {get {return UIState.MainScreen; } }

	public void Activate () {
		this.gameObject.SetActive( true );
		Application.LoadLevelAdditive( "UI_background" );
        var selectedGo = GetComponentInChildren<Button>().gameObject;
        EventSystem.current.SetSelectedGameObject(selectedGo);
	}

	public void Deactivate (System.Action onDone) {
        var animator = this.gameObject.GetComponent<Animator>();
        animator.GetBehaviour<AnimationFinished>().RegisterOnDoneCallBack(() =>
        {
            this.gameObject.SetActive(false);
            onDone();
        });
        animator.Play("HideUI");
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
		UIScreenHandler.Instance.ChangeState( UIState.IngameScreen );
	}
}
