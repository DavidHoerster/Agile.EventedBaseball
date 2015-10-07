using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agile.EventedBaseball.Domain.Game.Parsers;
using Agile.EventedBaseball.Entity.GameRecord;
using Xunit;

namespace Agile.EventBaseball.Domain.Game.Tests.VersionRecord
{
    [Trait("Category", "Version Record")]
    public class WhenAValidVersionRecordIsPassed
    {
        private String _versionRecord;
        private VersionGameRecord _gameRecord;

        public WhenAValidVersionRecordIsPassed()
        {
            GivenAValidStartRecord();
            ParseStartRecord();
        }
        private void GivenAValidStartRecord()
        {
            _versionRecord = "version,2";
        }

        private void ParseStartRecord()
        {
            _gameRecord = GameRecordParser.Parse(_versionRecord) as VersionGameRecord;
        }

        [Fact]
        public void TheGameRecordShouldNotBeNull()
        {
            Assert.NotNull(_gameRecord);
        }

        [Fact]
        public void TheRecordVersionIsCorrect()
        {
            Assert.Equal<Int32>(2, _gameRecord.Version);
        }
    }
}
