using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agile.EventedBaseball.Entity.GameRecord
{
    public class PlayGameRecord : GameRecordBase
    {
        public PlayGameRecord(String record) : base(GameRecordType.Play)
        {
            var recordSegments = record.Split(new char[] { ',' });
            if (recordSegments.Length != 7)
            {
                throw new ArgumentException("invalid record passed");
            }
            Inning = Convert.ToInt32(recordSegments[1]);
            IsHomeTeam = recordSegments[2].Equals("1");
            PlayerId = recordSegments[3];
            Count = recordSegments[4];
            PitchString = recordSegments[5];
            Play = recordSegments[6];

            Pitches = GetPitches(PitchString);
        }

        public readonly PitchType[] Pitches;
        public Int32 Inning { get; private set; }
        public Boolean IsHomeTeam { get; private set; }
        public String PlayerId { get; private set; }
        public String Count { get; private set; }
        public Int32 Balls
        {
            get
            {
                if (Count.Equals("??"))
                {
                    return 0;
                }
                else
                {
                    return Convert.ToInt32(Count.Substring(0, 1));
                }
            }
        }
        public Int32 Strikes
        {
            get
            {
                if (Count.Equals("??"))
                {
                    return 0;
                }
                else
                {
                    return Convert.ToInt32(Count.Substring(1, 1));
                }
            }
        }
        public String PitchString { get; private set; }
        public String Play { get; private set; }

        

        private PitchType[] GetPitches(String pitches)
        {
            return pitches.Select(p => GetPitchType(p)).ToArray();
        }

        private PitchType GetPitchType(char p)
        {
            PitchType returnedPitchType = PitchType.Unknown;

            switch (p)
            {
                case 'B':
                    returnedPitchType = PitchType.Ball;
                    break;
                case 'C':
                    returnedPitchType = PitchType.CalledStrike;
                    break;
                case 'F':
                    returnedPitchType = PitchType.Foul;
                    break;
                case 'H':
                    returnedPitchType = PitchType.HitBatter;
                    break;
                case 'I':
                    returnedPitchType = PitchType.IntentionalBall;
                    break;
                case 'K':
                    returnedPitchType = PitchType.Strike;
                    break;
                case 'L':
                    returnedPitchType = PitchType.FoulBunt;
                    break;
                case 'M':
                    returnedPitchType = PitchType.MissedBuntAttempt;
                    break;
                case 'N':
                    returnedPitchType = PitchType.NoPitch;
                    break;
                case 'O':
                    returnedPitchType = PitchType.FoulTipOnBunt;
                    break;
                case 'P':
                    returnedPitchType = PitchType.Pitchout;
                    break;
                case 'Q':
                    returnedPitchType = PitchType.SwingingOnPitchout;
                    break;
                case 'R':
                    returnedPitchType = PitchType.FoulBallOnPitchout;
                    break;
                case 'S':
                    returnedPitchType = PitchType.SwingingStrike;
                    break;
                case 'T':
                    returnedPitchType = PitchType.FoulTip;
                    break;
                case 'U':
                    returnedPitchType = PitchType.Unknown;
                    break;
                case 'V':
                    returnedPitchType = PitchType.CalledBallPitcherMouth;
                    break;
                case 'X':
                    returnedPitchType = PitchType.BallInPlayByBatter;
                    break;
                case 'Y':
                    returnedPitchType = PitchType.BallInPlayOnPitchout;
                    break;
                case '1':
                    returnedPitchType = PitchType.PickoffThrowToFirst;
                    break;
                case '2':
                    returnedPitchType = PitchType.PickoffThrowToSecond;
                    break;
                case '3':
                    returnedPitchType = PitchType.PickoffThrowToThird;
                    break;
                case '>':
                    returnedPitchType = PitchType.RunnerGoingOnPitch;
                    break;
                case '+':
                    returnedPitchType = PitchType.PickoffThrowByCatcher;
                    break;
                case '*':
                    returnedPitchType = PitchType.PitchBlockedByCatcher;
                    break;
                case '.':
                    returnedPitchType = PitchType.PlayNotInvolvingBatter;
                    break;
                default:
                    returnedPitchType = PitchType.Unknown;
                    break;
            }

            return returnedPitchType;
        }
    }
}
