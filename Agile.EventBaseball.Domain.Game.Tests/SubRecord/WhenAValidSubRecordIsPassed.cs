using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agile.EventedBaseball.Domain.Game.Parsers;
using Agile.EventedBaseball.Entity.GameRecord;
using Xunit;

namespace Agile.EventBaseball.Domain.Game.Tests.SubRecord
{
    [Trait("Category", "Sub Record")]
    public class WhenAValidSubRecordIsPassed
    {
        private String _startRecord;
        private SubGameRecord _gameRecord;

        public WhenAValidSubRecordIsPassed()
        {
            GivenAValidStartRecord();
            ParseStartRecord();
        }

        private void GivenAValidStartRecord()
        {
            _startRecord = "sub,watst001,\"Tony Watson\",1,9,1";
        }

        private void ParseStartRecord()
        {
            _gameRecord = GameRecordParser.Parse(_startRecord) as SubGameRecord;
        }

        [Fact]
        public void TheGameRecordIsProperlySet()
        {
            Assert.Equal<GameRecordType>(GameRecordType.Sub, _gameRecord.GameRecordType);
        }

        [Fact]
        public void TheGameRecordIsNotNull()
        {
            Assert.NotNull(_gameRecord);
        }

        [Fact]
        public void TheIdShouldBeSet()
        {
            Assert.Equal<String>("watst001", _gameRecord.PlayerId);
        }

        [Fact]
        public void TheNameShouldBeSetAndNotHaveQuotes()
        {
            Assert.Equal<String>("Tony Watson", _gameRecord.PlayerName);
        }

        [Fact]
        public void TheBattingOrderShouldBeSet()
        {
            Assert.Equal<Int32>(9, _gameRecord.BattingOrder);
        }

        [Fact]
        public void TheIsHomeTeamShouldBeSet()
        {
            Assert.True(_gameRecord.IsHomeTeam);
        }

        [Fact]
        public void TheFieldingPositionShouldBeSet()
        {
            Assert.Equal<FieldingPosition>(FieldingPosition.Pitcher, _gameRecord.FieldingPosition);
        }
    }
}
