using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HighscoreScreen : MonoBehaviour , IUIScreen
{
	public UIState StateId { get { return UIState.HighscoreScreen; } }

    public void Activate(UIState OldState)
    {
		this.gameObject.SetActive( true );
        var selectedGo = GetComponentInChildren<Button>().gameObject;
        EventSystem.current.SetSelectedGameObject(selectedGo);
	}

	public void Deactivate (System.Action onDone) {
		this.gameObject.SetActive( false );
		onDone();
	}

	public void GoBack () {
		UIScreenHandler.Instance.ChangeState( UIState.MainScreen );
	}

    void Update()
    {
        if(Input.GetButtonDown("Cancel"))
        {
            GoBack();
        }
    }
}
