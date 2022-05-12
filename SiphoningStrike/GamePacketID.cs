﻿using System;
namespace SiphoningStrike
{
    /*
    * Game packet IDs
    * BID = bi-directional, C2S = client to server, S2C = server to cliet, UNK = unknown yet
    */
    public enum GamePacketID
    {
        BID_Dummy                                = 0x000, // Done
        S2C_SPM_HierarchicalProfilerUpdate       = 0x001, // Done
        S2C_DisplayLocalizedTutorialChatText     = 0x002, // Done
        S2C_Barrack_SpawnUnit                    = 0x003, // Done
        S2C_SwitchNexusesToOnIdleParticles       = 0x004, // Done
        C2S_TutorialAudioEventFinished           = 0x005, // Done
        S2C_SetCircularMovementRestriction       = 0x006, // Done
        S2C_UpdateGoldRedirectTarget             = 0x007, // Done
        C2S_SynchSimTime                         = 0x008, // Done
        C2S_RemoveItemReq                        = 0x009, // Done
        BID_ResumePacket                         = 0x00A, // Done
        S2C_RemoveItemAns                        = 0x00B, // Done
        UNK_Unused_0C                            = 0x00C, // Done
        S2C_Basic_Attack                         = 0x00D, // Done
        S2C_RefreshObjectiveText                 = 0x00E, // Done
        S2C_CloseShop                            = 0x00F, // Done
        S2C_Reconnect                            = 0x010, // Done
        S2C_UnitAddEXP                           = 0x011, // Done
        S2C_EndSpawn                             = 0x012, // Done
        S2C_SetFrequency                         = 0x013, // Done
        S2C_HighlightTitanBarElement             = 0x014, // Done
        S2C_BotAI                                = 0x015, // Done
        S2C_TeamSurrenderCountDown               = 0x016, // Done
        C2S_QueryStatusReq                       = 0x017, // Done
        S2C_NPC_UpgradeSpellAns                  = 0x018, // Done
        C2S_Ping_Load_Info                       = 0x019, // Done
        S2C_ChangeSlotSpellType                  = 0x01A, // Done
        S2C_NPC_MessageToClient                  = 0x01B, // Done
        S2C_DisplayFloatingText                  = 0x01C, // Done
        S2C_Basic_Attack_Pos                     = 0x01D, // Done
        S2C_NPC_ForceDead                        = 0x01E, // Done
        S2C_NPC_BuffUpdateCount                  = 0x01F, // Done
        C2S_WriteNavFlags_Acc                    = 0x020, // Done
        S2C_NPC_BuffReplaceGroup                 = 0x021, // Done
        S2C_NPC_SetAutocast                      = 0x022, // Done
        C2S_SwapItemReq                          = 0x023, // Done
        S2C_NPC_Die_EventHistory                 = 0x024, // Done
        S2C_UnitAddGold                          = 0x025, // Done
        S2C_AddUnitPerceptionBubble              = 0x026, // Done
        S2C_MoveCameraToPoint                    = 0x027, // Done
        S2C_LineMissileHitList                   = 0x028, // Done
        S2C_MuteVolumeCategory                   = 0x029, // Done
        S2C_ServerTick                           = 0x02A, // Done
        S2C_StopAnimation                        = 0x02B, // Done
        S2C_AvatarInfo_Server                    = 0x02C, // Done
        S2C_DampenerSwitch                       = 0x02D, // Done
        S2C_World_SendCamera_Server_Ack          = 0x02E, // Done
        S2C_ModifyDebugCircleRadius              = 0x02F, // Done
        C2S_World_SendCamera_Server              = 0x030, // Done
        S2C_HeroReincarnateAlive                 = 0x031, // Done
        S2C_NPC_BuffReplace                      = 0x032, // Done
        S2C_Pause                                = 0x033, // Done
        S2C_SetFadeOut_Pop                       = 0x034, // Done
        S2C_ChangeSlotSpellName                  = 0x035, // Done
        S2C_ChangeSlotSpellIcon                  = 0x036, // Done
        S2C_ChangeSlotSpellOffsetTarget          = 0x037, // Done
        S2C_RemovePerceptionBubble               = 0x038, // Done
        S2C_NPC_InstantStop_Attack               = 0x039, // Done
        S2C_OnLeaveLocalVisiblityClient          = 0x03A, // Done
        S2C_ShowObjectiveText                    = 0x03B, // Done
        S2C_CHAR_SpawnPet                        = 0x03C, // Done
        S2C_FX_Kill                              = 0x03D, // Done
        C2S_NPC_UpgradeSpellReq                  = 0x03E, // Done
        C2S_UseObject                            = 0x03F, // Done
        UNK_Turret_CreateTurret                  = 0x040, // Todo: unused?
        S2C_MissileReplication                   = 0x041, // Done
        S2C_ResetForSlowLoader                   = 0x042, // Done
        S2C_HighlightHUDElement                  = 0x043, // Done
        S2C_SwapItemAns                          = 0x044, // Done
        S2C_NPC_LevelUp                          = 0x045, // Done
        S2C_MapPing                              = 0x046, // Done
        S2C_WriteNavFlags                        = 0x047, // Done
        S2C_PlayEmote                            = 0x048, // Done
        S2C_Reconnect_Done                       = 0x049, // Done
        S2C_OnEventWorld                         = 0x04A, // Fixme: no
        S2C_HeroStats                            = 0x04B, // Fixme: no
        C2S_PlayEmote                            = 0x04C, // Done
        S2C_HeroReincarnate                      = 0x04D, // Done
        C2S_OnScoreBoardOpened                   = 0x04E, // Done
        S2C_CreateHero                           = 0x04F, // Done
        C2S_SPM_AddMemoryListener                = 0x050, // Done
        S2C_SPM_HierarchicalMemoryUpdate         = 0x051, // Done
        S2C_ToggleUIHighlight                    = 0x052, // Done
        S2C_FaceDirection                        = 0x053, // Done
        S2C_OnLeaveVisiblityClient               = 0x054, // Done
        C2S_ClientReady                          = 0x055, // Done
        S2C_SetItem                              = 0x056, // Done
        S2C_SynchVersion                         = 0x057, // Done
        S2C_HandleTipUpdate                      = 0x058, // Done
        C2S_StatsUpdateReq                       = 0x059, // Done
        C2S_MapPing                              = 0x05A, // Done
        S2C_RemoveDebugCircle                    = 0x05B, // Done
        S2C_CreateUnitHighlight                  = 0x05C, // Done
        S2C_DestroyClientMissile                 = 0x05D, // Done
        S2C_LevelUpSpell                         = 0x05E, // Done
        S2C_StartGame                            = 0x05F, // Done
        C2S_OnShopOpened                         = 0x060, // Done
        S2C_NPC_Hero_Die                         = 0x061, // Done
        S2C_FadeOutMainSFX                       = 0x062, // Done
        UNK_UserMessagesStart                    = 0x063, // Todo: unused?
        S2C_WaypointGroup                        = 0x064, // Done
        S2C_StartSpawn                           = 0x065, // Done
        S2C_CreateNeutral                        = 0x066, // Done
        S2C_WaypointGroupWithSpeed               = 0x067, // Done
        S2C_UnitApplyDamage                      = 0x068, // Done
        S2C_ModifyShield                         = 0x069, // Done
        S2C_PopCharacterData                     = 0x06A, // Done
        S2C_NPC_BuffAddGroup                     = 0x06B, // Done
        S2C_AI_TargetSelection                   = 0x06C, // Done
        S2C_AI_Target                            = 0x06D, // Done
        S2C_SetAnimStates                        = 0x06E, // Done
        S2C_ChainMissileSync                     = 0x06F, // Done
        C2S_OnTipEvent                           = 0x070, // Done
        S2C_MissileReplication_ChainMissile      = 0x071, // Done
        S2C_BuyItemAns                           = 0x072, // Done
        S2C_SetSpellData                         = 0x073, // Done
        S2C_PauseAnimation                       = 0x074, // Done
        C2S_NPC_IssueOrderReq                    = 0x075, // Done
        S2C_CameraBehavior                       = 0x076, // Done
        S2C_AnimatedBuildingSetCurrentSkin       = 0x077, // Done
        S2C_Connected                            = 0x078, // Done
        S2C_SyncSimTimeFinal                     = 0x079, // Done
        C2S_Waypoint_Acc                         = 0x07A, // Done
        S2C_AddPosPerceptionBubble               = 0x07B, // Done
        S2C_LockCamera                           = 0x07C, // Done
        S2C_PlayVOAudioEvent                     = 0x07D, // Done
        C2S_AI_Command                           = 0x07E, // Done
        S2C_NPC_BuffRemove2                      = 0x07F, // Done
        S2C_SpawnMinion                          = 0x080, // Done
        C2S_ClientCheatDetectionSignal           = 0x081, // Done
        S2C_ToggleFoW                            = 0x082, // Done
        S2C_ToolTipVars                          = 0x083, // Done
        S2C_UnitApplyHeal                        = 0x084, // Done
        S2C_GlobalCombatMessage                  = 0x085, // Done
        C2S_World_LockCamera_Server              = 0x086, // Done
        C2S_BuyItemReq                           = 0x087, // Done
        S2C_WaypointListHeroWithSpeed            = 0x088, // Done
        S2C_SetInputLockingFlag                  = 0x089, // Done
        S2C_CHAR_SetCooldown                     = 0x08A, // Done
        S2C_CHAR_CancelTargetingReticle          = 0x08B, // Done
        S2C_FX_Create_Group                      = 0x08C, // Done
        S2C_QueryStatusAns                       = 0x08D, // Done
        S2C_Building_Die                         = 0x08E, // Done
        C2S_SPM_RemoveListener                   = 0x08F, // Done
        S2C_HandleQuestUpdate                    = 0x090, // Done
        C2S_ClientFinished                       = 0x091, // Done
        UNK_CHAT                                 = 0x092, // Done
        C2S_SPM_RemoveMemoryListener             = 0x093, // Done
        C2S_Exit                                 = 0x094, // Done
        S2C_ServerGameSettings                   = 0x095, // Done
        S2C_ModifyDebugCircleColor               = 0x096, // Done
        C2S_SPM_AddListener                      = 0x097, // Done
        S2C_World_SendGameNumber                 = 0x098, // Done
        S2C_ChangePARColorOverride               = 0x099, // Done
        UNK_ClientConnect_NamedPipe              = 0x09A, // Done
        S2C_NPC_BuffRemoveGroup                  = 0x09B, // Done
        UNK_Turret_Fire                          = 0x09C, // Done
        S2C_Ping_Load_Info                       = 0x09D, // Done
        S2C_ChangeCharacterVoice                 = 0x09E, // Done
        S2C_ChangeCharacterData                  = 0x09F, // Done
        S2C_Exit                                 = 0x0A0, // Done
        C2S_SPM_RemoveBBProfileListener          = 0x0A1, // Done
        C2S_NPC_CastSpellReq                     = 0x0A2, // Done
        S2C_ToggleInputLockingFlag               = 0x0A3, // Done
        C2S_Reconnect                            = 0x0A4, // Done
        S2C_CreateTurret                         = 0x0A5, // Done
        S2C_NPC_Die                              = 0x0A6, // Done
        S2C_UseItemAns                           = 0x0A7, // Done
        S2C_ShowAuxiliaryText                    = 0x0A8, // Done
        BID_PausePacket                          = 0x0A9, // Done
        S2C_HideObjectiveText                    = 0x0AA, // Done
        S2C_OnEvent                              = 0x0AB, // Fixme: no
        C2S_TeamSurrenderVote                    = 0x0AC, // Done
        S2C_TeamSurrenderStatus                  = 0x0AD, // Done
        C2S_SPM_AddBBProfileListener             = 0x0AE, // Done
        S2C_HideAuxiliaryText                    = 0x0AF, // Done
        C2S_OnReplication_Acc                    = 0x0B0, // Done
        UNK_OnDisconnected                       = 0x0B1, // Todo: unused?
        S2C_SetGreyscaleEnabledWhenDead          = 0x0B2, // Done
        S2C_AI_State                             = 0x0B3, // Done
        S2C_SetFoWStatus                         = 0x0B4, // Done
        S2C_OnEnterLocalVisiblityClient          = 0x0B5, // Done
        S2C_HighlightShopElement                 = 0x0B6, // Done
        C2S_SendSelectedObjID                    = 0x0B7, // Done
        S2C_PlayAnimation                        = 0x0B8, // Done
        S2C_RefreshAuxiliaryText                 = 0x0B9, // Done
        S2C_SetFadeOut_Push                      = 0x0BA, // Done
        S2C_OpenTutorialPopup                    = 0x0BB, // Done
        S2C_RemoveUnitHighlight                  = 0x0BC, // Done
        S2C_NPC_CastSpellAns                     = 0x0BD, // Done
        S2C_SPM_HierarchicalBBProfileUpdate      = 0x0BE, // Done
        S2C_NPC_BuffAdd2                         = 0x0BF, // Done
        S2C_OpenAFKWarningMessage                = 0x0C0, // Done
        S2C_WaypointList                         = 0x0C1, // Done
        S2C_OnEnterVisiblityClient               = 0x0C2, // Done
        S2C_AddDebugCircle                       = 0x0C3, // Done
        S2C_DisableHUDForEndOfGame               = 0x0C4, // Done
        C2S_SynchVersion                         = 0x0C5, // Done
        C2S_CharSelected                         = 0x0C6, // Done
        S2C_NPC_BuffUpdateCountGroup             = 0x0C7, // Done
        S2C_AI_TargetHero                        = 0x0C8, // Done
        S2C_SynchSimTime                         = 0x0C9, // Done
        S2C_SyncMissionStartTime                 = 0x0CA, // Done
        S2C_Neutral_Camp_Empty                   = 0x0CB, // Done
        S2C_OnReplication                        = 0x0CC, // Done
        S2C_EndOfGameEvent                       = 0x0CD, // Done
        S2C_EndGame                              = 0x0CE, // Done
        UNK_Undefined                            = 0x0CF, // Done
        S2C_SPM_SamplingProfilerUpdate           = 0x0D0, // Done
        S2C_PopAllCharacterData                  = 0x0D1, // Done
        S2C_TeamSurrenderVote                    = 0x0D2, // Done
        S2C_HandleUIHighlight                    = 0x0D3, // Done
        S2C_FadeMinions                          = 0x0D4, // Done
        C2S_OnTutorialPopupClosed                = 0x0D5, // Done
        C2S_OnQuestEvent                         = 0x0D6, // Done
        S2C_ShowHealthBar                        = 0x0D7, // Done
        S2C_SpawnBot                             = 0x0D8, // Done
        S2C_SpawnLevelProp                       = 0x0D9, // Done
        S2C_UpdateLevelProp                      = 0x0DA, // Done
        S2C_AttachFlexParticle                   = 0x0DB, // Done
        S2C_HandleCapturePointUpdate             = 0x0DC, // Done
        S2C_HandleGameScore                      = 0x0DD, // Done
        S2C_HandleRespawnPointUpdate             = 0x0DE, // Done
        C2S_OnRespawnPointEvent                  = 0x0DF, // Done
        S2C_UnitChangeTeam                       = 0x0E0, // Done
        S2C_UnitSetMinimapIcon                   = 0x0E1, // Done
        S2C_IncrementPlayerScore                 = 0x0E2, // Done
        S2C_IncrementPlayerStat                  = 0x0E3, // Done
        S2C_ColorRemapFX                         = 0x0E4, // Done
        S2C_MusicCueCommand                      = 0x0E5, // Done
        S2C_AntiBot                              = 0x0E6, // Done
        S2C_AntiBotWriteLog                      = 0x0E7, // Done
        S2C_AntiBotKickOut                       = 0x0E8, // Done
        S2C_AntiBotBanPlayer                     = 0x0E9, // Done
        S2C_AntiBotTrojan                        = 0x0EA, // Done
        S2C_AntiBotCloseClient                   = 0x0EB, // Done
        C2S_AntiBotDP                            = 0x0EC, // Done
        C2S_AntiBot                              = 0x0ED, // Done
        S2C_OnEnterTeamVisiblity                 = 0x0EE, // Done
        S2C_OnLeaveTeamVisiblity                 = 0x0EF, // Done
        S2C_FX_OnEnterTeamVisiblity              = 0x0F0, // Done
        S2C_FX_OnLeaveTeamVisiblity              = 0x0F1, // Done
        S2C_ReplayOnly_GoldEarned                = 0x0F2, // Done

        ExtendedPacket                           = 0x0FE, //
        Batch                                    = 0x0FF, //
    }
}
