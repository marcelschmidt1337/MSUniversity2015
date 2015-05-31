using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using WallOfFame.Client.Net35;
using System.Collections.Generic;
using WallOfFame.Client.Shared.DataContracts;
using System.Linq;
using System;

public class HighscoreScreen : MonoBehaviour , IUIScreen
{
	const string GAME_GUID = "480d4d21-7138-41a4-b77a-5a2af1de2097";
	Guid Guid = new Guid(GAME_GUID);

	public UIState StateId { get { return UIState.HighscoreScreen; } }

	[SerializeField]
	private GameObject ScrollBarContent;

	[SerializeField]
	private GameObject ScrollBarContentTemplate;

	private WofClient WofClient;
	private List<Round> HighscoreData = new List<Round>();

	public void Activate () {
		this.gameObject.SetActive( true );
		this.WofClient = new WofClient( GAME_GUID );
        var selectedGo = GetComponentInChildren<Button>().gameObject;
        EventSystem.current.SetSelectedGameObject(selectedGo);

		FetchScoreData();
		CreateUIList();
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

	private void FetchScoreData () {
		var response = this.WofClient.GetRounds().Rounds.Where( x => x.GameId == this.Guid ).ToList();
		this.HighscoreData = response;
	}

	private void CreateUIList()
	{
		foreach(var element in this.HighscoreData)
		{
			var instance = Instantiate( this.ScrollBarContentTemplate );
			instance.transform.SetParent( this.ScrollBarContent.transform );
			instance.GetComponent<Text>().text = element.Playername + "    " + element.PlayerComment + "    " + element.Score;
		}
	}
}
