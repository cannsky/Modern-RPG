using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCursorUI
{
    public class CursorUIState
    {
        public PlayerWorker playerWorker;

        public PlayerUISettings uiSettings;

        public CursorUIState(PlayerWorker playerWorker, PlayerUISettings uiSettings)
        {
            this.playerWorker = playerWorker;
            this.uiSettings = uiSettings;
        }
    }

    public CursorUIState cursorUIState;

    public PlayerCursorUI(PlayerWorker playerWorker) => cursorUIState = new CursorUIState(playerWorker, playerWorker.player.playerSettings.uiSettings);

    public void Start() => Cursor.visible = false;

    public void ToggleCursor() => Cursor.visible = !Cursor.visible;
}
