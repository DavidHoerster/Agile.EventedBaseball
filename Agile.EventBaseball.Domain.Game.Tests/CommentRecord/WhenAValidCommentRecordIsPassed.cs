using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agile.EventedBaseball.Domain.Game.Parsers;
using Agile.EventedBaseball.Entity.GameRecord;
using Xunit;

namespace Agile.EventBaseball.Domain.Game.Tests.CommentRecord
{
    [Trait("Category", "Comment Record")]
    public class WhenAValidCommentRecordIsPassed
    {
        private String _startRecord;
        private CommentGameRecord _gameRecord;

        public WhenAValidCommentRecordIsPassed()
        {
            GivenAValidStartRecord();
            ParseStartRecord();
        }

        private void GivenAValidStartRecord()
        {
            _startRecord = "com,\"padded wall and caromed back onto the field; it was ruled\"";
        }

        private void ParseStartRecord()
        {
            _gameRecord = GameRecordParser.Parse(_startRecord) as CommentGameRecord;
        }

        [Fact]
        public void TheGameRecordShouldNotBeNull()
        {
            Assert.NotNull(_gameRecord);
        }

        [Fact]
        public void TheCommentShouldBeSetAndWithoutQuotes()
        {
            Assert.Equal<String>("padded wall and caromed back onto the field; it was ruled", _gameRecord.Comment);
        }
    }
}
