using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UIScreenHandler : MonoBehaviour 
{
	public static UIScreenHandler Instance;
	public event System.Action<UIState> OnUIStateChanged = (newState) => { };

	public GameObject[] Screens;
	private IUIScreen[] UIScreens;
	private IUIScreen ActiveScreen;

    private List<RootObjects> LoadedRootObjects = new List<RootObjects>();

	void Start () {
		if (UIScreenHandler.Instance == null) {
			UIScreenHandler.Instance = this;
		}
		SetupInterfaces();
		this.ActiveScreen = GetScreenForState( UIState.MainScreen );
        this.ActiveScreen.Activate();
	}

	private void SetupInterfaces () {
		this.UIScreens = new IUIScreen[this.Screens.Length];

		for (int i = 0; i < this.Screens.Length; i++) {
			this.UIScreens[i] = this.Screens[i].GetComponent(typeof(IUIScreen)) as IUIScreen;
		}
	}

	public void ChangeState (UIState newState) {
		this.ActiveScreen.Deactivate( () => {
			if (newState != UIState.PauseScreen && this.ActiveScreen.StateId != UIState.PauseScreen) {
				 ClearLoadedRootObjects();
			}
			this.ActiveScreen = GetScreenForState( newState );
			this.ActiveScreen.Activate();
		} );
	}

    private void ClearLoadedRootObjects()
    {
        this.LoadedRootObjects.ForEach((element) => { Destroy(element.gameObject); });
        this.LoadedRootObjects.Clear();
    }

	private IUIScreen GetScreenForState (UIState uiState) {
		for (int i = 0; i < this.UIScreens.Length; i++) {
			if (this.UIScreens[i].StateId == uiState) {
				return this.UIScreens[i];
			}
		}

		throw new System.NotImplementedException( "UIScreen for state " + uiState.ToString() + "not found!" );
	}

    public void RegisterRootObject(RootObjects rootObject)
    {
        this.LoadedRootObjects.Add(rootObject);
    }
}
