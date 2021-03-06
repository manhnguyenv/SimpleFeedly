﻿
namespace SimpleFeedly.Rss.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("SimpleFeedlyConn"), Module("Rss"), TableName("[dbo].[RssFeedItems]")]
    [DisplayName("Rss Feed Items"), InstanceName("Rss Feed Items")]
    [ReadPermission("Administration:General")]
    [ModifyPermission("Administration:General")]
    public sealed class RssFeedItemsRow : Row, IIdRow, INameRow
    {
        [DisplayName("Id"), Identity]
        public Int64? Id
        {
            get { return Fields.Id[this]; }
            set { Fields.Id[this] = value; }
        }

        [DisplayName("Channel Id"), NotNull]
        [ForeignKey(typeof(RssChannelsRow), nameof(RssChannelsRow.Fields.Id)), LeftJoin("jChannel")]
        [LookupEditor(typeof(RssChannelsRow))]
        public Int64? ChannelId
        {
            get { return Fields.ChannelId[this]; }
            set { Fields.ChannelId[this] = value; }
        }

        [DisplayName("Channel Name")]
        [Expression("jChannel.Title")]
        public String RssChannelTitle
        {
            get { return Fields.RssChannelTitle[this]; }
            set { Fields.RssChannelTitle[this] = value; }
        }

        [DisplayName("Feed Item Id"), Size(500), NotNull, QuickSearch]
        public String FeedItemId
        {
            get { return Fields.FeedItemId[this]; }
            set { Fields.FeedItemId[this] = value; }
        }

        [DisplayName("Title"), Size(300)]
        public String Title
        {
            get { return Fields.Title[this]; }
            set { Fields.Title[this] = value; }
        }

        [DisplayName("Link"), Size(500)]
        public String Link
        {
            get { return Fields.Link[this]; }
            set { Fields.Link[this] = value; }
        }

        [DisplayName("Description")]
        [TextAreaEditor(Rows = 3)]
        public String Description
        {
            get { return Fields.Description[this]; }
            set { Fields.Description[this] = value; }
        }

        [DisplayName("Publishing Date")]
        public DateTime? PublishingDate
        {
            get { return Fields.PublishingDate[this]; }
            set { Fields.PublishingDate[this] = value; }
        }

        [DisplayName("Author"), Size(200)]
        public String Author
        {
            get { return Fields.Author[this]; }
            set { Fields.Author[this] = value; }
        }

        [DisplayName("Content"), Column("Content"), QuickSearch]
        public String Content
        {
            get { return Fields.Content[this]; }
            set { Fields.Content[this] = value; }
        }

        [DisplayName("Is Checked")]
        public Boolean? IsChecked
        {
            get { return Fields.IsChecked[this]; }
            set { Fields.IsChecked[this] = value; }
        }

        IIdField IIdRow.IdField
        {
            get { return Fields.Id; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.FeedItemId; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public RssFeedItemsRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int64Field Id;
            public Int64Field ChannelId;
            public StringField FeedItemId;
            public StringField Title;
            public StringField Link;
            public StringField Description;
            public DateTimeField PublishingDate;
            public StringField Author;
            public StringField Content;
            public BooleanField IsChecked;

            public StringField RssChannelTitle;
        }
    }
}
