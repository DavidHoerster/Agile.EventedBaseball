using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agile.EventedBaseball.Entity
{
    public enum PitchType
    {
        Ball = 0,
        CalledStrike = 1,
        Foul = 2,
        HitBatter=3,
        IntentionalBall = 4,
        Strike =5,
        FoulBunt=6,
        MissedBuntAttempt=7,
        NoPitch=8,
        FoulTipOnBunt=9,
        Pitchout=10,
        SwingingOnPitchout=11,
        FoulBallOnPitchout=12,
        SwingingStrike=13,
        FoulTip=14,
        Unknown=15,
        CalledBallPitcherMouth=16,
        BallInPlayByBatter=17,
        BallInPlayOnPitchout=18,
        PickoffThrowToFirst=19,
        PickoffThrowToSecond=20,
        PickoffThrowToThird=21,
        RunnerGoingOnPitch=22,
        PlayNotInvolvingBatter=23,
        PitchBlockedByCatcher=24,
        PickoffThrowByCatcher=25,
    }
}
