using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agile.EventedBaseball.Domain.Game.Parsers;
using Agile.EventedBaseball.Entity;
using Agile.EventedBaseball.Entity.GameRecord;
using Xunit;

namespace Agile.EventBaseball.Domain.Game.Tests.PlayRecord
{
    [Trait("Category", "Play Record")]
    public class WhenAValidPlayRecordIsPassed
    {
        private String _playRecord;
        private PlayGameRecord _gameRecord;

        public WhenAValidPlayRecordIsPassed()
        {
            GivenAValidStartRecord();
            ParseStartRecord();
        }

        private void GivenAValidStartRecord()
        {
            _playRecord = "play,3,1,lakej001,12,SS*B1,PO1(1E3)";
        }

        private void ParseStartRecord()
        {
            _gameRecord = GameRecordParser.Parse(_playRecord) as PlayGameRecord;
        }

        [Fact]
        public void TheGameRecordShouldNotBeNull()
        {
            Assert.NotNull(_gameRecord);
        }

        [Fact]
        public void TheInningShouldBeSet()
        {
            Assert.Equal<Int32>(3, _gameRecord.Inning);
        }

        [Fact]
        public void TheIsHomeTeamSHouldBeSet()
        {
            Assert.True(_gameRecord.IsHomeTeam);
        }

        [Fact]
        public void ThePlayerIdShouldBeSet()
        {
            Assert.Equal<String>("lakej001", _gameRecord.PlayerId);
        }

        [Fact]
        public void TheCountShouldBeSet()
        {
            Assert.Equal<String>("12", _gameRecord.Count);
            Assert.Equal<Int32>(1, _gameRecord.Balls);
            Assert.Equal<Int32>(2, _gameRecord.Strikes);
        }

        [Fact]
        public void ThePitchesShouldBeSet()
        {
            Assert.Equal<String>("SS*B1", _gameRecord.PitchString);
        }

        [Fact]
        public void ThePlayShouldBeSet()
        {
            Assert.Equal<String>("PO1(1E3)", _gameRecord.Play);
        }

        [Fact]
        public void ThePitchArrayShouldBeSet()
        {
            Assert.Equal<Int32>(5, _gameRecord.Pitches.Length);

            Assert.Equal<Int32>(2, _gameRecord.Pitches.Count(p => p == PitchType.SwingingStrike));
        }
    }
}
