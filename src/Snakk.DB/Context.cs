//  SPDX-FileCopyrightText: 2021 Pål Rune Sørensen Tuv <me@paaltuv.no>
//  SPDX-License-Identifier: MIT

using Microsoft.EntityFrameworkCore;

namespace Snakk.DB
{
    public interface IContext
    {
        DbSet<AccessGroup> AccessGroups { get; set; }
        DbSet<Permission> AdministratorPermissions { get; set; }
        DbSet<Avatar> Avatars { get; set; }
        DbSet<Ban> Bans { get; set; }
        DbSet<ChannelSubscription> ChannelAccessGroups { get; set; }
        DbSet<ChannelAvatar> ChannelAvatars { get; set; }
        DbSet<ChannelBan> ChannelBans { get; set; }
        DbSet<ChannelLastView> ChannelLastViews { get; set; }
        DbSet<ChannelModeratorPermission> ChannelModeratorPermissions { get; set; }
        DbSet<ChannelReport> ChannelReports { get; set; }
        DbSet<ChannelRule> ChannelRules { get; set; }
        DbSet<Channel> Channels { get; set; }
        DbSet<ChannelSubscription> ChannelSubscriptions { get; set; }
        DbSet<ChannelTag> ChannelTags { get; set; }
        DbSet<CommentReport> CommentReports { get; set; }
        DbSet<Comment> Comments { get; set; }
        DbSet<CommentVote> CommentVotes { get; set; }
        DbSet<LastView> LastViews { get; set; }
        DbSet<Permission> Permissions { get; set; }
        DbSet<ThreadBan> ThreadBans { get; set; }
        DbSet<ThreadComment> ThreadComments { get; set; }
        DbSet<ThreadLastView> ThreadLastViews { get; set; }
        DbSet<ThreadReport> ThreadReports { get; set; }
        DbSet<Thread> Threads { get; set; }
        DbSet<ThreadSubscription> ThreadSubscriptions { get; set; }
        DbSet<ThreadSurvey> ThreadSurveys { get; set; }
        DbSet<ReportComment> ReportComments { get; set; }
        DbSet<Report> Reports { get; set; }
        DbSet<Rule> Rules { get; set; }
        DbSet<Signature> Signatures { get; set; }
        DbSet<SubscriptionNotification> SubscriptionNotifications { get; set; }
        DbSet<Subscription> Subscriptions { get; set; }
        DbSet<SurveyQuestionAnswer> SurveyQuestionAnswers { get; set; }
        DbSet<SurveyQuestionOption> SurveyQuestionOptions { get; set; }
        DbSet<SurveyQuestion> SurveyQuestions { get; set; }
        DbSet<Survey> Surveys { get; set; }
        DbSet<Tag> Tags { get; set; }
        DbSet<UserAccessGroup> UserAccessGroups { get; set; }
        DbSet<UserAvatar> UserAvatars { get; set; }
        DbSet<UserBan> UserBans { get; set; }
        DbSet<UserReport> UserReports { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<UserSignature> UserSignatures { get; set; }
        DbSet<UserSocialLink> UserSocialLinks { get; set; }
        DbSet<UserSubscription> UserSubscriptions { get; set; }
        DbSet<Vote> Votes { get; set; }
    }

    public class Context : DbContext, IContext
    {
        private static bool _created = false;
        public Context()
        {
            if (!_created)
            {
                _created = true;
                Database.EnsureDeleted();
                Database.EnsureCreated();
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=snakk.db");

        public DbSet<AccessGroup> AccessGroups { get; set; }
        public DbSet<Permission> AdministratorPermissions { get; set; }
        public DbSet<Avatar> Avatars { get; set; }
        public DbSet<Ban> Bans { get; set; }
        public DbSet<Channel> Channels { get; set; }
        public DbSet<ChannelSubscription> ChannelAccessGroups { get; set; }
        public DbSet<ChannelAvatar> ChannelAvatars { get; set; }
        public DbSet<ChannelBan> ChannelBans { get; set; }
        public DbSet<ChannelLastView> ChannelLastViews { get; set; }
        public DbSet<ChannelModeratorPermission> ChannelModeratorPermissions { get; set; }
        public DbSet<ChannelReport> ChannelReports { get; set; }
        public DbSet<ChannelRule> ChannelRules { get; set; }
        public DbSet<ChannelSubscription> ChannelSubscriptions { get; set; }
        public DbSet<ChannelTag> ChannelTags { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<CommentReport> CommentReports { get; set; }
        public DbSet<CommentVote> CommentVotes { get; set; }
        public DbSet<LastView> LastViews { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Thread> Threads { get; set; }
        public DbSet<ThreadBan> ThreadBans { get; set; }
        public DbSet<ThreadComment> ThreadComments { get; set; }
        public DbSet<ThreadLastView> ThreadLastViews { get; set; }
        public DbSet<ThreadReport> ThreadReports { get; set; }
        public DbSet<ThreadSubscription> ThreadSubscriptions { get; set; }
        public DbSet<ThreadSurvey> ThreadSurveys { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<ReportComment> ReportComments { get; set; }
        public DbSet<Rule> Rules { get; set; }
        public DbSet<Signature> Signatures { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<SubscriptionNotification> SubscriptionNotifications { get; set; }
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<SurveyQuestion> SurveyQuestions { get; set; }
        public DbSet<SurveyQuestionOption> SurveyQuestionOptions { get; set; }
        public DbSet<SurveyQuestionAnswer> SurveyQuestionAnswers { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserAccessGroup> UserAccessGroups { get; set; }
        public DbSet<UserAvatar> UserAvatars { get; set; }
        public DbSet<UserBan> UserBans { get; set; }
        public DbSet<UserReport> UserReports { get; set; }
        public DbSet<UserSignature> UserSignatures { get; set; }
        public DbSet<UserSocialLink> UserSocialLinks { get; set; }
        public DbSet<UserSubscription> UserSubscriptions { get; set; }
        public DbSet<Vote> Votes { get; set; }
    }
}
