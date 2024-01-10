using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.FriendCircles;
using Nop.Core.Domain.Stores;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.FriendCircles
{
    /// <summary>
    /// 朋友圈评论
    /// </summary>
    public partial class FriendCircleCommentBuilder : NopEntityBuilder<FriendCircleComment>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(FriendCircleComment.CustomerId)).AsInt32().ForeignKey<Customer>()
                .WithColumn(nameof(FriendCircleComment.FriendCircleId)).AsInt32().ForeignKey<FriendCircle>()
                .WithColumn(nameof(FriendCircleComment.CommentText)).AsString(1024).Nullable() //防止评论内容过长的攻击
                .WithColumn(nameof(FriendCircleComment.ReplyText)).AsString(1024).Nullable()
                .WithColumn(nameof(FriendCircleComment.PublisherIp)).AsAnsiString(32).Nullable()
                .WithColumn(nameof(FriendCircleComment.Latitude)).AsDecimal(9, 6).Nullable()
                .WithColumn(nameof(FriendCircleComment.Longitude)).AsDecimal(9, 6).Nullable()
                .WithColumn(nameof(FriendCircleComment.ReplyOnUtc)).AsDateTime2().Nullable()
                ;
        }

        #endregion
    }
}