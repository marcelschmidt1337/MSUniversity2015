using UnityEngine;
using System.Collections;

public class UIScreenHandler : MonoBehaviour 
{
	public static UIScreenHandler Instance;
	public event System.Action<UIState> OnUIStateChanged = (newState) => { };

	public GameObject[] Screens;
	private IUIScreen[] UIScreens;
	private IUIScreen ActiveScreen;

	void Start () {
		if (UIScreenHandler.Instance == null) {
			UIScreenHandler.Instance = this;
		}
		SetupInterfaces();
		this.ActiveScreen = GetScreenForState( UIState.MainScreen );
	}

	private void SetupInterfaces () {
		this.UIScreens = new IUIScreen[this.Screens.Length];

		for (int i = 0; i < this.Screens.Length; i++) {
			this.UIScreens[i] = this.Screens[i].GetComponent(typeof(IUIScreen)) as IUIScreen;
		}
	}

	public void ChangeState (UIState newState) {
		this.ActiveScreen.Deactivate( () => {
			this.ActiveScreen = GetScreenForState( newState );
			this.ActiveScreen.Activate();
		} );
	}

	private IUIScreen GetScreenForState (UIState uiState) {
		for (int i = 0; i < this.UIScreens.Length; i++) {
			if (this.UIScreens[i].StateId == uiState) {
				return this.UIScreens[i];
			}
		}

		throw new System.NotImplementedException( "UIScreen for state " + uiState.ToString() + "not found!" );
	}
}
