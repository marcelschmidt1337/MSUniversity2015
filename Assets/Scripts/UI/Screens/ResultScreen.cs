using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using WallOfFame.Client.Net35;

public class ResultScreen : MonoBehaviour, IUIScreen {

	[SerializeField]
	private InputField NameInput;

	[SerializeField]
	private InputField CommentInput;

	[SerializeField]
	private Text Description;

	[SerializeField]
	private Text Score;

	public UIState StateId { get { return UIState.ResultScreen; } }

	private WofClient WofClient;
	private Player Winner;

	public void Activate (UIState OldState) {
		this.gameObject.SetActive( true );
		var selectedGo = GetComponentInChildren<Button>().gameObject;
		EventSystem.current.SetSelectedGameObject( selectedGo );
		this.WofClient = new WofClient( "480d4d21-7138-41a4-b77a-5a2af1de2097 " );
		this.Winner = GameManager.Instance.WinningPlayer;
		this.Description.text = string.Format("Player {0} won!", this.Winner.ID);
		this.Score.text = string.Format( "Score {0}", this.Winner.Score );
	}

	public void Deactivate (System.Action onDone) {
		this.gameObject.SetActive( false );
		onDone();
	}

	public void SubmitScore () {
		if(!string.IsNullOrEmpty(this.NameInput.text))
		{
			this.WofClient.EndRound(this.NameInput.text, this.CommentInput.text, this.Winner.Score);
			UIScreenHandler.Instance.ChangeState( UIState.HighscoreScreen );
		}
	}

	public void GotoMainMenu () {
		UIScreenHandler.Instance.ChangeState( UIState.MainScreen );
	}
}
