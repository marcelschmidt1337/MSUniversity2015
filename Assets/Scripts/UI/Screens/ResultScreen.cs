using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ResultScreen : MonoBehaviour, IUIScreen {

	public UIState StateId { get { return UIState.ResultScreen; } }

	public void Activate () {
		this.gameObject.SetActive( true );
		var selectedGo = GetComponentInChildren<Button>().gameObject;
		EventSystem.current.SetSelectedGameObject( selectedGo );
	}

	public void Deactivate (System.Action onDone) {
		this.gameObject.SetActive( false );
		onDone();
	}

	public void SubmitScore () {

	}
}
