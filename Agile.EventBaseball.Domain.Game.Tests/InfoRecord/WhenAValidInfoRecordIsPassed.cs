using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agile.EventedBaseball.Domain.Game.Parsers;
using Agile.EventedBaseball.Entity.GameRecord;
using Xunit;

namespace Agile.EventBaseball.Domain.Game.Tests.InfoRecord
{
    [Trait("Category", "Info Record")]
    public class WhenAValidInfoRecordIsPassed
    {
        private String _infoRecord;
        private InfoGameRecord _gameRecord;

        public WhenAValidInfoRecordIsPassed()
        {
            GivenAValidStartRecord();
            ParseStartRecord();
        }

        private void GivenAValidStartRecord()
        {
            _infoRecord = "info,visteam, CHN";
        }

        private void ParseStartRecord()
        {
            _gameRecord = GameRecordParser.Parse(_infoRecord) as InfoGameRecord;
        }

        [Fact]
        public void TheInfoRecordShouldNotBeNull()
        {
            Assert.NotNull(_gameRecord);
        }

        [Fact]
        public void TheKeyIsCorrect()
        {
            Assert.Equal<String>("visteam", _gameRecord.Key);
        }

        [Fact]
        public void TheValueIsCorrect()
        {
            Assert.Equal<String>("CHN", _gameRecord.Value);
        }
    }
}
