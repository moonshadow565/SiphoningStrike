using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;

namespace SiphoningStrike.Game.Events
{
    public class OnDie : Event<ArgsDie, ArgsBase>
    {
        public override EventID ID => EventID.OnDie;
    }
    public class OnKill : Event<ArgsBase, ArgsBase>
    {
        public override EventID ID => EventID.OnKill;
    }
    public class OnChampionDie : Event<ArgsBase, ArgsBase>
    {
        public override EventID ID => EventID.OnChampionDie;
    }
    public class OnChampionKill : Event<ArgsBase, ArgsBase>
    {
        public override EventID ID => EventID.OnChampionKill;
    }
    public class OnChampionDoubleKill : Event<ArgsBase, ArgsBase>
    {
        public override EventID ID => EventID.OnChampionDoubleKill;
    }
    public class OnChampionTripleKill : Event<ArgsBase, ArgsBase>
    {
        public override EventID ID => EventID.OnChampionTripleKill;
    }
    public class OnChampionQuadraKill : Event<ArgsBase, ArgsBase>
    {
        public override EventID ID => EventID.OnChampionQuadraKill;
    }
    public class OnChampionPentaKill : Event<ArgsBase, ArgsBase>
    {
        public override EventID ID => EventID.OnChampionPentaKill;
    }
    public class OnChampionUnrealKill : Event<ArgsBase, ArgsBase>
    {
        public override EventID ID => EventID.OnChampionUnrealKill;
    }
    public class OnFirstBlood : Event<ArgsBase, ArgsBase>
    {
        public override EventID ID => EventID.OnFirstBlood;
    }
    public class OnDamageTaken : Event<ArgsDamage, ArgsDamage>
    {
        public override EventID ID => EventID.OnDamageTaken;
    }
    public class OnDamageGiven : Event<ArgsDamage, ArgsDamage>
    {
        public override EventID ID => EventID.OnDamageGiven;
    }
    public class OnSpellCast1 : Event<ArgsBase, ArgsBase>
    {
        public override EventID ID => EventID.OnSpellCast1;
    }
    public class OnSpellCast2 : Event<ArgsBase, ArgsBase>
    {
        public override EventID ID => EventID.OnSpellCast2;
    }
    public class OnSpellCast3 : Event<ArgsBase, ArgsBase>
    {
        public override EventID ID => EventID.OnSpellCast3;
    }
    public class OnSpellCast4 : Event<ArgsBase, ArgsBase>
    {
        public override EventID ID => EventID.OnSpellCast4;
    }
    public class OnSpellAvatarCast1 : Event<ArgsBase, ArgsBase>
    {
        public override EventID ID => EventID.OnSpellAvatarCast1;
    }
    public class OnSpellAvatarCast2 : Event<ArgsBase, ArgsBase>
    {
        public override EventID ID => EventID.OnSpellAvatarCast2;
    }
    public class OnGoldSpent : Event<ArgsGoldSpent, ArgsBase>
    {
        public override EventID ID => EventID.OnGoldSpent;
    }
    public class OnGoldEarned : Event<ArgsGoldEarned, ArgsBase>
    {
        public override EventID ID => EventID.OnGoldEarned;
    }
    public class OnItemConsumeablePurchased : Event<ArgsItemConsumedPurchased, ArgsBase>
    {
        public override EventID ID => EventID.OnItemConsumeablePurchased;
    }
    public class OnCriticalStrike : Event<ArgsDamageCriticalStrike, ArgsBase>
    {
        public override EventID ID => EventID.OnCriticalStrike;
    }
    public class OnAce : Event<ArgsBase, ArgsBase>
    {
        public override EventID ID => EventID.OnAce;
    }
    public class OnReincarnate : Event<ArgsBase, ArgsBase>
    {
        public override EventID ID => EventID.OnReincarnate;
    }
    public class OnDampenerKill : Event<ArgsBase, ArgsBase>
    {
        public override EventID ID => EventID.OnDampenerKill;
    }
    public class OnDampenerDie : Event<ArgsBase, ArgsBase>
    {
        public override EventID ID => EventID.OnDampenerDie;
    }
    public class OnDampenerRespawnSoon : Event<ArgsBase, ArgsBase>
    {
        public override EventID ID => EventID.OnDampenerRespawnSoon;
    }
    public class OnDampenerRespawn : Event<ArgsBase, ArgsBase>
    {
        public override EventID ID => EventID.OnDampenerRespawn;
    }
    public class OnTurretKill : Event<ArgsBase, ArgsBase>
    {
        public override EventID ID => EventID.OnTurretKill;
    }
    public class OnTurretDie : Event<ArgsBase, ArgsBase>
    {
        public override EventID ID => EventID.OnTurretDie;
    }
    public class OnMinionKill : Event<ArgsBase, ArgsBase>
    {
        public override EventID ID => EventID.OnMinionKill;
    }
    public class OnMinionDenied : Event<ArgsBase, ArgsBase>
    {
        public override EventID ID => EventID.OnMinionDenied;
    }
    public class OnNeutralMinionKill : Event<ArgsBase, ArgsBase>
    {
        public override EventID ID => EventID.OnNeutralMinionKill;
    }
    public class OnSuperMonsterKill : Event<ArgsBase, ArgsBase>
    {
        public override EventID ID => EventID.OnSuperMonsterKill;
    }
    public class OnHQKill : Event<ArgsBase, ArgsBase>
    {
        public override EventID ID => EventID.OnHQKill;
    }
    public class OnHQDie : Event<ArgsBase, ArgsBase>
    {
        public override EventID ID => EventID.OnHQDie;
    }
    public class OnHeal : Event<ArgsHeal, ArgsBase>
    {
        public override EventID ID => EventID.OnHeal;
    }
    public class OnCastHeal : Event<ArgsHeal, ArgsHeal>
    {
        public override EventID ID => EventID.OnCastHeal;
    }
    public class OnBuff : Event<ArgsBuff, ArgsBuff>
    {
        public override EventID ID => EventID.OnBuff;
    }
    public class OnKillingSpree : Event<ArgsKillingSpree, ArgsBase>
    {
        public override EventID ID => EventID.OnKillingSpree;
    }
    public class OnKillingSpreeSet1 : Event<ArgsBase, ArgsBase>
    {
        public override EventID ID => EventID.OnKillingSpreeSet1;
    }
    public class OnKillingSpreeSet2 : Event<ArgsBase, ArgsBase>
    {
        public override EventID ID => EventID.OnKillingSpreeSet2;
    }
    public class OnKillingSpreeSet3 : Event<ArgsBase, ArgsBase>
    {
        public override EventID ID => EventID.OnKillingSpreeSet3;
    }
    public class OnKillingSpreeSet4 : Event<ArgsBase, ArgsBase>
    {
        public override EventID ID => EventID.OnKillingSpreeSet4;
    }
    public class OnKillingSpreeSet5 : Event<ArgsBase, ArgsBase>
    {
        public override EventID ID => EventID.OnKillingSpreeSet5;
    }
    public class OnKillingSpreeSet6 : Event<ArgsBase, ArgsBase>
    {
        public override EventID ID => EventID.OnKillingSpreeSet6;
    }
    public class OnKilledUnitOnKillingSpree : Event<ArgsBase, ArgsBase>
    {
        public override EventID ID => EventID.OnKilledUnitOnKillingSpree;
    }
    public class OnKilledUnitOnKillingSpreeSet1 : Event<ArgsBase, ArgsBase>
    {
        public override EventID ID => EventID.OnKilledUnitOnKillingSpreeSet1;
    }
    public class OnKilledUnitOnKillingSpreeSet2 : Event<ArgsBase, ArgsBase>
    {
        public override EventID ID => EventID.OnKilledUnitOnKillingSpreeSet2;
    }
    public class OnKilledUnitOnKillingSpreeSet3 : Event<ArgsBase, ArgsBase>
    {
        public override EventID ID => EventID.OnKilledUnitOnKillingSpreeSet3;
    }
    public class OnKilledUnitOnKillingSpreeSet4 : Event<ArgsBase, ArgsBase>
    {
        public override EventID ID => EventID.OnKilledUnitOnKillingSpreeSet4;
    }
    public class OnKilledUnitOnKillingSpreeSet5 : Event<ArgsBase, ArgsBase>
    {
        public override EventID ID => EventID.OnKilledUnitOnKillingSpreeSet5;
    }
    public class OnKilledUnitOnKillingSpreeSet6 : Event<ArgsBase, ArgsBase>
    {
        public override EventID ID => EventID.OnKilledUnitOnKillingSpreeSet6;
    }
    public class OnDeathAssist : Event<ArgsAssist, ArgsBase>
    {
        public override EventID ID => EventID.OnDeathAssist;
    }
    public class OnQuit : Event<ArgsBase, ArgsBase>
    {
        public override EventID ID => EventID.OnQuit;
    }
    public class OnLeave : Event<ArgsBase, ArgsBase>
    {
        public override EventID ID => EventID.OnLeave;
    }
    public class OnReconnect : Event<ArgsBase, ArgsBase>
    {
        public override EventID ID => EventID.OnReconnect;
    }
    public class OnGameStart : Event<ArgsBase, ArgsBase>
    {
        public override EventID ID => EventID.OnGameStart;
    }
    public class OnPing : Event<ArgsBase, ArgsBase>
    {
        public override EventID ID => EventID.OnPing;
    }
    public class OnPingPlayer : Event<ArgsBase, ArgsBase>
    {
        public override EventID ID => EventID.OnPingPlayer;
    }
    public class OnPingBuilding : Event<ArgsBase, ArgsBase>
    {
        public override EventID ID => EventID.OnPingBuilding;
    }
    public class OnPingOther : Event<ArgsBase, ArgsBase>
    {
        public override EventID ID => EventID.OnPingOther;
    }
    public class OnEndGame : Event<ArgsBase, ArgsBase>
    {
        public override EventID ID => EventID.OnEndGame;
    }
    public class OnSpellLevelup1 : Event<ArgsBase, ArgsBase>
    {
        public override EventID ID => EventID.OnSpellLevelup1;
    }
    public class OnSpellLevelup2 : Event<ArgsBase, ArgsBase>
    {
        public override EventID ID => EventID.OnSpellLevelup2;
    }
    public class OnSpellLevelup3 : Event<ArgsBase, ArgsBase>
    {
        public override EventID ID => EventID.OnSpellLevelup3;
    }
    public class OnSpellLevelup4 : Event<ArgsBase, ArgsBase>
    {
        public override EventID ID => EventID.OnSpellLevelup4;
    }
    public class OnItemPurchased : Event<ArgsItemConsumedPurchased, ArgsBase>
    {
        public override EventID ID => EventID.OnItemPurchased;
    }
    public class OnSurrenderVoteStart : Event<ArgsBase, ArgsSurrenderVotes>
    {
        public override EventID ID => EventID.OnSurrenderVoteStart;
    }
    public class OnSurrenderVote : Event<ArgsBase, ArgsSurrenderVotes>
    {
        public override EventID ID => EventID.OnSurrenderVote;
    }
    public class OnSurrenderVoteAlready : Event<ArgsBase, ArgsBase>
    {
        public override EventID ID => EventID.OnSurrenderVoteAlready;
    }
    public class OnSurrenderCountDown : Event<ArgsBase, ArgsSurrenderRemainingTime>
    {
        public override EventID ID => EventID.OnSurrenderCountDown;
    }
    public class OnSurrenderFailedVotes : Event<ArgsBase, ArgsSurrenderVotes>
    {
        public override EventID ID => EventID.OnSurrenderFailedVotes;
    }
    public class OnSurrenderTooEarly : Event<ArgsBase, ArgsBase>
    {
        public override EventID ID => EventID.OnSurrenderTooEarly;
    }
    public class OnSurrenderAgreed : Event<ArgsBase, ArgsSurrenderVotes>
    {
        public override EventID ID => EventID.OnSurrenderAgreed;
    }
    public class OnSurrenderSpam : Event<ArgsBase, ArgsSurrenderVotes>
    {
        public override EventID ID => EventID.OnSurrenderSpam;
    }
    public class OnPause : Event<ArgsBase, ArgsBase>
    {
        public override EventID ID => EventID.OnPause;
    }
    public class OnPauseResume : Event<ArgsBase, ArgsBase>
    {
        public override EventID ID => EventID.OnPauseResume;
    }
    public class OnMinionsSpawn : Event<ArgsBase, ArgsBase>
    {
        public override EventID ID => EventID.OnMinionsSpawn;
    }
    public class OnStartGameMessage1 : Event<ArgsBase, ArgsBase>
    {
        public override EventID ID => EventID.OnStartGameMessage1;
    }
    public class OnStartGameMessage2 : Event<ArgsBase, ArgsBase>
    {
        public override EventID ID => EventID.OnStartGameMessage2;
    }
    public class OnAlert : Event<ArgsBase, ArgsAlert>
    {
        public override EventID ID => EventID.OnAlert;
    }
    public class OnScoreboardOpen : Event<ArgsBase, ArgsBase>
    {
        public override EventID ID => EventID.OnScoreboardOpen;
    }
    public class OnAudioEventFinished : Event<ArgsBase, ArgsBase>
    {
        public override EventID ID => EventID.OnAudioEventFinished;
    }
    public class OnNexusCrystalStart : Event<ArgsBase, ArgsBase>
    {
        public override EventID ID => EventID.OnNexusCrystalStart;
    }
    public class OnCapturePointNeutralized_A : Event<ArgsBase, ArgsCapturePoint>
    {
        public override EventID ID => EventID.OnCapturePointNeutralized_A;
    }
    public class OnCapturePointNeutralized_B : Event<ArgsBase, ArgsCapturePoint>
    {
        public override EventID ID => EventID.OnCapturePointNeutralized_B;
    }
    public class OnCapturePointNeutralized_C : Event<ArgsBase, ArgsCapturePoint>
    {
        public override EventID ID => EventID.OnCapturePointNeutralized_C;
    }
    public class OnCapturePointNeutralized_D : Event<ArgsBase, ArgsCapturePoint>
    {
        public override EventID ID => EventID.OnCapturePointNeutralized_D;
    }
    public class OnCapturePointNeutralized_E : Event<ArgsBase, ArgsCapturePoint>
    {
        public override EventID ID => EventID.OnCapturePointNeutralized_E;
    }
    public class OnCapturePointCaptured_A : Event<ArgsBase, ArgsCapturePoint>
    {
        public override EventID ID => EventID.OnCapturePointCaptured_A;
    }
    public class OnCapturePointCaptured_B : Event<ArgsBase, ArgsCapturePoint>
    {
        public override EventID ID => EventID.OnCapturePointCaptured_B;
    }
    public class OnCapturePointCaptured_C : Event<ArgsBase, ArgsCapturePoint>
    {
        public override EventID ID => EventID.OnCapturePointCaptured_C;
    }
    public class OnCapturePointCaptured_D : Event<ArgsBase, ArgsCapturePoint>
    {
        public override EventID ID => EventID.OnCapturePointCaptured_D;
    }
    public class OnCapturePointCaptured_E : Event<ArgsBase, ArgsCapturePoint>
    {
        public override EventID ID => EventID.OnCapturePointCaptured_E;
    }
    public class OnVictoryPointThreshold1 : Event<ArgsBase, ArgsCapturePoint>
    {
        public override EventID ID => EventID.OnVictoryPointThreshold1;
    }
    public class OnVictoryPointThreshold2 : Event<ArgsBase, ArgsCapturePoint>
    {
        public override EventID ID => EventID.OnVictoryPointThreshold2;
    }
    public class OnVictoryPointThreshold3 : Event<ArgsBase, ArgsCapturePoint>
    {
        public override EventID ID => EventID.OnVictoryPointThreshold3;
    }
    public class OnVictoryPointThreshold4 : Event<ArgsBase, ArgsCapturePoint>
    {
        public override EventID ID => EventID.OnVictoryPointThreshold4;
    }
}