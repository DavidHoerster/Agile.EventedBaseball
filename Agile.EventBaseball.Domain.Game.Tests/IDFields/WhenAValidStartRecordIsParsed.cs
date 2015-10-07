using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agile.EventedBaseball.Domain.Game.Parsers;
using Agile.EventedBaseball.Entity.GameRecord;
using Xunit;

namespace Agile.EventBaseball.Domain.Game.Tests.IDFields
{
    [Trait("Category", "ID Record")]
    public class WhenAValidStartRecordIsParsed
    {
        private String _startRecord;
        private IdGameRecord _gameRecord;

        public WhenAValidStartRecordIsParsed()
        {
            GivenAValidStartRecord();
            ParseStartRecord();
        }

        private void ParseStartRecord()
        {
            _gameRecord = GameRecordParser.Parse(_startRecord) as IdGameRecord;
        }

        private void GivenAValidStartRecord()
        {
            _startRecord = "id,PIT201403310";
        }

        [Fact]
        public void TheRecordIsNotNull()
        {
            Assert.NotNull(_gameRecord);
        }

        [Fact]
        public void TheRecordShouldBeOfIdType()
        {
            Assert.Equal<GameRecordType>(GameRecordType.Id, _gameRecord.GameRecordType);
        }

        [Fact]
        public void ItShouldParseOutTheHomeTeam()
        {
            Assert.Equal<String>("PIT", _gameRecord.HomeTeam);
        }

        [Fact]
        public void ItShouldParseOutTheYear()
        {
            Assert.Equal<Int32>(2014, _gameRecord.Year);
        }

        [Fact]
        public void ItShouldParseOutTheMonth()
        {
            Assert.Equal<Int32>(3, _gameRecord.Month);
        }

        [Fact]
        public void ItShouldParseOutTheDay()
        {
            Assert.Equal<Int32>(31, _gameRecord.Day);
        }

        [Fact]
        public void ItShouldParseOutTheTimeOfGame()
        {
            Assert.Equal<GameNumber>(GameNumber.SingleGame, _gameRecord.GameNumber);
        }

    }
}
