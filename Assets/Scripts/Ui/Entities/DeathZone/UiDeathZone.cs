﻿namespace SpaceMarine
{
    public class UiDeathZone : UiBaseEntity
    {
        protected override void OnTriggerEnterPlayer() => GameData.Instance.Game.Player.Destroy();
    }
}