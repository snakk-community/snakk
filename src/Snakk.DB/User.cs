//  SPDX-FileCopyrightText: 2021 Pål Rune Sørensen Tuv <me@paaltuv.no>
//  SPDX-License-Identifier: MIT

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Snakk.DB
{
    [Table("User")]
    public class User
    {
        public long UserId { get; set; }

        public string Username { get; set; }
        public string DisplayName { get; set; }

        public string EncryptedEmail { get; set; }
        public string HashedPassword { get; set; }

        public int TimeZoneId { get; set; }

        public string About { get; set; }

        public bool IsAdministrator { get; set; }

        public DateTime CreatedUtc { get; set; }

        public List<UserAvatar> Avatars { get; set; } = new List<UserAvatar>();
        public List<UserBan> Bans { get; set; } = new List<UserBan>();
        public List<UserAccessGroup> AccessGroups { get; set; } = new List<UserAccessGroup>();

        public List<ChannelReport> ChannelReports { get; set; } = new List<ChannelReport>();
        public List<ThreadReport> ThreadReports { get; set; } = new List<ThreadReport>();
        public List<CommentReport> CommentReports { get; set; } = new List<CommentReport>();

        public List<UserReport> UserReports { get; set; } = new List<UserReport>();

        [InverseProperty("ReportedUser")]
        public List<UserReport> OtherUsersReportsOfThisUser { get; set; } = new List<UserReport>();

        public List<Thread> Threads { get; set; } = new List<Thread>();
        public List<UserSocialLink> SocialLinks { get; set; } = new List<UserSocialLink>();
        public List<ThreadLastView> ThreadLastViews { get; set; } = new List<ThreadLastView>();
        public List<ChannelLastView> ChannelLastViews { get; set; } = new List<ChannelLastView>();
        public List<Vote> GivenVotes { get; set; } = new List<Vote>();
        public List<SurveyQuestionAnswer> SurveyQuestionAnswers { get; set; } = new List<SurveyQuestionAnswer>();

        public List<ThreadComment> ThreadComments { get; set; } = new List<ThreadComment>();
        public List<ReportComment> ReportComments { get; set; } = new List<ReportComment>();

        public List<AdministratorPermission> AdministratorPermissions { get; set; } = new List<AdministratorPermission>();
        public List<ChannelModeratorPermission> ModeratorPermissions { get; set; } = new List<ChannelModeratorPermission>();

        public List<ThreadBan> ThreadBans { get; set; } = new List<ThreadBan>();
        public List<ChannelBan> ChannelBans { get; set; } = new List<ChannelBan>();

        public List<UserSubscription> UserSubscriptions { get; set; } = new List<UserSubscription>();
        public List<ChannelSubscription> ChannelSubscriptions { get; set; } = new List<ChannelSubscription>();

        [InverseProperty("SubscribeToUser")]
        public List<UserSubscription> OtherUsersSubscriedToThisUser { get; set; } = new List<UserSubscription>();

    }
}
