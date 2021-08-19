using Microsoft.EntityFrameworkCore;

namespace Snakk.DB
{
    public class Context : DbContext
    {
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
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostBan> PostBans { get; set; }
        public DbSet<PostComment> PostComments { get; set; }
        public DbSet<PostLastView> PostLastViews { get; set; }
        public DbSet<PostReport> PostReports { get; set; }
        public DbSet<PostSubscription> PostSubscriptions { get; set; }
        public DbSet<PostSurvey> PostSurveys { get; set; }
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
