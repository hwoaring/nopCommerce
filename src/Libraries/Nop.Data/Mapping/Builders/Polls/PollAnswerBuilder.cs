using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Polls;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Polls
{
    /// <summary>
    /// Represents a poll answer entity builder
    /// </summary>
    public partial class PollAnswerBuilder : NopEntityBuilder<PollAnswer>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(PollAnswer.Name)).AsString(int.MaxValue).NotNullable()
                .WithColumn(nameof(PollAnswer.PollId)).AsInt32().ForeignKey<Poll>()


                //新增属性
                .WithColumn(nameof(PollAnswer.Code)).AsString(32).Nullable()
                .WithColumn(nameof(PollAnswer.GroupName)).AsString(512).Nullable()
                .WithColumn(nameof(PollAnswer.AreaName)).AsString(512).Nullable()

                ;
        }

        #endregion
    }
}