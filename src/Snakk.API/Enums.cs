//  SPDX-FileCopyrightText: 2021 Pål Rune Sørensen Tuv <me@paaltuv.no>
//  SPDX-License-Identifier: MIT

namespace Snakk.API
{
    public enum SurveyQuestionType
    {
        SingleChoice = 1,
        MultipeChoises = 2,
    }

    public enum ChannelModeratorPermissionType
    {
        ManageModerators = 1,
        DeleteAndUndeleteThread = 2,
        DeleteAndUndeleteComment = 3,
        ShowDeletedComments = 4,
        ShowDeletedThreads = 5,
        EditCommentText = 6,
        EditThreadName = 7,
        EditSurveyQuestionsAndOptions = 8,
        BanAndUnbanUserFromChannel = 9,
        BanAndUnbanUserFromThread = 10,
        OpenAndCloseThread = 11,
        CreateWarningInThread = 12,
        CreatePreMessageForThread = 13,
        CreateThreadMessageForThread = 14,
        ChangeChannelSettings = 14,
        StickAndUnstickThread = 15,
        ManageTags = 16,
    }

    public enum NotificationType
    {
        Spam = 1,
    }

    public enum SocialLinkType
    {
        Facebook = 1,
        Instagram = 2,
        Youtube = 3,
        Twitter = 4,
        Tiktok = 5,
        Pinterest = 6,
        Snapchat = 7,
        WeChat = 8,
        Tumblr = 9,
        Reddit = 10,
        LinkedIn = 11,
        Medium = 12,
        GitHub = 13,
        Twitch = 14,
        VK = 15,
        Vimeo = 16,
    }

    public enum UserSpecialAccessLevelType
    {
    }

    public enum ReportType
    {
        Spam = 1,
    }
}
