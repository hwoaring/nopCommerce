using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Polls;
using Nop.Data.Extensions;

using Nop.Core.Domain.Customers;

namespace Nop.Data.Mapping.Builders.Polls
{
    /// <summary>
    /// Represents a poll answer entity builder
    /// </summary>
    public partial class PollVotingLimitBuilder : NopEntityBuilder<PollVotingLimit>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(PollVotingLimit.CustomerId)).AsInt32().ForeignKey<Customer>()
                .WithColumn(nameof(PollVotingLimit.PollId)).AsInt32().ForeignKey<Poll>()

                ;
        }

        #endregion
    }
}