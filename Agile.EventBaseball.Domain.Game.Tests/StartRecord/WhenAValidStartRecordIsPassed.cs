using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agile.EventedBaseball.Domain.Game.Parsers;
using Agile.EventedBaseball.Entity.GameRecord;
using Xunit;

namespace Agile.EventBaseball.Domain.Game.Tests.StartRecord
{
    [Trait("Category", "Start Record")]
    public class WhenAValidStartRecordIsPassed
    {
        //start,marts002,"Starling Marte",1,1,7
        private String _startRecord;
        private StartGameRecord _gameRecord;

        public WhenAValidStartRecordIsPassed()
        {
            GivenAValidStartRecord();
            ParseStartRecord();
        }

        private void GivenAValidStartRecord()
        {
            _startRecord = "start,marts002,\"Starling Marte\",1,2,7";
        }

        private void ParseStartRecord()
        {
            _gameRecord = GameRecordParser.Parse(_startRecord) as StartGameRecord;
        }

        [Fact]
        public void TheStartRecordShouldNotBeNull()
        {
            Assert.NotNull(_gameRecord);
        }

        [Fact]
        public void TheIdShouldBeSet()
        {
            Assert.Equal<String>("marts002", _gameRecord.PlayerId);
        }

        [Fact]
        public void TheNameShouldBeSetAndNotHaveQuotes()
        {
            Assert.Equal<String>("Starling Marte", _gameRecord.PlayerName);
        }

        [Fact]
        public void TheBattingOrderShouldBeSet()
        {
            Assert.Equal<Int32>(2, _gameRecord.BattingOrder);
        }

        [Fact]
        public void TheIsHomeTeamShouldBeSet()
        {
            Assert.True(_gameRecord.IsHomeTeam);
        }

        [Fact]
        public void TheFieldingPositionShouldBeSet()
        {
            Assert.Equal<FieldingPosition>(FieldingPosition.LeftField, _gameRecord.FieldingPosition);
        }
    }
}
