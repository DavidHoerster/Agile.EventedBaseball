using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agile.EventedBaseball.Domain.Game.Parsers;
using Agile.EventedBaseball.Entity.GameRecord;
using Xunit;

namespace Agile.EventBaseball.Domain.Game.Tests.DataRecord
{
    [Trait("Category", "Data Record")]
    public class WhenAValidDataRecordIsPassed
    {
        private String _dataRecord;
        private DataGameRecord _gameRecord;

        public WhenAValidDataRecordIsPassed()
        {
            GivenAValidStartRecord();
            ParseStartRecord();
        }

        private void GivenAValidStartRecord()
        {
            _dataRecord = "data,er,morrb002,1";
        }

        private void ParseStartRecord()
        {
            _gameRecord = GameRecordParser.Parse(_dataRecord) as DataGameRecord;
        }

        [Fact]
        public void TheGameRecordShouldNotBeNull()
        {
            Assert.NotNull(_gameRecord);
        }

        [Fact]
        public void TheDataTypeShouldBeSet()
        {
            Assert.Equal<String>("er", _gameRecord.DataType);
        }

        [Fact]
        public void ThePlayerIdShouldBeSet()
        {
            Assert.Equal<String>("morrb002", _gameRecord.PlayerId);
        }

        [Fact]
        public void TheEarnedRunsShouldBeSet()
        {
            Assert.Equal<Int32>(1, _gameRecord.EarnedRuns);
        }
    }
}
